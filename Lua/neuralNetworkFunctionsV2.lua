dofile("readMemoryStructureV2.lua")

formGridSize = 10
archiveFolderName = "Archived Pools"

-- The following line speeds up emulation speed, resulting in faster processing
-- Comment it out for demonstrations
emu.limitframerate(false)

-- Building the address database that will produce an output table

nodeAreaWidth = 300
nodeAreaHeight = 200
nodeAreaStartX = 1
nodeAreaStartY = 1
nodeAreaEndX = nodeAreaWidth - formGridSize
nodeAreaEndY = nodeAreaHeight - formGridSize

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

tempColors = {}
tempColors[0] = 0xFF000000
tempColors[1] = 0xFFFFFFFF

Database = buildAddressDatabase({ MainPlane }, { ShapeAndOrientation }, ScoreAddresses, 0x1912, 80, tempColors)


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

-- Many values here taken from the orginal NEAT paper

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
FitnessTimeout = 2000
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
	pool.TopSpecies = 1
	pool.TopGenome = 1
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
	node.X = math.random(nodeAreaStartX, nodeAreaEndX)
	node.Y = math.random(nodeAreaStartY, nodeAreaEndY)
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
	
	if fixedNodeCoords == nil then
		for i = 1,InputCount do
			genome.Nodes[i] = buildNode()
		end
		for i = MaxTotalNodes + 1, MaxTotalNodes + OutputCount do
			genome.Nodes[i] = buildNode()
		end
	else
		for i = 1,InputCount do
			genome.Nodes[i] = buildNode()
			genome.Nodes[i].X = fixedNodeCoords[i].X
			genome.Nodes[i].Y = fixedNodeCoords[i].Y
		end
		for i = MaxTotalNodes + 1, MaxTotalNodes + OutputCount do
			genome.Nodes[i] = buildNode()
			genome.Nodes[i].X = fixedNodeCoords[i].X
			genome.Nodes[i].Y = fixedNodeCoords[i].Y
		end
	end
	
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
		getNextNode(newGenome, genome)
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

function getNextNode(genome, copyGenome)
	genome.TopNode = genome.TopNode + 1
	genome.Nodes[genome.TopNode] = buildNode()
	if copyGenome ~= nil then
		genome.Nodes[genome.TopNode].X = copyGenome.Nodes[genome.TopNode].X
		genome.Nodes[genome.TopNode].Y = copyGenome.Nodes[genome.TopNode].Y
	end
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
	local newTopNode
	local copyGenome
	if genome1.TopNode >= genome2.TopNode then
		newTopNode = genome1.TopNode
		copyGenome = genome1
	else
		newTopNode = genome2.TopNode
		copyGenome = genome2
	end
	while newGenome.TopNode < newTopNode do
		getNextNode(newGenome, copyGenome)
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
		
		local remaining = math.ceil(#species.Genomes / 3)
		
		while #species.Genomes > remaining do
			table.remove(species.Genomes)
		end
	end
end

function cullUnfitFromSpecies()
	local sortFunction = function(a,b)
		return a.Fitness > b.Fitness
	end
	
	for i, species in ipairs(GenePool.Species) do	
		table.sort(species.Genomes, sortFunction)
		
		local topAllowedFitness = species.Genomes[1].Fitness * 0.9
		
		local removing = true
		while removing do
			local unfitGenome = species.Genomes[#species.Genomes]
			if unfitGenome.Fitness < topAllowedFitness then
				table.remove(species.Genomes)
			else
				removing = false
			end
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
	
	-- Sort species table by top fitness
	local topFitnessSort = function(a,b)
		return a.TopFitness > b.TopFitness
	end
	
	table.sort(GenePool.Species, topFitnessSort)
	
	for i,species in pairs(GenePool.Species) do
		local tempSpecies = deriveSpecies(species)
		table.insert(newSpecies, tempSpecies)
		-- Always insert the fittest genome from each species, for future breeding purposes
		table.insert(newGenomes, copyGenome(species.Genomes[1]))
		
		-- First, create half from the top half of the genomes in a species
		-- (found from earlier culling)
		for j = 2, math.ceil(speciesPopulations[i] / 2) do
			table.insert(newGenomes, getChild(species))
		end
	end
	
	-- Then, create half from only genomes close enough to the top fitness of each species
	cullUnfitFromSpecies()
	
	for i,species in pairs(GenePool.Species) do
		for j = math.ceil(speciesPopulations[i] / 2) + 1, speciesPopulations[i] do
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
	GenePool.TotalAdjustedFitness = 0
	GenePool.TopSpecies = 1
	GenePool.TopGenome = 1
end



-- FILE SAVE/LOAD FUNCTIONS
-- All lower-level functions assume a proper value has been stored in io.output/input
function saveLinkAsText(link)
	local enabledNumber = 0
	if link.Enabled then enabledNumber = 1 end
	io.write(link.InNode, ",", link.OutNode, ",", link.Weight, ",", enabledNumber, ",", link.InnovationNumber, "\n")
end

function saveGenomeAsText(genome)	
	local mRates = genome.MutatationRates
	io.write(genome.Fitness, ",", genome.TopNode, "," )
	io.write(mRates.PointMutate, ",", mRates.LinkMutate, ",", mRates.NodeMutate, ",", mRates.Step, ",", mRates.DisableMutate, ",", mRates.EnableMutate, ",")
	io.write(#genome.Links, "\n")
	
	for i = InputCount + 1, genome.TopNode do
		io.write(genome.Nodes[i].X, ",", genome.Nodes[i].Y, "\n")
	end

	for i,link in ipairs(genome.Links) do
		saveLinkAsText(link)
	end
end

function saveSpeciesAsText(species)	
	local isStaleNumber = 0
	if species.IsStale then isStaleNumber = 1 end
	io.write(species.TopFitness, ",", species.TotalFitness, ",", species.StaleGenerations, ",", isStaleNumber, ",", #species.Genomes, "\n")
	
	saveGenomeAsText(species.DefiningGenome)
	for i,genome in ipairs(species.Genomes) do
		saveGenomeAsText(genome)
	end
end

function savePoolAsText(pool)
	io.write("V3", "\n")
	io.write(pool.Generation, ",", pool.GlobalInnovationNumber, ",", pool.CurrentSpecies, ",", pool.CurrentGenome, ",", pool.OverallGenome, ",",
			pool.TopFitness, ",", #pool.Species, ",", pool.TopSpecies, ",", pool.TopGenome, "\n")
	for i,species in ipairs(pool.Species) do
		saveSpeciesAsText(species)
	end
end

function saveFile(filename)
	local fileSave = io.open(filename, "w")
	io.output(fileSave)
	savePoolAsText(GenePool)
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

function loadLinkFromText()
	local splitLinkText = splitString(io.read(), ",")
	return buildLink(tonumber(splitLinkText[1]), tonumber(splitLinkText[2]), tonumber(splitLinkText[3]), tonumber(splitLinkText[4]) == 1, tonumber(splitLinkText[5]))
end

function loadGenomeFromText()
	local genomeSplitText = splitString(io.read(), ",")
	local newGenome = buildGenome()
	newGenome.Fitness = tonumber(genomeSplitText[1])
	newGenome.TopNode = tonumber(genomeSplitText[2])	
	newGenome.MutatationRates.PointMutate = tonumber(genomeSplitText[3])
	newGenome.MutatationRates.LinkMutate = tonumber(genomeSplitText[4])
	newGenome.MutatationRates.NodeMutate = tonumber(genomeSplitText[5])
	newGenome.MutatationRates.Step = tonumber(genomeSplitText[6])
	newGenome.MutatationRates.DisableMutate = tonumber(genomeSplitText[7])
	newGenome.MutatationRates.EnableMutate = tonumber(genomeSplitText[8])
	
	if saveFileVersion == 1 then
		for i = InputCount + 1, newGenome.TopNode do
			newGenome.Nodes[i] = buildNode()
		end
	else
		for i = InputCount + 1, newGenome.TopNode do
			newGenome.Nodes[i] = buildNode()
			local nodeSplitText = splitString(io.read(), ",")
			newGenome.Nodes[i].X = tonumber(nodeSplitText[1])
			newGenome.Nodes[i].Y = tonumber(nodeSplitText[2])
		end
	end
	
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
	local line = io.read()
	if line == "V3" then
		saveFileVersion = 3
		line = io.read()	
	elseif line == "V2" then
		saveFileVersion = 2
		line = io.read()
	else
		saveFileVersion = 1
	end
	local poolSplitText = splitString(line, ",")
	
	newPool.Generation = tonumber(poolSplitText[1])
	newPool.GlobalInnovationNumber = tonumber(poolSplitText[2])
	newPool.CurrentSpecies = tonumber(poolSplitText[3])
	newPool.CurrentGenome = tonumber(poolSplitText[4])
	newPool.OverallGenome = tonumber(poolSplitText[5])
	newPool.TopFitness = tonumber(poolSplitText[6])
	if saveFileVersion >= 3 then
		newPool.TopSpecies = tonumber(poolSplitText[8])
		newPool.TopGenome = tonumber(poolSplitText[9])
	else
		newPool.TopSpecies = 1
		newPool.TopGenome = 1
	end
	
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
			io.close(readFile)
			return false
		end
		io.close(readFile)
		return true
	else
		return false
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
	
	if outputs["P2 Left"] and outputs["P2 Right"] then
		outputs["P2 Left"] = false
		outputs["P2 Right"] = false
	end
	if outputs["P2 Up"] and outputs["P2 Down"] then
		outputs["P2 Up"] = false
		outputs["P2 Down"] = false
	end
	
	if outputs["P3 Left"] and outputs["P3 Right"] then
		outputs["P3 Left"] = false
		outputs["P3 Right"] = false
	end
	if outputs["P3 Up"] and outputs["P3 Down"] then
		outputs["P3 Up"] = false
		outputs["P3 Down"] = false
	end
	
	if outputs["P4 Left"] and outputs["P4 Right"] then
		outputs["P4 Left"] = false
		outputs["P4 Right"] = false
	end
	if outputs["P4 Up"] and outputs["P4 Down"] then
		outputs["P4 Up"] = false
		outputs["P4 Down"] = false
	end
	
	return outputs
end

function processGenome(genome)
	local processed = false
	
	while not processed do
		if fittestPending then
			fittestPending = false
			if not showingFittestGenome then
				showingFittestGenome = true
				local newDisplayString = "Fittest: Species: " .. GenePool.TopSpecies .. " | Genome: " .. GenePool.TopGenome .. " | Fitness: " .. GenePool.TopFitness
				forms.settext(neuralNetworkDisplayForm.Info, newDisplayString)
				
				processGenome(GenePool.Species[GenePool.TopSpecies].Genomes[GenePool.TopGenome])
				
				forms.settext(neuralNetworkDisplayForm.Info, DisplayString)
				showingFittestGenome = false
			end
		end
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
		
		while not ended do
			if terminateLearning or runEnded(Database) then
				ended = true
				processed = true				
			elseif fittestPending then
				ended = true
			else			
				local currentFitness = processScore(Database)
				if currentFitness > maxFitness then
					maxFitness = currentFitness
					fitnessIncreaseFrame = 0
				end
				local outputs = getOutputs(genome, processAddressDatabase(Database))
				updateFormImage(genome)
				
				for i=1,FramesPerInputUpdate do
					joypad.set(outputs)
					emu.frameadvance()
				end
				frameCount = frameCount + FramesPerInputUpdate
				fitnessIncreaseFrame = fitnessIncreaseFrame + FramesPerInputUpdate
				
				if frameCount > TimeoutFrame or fitnessIncreaseFrame > FitnessTimeout then
					ended = true
					processed = true				
				end
			end
			
			coroutine.yield()
		end
	end
	if not terminateLearning then
		genome.Fitness = processScore(Database)
	end
end

function processSpecies(species)
	local displayStringFirstPart = "Generation: " .. GenePool.Generation .. " | Species: " .. GenePool.CurrentSpecies .. " | Genome: "
	
	while not terminateLearning and GenePool.CurrentGenome <= #species.Genomes do
		local i = GenePool.CurrentGenome
		local genome = species.Genomes[i]
		
		DisplayString = displayStringFirstPart .. GenePool.CurrentGenome .. " | Overall: " .. GenePool.OverallGenome .. " | Top fitness: " .. GenePool.TopFitness
		-- Bug test code
		-- DisplayString = DisplayString .. " " .. GenePool.TopSpecies .. " " .. GenePool.TopGenome
		forms.settext(neuralNetworkDisplayForm.Info, DisplayString)
		
		processGenome(genome)
		
		if not terminateLearning then
			species.TotalFitness = species.TotalFitness + genome.Fitness
			
			if genome.Fitness > species.TopFitness then
				species.TopFitness = genome.Fitness
				species.StaleGenerations = 0
				species.IsStale = false
				
				if species.TopFitness > GenePool.TopFitness then
					GenePool.TopFitness = species.TopFitness
					GenePool.TopSpecies = GenePool.CurrentSpecies
					GenePool.TopGenome = GenePool.CurrentGenome
				end
			end
			
			GenePool.CurrentGenome = GenePool.CurrentGenome + 1
			GenePool.OverallGenome = GenePool.OverallGenome + 1
			
			saveFile(SessionFileName)
		end
	end
	
	if species.IsStale then species.StaleGenerations = species.StaleGenerations + 1 end
end

function processPool()
	while not terminateLearning and GenePool.CurrentSpecies <= #GenePool.Species do
		local species = GenePool.Species[GenePool.CurrentSpecies]
		processSpecies(species)
		
		GenePool.CurrentGenome = 1		
		GenePool.CurrentSpecies = GenePool.CurrentSpecies + 1
	end
end

function processGenerations()
	terminateLearning = false
	while true do
		processPool()
		if not terminateLearning then
			saveFile(PreviousGenerationFileName .. GenePool.Generation .. ".txt")
			saveFile(PreviousGenerationFileName .. ".txt")
			newGeneration()
		else
			break
		end
	end
end

-- FORM DISPLAY FUNCTIONS

function fittestButtonFunction()
	fittestPending = true
end

function displayFormCloseFunction()
	terminateLearning = true
	forms.destroy(neuralNetworkDisplayForm.Form)
end

function backButtonFunction()
	terminateLearning = true
	forms.destroy(neuralNetworkDisplayForm.Form)
end

function createDisplayForm()	
	if neuralNetworkDisplayForm ~= nil then
		forms.destroy(neuralNetworkDisplayForm.Form)
		neuralNetworkDisplayForm = nil
	end
	
	local widths = {}
	local heights = {}
	for i,plane in ipairs(Database.AddressPlanes) do
		table.insert(widths, plane.XMax - plane.XMin + 1)
		table.insert(heights, plane.YMax - plane.YMin + 1)
	end
	
	for i,address in ipairs(Database.InfoAddresses) do
		table.insert(widths, address.MaxValue)
		table.insert(heights, 1)	
	end
	
	local gridWidth = math.max(unpack(widths))
	local gridHeight = 1
	for i, v in ipairs(heights) do
		gridHeight = gridHeight + v + 1
	end
	
	-- Input node width + buffer + hidden node width + buffer + output node width (same width as buffer + text area of essentially arbitrary length)
	local picWidth = formGridSize*gridWidth + 3*formGridSize + nodeAreaWidth + 70
	local picHeight = formGridSize*gridHeight
	nodeAreaHeight = math.max(picHeight, nodeAreaHeight, OutputCount * formGridSize)
	picHeight = nodeAreaHeight
	-- Width = buffer + picture box width + buffer + constant value 16 that fixes weird unexplained size mishaps
	-- Height = buffer + picture box height + buffer + text box height (22) + button height (21) + buffer + size fixing constant (39)
	local formWidth = picWidth + 2*formGridSize + 16
	if formWidth < 450 then formWidth = 450 end
	local formHeight = picHeight + 3*formGridSize + 82
	
	local newFormHandle = forms.newform(formWidth, formHeight, "Network Display", displayFormCloseFunction)
	local pictureBoxHandle = forms.pictureBox(newFormHandle, formGridSize, formGridSize, picWidth, picHeight)
	
	local nextY = formGridSize * 2 + picHeight
	local displayInformation = forms.label(newFormHandle, "Waiting for input", formGridSize, nextY, 400, 22)
	nextY = nextY + 22
	local fittestButton = forms.button(newFormHandle, "Fittest", fittestButtonFunction, formGridSize, nextY)
	local backButton = forms.button(newFormHandle, "Back", backButtonFunction, formGridSize + 92, nextY)
	
	neuralNetworkDisplayForm = {}
	neuralNetworkDisplayForm.Form = newFormHandle
	neuralNetworkDisplayForm.Picture = pictureBoxHandle
	neuralNetworkDisplayForm.Width = formWidth
	neuralNetworkDisplayForm.Height = formHeight
	neuralNetworkDisplayForm.GridWidth = gridWidth
	neuralNetworkDisplayForm.GridHeight = gridHeight
	neuralNetworkDisplayForm.Info = displayInformation
	neuralNetworkDisplayForm.FittestButton = fittestButton
	neuralNetworkDisplayForm.BackButton = backButton
	
	nodeAreaStartX = gridWidth * formGridSize + formGridSize + 1
	nodeAreaEndX = nodeAreaStartX + nodeAreaWidth - formGridSize
	nodeAreaEndY = nodeAreaHeight - formGridSize
	
	-- Set vales for fixed node coordinates (inputs and outputs)
	fixedNodeCoords = {}
	local yDraw = 0
	local rectSize = formGridSize - 1
	local nodeNumber = 1
	
	for i, addressPlane in ipairs(Database.AddressPlanes) do
		local processedTable, tableWidth, tableHeight = processAddressPlane(addressPlane)
		local startingPoint = gridWidth - tableWidth - 1
		for y = 1, tableHeight, 1 do
			for x = 1, tableWidth, 1 do
				local rectCornerX = (startingPoint + x) * formGridSize
				for j = 1, addressPlane.MaxValue do
					fixedNodeCoords[nodeNumber] = {}
					fixedNodeCoords[nodeNumber].X = rectCornerX
					fixedNodeCoords[nodeNumber].Y = yDraw
					nodeNumber = nodeNumber + 1
				end
			end
			yDraw = yDraw + formGridSize
		end
		yDraw = yDraw + formGridSize
	end
	
	for i, infoAddress in ipairs(Database.InfoAddresses) do
		local infoArray = {}
		addInfoAddressToResultArray(infoAddress, infoArray)
		
		local startingPoint = gridWidth - #infoArray - 1
		
		for i = 1, #infoArray, 1 do
			fixedNodeCoords[nodeNumber] = {}
			fixedNodeCoords[nodeNumber].X = (startingPoint + i) * formGridSize
			fixedNodeCoords[nodeNumber].Y = yDraw
			nodeNumber = nodeNumber + 1
		end
		
		yDraw = yDraw + 2 * formGridSize
	end
	
	fixedNodeCoords[nodeNumber] = {}
	fixedNodeCoords[nodeNumber].X = (gridWidth - 1) * formGridSize
	fixedNodeCoords[nodeNumber].Y = yDraw
	nodeNumber = nodeNumber + 1
	
	local outputNodeX = nodeAreaEndX + 2 * formGridSize
	local outputNodeY = math.ceil((nodeAreaHeight - OutputCount * formGridSize)/ 2)
	for i = MaxTotalNodes + 1, MaxTotalNodes + OutputCount do
		fixedNodeCoords[i] = {}
		fixedNodeCoords[i].X = outputNodeX
		fixedNodeCoords[i].Y = outputNodeY
		outputNodeY = outputNodeY + formGridSize
	end
end

function updateFormImage(genome)
	-- Draw nodes
	forms.clear(neuralNetworkDisplayForm.Picture, 0xFFF0F0F0)
	local picture = neuralNetworkDisplayForm.Picture
	local gridWidth = neuralNetworkDisplayForm.GridWidth
	local gridHeight = neuralNetworkDisplayForm.GridHeight
	local yDraw = 0
	local black = 0xFF000000
	local white = 0xFFFFFFFF
	local translBlack = 0x22000000
	local translWhite = 0x22FFFFFF
	local rectSize = formGridSize - 1
	
	for i, addressPlane in ipairs(Database.AddressPlanes) do
		local processedTable, tableWidth, tableHeight = processAddressPlane(addressPlane)
		local startingPoint = gridWidth - tableWidth - 1
		for y = 1, tableHeight, 1 do
			for x = 1, tableWidth, 1 do
				local rectCornerX = (startingPoint + x) * formGridSize				
				forms.drawRectangle(picture, rectCornerX, yDraw, rectSize, rectSize, black, Database.ValueColors[processedTable[x][y]])
			end
			yDraw = yDraw + formGridSize
		end
		yDraw = yDraw + formGridSize
	end
	
	for i, infoAddress in ipairs(Database.InfoAddresses) do
		local infoArray = {}
		addInfoAddressToResultArray(infoAddress, infoArray)
		
		local startingPoint = gridWidth - #infoArray - 1
		
		for i = 1, #infoArray, 1 do
			local color = black
			if infoArray[i] == 1 then color = white end
			
			forms.drawRectangle(picture, (startingPoint + i) * formGridSize, yDraw, rectSize, rectSize, black, color)
		end
		
		yDraw = yDraw + 2 * formGridSize
	end
	
	forms.drawRectangle(picture, (gridWidth - 1) * formGridSize, yDraw, rectSize, rectSize, black, white)
	
	for i = InputCount + 1, genome.TopNode do
		local node = genome.Nodes[i]
		local border = black
		local fill = white
		if node.Value <= 0 then
			border = translBlack
			fill = translBlack
		end
		
		forms.drawRectangle(picture, node.X, node.Y, rectSize, rectSize, border, fill)
	end
	
	local outputNodeX = nodeAreaEndX + 2 * formGridSize
	local outputTextX = outputNodeX + formGridSize + 2
	local outputNodeY = math.ceil((nodeAreaHeight - OutputCount * formGridSize)/ 2)
	for i = 1, OutputCount do
		local outputNode = genome.Nodes[MaxTotalNodes + i]
		local color = white
		if outputNode.Value <= 0 then
			color = black
		end
		
		forms.drawRectangle(picture, outputNodeX, outputNodeY, rectSize, rectSize, black, color)
		forms.drawText(picture, outputTextX, outputNodeY, ButtonNames[i], black, 0x00000000, formGridSize)
		
		outputNodeY = outputNodeY + formGridSize
	end
	
	-- Draw links (must be done afterwards in order to have all links drawn above nodes)
	local centerAdjust = math.ceil(formGridSize / 2)
	local lPosOn = 0xAA00FF00
	local lPosOff = 0x2200FF00
	local lNegOn = 0xAAFF0000
	local lNegOff = 0x22FF0000
	
	for i = 1, genome.TopNode do
		local drawNode = genome.Nodes[i]
		local startX = drawNode.X + formGridSize - 1
		if i <= InputCount then
			startX = drawNode.X + centerAdjust
		end
		local startY = drawNode.Y + centerAdjust
		for j, link in ipairs(drawNode.OutLinks) do
			if link.Enabled and link.Weight ~= 0 then
				local endNode = genome.Nodes[link.OutNode]
				local endNodeXAdjusted
				if link.OutNode > genome.TopNode then
					endNodeXAdjusted = endNode.X + centerAdjust
				else
					endNodeXAdjusted = endNode.X
				end
				local linkColor
				if link.Weight > 0 then
					if drawNode.Value > 0 then
						linkColor = lPosOn
					else
						linkColor = lPosOff
					end
				else
					if drawNode.Value > 0 then
						linkColor = lNegOn
					else
						linkColor = lNegOff
					end
				end
				
				forms.drawLine(picture, startX, startY, endNodeXAdjusted, endNode.Y + centerAdjust, linkColor)
			end
		end
	end
				
	
	forms.refresh(picture)
end