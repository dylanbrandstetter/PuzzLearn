dofile("readMemoryStructureV2.lua")

-- The following line speeds up emulation speed, resulting in faster processing
-- Comment it out for demonstrations
emu.limitframerate(false)

-- Building the address database that will produce an output table

CursorX = buildInteger("Cursor X", 0x326, -96, 1/8)
CursorY = buildInteger("Cursor Y", 0x327, -48, 1/8)

cursorXTable = { CursorX }
cursorYTable = { CursorY }
Cursor = buildObject("Cursor", cursorXTable, cursorYTable, nil, 1)

orientationValues = {
	-- T block
	[0] = 1,
	[2] = 2,
	[4] = 3,
	[6] = 4,
	-- J block
	[8] = 5,
	[10] = 6,
	[12] = 7,
	[14] = 8,
	-- Z block
	[16] = 9,
	[18] = 10,
	[20] = 9,
	[22] = 10,
	-- O block
	[24] = 11,
	[26] = 11,
	[28] = 11,
	[30] = 11,
	-- S block
	[32] = 12,
	[34] = 13,
	[36] = 12,
	[38] = 13,
	-- L block
	[40] = 14,
	[42] = 15,
	[44] = 16,
	[46] = 17,
	-- I block
	[48] = 18,
	[50] = 19,
	[52] = 18,
	[54] = 19
}

ShapeAndOrientation = buildInfo("Block shape and orientation", 0x317, orientationValues, -1, 19)

categoryValues1 = {}
categoryValues1[0] = 0

BlockLocations = buildXYRegion("Placed block locations", 0x100, 12, -1, 0x17, -2, 0x10, categoryValues1, 1)

Score1 = buildInteger("Score 1", 0x270, 0, 1)
Score2 = buildInteger("Score 2", 0x271, 0, 256)
Score3 = buildInteger("Score 3", 0x272, 0, 256*256)
Score4 = buildInteger("Score 4", 0x273, 0, 256*256*256)

ScoreAddresses = { Score1, Score2, Score3, Score4 }

AddressTable = {}
AddressTable[1] = BlockLocations

MainPlane = buildAddressPlane(AddressTable, CursorX, -6, 6, CursorY, -1, 10, 1, 1)

Database = buildAddressDatabase({ MainPlane }, { ShapeAndOrientation }, ScoreAddresses, 0x1912, 80)


DisplayString = ""

-- Setting up the settings for a neural network

StateName = "TetrisState.state"
SessionFileName = "proofOfConceptV2_Pool.txt"
PreviousGenerationFileName = "proofOfConceptV2_ArchivePool"
ButtonNames = {
		"P1 A",
		"P1 B",
		"P1 Down",
		"P1 Left",
		"P1 Right",
	}

InputCount = getResultArrayLength(Database)
OutputCount = #ButtonNames

-- Most of the following values, which control how the neural network will mutate and how generations will develop,
-- are borrowed from SethBling's NEATEvolve.lua, from MarI/O, which this project draws inspiration from.

Population = 200
DeltaDisjoint = 1.5
DeltaExcess = 1.5
DeltaWeights = 0.4
DeltaThreshold = 1.0

StaleSpeciesThreshold = 15
CrossoverEnableChance = 0.25

PointMutateChance = 0.25
PerturbChance = 0.90
CrossoverChance = 0.75
LinkMutationChance = 2.0
NodeMutationChance = 0.50
StepSize = 0.1
DisableMutationChance = 0.4
EnableMutationChance = 0.2

MaxTotalNodes = 500000
FramesPerInputUpdate = 2
FitnessTimeout = 18000
TimeoutFrame = 18000

function sigmoid(x)
	return 2/(1 + math.exp(-4.9*x)) - 1
end



-- BASIC CONSTRUCTORS AND OBJECT FUNCTIONS
function buildPool()
	local pool = {}
	pool.Species = {}
	pool.Generation = 1
	pool.GlobalInnovationNumber = 0
	pool.CurrentSpecies = 1
	pool.CurrentGenome = 1
	pool.OverallGenome = 1
	pool.TopFitness = 0
	pool.TotalAdjustedFitness = 0
	
	return pool
end

function getNextInnovationNumber()
	GenePool.GlobalInnovationNumber = GenePool.GlobalInnovationNumber + 1
	return GenePool.GlobalInnovationNumber
end

function buildLink(inNode, outNode, weight, enabled, innovationNumber)
	local link = {}
	link.InNode = inNode
	link.OutNode = outNode
	link.Weight = weight
	link.Enabled = enabled
	link.InnovationNumber = innovationNumber
	
	return link
end

function copyLink(link)
	return buildLink(link.InNode, link.OutNode, link.Weight, link.Enabled, link.InnovationNumber)
end

function buildNode()
	local node = {}
	node.InLinks = {}
	node.OutLinks = {}
	node.Value = 0
	
	return node
end

function buildGenome()
	local genome = {}
	genome.Links = {}
	genome.Fitness = 0
	genome.AdjustedFitness = 0
	genome.TopNode = InputCount
	
	genome.Nodes = {}
	for i = 1,InputCount do
		genome.Nodes[i] = buildNode()
	end
	for i = MaxTotalNodes + 1, MaxTotalNodes + OutputCount do
		genome.Nodes[i] = buildNode()
	end
	
	-- Idea borrowed from MarI/O
	-- Including mutation chances as part of the genome and mutating them
	-- will in theory allow the network to find optimal mutation chances
	local mRates = {}
	mRates.PointMutate = PointMutateChance
	mRates.LinkMutate = LinkMutationChance
	mRates.NodeMutate = NodeMutationChance
	mRates.Step = StepSize
	mRates.DisableMutate = DisableMutationChance
	mRates.EnableMutate = EnableMutationChance
	
	genome.MutatationRates = mRates
	
	return genome
end

function insertLinkIntoGenome(genome, link)
	--[[ Error test code
	if not genome.Nodes[link.OutNode] and link.OutNode > MaxTotalNodes then
		error()
	end
	
	local i = nil
	local o = nil
	
	while not i or not o do
		i = genome.Nodes[link.InNode]
		o = genome.Nodes[link.OutNode]
		if not i or not o then
			getNextNode(genome)
		end
	end
	--]]
	local i = genome.Nodes[link.InNode]
	local o = genome.Nodes[link.OutNode]
	table.insert(genome.Links, link)
	table.insert(i.OutLinks, link)
	table.insert(o.InLinks, link)
end

function copyGenome(genome)
	local newGenome = buildGenome()
	newGenome.Fitness = genome.Fitness
	newGenome.AdjustedFitness = genome.AdjustedFitness
	for key,value in pairs(genome.MutatationRates) do
		newGenome.MutatationRates[key] = value
	end
	while newGenome.TopNode < genome.TopNode do
		getNextNode(newGenome)
	end
	for i,link in ipairs(genome.Links) do
		local tempLink = copyLink(link)
		insertLinkIntoGenome(newGenome, tempLink)
	end
	
	return newGenome
end

-- Sets the value for all nodes in a genome back to 0
function resetGenomeNodes(genome)
	for key,node in pairs(genome.Nodes) do
		node.Value = 0
	end
end

function getNextNode(genome)
	genome.TopNode = genome.TopNode + 1
	genome.Nodes[genome.TopNode] = buildNode()
	return genome.TopNode
end

function buildSpecies(genome)
	local species = {}
	species.DefiningGenome = genome
	species.Genomes = {}
	species.TopFitness = 0
	species.TotalFitness = 0
	species.TotalAdjustedFitness = 0
	species.StaleGenerations = 0
	species.IsStale = true
	
	return species
end

-- Creates a new species based on a previous species
function deriveSpecies(species)
	local newSpecies = buildSpecies()
	newSpecies.TopFitness = species.TopFitness
	newSpecies.StaleGenerations = species.StaleGenerations
	if #species.Genomes < 1 then
		newSpecies.DefiningGenome = species.DefiningGenome
	else
		newSpecies.DefiningGenome = species.Genomes[math.random(1,#species.Genomes)]
	end
	
	return newSpecies
end



-- MUTATION RELATED FUNCTIONS
function getRandomLink(links)
	return links[math.random(#links)]
end

-- Returns a random weight between -2 and 2
function getRandomWeight()
	return 4*math.random() - 2
end

-- Returns a random value between -step and step
function getRandomStep(step)
	return (2*math.random() - 1)*step
end

-- Mutates a given weight
function mutateWeight(weight, step)
	local p = math.random()
	if p < PerturbChance then
		return weight + getRandomStep(step)
	else
		return getRandomWeight()
	end
end

-- Mutates a random link's weight
function pointMutate(genome)
	-- If no links are available (only possible early on), do nothing and return
	if #genome.Links == 0 then return end	
	
	local link = getRandomLink(genome.Links)
	link.Weight = mutateWeight(link.Weight, genome.MutatationRates.Step)
end

-- Adds a link between two valid, random nodes
function mutateLink(genome)
	local topHiddenNode = genome.TopNode
	-- First node is either an input or hidden node
	local node1 = math.random(1, topHiddenNode)
	-- Second node is either a hidden or output node
	-- The "+ OutputCount" adds output nodes as an option
	local node2 = math.random(InputCount + 1, topHiddenNode + OutputCount)
	-- Convert output node values to the corresponding index
	if node2 > topHiddenNode then
		node2 = node2 - topHiddenNode + MaxTotalNodes
	end
	
	local newLink = buildLink(node1, node2, getRandomWeight(), true, getNextInnovationNumber())
	insertLinkIntoGenome(genome, newLink)
end

-- Adds a node that replaces a random link
function mutateNode(genome)
	-- If no links are available (only possible early on),
	-- OR if the program has run long enough to max out the number of nodes,
	-- do nothing and return
	if #genome.Links == 0 or genome.TopNode >= MaxTotalNodes then return end	

	local link = getRandomLink(genome.Links)

	local inNodeID = link.InNode
	local outNodeID = link.OutNode
	
	local newNodeID = getNextNode(genome)
	
	local inLink = buildLink(inNodeID, newNodeID, 1, true, getNextInnovationNumber())
	local outLink = buildLink(newNodeID, outNodeID, link.Weight, link.Enabled, getNextInnovationNumber())
	
	insertLinkIntoGenome(genome, inLink)
	insertLinkIntoGenome(genome, outLink)
	
	link.Enabled = false
end



-- Sets one random link that is currently not the value of enable to the value of enable
function enableOrDisable(genome, enable)
	local linkPool = {}
	for i,link in ipairs(genome.Links) do
		if link.Enabled ~= enable then
			table.insert(linkPool, link)
		end
	end
	
	if #linkPool == 0 then return end
	
	local link = getRandomLink(linkPool)
	link.Enabled = enable
end

-- Randomly disables an enabled link
function mutateDisable(genome)
	enableOrDisable(genome, false)
end

-- Randomly enables a disabled link
function mutateEnable(genome)
	enableOrDisable(genome, true)
end

-- Generic function to run the given mutation function with the given probability
-- If p > 1, the function is ran math.floor(p) times, then randomly one more based on the value after the decimal
function runMutation(genome, key, mutateFunction)
	local p = genome.MutatationRates[key]
	local randomVal = math.random()
	while randomVal <= p do
		mutateFunction(genome)
		p = p - 1
	end
end

-- Mutates a genome
function mutateGenome(genome)
	-- Idea borrowed from MarI/O
	-- Changing mutation rates will in theory produce optimal mutation rates eventually
	for key, value in pairs(genome.MutatationRates) do
		local randomValue = math.random(1,3)
		if randomValue == 1 then
			-- Decrease the mutation rate
			genome.MutatationRates[key] = value * 0.95
		elseif randomValue == 2 then
			-- Increase the mutation rate
			genome.MutatationRates[key] = value / 0.95
			
			-- If randomValue == 3, keep the mutation rate the same (do nothing)
		end
	end
	
	runMutation(genome, "LinkMutate", mutateLink)
	runMutation(genome, "NodeMutate", mutateNode)
	runMutation(genome, "PointMutate", pointMutate)
	runMutation(genome, "DisableMutate", mutateDisable)
	runMutation(genome, "EnableMutate", mutateEnable)
	
	genome.Fitness = 0
	genome.AdjustedFitness = 0
end



-- SPECIES AND GENE POOL FUNCTIONS
function createSimpleGenome()
	local genome = buildGenome()
	mutateGenome(genome)
	
	return genome
end

function processDisjointExcessAndWeightMean(genome1, genome2)
	-- Double-check that both genomes have their links ordered from lowest innovation to highest
	-- (Should happen by default, but there may be edge cases I haven't considered)
	local sortFunction = function(a,b)
		return a.InnovationNumber < b.InnovationNumber
	end
	
	local genomeLinks1 = genome1.Links
	local genomeLinks2 = genome2.Links
	table.sort(genomeLinks1, sortFunction)
	table.sort(genomeLinks2, sortFunction)
	
	local sharedCount = 0
	local disjointCount = 0
	local sumOfWeightDifferences = 0
	
	local i1, i2 = 1, 1
	while i1 <= #genomeLinks1 and i2 <= #genomeLinks2 do
		local link1 = genomeLinks1[i1]
		local link2 = genomeLinks2[i2]
		
		if link1.InnovationNumber < link2.InnovationNumber then
			disjointCount = disjointCount + 1
			i1 = i1 + 1
		elseif link1.InnovationNumber > link2.InnovationNumber then
			disjointCount = disjointCount + 1
			i2 = i2 + 1
		else
			sharedCount = sharedCount + 1
			local weightDifference = math.abs(link1.Weight - link2.Weight)
			sumOfWeightDifferences = weightDifference + sumOfWeightDifferences
			
			i1 = i1 + 1
			i2 = i2 + 1
		end
	end
	
	-- Handle excess innovation numbers
	local excessCount = 0
	while i1 <= #genomeLinks1 do
		excessCount =  excessCount + 1
		i1 = i1 + 1
	end
	while i2 <= #genomeLinks2 do
		excessCount =  excessCount + 1
		i2 = i2 + 1
	end
	
	maxLinkCount = math.max(#genome1.Links, #genome2.Links)
	
	local weightMean = 999999999999
	if sharedCount ~= 0 then weightMean = sumOfWeightDifferences / sharedCount end
	
	return disjointCount / maxLinkCount, excessCount / maxLinkCount, weightMean
end

function sameSpecies(genome1, genome2)
	if genome1 == genome2 then return true end
	local disjoint, excess, weight = processDisjointExcessAndWeightMean(genome1, genome2)
	return disjoint*DeltaDisjoint + excess*DeltaExcess + weight*DeltaWeights < DeltaThreshold
end

function addToSpecies(genome)
	local speciesFound = false
	for i, species in ipairs(GenePool.Species) do
		local same = sameSpecies(genome, species.DefiningGenome)
		if same then
			table.insert(species.Genomes, genome)
			speciesFound = true
			break
		end
	end
	
	if not speciesFound then
		local newSpecies = buildSpecies(genome)
		table.insert(newSpecies.Genomes, genome)
		table.insert(GenePool.Species, newSpecies)
	end
end

function calculateGenomeAdjustedFitness(genome)
	local numSharedSpecies = 0
	for i,species in ipairs(GenePool.Species) do
		for j, subGenome in ipairs(species.Genomes) do
			if sameSpecies(genome, subGenome) then
				numSharedSpecies = numSharedSpecies + 1
			end
		end
	end
	
	genome.AdjustedFitness = genome.Fitness / numSharedSpecies
end

function calculateSpeciesTotalAdjustedFitness(species)
	species.TotalAdjustedFitness = 0
	
	for i,genome in ipairs(species.Genomes) do
		calculateGenomeAdjustedFitness(genome)
		species.TotalAdjustedFitness = species.TotalAdjustedFitness + genome.AdjustedFitness
	end
end

function calculatePoolTotalAdjustedFitness()
	GenePool.TotalAdjustedFitness = 0
	
	for i,species in ipairs(GenePool.Species) do
		calculateSpeciesTotalAdjustedFitness(species)
		GenePool.TotalAdjustedFitness = GenePool.TotalAdjustedFitness + species.TotalAdjustedFitness
	end
end

function initializePool()
	GenePool = buildPool()
	
	for i = 1,Population do
		local genome = createSimpleGenome()
		addToSpecies(genome)
	end
end

-- Combines two selected genomes into a new genome
function genomeCrossover(genome1, genome2)
	-- Makes sure that genome1 has a greater fitness than genome2
	if genome1.Fitness < genome2.Fitness then
		genome1, genome2 = genome2, genome1
	end
	
	local newGenome = buildGenome()

	-- Double-check that both genomes have their links ordered from lowest innovation to highest
	-- (Should happen by default, but there may be edge cases I haven't considered)
	local sortFunction = function(a,b)
		return a.InnovationNumber < b.InnovationNumber
	end
	
	local genomeLinks1 = genome1.Links
	local genomeLinks2 = genome2.Links
	table.sort(genomeLinks1, sortFunction)
	table.sort(genomeLinks2, sortFunction)
	
	-- Populate nodes
	newTopNode = math.max(genome1.TopNode, genome2.TopNode)
	while newGenome.TopNode < newTopNode do
		getNextNode(newGenome)
	end
	
	-- Handle shared and disjoint innovations between the two genomes
	local newI = 1
	local i1 = 1
	local i2 = 1
	
	while i1 <= #genomeLinks1 and i2 <= #genomeLinks2 do
		local link1 = genomeLinks1[i1]
		local link2 = genomeLinks2[i2]
		local tempLink = nil
		
		if link1.InnovationNumber <= link2.InnovationNumber then
			tempLink = copyLink(link1)
			i1 = i1 + 1
			if link1.InnovationNumber == link2.InnovationNumber then
				i2 = i2 + 1
			end
		else
			tempLink = copyLink(link2)
			i2 = i2 + 1
		end
		
		if not tempLink.Enabled and math.random() < CrossoverEnableChance then
			tempLink.Enabled = true
		end
		
		insertLinkIntoGenome(newGenome, tempLink)
	end
	
	-- Handle excess innovation numbers
	while i1 <= #genomeLinks1 do
		local tempLink = copyLink(genomeLinks1[i1])
		if not tempLink.Enabled and math.random() < CrossoverEnableChance then
			tempLink.Enabled = true
		end
		i1 = i1 + 1
		insertLinkIntoGenome(newGenome, tempLink)
	end
	while i2 <= #genomeLinks2 do
		local tempLink = copyLink(genomeLinks2[i2])
		if not tempLink.Enabled and math.random() < CrossoverEnableChance then
			tempLink.Enabled = true
		end
		i2 = i2 + 1
		insertLinkIntoGenome(newGenome, tempLink)
	end
	
	for key, value in pairs(genome1.MutatationRates) do
		newGenome.MutatationRates[key] = value
	end
	
	return newGenome
end

function getChild(species)
	local child
	if math.random() < CrossoverChance then
		local genome1 = species.Genomes[math.random(1, #species.Genomes)]
		local genome2 = species.Genomes[math.random(1, #species.Genomes)]
		child = genomeCrossover(genome1, genome2)
	else
		child = copyGenome(species.Genomes[math.random(1, #species.Genomes)])
	end
	
	mutateGenome(child)
	
	return child
end

-- Removes the lower elements from each species
function cullSpecies()
	local sortFunction = function(a,b)
		return a.Fitness > b.Fitness
	end
	
	for i, species in ipairs(GenePool.Species) do	
		table.sort(species.Genomes, sortFunction)
		
		local remaining = math.ceil(#species.Genomes / 2)
		
		while #species.Genomes > remaining do
			table.remove(species.Genomes)
		end
	end
end

function removeStaleSpecies()
	local survivingSpecies = {}
	for i,species in ipairs(GenePool.Species) do
		if species.StaleGenerations < StaleSpeciesThreshold or species.TopFitness >= GenePool.TopFitness then
			table.insert(survivingSpecies, species)
		end
	end
	GenePool.Species = survivingSpecies
end

function newGeneration()
	removeStaleSpecies()
	cullSpecies()
	calculatePoolTotalAdjustedFitness()
	
	-- Get populations for each species
	local speciesPopulations = {}
	local populationSum = 0
		
	-- Must include the event (possible early on, unlikely elsewhere) that GenePool.TotalAdjustedFitness = 0
	if GenePool.TotalAdjustedFitness == 0 then
		-- All species performed identically (no fitness)
		local populationResult = math.floor(Population / #GenePool.Species + 0.5)
		for i,species in ipairs(GenePool.Species) do
			speciesPopulations[i] = populationResult
			populationSum = populationSum + populationResult
		end
	else
		local sortFunction = function(a,b)
			return a.TotalAdjustedFitness > b.TotalAdjustedFitness
		end
		
		table.sort(GenePool.Species, sortFunction)
		
		local i = #GenePool.Species
		while i >= 1 do
			local species = GenePool.Species[i]
			local populationResult = math.floor(species.TotalAdjustedFitness / GenePool.TotalAdjustedFitness * Population + 0.5)
			if populationResult >= 2 then
				speciesPopulations[i] = populationResult
				populationSum = populationSum + populationResult
			else
				table.remove(GenePool.Species, i)
				calculatePoolTotalAdjustedFitness()
				table.sort(GenePool.Species, sortFunction)
			end
			i = i - 1
		end
	end
	-- Adjust for discrepency between populationSum and the desired population
	-- Largest population will be the least relatively affected by a change
	local popAdjustment = Population - populationSum
	speciesPopulations[1] = speciesPopulations[1] + popAdjustment
	
	-- Breed for every species
	local newSpecies = {}
	local newGenomes = {}
	
	for i,species in pairs(GenePool.Species) do
		local tempSpecies = deriveSpecies(species)
		table.insert(newSpecies, tempSpecies)
		-- Always insert the fittest genome from each species, for future breeding purposes,
		-- and a mutation of the fittest genome, for developmental purposes
		table.insert(newGenomes, copyGenome(species.Genomes[1]))
		local mutateCopy = copyGenome(species.Genomes[1])
		mutateGenome(mutateCopy)
		table.insert(newGenomes, mutateCopy)
		for j = 3, speciesPopulations[i] do
			table.insert(newGenomes, getChild(species))
		end
	end
	
	-- Finally, readjust the pool	
	GenePool.Species = newSpecies
	for i,genome in ipairs(newGenomes) do
		addToSpecies(genome)
	end
	
	GenePool.Generation = GenePool.Generation + 1
	GenePool.CurrentSpecies = 1
	GenePool.CurrentGenome = 1
	GenePool.OverallGenome = 1
	GenePool.TotalAdjustedFitness = 0--]]
end



-- FILE SAVE/LOAD FUNCTIONS
function saveLinkAsText(link)
	local enabledNumber = 0
	if link.Enabled then enabledNumber = 1 end
	return link.InNode .. "," .. link.OutNode .. "," .. link.Weight .. "," .. enabledNumber .. "," .. link.InnovationNumber .. "\n"
end

function saveGenomeAsText(genome)	
	local mRates = genome.MutatationRates
	local genomeText = genome.Fitness .. "," .. genome.TopNode .. "," 
	genomeText = genomeText .. mRates.PointMutate .. "," .. mRates.LinkMutate .. "," .. mRates.NodeMutate .. "," .. mRates.Step .. "," .. mRates.DisableMutate .. "," .. mRates.EnableMutate .. ","
	genomeText = genomeText .. #genome.Links .. "\n"
	
	for i,link in ipairs(genome.Links) do
		genomeText = genomeText .. saveLinkAsText(link)
	end
	
	return genomeText
end

function saveSpeciesAsText(species)	
	local isStaleNumber = 0
	if species.IsStale then isStaleNumber = 1 end
	local speciesText = species.TopFitness ..  "," .. species.TotalFitness .. "," .. species.StaleGenerations .. "," .. isStaleNumber .. "," .. #species.Genomes .. "\n"
	speciesText = speciesText .. saveGenomeAsText(species.DefiningGenome)
	for i,genome in ipairs(species.Genomes) do
		speciesText = speciesText .. saveGenomeAsText(genome)
	end
	
	return speciesText
end

function savePoolAsText(pool)
	local poolText = pool.Generation .. "," .. pool.GlobalInnovationNumber .. "," .. pool.CurrentSpecies .. "," .. pool.CurrentGenome .. "," .. pool.OverallGenome .. "," .. pool.TopFitness .. "," .. #pool.Species .. "\n"
	for i,species in ipairs(pool.Species) do
		poolText = poolText .. saveSpeciesAsText(species)
	end
	
	return poolText
end

function saveFile(filename)
	local fileText = savePoolAsText(GenePool)
	local fileSave = io.open(filename, "w")
	io.output(fileSave)
	io.write(fileText)
	io.close(fileSave)
end


-- Lua doesn't have this by default
function splitString(str, sep)
	local result = {}
	local start = 1
	local delimIndexStart, delimIndexEnd = string.find(str, sep, start)
	
	while delimIndexStart do
		local stringComponent = string.sub(str, start, delimIndexStart - 1)
		table.insert(result, stringComponent)
		
		start = delimIndexEnd + 1
		delimIndexStart, delimIndexEnd = string.find(str, sep, start)
	end
	
	table.insert(result, string.sub(str, start))
	
	return result	
end

-- All functions below assume a file to be read has been loaded into io.input
function loadLinkFromText()
	local splitLinkText = splitString(io.read(), ",")
	return buildLink(tonumber(splitLinkText[1]), tonumber(splitLinkText[2]), tonumber(splitLinkText[3]), tonumber(splitLinkText[4]) == 1, tonumber(splitLinkText[5]))
end

function loadGenomeFromText()
	local genomeSplitText = splitString(io.read(), ",")
	local newGenome = buildGenome()
	newGenome.Fitness = tonumber(genomeSplitText[1])
	newGenome.TopNode = tonumber(genomeSplitText[2])
	
	for i = InputCount + 1, newGenome.TopNode do
		newGenome.Nodes[i] = buildNode()
	end
	
	newGenome.MutatationRates.PointMutate = tonumber(genomeSplitText[3])
	newGenome.MutatationRates.LinkMutate = tonumber(genomeSplitText[4])
	newGenome.MutatationRates.NodeMutate = tonumber(genomeSplitText[5])
	newGenome.MutatationRates.Step = tonumber(genomeSplitText[6])
	newGenome.MutatationRates.DisableMutate = tonumber(genomeSplitText[7])
	newGenome.MutatationRates.EnableMutate = tonumber(genomeSplitText[8])
	
	for i = 1, tonumber(genomeSplitText[9]) do
		local newLink = loadLinkFromText()
		insertLinkIntoGenome(newGenome, newLink)
	end
	
	return newGenome
end

function loadSpeciesFromText()
	local newSpecies = buildSpecies(nil)
	local speciesSplitText = splitString(io.read(), ",")
	
	newSpecies.TopFitness = tonumber(speciesSplitText[1])
	newSpecies.TotalFitness = tonumber(speciesSplitText[2])
	newSpecies.StaleGenerations = tonumber(speciesSplitText[3])
	newSpecies.IsStale = tonumber(speciesSplitText[4]) == 1
	
	newSpecies.DefiningGenome = loadGenomeFromText()
	for i = 1, tonumber(speciesSplitText[5]) do
		table.insert(newSpecies.Genomes, loadGenomeFromText())
	end
	
	return newSpecies
end

function loadPoolFromText()
	local newPool = buildPool()
	local poolSplitText = splitString(io.read(), ",")
	
	newPool.Generation = tonumber(poolSplitText[1])
	newPool.GlobalInnovationNumber = tonumber(poolSplitText[2])
	newPool.CurrentSpecies = tonumber(poolSplitText[3])
	newPool.CurrentGenome = tonumber(poolSplitText[4])
	newPool.OverallGenome = tonumber(poolSplitText[5])
	newPool.TopFitness = tonumber(poolSplitText[6])
	
	for i=1, tonumber(poolSplitText[7]) do
		table.insert(newPool.Species, loadSpeciesFromText())
	end
	
	GenePool = newPool
end

function loadFile(filename)
	local readFile = io.open(filename, "r")
	if readFile ~= nil then
		io.input(readFile)
		if not pcall(loadPoolFromText) then
			initializePool()
		end
		io.close(readFile)
	else
		initializePool()
	end
end



-- NETWORK PROCESSING FUNCTIONS

function processInputNodes(genome, inputArray)
	-- Set input nodes
	for i = 1,InputCount do
		if inputArray[i] == 1 then
			genome.Nodes[i].Value = 1
		end
	end
end

function processNode(evalNode, genome)
	if #evalNode.InLinks > 0 then
		local valueSum = 0
		for linkID, link in ipairs(evalNode.InLinks) do
			if link.Enabled then
				local inNode = genome.Nodes[link.InNode]
				valueSum = valueSum + inNode.Value * link.Weight
			end
		end
		evalNode.Value = sigmoid(valueSum)
	end
end

function getOutputs(genome, inputArray)	
	resetGenomeNodes(genome)
	processInputNodes(genome, inputArray)
	
	-- Run through the network 5 times to compensate for loops
	for i=1,5 do
		for j=InputCount + 1, genome.TopNode do
			local evalNode = genome.Nodes[j]
			processNode(evalNode, genome)
		end
		
		for j=MaxTotalNodes+1,MaxTotalNodes+OutputCount do
			local evalNode = genome.Nodes[j]
			processNode(evalNode, genome)
		end
	end
	
	local outputs = {}
	
	for i, name in ipairs(ButtonNames) do
		if genome.Nodes[MaxTotalNodes + i].Value > 0 then
			outputs[name] = true
		else
			outputs[name] = false
		end
	end
	
	if outputs["P1 Left"] and outputs["P1 Right"] then
		outputs["P1 Left"] = false
		outputs["P1 Right"] = false
	end
	if outputs["P1 Up"] and outputs["P1 Down"] then
		outputs["P1 Up"] = false
		outputs["P1 Down"] = false
	end
	
	return outputs
end

function processGenome(genome)
	local ended = false
	local frameCount = 0
	local fitnessIncreaseFrame = 0
	local maxFitness = 0
	savestate.load(StateName)
	-- Code if bug where evalNode = nil keeps occuring
	--[[for j=InputCount + 1, genome.TopNode do
		
		if not genome.Nodes[j] then
			genome.Nodes[j] = buildNode()
		end
	end--]]
	while not ended and frameCount <= TimeoutFrame and fitnessIncreaseFrame <= FitnessTimeout do
		if not runEnded(Database) then
			local currentFitness = processScore(Database)
			if currentFitness > maxFitness then
				maxFitness = currentFitness
				fitnessIncreaseFrame = 0
			end
			local outputs = getOutputs(genome, processAddressDatabase(Database))
			
			for i=1,FramesPerInputUpdate do
				gui.text(2,2,DisplayString)
				gui.text(2,15,"Top fitness " .. GenePool.TopFitness)
				joypad.set(outputs)
				emu.frameadvance()
			end
			frameCount = frameCount + FramesPerInputUpdate
			fitnessIncreaseFrame = fitnessIncreaseFrame + FramesPerInputUpdate
		else
			ended = true
		end
	end
	genome.Fitness = processScore(Database)
end

function processSpecies(species)
	local displayStringFirstPart = "Generation " .. GenePool.Generation .. " Species " .. GenePool.CurrentSpecies .. " Genome "
	
	while GenePool.CurrentGenome <= #species.Genomes do
		local i = GenePool.CurrentGenome
		local genome = species.Genomes[i]
		
		DisplayString = displayStringFirstPart .. i .. " Overall " .. GenePool.OverallGenome
		processGenome(genome)
		
		species.TotalFitness = species.TotalFitness + genome.Fitness
		
		if genome.Fitness > species.TopFitness then
			species.TopFitness = genome.Fitness
			species.StaleGenerations = 0
			species.IsStale = false
			
			if species.TopFitness > GenePool.TopFitness then GenePool.TopFitness = species.TopFitness end
		end
		
		GenePool.CurrentGenome = GenePool.CurrentGenome + 1
		GenePool.OverallGenome = GenePool.OverallGenome + 1
		
		saveFile(SessionFileName)
	end
	
	if species.IsStale then species.StaleGenerations = species.StaleGenerations + 1 end
end

function processPool(startGenome)	
	while GenePool.CurrentSpecies <= #GenePool.Species do
		local species = GenePool.Species[GenePool.CurrentSpecies]
		processSpecies(species)
		GenePool.CurrentGenome = 1
		
		GenePool.CurrentSpecies = GenePool.CurrentSpecies + 1
	end
end