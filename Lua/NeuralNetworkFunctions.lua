dofile("ReadMemoryStructure.lua")

PuzzLearn.NeuralNetwork = {}

PuzzLearn.NeuralNetwork.FormGridSize = 10
PuzzLearn.NeuralNetwork.ArchiveFolderName = "Archived Pools"


PuzzLearn.NeuralNetwork.NodeAreaWidth = 300
PuzzLearn.NeuralNetwork.NodeAreaHeight = 200
PuzzLearn.NeuralNetwork.NodeAreaStartX = 1
PuzzLearn.NeuralNetwork.NodeAreaStartY = 1
PuzzLearn.NeuralNetwork.NodeAreaEndX = PuzzLearn.NeuralNetwork.NodeAreaWidth - PuzzLearn.NeuralNetwork.FormGridSize
PuzzLearn.NeuralNetwork.NodeAreaEndY = PuzzLearn.NeuralNetwork.NodeAreaHeight - PuzzLearn.NeuralNetwork.FormGridSize

-- Building the address database that will produce an output table.
-- These values are placeholders and do not need to be global until they are removed.
CursorX = PuzzLearn.MemoryStructure.BuildInteger("Cursor X", 0x326, -96, 1/8)
CursorY = PuzzLearn.MemoryStructure.BuildInteger("Cursor Y", 0x327, -48, 1/8)

cursorXTable = { CursorX }
cursorYTable = { CursorY }
Cursor = PuzzLearn.MemoryStructure.BuildObject("Cursor", cursorXTable, cursorYTable, nil, 1)

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

ShapeAndOrientation = PuzzLearn.MemoryStructure.BuildInfo("Block shape and orientation", 0x317, orientationValues, -1, 19)

categoryValues1 = {}
categoryValues1[0] = 0

BlockLocations = PuzzLearn.MemoryStructure.BuildXYRegion("Placed block locations", 0x100, 12, -1, 0x17, -2, 0x10, categoryValues1, 1)

Score1 = PuzzLearn.MemoryStructure.BuildInteger("Score 1", 0x270, 0, 1)
Score2 = PuzzLearn.MemoryStructure.BuildInteger("Score 2", 0x271, 0, 256)
Score3 = PuzzLearn.MemoryStructure.BuildInteger("Score 3", 0x272, 0, 256*256)
Score4 = PuzzLearn.MemoryStructure.BuildInteger("Score 4", 0x273, 0, 256*256*256)

ScoreAddresses = { Score1, Score2, Score3, Score4 }

AddressTable = {}
AddressTable[1] = BlockLocations

MainPlane = PuzzLearn.MemoryStructure.BuildAddressPlane(AddressTable, CursorX, -6, 6, CursorY, -1, 10, 1, 1)

tempColors = {}
tempColors[0] = 0xFF000000
tempColors[1] = 0xFFFFFFFF

PuzzLearn.NeuralNetwork.Database = PuzzLearn.MemoryStructure.BuildAddressDatabase({ MainPlane }, { ShapeAndOrientation }, ScoreAddresses, 0x1912, 80, tempColors)


PuzzLearn.NeuralNetwork.DisplayString = ""

-- Setting up the settings for a neural network

PuzzLearn.NeuralNetwork.StateName = "TetrisState.state"
PuzzLearn.NeuralNetwork.SessionFileName = "proofOfConceptV2_Pool.txt"
PuzzLearn.NeuralNetwork.PreviousGenerationFileName = "proofOfConceptV2_ArchivePool"
PuzzLearn.NeuralNetwork.ButtonNames = {
		"P1 A",
		"P1 B",
		"P1 Down",
		"P1 Left",
		"P1 Right",
	}

PuzzLearn.NeuralNetwork.InputCount = PuzzLearn.MemoryStructure.GetResultArrayLength(PuzzLearn.NeuralNetwork.Database)
PuzzLearn.NeuralNetwork.OutputCount = #PuzzLearn.NeuralNetwork.ButtonNames

-- Many values here taken from the orginal NEAT paper

PuzzLearn.NeuralNetwork.Population = 200
PuzzLearn.NeuralNetwork.DeltaDisjoint = 1.5
PuzzLearn.NeuralNetwork.DeltaExcess = 1.5
PuzzLearn.NeuralNetwork.DeltaWeights = 0.4
PuzzLearn.NeuralNetwork.DeltaThreshold = 1.0

PuzzLearn.NeuralNetwork.StaleSpeciesThreshold = 15
PuzzLearn.NeuralNetwork.CrossoverEnableChance = 0.25

PuzzLearn.NeuralNetwork.PointMutateChance = 0.25
PuzzLearn.NeuralNetwork.PerturbChance = 0.90
PuzzLearn.NeuralNetwork.CrossoverChance = 0.75
PuzzLearn.NeuralNetwork.LinkMutationChance = 2.0
PuzzLearn.NeuralNetwork.NodeMutationChance = 0.50
PuzzLearn.NeuralNetwork.StepSize = 0.1
PuzzLearn.NeuralNetwork.DisableMutationChance = 0.4
PuzzLearn.NeuralNetwork.EnableMutationChance = 0.2

PuzzLearn.NeuralNetwork.MaxTotalNodes = 500000
PuzzLearn.NeuralNetwork.FramesPerInputUpdate = 2
PuzzLearn.NeuralNetwork.FitnessTimeout = 2000
PuzzLearn.NeuralNetwork.TimeoutFrame = 18000

function PuzzLearn.NeuralNetwork.Sigmoid(x)
	return 2/(1 + math.exp(-4.9*x)) - 1
end



-- BASIC CONSTRUCTORS AND OBJECT FUNCTIONS
-- Builds a new gene pool.
function PuzzLearn.NeuralNetwork.BuildPool()
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

-- Retreives the next innovation number from the global gene pool and increments it.
function PuzzLearn.NeuralNetwork.GetNextInnovationNumber()
	PuzzLearn.NeuralNetwork.GenePool.GlobalInnovationNumber = PuzzLearn.NeuralNetwork.GenePool.GlobalInnovationNumber + 1
	return PuzzLearn.NeuralNetwork.GenePool.GlobalInnovationNumber
end

-- Builds a new link between nodes.
function PuzzLearn.NeuralNetwork.BuildLink(inNode, outNode, weight, enabled, innovationNumber)
	local link = {}
	link.InNode = inNode
	link.OutNode = outNode
	link.Weight = weight
	link.Enabled = enabled
	link.InnovationNumber = innovationNumber
	
	return link
end

-- Builds an identical, but seperate, link from the input.
function PuzzLearn.NeuralNetwork.CopyLink(link)
	return PuzzLearn.NeuralNetwork.BuildLink(link.InNode, link.OutNode, link.Weight, link.Enabled, link.InnovationNumber)
end

-- Builds a default node.
function PuzzLearn.NeuralNetwork.BuildNode()
	local node = {}
	node.InLinks = {}
	node.OutLinks = {}
	node.X = math.random(PuzzLearn.NeuralNetwork.NodeAreaStartX, PuzzLearn.NeuralNetwork.NodeAreaEndX)
	node.Y = math.random(PuzzLearn.NeuralNetwork.NodeAreaStartY, PuzzLearn.NeuralNetwork.NodeAreaEndY)
	node.Value = 0
	
	return node
end

-- Builds a default genome.
function PuzzLearn.NeuralNetwork.BuildGenome()
	local genome = {}
	genome.Links = {}
	genome.Fitness = 0
	genome.AdjustedFitness = 0
	genome.TopNode = PuzzLearn.NeuralNetwork.InputCount
	
	genome.Nodes = {}
	
	if PuzzLearn.NeuralNetwork.FixedNodeCoords == nil then
		for i = 1,PuzzLearn.NeuralNetwork.InputCount do
			genome.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
		end
		for i = PuzzLearn.NeuralNetwork.MaxTotalNodes + 1, PuzzLearn.NeuralNetwork.MaxTotalNodes + PuzzLearn.NeuralNetwork.OutputCount do
			genome.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
		end
	else
		for i = 1,PuzzLearn.NeuralNetwork.InputCount do
			genome.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
			genome.Nodes[i].X = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].X
			genome.Nodes[i].Y = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].Y
		end
		for i = PuzzLearn.NeuralNetwork.MaxTotalNodes + 1, PuzzLearn.NeuralNetwork.MaxTotalNodes + PuzzLearn.NeuralNetwork.OutputCount do
			genome.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
			genome.Nodes[i].X = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].X
			genome.Nodes[i].Y = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].Y
		end
	end
	
	local mRates = {}
	mRates.PointMutate = PuzzLearn.NeuralNetwork.PointMutateChance
	mRates.LinkMutate = PuzzLearn.NeuralNetwork.LinkMutationChance
	mRates.NodeMutate = PuzzLearn.NeuralNetwork.NodeMutationChance
	mRates.Step = PuzzLearn.NeuralNetwork.StepSize
	mRates.DisableMutate = PuzzLearn.NeuralNetwork.DisableMutationChance
	mRates.EnableMutate = PuzzLearn.NeuralNetwork.EnableMutationChance
	
	genome.MutatationRates = mRates
	
	return genome
end

-- Inserts a link into a genome.
function PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(genome, link)
	local i = genome.Nodes[link.InNode]
	local o = genome.Nodes[link.OutNode]
	table.insert(genome.Links, link)
	table.insert(i.OutLinks, link)
	table.insert(o.InLinks, link)
end

-- Copies a genome, creating an identical but seperate output.
function PuzzLearn.NeuralNetwork.DuplicateGenome(genome)
	local newGenome = PuzzLearn.NeuralNetwork.BuildGenome()
	newGenome.Fitness = genome.Fitness
	newGenome.AdjustedFitness = genome.AdjustedFitness
	for key,value in pairs(genome.MutatationRates) do
		newGenome.MutatationRates[key] = value
	end
	while newGenome.TopNode < genome.TopNode do
		PuzzLearn.NeuralNetwork.GetNextNode(newGenome, genome)
	end
	for i,link in ipairs(genome.Links) do
		local tempLink = PuzzLearn.NeuralNetwork.CopyLink(link)
		PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(newGenome, tempLink)
	end
	
	return newGenome
end

-- Gets the next node by incrementing the top node of a genome.
-- If the optional second input is set, it will copy the X and Y values of the next genome's equivalent nodes.
function PuzzLearn.NeuralNetwork.GetNextNode(genome, copyGenome)
	genome.TopNode = genome.TopNode + 1
	genome.Nodes[genome.TopNode] = PuzzLearn.NeuralNetwork.BuildNode()
	if copyGenome ~= nil then
		genome.Nodes[genome.TopNode].X = copyGenome.Nodes[genome.TopNode].X
		genome.Nodes[genome.TopNode].Y = copyGenome.Nodes[genome.TopNode].Y
	end
	return genome.TopNode
end

-- Sets the value for all nodes in a genome back to 0
function PuzzLearn.NeuralNetwork.ResetGenomeNodes(genome)
	for key,node in pairs(genome.Nodes) do
		node.Value = 0
	end
end

-- Builds a new species with its defining genome as the input genome.
function PuzzLearn.NeuralNetwork.BuildSpecies(genome)
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

-- Creates a new species based on a previous species.
function PuzzLearn.NeuralNetwork.DeriveSpecies(species)
	local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies()
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
-- Retrieves a random entry from a given table.
function PuzzLearn.NeuralNetwork.GetRandomEntry(links)
	return links[math.random(#links)]
end

-- Produces a random weight between -2 and 2.
function PuzzLearn.NeuralNetwork.GetRandomWeight()
	return 4*math.random() - 2
end

-- Returns a random value between -step and step.
function PuzzLearn.NeuralNetwork.GetRandomStep(step)
	return (2*math.random() - 1)*step
end

-- Mutates a given weight.
function PuzzLearn.NeuralNetwork.MutateWeight(weight, step)
	local p = math.random()
	if p < PuzzLearn.NeuralNetwork.PerturbChance then
		return weight + PuzzLearn.NeuralNetwork.GetRandomStep(step)
	else
		return PuzzLearn.NeuralNetwork.GetRandomWeight()
	end
end

-- Mutates a random link's weight.
function PuzzLearn.NeuralNetwork.PointMutate(genome)
	-- If no links are available (only possible early on), do nothing and return
	if #genome.Links == 0 then return end	
	
	local link = PuzzLearn.NeuralNetwork.GetRandomEntry(genome.Links)
	link.Weight = PuzzLearn.NeuralNetwork.MutateWeight(link.Weight, genome.MutatationRates.Step)
end

-- Adds a link between two random, valid nodes.
function PuzzLearn.NeuralNetwork.MutateLink(genome)
	local topHiddenNode = genome.TopNode
	-- First node is either an input or hidden node
	local node1 = math.random(1, topHiddenNode)
	-- Second node is either a hidden or output node
	-- The "+ PuzzLearn.NeuralNetwork.OutputCount" adds output nodes as an option
	local node2 = math.random(PuzzLearn.NeuralNetwork.InputCount + 1, topHiddenNode + PuzzLearn.NeuralNetwork.OutputCount)
	-- Convert output node values to the corresponding index
	if node2 > topHiddenNode then
		node2 = node2 - topHiddenNode + PuzzLearn.NeuralNetwork.MaxTotalNodes
	end
	
	local newLink = PuzzLearn.NeuralNetwork.BuildLink(node1, node2, PuzzLearn.NeuralNetwork.GetRandomWeight(), true, PuzzLearn.NeuralNetwork.GetNextInnovationNumber())
	PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(genome, newLink)
end

-- Adds a node with two links that replaces a random link.
-- Disables the repaced link.
function PuzzLearn.NeuralNetwork.MutateNode(genome)
	-- If no links are available (only possible early on),
	-- OR if the program has run long enough to max out the number of nodes,
	-- do nothing and return
	if #genome.Links == 0 or genome.TopNode >= PuzzLearn.NeuralNetwork.MaxTotalNodes then return end	

	local link = PuzzLearn.NeuralNetwork.GetRandomEntry(genome.Links)

	local inNodeID = link.InNode
	local outNodeID = link.OutNode
	
	local newNodeID = PuzzLearn.NeuralNetwork.GetNextNode(genome)
	
	local inLink = PuzzLearn.NeuralNetwork.BuildLink(inNodeID, newNodeID, 1, true, PuzzLearn.NeuralNetwork.GetNextInnovationNumber())
	local outLink = PuzzLearn.NeuralNetwork.BuildLink(newNodeID, outNodeID, link.Weight, link.Enabled, PuzzLearn.NeuralNetwork.GetNextInnovationNumber())
	
	PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(genome, inLink)
	PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(genome, outLink)
	
	link.Enabled = false
end



-- Sets one random link that is currently not the value of enable to the value of enable.
function PuzzLearn.NeuralNetwork.EnableOrDisable(genome, enable)
	local linkPool = {}
	for i,link in ipairs(genome.Links) do
		if link.Enabled ~= enable then
			table.insert(linkPool, link)
		end
	end
	
	if #linkPool == 0 then return end
	
	local link = PuzzLearn.NeuralNetwork.GetRandomEntry(linkPool)
	link.Enabled = enable
end

-- Randomly disables an enabled link.
function PuzzLearn.NeuralNetwork.MutateDisable(genome)
	PuzzLearn.NeuralNetwork.EnableOrDisable(genome, false)
end

-- Randomly enables a disabled link.
function PuzzLearn.NeuralNetwork.MutateEnable(genome)
	PuzzLearn.NeuralNetwork.EnableOrDisable(genome, true)
end

-- Generic function to run the given mutation function with the given probability.
-- If p > 1, the function is ran math.floor(p) times, then randomly one more based on the value after the decimal.
function PuzzLearn.NeuralNetwork.RunMutation(genome, key, mutateFunction)
	local p = genome.MutatationRates[key]
	local randomVal = math.random()
	while randomVal <= p do
		mutateFunction(genome)
		p = p - 1
	end
end

-- Mutates a genome.
function PuzzLearn.NeuralNetwork.MutateGenome(genome)
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
	
	PuzzLearn.NeuralNetwork.RunMutation(genome, "LinkMutate", PuzzLearn.NeuralNetwork.MutateLink)
	PuzzLearn.NeuralNetwork.RunMutation(genome, "NodeMutate", PuzzLearn.NeuralNetwork.MutateNode)
	PuzzLearn.NeuralNetwork.RunMutation(genome, "PointMutate", PuzzLearn.NeuralNetwork.PointMutate)
	PuzzLearn.NeuralNetwork.RunMutation(genome, "DisableMutate", PuzzLearn.NeuralNetwork.MutateDisable)
	PuzzLearn.NeuralNetwork.RunMutation(genome, "EnableMutate", PuzzLearn.NeuralNetwork.MutateEnable)
	
	genome.Fitness = 0
	genome.AdjustedFitness = 0
end



-- SPECIES AND GENE POOL FUNCTIONS
-- Creates a new 1st-generation genome, with few features.
function PuzzLearn.NeuralNetwork.CreateSimpleGenome()
	local genome = PuzzLearn.NeuralNetwork.BuildGenome()
	PuzzLearn.NeuralNetwork.MutateGenome(genome)
	
	return genome
end

-- Processes the necessary values used when determining if two genomes are the same species.
function PuzzLearn.NeuralNetwork.ProcessDisjointExcessAndWeightMean(genome1, genome2)
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

-- Checks if two genomes are the same species.
function PuzzLearn.NeuralNetwork.SameSpecies(genome1, genome2)
	if genome1 == genome2 then return true end
	local disjoint, excess, weight = PuzzLearn.NeuralNetwork.ProcessDisjointExcessAndWeightMean(genome1, genome2)
	return disjoint*PuzzLearn.NeuralNetwork.DeltaDisjoint + excess*PuzzLearn.NeuralNetwork.DeltaExcess + weight*PuzzLearn.NeuralNetwork.DeltaWeights < PuzzLearn.NeuralNetwork.DeltaThreshold
end

-- Adds a genome to an existing species or, if none can be found, creates a new species based on the genome.
function PuzzLearn.NeuralNetwork.AddToSpecies(genome)
	local speciesFound = false
	for i, species in ipairs(PuzzLearn.NeuralNetwork.GenePool.Species) do
		local same = PuzzLearn.NeuralNetwork.SameSpecies(genome, species.DefiningGenome)
		if same then
			table.insert(species.Genomes, genome)
			speciesFound = true
			break
		end
	end
	
	if not speciesFound then
		local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies(genome)
		table.insert(newSpecies.Genomes, genome)
		table.insert(PuzzLearn.NeuralNetwork.GenePool.Species, newSpecies)
	end
end

-- Calculates the adjusted fitness for a genome.
-- Adjusted fitness is fitness / number of genomes that share a species with it.
function PuzzLearn.NeuralNetwork.CalculateGenomeAdjustedFitness(genome)
	local numSharedSpecies = 0
	for i,species in ipairs(PuzzLearn.NeuralNetwork.GenePool.Species) do
		for j, subGenome in ipairs(species.Genomes) do
			if PuzzLearn.NeuralNetwork.SameSpecies(genome, subGenome) then
				numSharedSpecies = numSharedSpecies + 1
			end
		end
	end
	
	genome.AdjustedFitness = genome.Fitness / numSharedSpecies
end

-- Calculates the total adjusted fitness of a species.
function PuzzLearn.NeuralNetwork.CalculateSpeciesTotalAdjustedFitness(species)
	species.TotalAdjustedFitness = 0
	
	for i,genome in ipairs(species.Genomes) do
		PuzzLearn.NeuralNetwork.CalculateGenomeAdjustedFitness(genome)
		species.TotalAdjustedFitness = species.TotalAdjustedFitness + genome.AdjustedFitness
	end
end

-- Calculates the total adjusted fitness of the whole gene pool.
function PuzzLearn.NeuralNetwork.CalculatePoolTotalAdjustedFitness()
	PuzzLearn.NeuralNetwork.GenePool.TotalAdjustedFitness = 0
	
	for i,species in ipairs(PuzzLearn.NeuralNetwork.GenePool.Species) do
		PuzzLearn.NeuralNetwork.CalculateSpeciesTotalAdjustedFitness(species)
		PuzzLearn.NeuralNetwork.GenePool.TotalAdjustedFitness = PuzzLearn.NeuralNetwork.GenePool.TotalAdjustedFitness + species.TotalAdjustedFitness
	end
end

-- Creates a new gene pool containing simple genomes.
function PuzzLearn.NeuralNetwork.InitializePool()
	PuzzLearn.NeuralNetwork.GenePool = PuzzLearn.NeuralNetwork.BuildPool()
	
	for i = 1,PuzzLearn.NeuralNetwork.Population do
		local genome = PuzzLearn.NeuralNetwork.CreateSimpleGenome()
		PuzzLearn.NeuralNetwork.AddToSpecies(genome)
	end
end

-- Combines two selected genomes into a new genome.
function PuzzLearn.NeuralNetwork.GenomeCrossover(genome1, genome2)
	-- Makes sure that genome1 has a greater fitness than genome2
	if genome1.Fitness < genome2.Fitness then
		genome1, genome2 = genome2, genome1
	end
	
	local newGenome = PuzzLearn.NeuralNetwork.BuildGenome()

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
		PuzzLearn.NeuralNetwork.GetNextNode(newGenome, PuzzLearn.NeuralNetwork.CopyGenome)
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
			tempLink = PuzzLearn.NeuralNetwork.CopyLink(link1)
			i1 = i1 + 1
			if link1.InnovationNumber == link2.InnovationNumber then
				i2 = i2 + 1
			end
		else
			tempLink = PuzzLearn.NeuralNetwork.CopyLink(link2)
			i2 = i2 + 1
		end
		
		if not tempLink.Enabled and math.random() < PuzzLearn.NeuralNetwork.CrossoverEnableChance then
			tempLink.Enabled = true
		end
		
		PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(newGenome, tempLink)
	end
	
	-- Handle excess innovation numbers
	while i1 <= #genomeLinks1 do
		local tempLink = PuzzLearn.NeuralNetwork.CopyLink(genomeLinks1[i1])
		if not tempLink.Enabled and math.random() < PuzzLearn.NeuralNetwork.CrossoverEnableChance then
			tempLink.Enabled = true
		end
		i1 = i1 + 1
		PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(newGenome, tempLink)
	end
	while i2 <= #genomeLinks2 do
		local tempLink = PuzzLearn.NeuralNetwork.CopyLink(genomeLinks2[i2])
		if not tempLink.Enabled and math.random() < PuzzLearn.NeuralNetwork.CrossoverEnableChance then
			tempLink.Enabled = true
		end
		i2 = i2 + 1
		PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(newGenome, tempLink)
	end
	
	for key, value in pairs(genome1.MutatationRates) do
		newGenome.MutatationRates[key] = value
	end
	
	return newGenome
end

-- Creates a new child from a given species.
function PuzzLearn.NeuralNetwork.GetChild(species)
	local child
	if math.random() < PuzzLearn.NeuralNetwork.CrossoverChance then
		local genome1 = 
		species.Genomes[math.random(1, #species.Genomes)]
		local genome2 = species.Genomes[math.random(1, #species.Genomes)]
		child = PuzzLearn.NeuralNetwork.GenomeCrossover(genome1, genome2)
	else
		child = PuzzLearn.NeuralNetwork.DuplicateGenome(species.Genomes[math.random(1, #species.Genomes)])
	end
	
	PuzzLearn.NeuralNetwork.MutateGenome(child)
	
	return child
end

-- Removes the weaker 2/3 of genomes within each species
function PuzzLearn.NeuralNetwork.CullSpecies()
	local sortFunction = function(a,b)
		return a.Fitness > b.Fitness
	end
	
	for i, species in ipairs(PuzzLearn.NeuralNetwork.GenePool.Species) do	
		table.sort(species.Genomes, sortFunction)
		
		local remaining = math.ceil(#species.Genomes / 3)
		
		while #species.Genomes > remaining do
			table.remove(species.Genomes)
		end
	end
end

-- Removes genomes that are sufficiently less fit than the fittest genome of a species for each species.
function PuzzLearn.NeuralNetwork.CullUnfitFromSpecies()
	local sortFunction = function(a,b)
		return a.Fitness > b.Fitness
	end
	
	for i, species in ipairs(PuzzLearn.NeuralNetwork.GenePool.Species) do	
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

-- Removes species that have not advanced within a certain number of generations.
-- Excludes the species with the fittest genome.
function PuzzLearn.NeuralNetwork.RemoveStaleSpecies()
	local survivingSpecies = {}
	for i,species in ipairs(PuzzLearn.NeuralNetwork.GenePool.Species) do
		if species.StaleGenerations < PuzzLearn.NeuralNetwork.StaleSpeciesThreshold or species.TopFitness >= PuzzLearn.NeuralNetwork.GenePool.TopFitness then
			table.insert(survivingSpecies, species)
		end
	end
	PuzzLearn.NeuralNetwork.GenePool.Species = survivingSpecies
end

-- Creates a new generation of genomes from the gene pool.
function PuzzLearn.NeuralNetwork.NewGeneration()
	local genePool = PuzzLearn.NeuralNetwork.GenePool
	
	PuzzLearn.NeuralNetwork.RemoveStaleSpecies()
	PuzzLearn.NeuralNetwork.CullSpecies()
	PuzzLearn.NeuralNetwork.CalculatePoolTotalAdjustedFitness()
	
	-- Get populations for each species
	local speciesPopulations = {}
	local populationSum = 0
		
	-- Must include the event (possible early on, unlikely elsewhere) that genePool.TotalAdjustedFitness = 0
	if genePool.TotalAdjustedFitness == 0 then
		-- All species performed identically (no fitness)
		local populationResult = math.floor(PuzzLearn.NeuralNetwork.Population / #genePool.Species + 0.5)
		for i,species in ipairs(genePool.Species) do
			speciesPopulations[i] = populationResult
			populationSum = populationSum + populationResult
		end
	else
		local sortFunction = function(a,b)
			return a.TotalAdjustedFitness > b.TotalAdjustedFitness
		end
		
		table.sort(genePool.Species, sortFunction)
		
		local i = #genePool.Species
		while i >= 1 do
			local species = genePool.Species[i]
			local populationResult = math.floor(species.TotalAdjustedFitness / genePool.TotalAdjustedFitness * PuzzLearn.NeuralNetwork.Population + 0.5)
			if populationResult >= 2 then
				speciesPopulations[i] = populationResult
				populationSum = populationSum + populationResult
			else
				table.remove(genePool.Species, i)
				PuzzLearn.NeuralNetwork.CalculatePoolTotalAdjustedFitness()
				table.sort(genePool.Species, sortFunction)
			end
			i = i - 1
		end
	end
	-- Adjust for discrepency between populationSum and the desired population
	-- Largest population will be the least relatively affected by a change
	local popAdjustment = PuzzLearn.NeuralNetwork.Population - populationSum
	speciesPopulations[1] = speciesPopulations[1] + popAdjustment
	
	-- Breed for every species
	local newSpecies = {}
	local newGenomes = {}
	
	-- Sort species table by top fitness
	local topFitnessSort = function(a,b)
		return a.TopFitness > b.TopFitness
	end
	
	table.sort(genePool.Species, topFitnessSort)
	
	for i,species in pairs(genePool.Species) do
		local tempSpecies = PuzzLearn.NeuralNetwork.DeriveSpecies(species)
		table.insert(newSpecies, tempSpecies)
		-- Always insert the fittest genome from each species, for future breeding purposes
		table.insert(newGenomes, PuzzLearn.NeuralNetwork.DuplicateGenome(species.Genomes[1]))
		
		-- First, create half from the top half of the genomes in a species
		-- (found from earlier culling)
		for j = 2, math.ceil(speciesPopulations[i] / 2) do
			table.insert(newGenomes, PuzzLearn.NeuralNetwork.GetChild(species))
		end
	end
	
	-- Then, create half from only genomes close enough to the top fitness of each species
	PuzzLearn.NeuralNetwork.CullUnfitFromSpecies()
	
	for i,species in pairs(genePool.Species) do
		for j = math.ceil(speciesPopulations[i] / 2) + 1, speciesPopulations[i] do
			table.insert(newGenomes, PuzzLearn.NeuralNetwork.GetChild(species))
		end
	end
	
	-- Finally, readjust the pool	
	genePool.Species = newSpecies
	for i,genome in ipairs(newGenomes) do
		PuzzLearn.NeuralNetwork.AddToSpecies(genome)
	end
	
	genePool.Generation = genePool.Generation + 1
	genePool.CurrentSpecies = 1
	genePool.CurrentGenome = 1
	genePool.OverallGenome = 1
	genePool.TotalAdjustedFitness = 0
	genePool.TopSpecies = 1
	genePool.TopGenome = 1
end



-- FILE SAVE/LOAD FUNCTIONS
-- All lower-level functions assume a proper value has been stored in io.output/input

-- Saves the relevant information for an individual link.
function PuzzLearn.NeuralNetwork.SaveLinkAsText(link)
	local enabledNumber = 0
	if link.Enabled then enabledNumber = 1 end
	io.write(link.InNode, ",", link.OutNode, ",", link.Weight, ",", enabledNumber, ",", link.InnovationNumber, "\n")
end

-- Saves the relevant information for an individual genome, including all nodes and links.
function PuzzLearn.NeuralNetwork.SaveGenomeAsText(genome)	
	local mRates = genome.MutatationRates
	io.write(genome.Fitness, ",", genome.TopNode, "," )
	io.write(mRates.PointMutate, ",", mRates.LinkMutate, ",", mRates.NodeMutate, ",", mRates.Step, ",", mRates.DisableMutate, ",", mRates.EnableMutate, ",")
	io.write(#genome.Links, "\n")
	
	for i = PuzzLearn.NeuralNetwork.InputCount + 1, genome.TopNode do
		io.write(genome.Nodes[i].X, ",", genome.Nodes[i].Y, "\n")
	end

	for i,link in ipairs(genome.Links) do
		PuzzLearn.NeuralNetwork.SaveLinkAsText(link)
	end
end

-- Saves the relevant information for an individual species, including all genomes.
function PuzzLearn.NeuralNetwork.SaveSpeciesAsText(species)	
	local isStaleNumber = 0
	if species.IsStale then isStaleNumber = 1 end
	io.write(species.TopFitness, ",", species.TotalFitness, ",", species.StaleGenerations, ",", isStaleNumber, ",", #species.Genomes, "\n")
	
	PuzzLearn.NeuralNetwork.SaveGenomeAsText(species.DefiningGenome)
	for i,genome in ipairs(species.Genomes) do
		PuzzLearn.NeuralNetwork.SaveGenomeAsText(genome)
	end
end

-- Saves all data from a given pool.
function PuzzLearn.NeuralNetwork.SavePoolAsText(pool)
	io.write("V3", "\n")
	io.write(pool.Generation, ",", pool.GlobalInnovationNumber, ",", pool.CurrentSpecies, ",", pool.CurrentGenome, ",", pool.OverallGenome, ",",
			pool.TopFitness, ",", #pool.Species, ",", pool.TopSpecies, ",", pool.TopGenome, "\n")
	for i,species in ipairs(pool.Species) do
		PuzzLearn.NeuralNetwork.SaveSpeciesAsText(species)
	end
end

-- Saves the global gene pool at the given file name.
function PuzzLearn.NeuralNetwork.SaveFile(filename)
	local fileSave = io.open(filename, "w")
	io.output(fileSave)
	PuzzLearn.NeuralNetwork.SavePoolAsText(PuzzLearn.NeuralNetwork.GenePool)
	io.close(fileSave)
end


-- Lua does not have a split string function by default. This function simply splits a string.
function PuzzLearn.SplitString(str, sep)
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

-- Loads a link from the default input.
function PuzzLearn.NeuralNetwork.LoadLinkFromText()
	local splitLinkText = PuzzLearn.SplitString(io.read(), ",")
	return PuzzLearn.NeuralNetwork.BuildLink(tonumber(splitLinkText[1]), tonumber(splitLinkText[2]), tonumber(splitLinkText[3]), tonumber(splitLinkText[4]) == 1, tonumber(splitLinkText[5]))
end

-- Loads a genome from the default input, including all nodes and links.
function PuzzLearn.NeuralNetwork.LoadGenomeFromText()
	local genomeSplitText = PuzzLearn.SplitString(io.read(), ",")
	local newGenome = PuzzLearn.NeuralNetwork.BuildGenome()
	newGenome.Fitness = tonumber(genomeSplitText[1])
	newGenome.TopNode = tonumber(genomeSplitText[2])	
	newGenome.MutatationRates.PointMutate = tonumber(genomeSplitText[3])
	newGenome.MutatationRates.LinkMutate = tonumber(genomeSplitText[4])
	newGenome.MutatationRates.NodeMutate = tonumber(genomeSplitText[5])
	newGenome.MutatationRates.Step = tonumber(genomeSplitText[6])
	newGenome.MutatationRates.DisableMutate = tonumber(genomeSplitText[7])
	newGenome.MutatationRates.EnableMutate = tonumber(genomeSplitText[8])
	
	if saveFileVersion == 1 then
		for i = PuzzLearn.NeuralNetwork.InputCount + 1, newGenome.TopNode do
			newGenome.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
		end
	else
		for i = PuzzLearn.NeuralNetwork.InputCount + 1, newGenome.TopNode do
			newGenome.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
			local nodeSplitText = PuzzLearn.SplitString(io.read(), ",")
			newGenome.Nodes[i].X = tonumber(nodeSplitText[1])
			newGenome.Nodes[i].Y = tonumber(nodeSplitText[2])
		end
	end
	
	for i = 1, tonumber(genomeSplitText[9]) do
		local newLink = PuzzLearn.NeuralNetwork.LoadLinkFromText()
		PuzzLearn.NeuralNetwork.InsertLinkIntoGenome(newGenome, newLink)
	end
	
	return newGenome
end

-- Loads a species from the default IO, including all genomes.
function PuzzLearn.NeuralNetwork.LoadSpeciesFromText()
	local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies(nil)
	local speciesSplitText = PuzzLearn.SplitString(io.read(), ",")
	
	newSpecies.TopFitness = tonumber(speciesSplitText[1])
	newSpecies.TotalFitness = tonumber(speciesSplitText[2])
	newSpecies.StaleGenerations = tonumber(speciesSplitText[3])
	newSpecies.IsStale = tonumber(speciesSplitText[4]) == 1
	
	newSpecies.DefiningGenome = PuzzLearn.NeuralNetwork.LoadGenomeFromText()
	for i = 1, tonumber(speciesSplitText[5]) do
		table.insert(newSpecies.Genomes, PuzzLearn.NeuralNetwork.LoadGenomeFromText())
	end
	
	return newSpecies
end

-- Loads a gene pool from the default IO and sets the global gene pool to it.
function PuzzLearn.NeuralNetwork.LoadPoolFromText()
	local newPool = PuzzLearn.NeuralNetwork.BuildPool()
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
	local poolSplitText = PuzzLearn.SplitString(line, ",")
	
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
		table.insert(newPool.Species, PuzzLearn.NeuralNetwork.LoadSpeciesFromText())
	end
	
	PuzzLearn.NeuralNetwork.GenePool = newPool
end

-- Loads a given file to retrieve a gene pool.
-- Returns true if it succeeds, false otherwise.
function PuzzLearn.NeuralNetwork.LoadFile(filename)
	local readFile = io.open(filename, "r")
	if readFile ~= nil then
		io.input(readFile)
		if not pcall(PuzzLearn.NeuralNetwork.LoadPoolFromText) then
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

-- Sets the input nodes of the array.
function PuzzLearn.NeuralNetwork.ProcessInputNodes(genome, inputArray)
	for i = 1, #inputArray do
		if inputArray[i] == 1 then
			genome.Nodes[i].Value = 1
		end
	end
end

-- Processes an individual node within a genome.
function PuzzLearn.NeuralNetwork.ProcessNode(evalNode, genome)
	if #evalNode.InLinks > 0 then
		local valueSum = 0
		for linkID, link in ipairs(evalNode.InLinks) do
			if link.Enabled then
				local inNode = genome.Nodes[link.InNode]
				valueSum = valueSum + inNode.Value * link.Weight
			end
		end
		evalNode.Value = PuzzLearn.NeuralNetwork.Sigmoid(valueSum)
	end
end

-- Processes all nodes within a genome and retrieves outputs.
function PuzzLearn.NeuralNetwork.GetOutputs(genome, inputArray)	
	PuzzLearn.NeuralNetwork.ResetGenomeNodes(genome)
	PuzzLearn.NeuralNetwork.ProcessInputNodes(genome, inputArray)
	
	-- Run through the network 5 times to compensate for loops
	for i=1,5 do
		for j=PuzzLearn.NeuralNetwork.InputCount + 1, genome.TopNode do
			local evalNode = genome.Nodes[j]
			PuzzLearn.NeuralNetwork.ProcessNode(evalNode, genome)
		end
		
		for j=PuzzLearn.NeuralNetwork.MaxTotalNodes+1,PuzzLearn.NeuralNetwork.MaxTotalNodes+PuzzLearn.NeuralNetwork.OutputCount do
			local evalNode = genome.Nodes[j]
			PuzzLearn.NeuralNetwork.ProcessNode(evalNode, genome)
		end
	end
	
	local outputs = {}
	
	for i, name in ipairs(PuzzLearn.NeuralNetwork.ButtonNames) do
		if genome.Nodes[PuzzLearn.NeuralNetwork.MaxTotalNodes + i].Value > 0 then
			outputs[name] = true
		else
			outputs[name] = false
		end
	end
	
	-- On a typical controller, left and right cannot be pressed at the same time, nor can up and down.
	-- In certain games, doing so can lead to a crash.
	-- This removes that possibility.
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

-- Processes the given genome, loading a state and playing until a timer runs out or a failure state is reached,
-- then updates its score.
function PuzzLearn.NeuralNetwork.ProcessGenome(genome)
	local processed = false
	local maxFitness
	
	while not processed do
		if PuzzLearn.NeuralNetwork.FittestPending then
			PuzzLearn.NeuralNetwork.FittestPending = false
			if not PuzzLearn.NeuralNetwork.ShowingFittestGenome then
				PuzzLearn.NeuralNetwork.ShowingFittestGenome = true
				local newDisplayString = "Fittest: Species: " .. PuzzLearn.NeuralNetwork.GenePool.TopSpecies .. " | Genome: " .. PuzzLearn.NeuralNetwork.GenePool.TopGenome .. " | Fitness: " .. PuzzLearn.NeuralNetwork.GenePool.TopFitness
				forms.settext(PuzzLearn.NeuralNetwork.DisplayForm.Info, newDisplayString)
				
				PuzzLearn.NeuralNetwork.ProcessGenome(PuzzLearn.NeuralNetwork.GenePool.Species[PuzzLearn.NeuralNetwork.GenePool.TopSpecies].Genomes[PuzzLearn.NeuralNetwork.GenePool.TopGenome])
				
				forms.settext(PuzzLearn.NeuralNetwork.DisplayForm.Info, PuzzLearn.NeuralNetwork.DisplayString)
				PuzzLearn.NeuralNetwork.ShowingFittestGenome = false
			end
		end
		local ended = false
		local frameCount = 0
		local fitnessIncreaseFrame = 0
		maxFitness = 0
		savestate.load(PuzzLearn.NeuralNetwork.StateName)
		-- Code if bug where evalNode = nil keeps occuring
		--[[for j=PuzzLearn.NeuralNetwork.InputCount + 1, genome.TopNode do
			
			if not genome.Nodes[j] then
				genome.Nodes[j] = PuzzLearn.NeuralNetwork.BuildNode()
			end
		end--]]
		
		while not ended do
			if PuzzLearn.NeuralNetwork.TerminateLearning or PuzzLearn.MemoryStructure.RunEnded(PuzzLearn.NeuralNetwork.Database) then
				ended = true
				processed = true				
			elseif PuzzLearn.NeuralNetwork.FittestPending then
				ended = true
			else			
			currentFitness = PuzzLearn.MemoryStructure.ProcessScore(PuzzLearn.NeuralNetwork.Database)
				if currentFitness > maxFitness then
					maxFitness = currentFitness
					fitnessIncreaseFrame = 0
				end
				local outputs = PuzzLearn.NeuralNetwork.GetOutputs(genome, PuzzLearn.MemoryStructure.ProcessAddressDatabase(PuzzLearn.NeuralNetwork.Database))
				PuzzLearn.NeuralNetwork.UpdateFormImage(genome)
				
				for i=1,PuzzLearn.NeuralNetwork.FramesPerInputUpdate do
					joypad.set(outputs)
					emu.frameadvance()
				end
				frameCount = frameCount + PuzzLearn.NeuralNetwork.FramesPerInputUpdate
				fitnessIncreaseFrame = fitnessIncreaseFrame + PuzzLearn.NeuralNetwork.FramesPerInputUpdate
				
				if frameCount > PuzzLearn.NeuralNetwork.TimeoutFrame or fitnessIncreaseFrame > PuzzLearn.NeuralNetwork.FitnessTimeout then
					ended = true
					processed = true				
				end
			end
			
			coroutine.yield()
		end
	end
	if not PuzzLearn.NeuralNetwork.TerminateLearning then
		genome.Fitness = maxFitness
	end
end

-- Processes a whole species, starting at the genome marked by CurrentGenome.
function PuzzLearn.NeuralNetwork.ProcessSpecies(species)
	local genePool = PuzzLearn.NeuralNetwork.GenePool
	local displayStringFirstPart = "Generation: " .. genePool.Generation .. " | Species: " .. genePool.CurrentSpecies .. " | Genome: "
	
	while not PuzzLearn.NeuralNetwork.TerminateLearning and genePool.CurrentGenome <= #species.Genomes do
		local i = genePool.CurrentGenome
		local genome = species.Genomes[i]
		
		PuzzLearn.NeuralNetwork.DisplayString = displayStringFirstPart .. genePool.CurrentGenome .. " | Overall: " .. genePool.OverallGenome .. " | Top fitness: " .. genePool.TopFitness
		-- Bug test code
		-- PuzzLearn.NeuralNetwork.DisplayString = PuzzLearn.NeuralNetwork.DisplayString .. " " .. genePool.TopSpecies .. " " .. genePool.TopGenome
		forms.settext(PuzzLearn.NeuralNetwork.DisplayForm.Info, PuzzLearn.NeuralNetwork.DisplayString)
		
		PuzzLearn.NeuralNetwork.ProcessGenome(genome)
		
		if not PuzzLearn.NeuralNetwork.TerminateLearning then
			species.TotalFitness = species.TotalFitness + genome.Fitness
			
			if genome.Fitness > species.TopFitness then
				species.TopFitness = genome.Fitness
				species.StaleGenerations = 0
				species.IsStale = false
				
				if species.TopFitness > genePool.TopFitness then
					genePool.TopFitness = species.TopFitness
					genePool.TopSpecies = genePool.CurrentSpecies
					genePool.TopGenome = genePool.CurrentGenome
				end
			end
			
			genePool.CurrentGenome = genePool.CurrentGenome + 1
			genePool.OverallGenome = genePool.OverallGenome + 1
			
			PuzzLearn.NeuralNetwork.SaveFile(PuzzLearn.NeuralNetwork.SessionFileName)
		end
	end
	
	if species.IsStale then species.StaleGenerations = species.StaleGenerations + 1 end
end

-- Processes the entire gene pool, starting at the species marked by CurrentSpecies.
function PuzzLearn.NeuralNetwork.ProcessPool()
	local genePool = PuzzLearn.NeuralNetwork.GenePool
	while not PuzzLearn.NeuralNetwork.TerminateLearning and genePool.CurrentSpecies <= #genePool.Species do
		local species = genePool.Species[genePool.CurrentSpecies]
		PuzzLearn.NeuralNetwork.ProcessSpecies(species)
		
		genePool.CurrentGenome = 1		
		genePool.CurrentSpecies = genePool.CurrentSpecies + 1
	end
end

-- Continually processes the gene pool, producing new generations when it is done processing.
function PuzzLearn.NeuralNetwork.ProcessGenerations()
	PuzzLearn.NeuralNetwork.TerminateLearning = false
	while true do
		PuzzLearn.NeuralNetwork.ProcessPool()
		if not PuzzLearn.NeuralNetwork.TerminateLearning then
			PuzzLearn.NeuralNetwork.SaveFile(PuzzLearn.NeuralNetwork.PreviousGenerationFileName .. PuzzLearn.NeuralNetwork.GenePool.Generation .. ".txt")
			PuzzLearn.NeuralNetwork.SaveFile(PuzzLearn.NeuralNetwork.PreviousGenerationFileName .. ".txt")
			PuzzLearn.NeuralNetwork.NewGeneration()
		else
			break
		end
	end
end

-- FORM DISPLAY FUNCTIONS

-- Creates the neural network display form.
function PuzzLearn.NeuralNetwork.CreateDisplayForm()
	if PuzzLearn.NeuralNetwork.DisplayForm ~= nil then
		forms.destroy(PuzzLearn.NeuralNetwork.DisplayForm.Form)
		PuzzLearn.NeuralNetwork.DisplayForm = nil
	end

	-- Defines button functions.
	local function fittestButtonFunction()
		PuzzLearn.NeuralNetwork.FittestPending = true
	end

	local function displayFormCloseFunction()
		PuzzLearn.NeuralNetwork.TerminateLearning = true
		forms.destroy(PuzzLearn.NeuralNetwork.DisplayForm.Form)
	end

	local function backButtonFunction()
		PuzzLearn.NeuralNetwork.TerminateLearning = true
		forms.destroy(PuzzLearn.NeuralNetwork.DisplayForm.Form)
	end

	-- Finds widths and heights to calculate the desired width and height of the window.
	local widths = {}
	local heights = {}
	for i,plane in ipairs(PuzzLearn.NeuralNetwork.Database.AddressPlanes) do
		table.insert(widths, plane.XMax - plane.XMin + 1)
		table.insert(heights, plane.YMax - plane.YMin + 1)
	end
	
	for i,address in ipairs(PuzzLearn.NeuralNetwork.Database.InfoAddresses) do
		table.insert(widths, address.MaxValue)
		table.insert(heights, 1)	
	end
	
	local gridWidth = math.max(unpack(widths))
	local gridHeight = 1
	for i, v in ipairs(heights) do
		gridHeight = gridHeight + v + 1
	end
	
	-- Input node width + buffer + hidden node width + buffer + output node width (same width as buffer + text area of essentially arbitrary length)
	local picWidth = PuzzLearn.NeuralNetwork.FormGridSize*gridWidth + 3*PuzzLearn.NeuralNetwork.FormGridSize + PuzzLearn.NeuralNetwork.NodeAreaWidth + 70
	local picHeight = PuzzLearn.NeuralNetwork.FormGridSize*gridHeight
	PuzzLearn.NeuralNetwork.NodeAreaHeight = math.max(picHeight, PuzzLearn.NeuralNetwork.NodeAreaHeight, PuzzLearn.NeuralNetwork.OutputCount * PuzzLearn.NeuralNetwork.FormGridSize)
	picHeight = PuzzLearn.NeuralNetwork.NodeAreaHeight
	-- Width = buffer + picture box width + buffer + constant value 16 that fixes weird unexplained size mishaps
	-- Height = buffer + picture box height + buffer + text label height (22) + button height (21) + buffer + size fixing constant (39)
	local formWidth = picWidth + 2*PuzzLearn.NeuralNetwork.FormGridSize + 16
	if formWidth < 450 then formWidth = 450 end
	local formHeight = picHeight + 3*PuzzLearn.NeuralNetwork.FormGridSize + 82
	
	local newFormHandle = forms.newform(formWidth, formHeight, "Network Display", displayFormCloseFunction)
	local pictureBoxHandle = forms.pictureBox(newFormHandle, PuzzLearn.NeuralNetwork.FormGridSize, PuzzLearn.NeuralNetwork.FormGridSize, picWidth, picHeight)
	
	local nextY = PuzzLearn.NeuralNetwork.FormGridSize * 2 + picHeight
	local displayInformation = forms.label(newFormHandle, "Waiting for input", PuzzLearn.NeuralNetwork.FormGridSize, nextY, 400, 22)
	nextY = nextY + 22
	local fittestButton = forms.button(newFormHandle, "Fittest", fittestButtonFunction, PuzzLearn.NeuralNetwork.FormGridSize, nextY)
	local backButton = forms.button(newFormHandle, "Back", backButtonFunction, PuzzLearn.NeuralNetwork.FormGridSize + 92, nextY)
	
	PuzzLearn.NeuralNetwork.DisplayForm = {}
	PuzzLearn.NeuralNetwork.DisplayForm.Form = newFormHandle
	PuzzLearn.NeuralNetwork.DisplayForm.Picture = pictureBoxHandle
	PuzzLearn.NeuralNetwork.DisplayForm.Width = formWidth
	PuzzLearn.NeuralNetwork.DisplayForm.Height = formHeight
	PuzzLearn.NeuralNetwork.DisplayForm.GridWidth = gridWidth
	PuzzLearn.NeuralNetwork.DisplayForm.GridHeight = gridHeight
	PuzzLearn.NeuralNetwork.DisplayForm.Info = displayInformation
	PuzzLearn.NeuralNetwork.DisplayForm.FittestButton = fittestButton
	PuzzLearn.NeuralNetwork.DisplayForm.BackButton = backButton
	
	PuzzLearn.NeuralNetwork.NodeAreaStartX = gridWidth * PuzzLearn.NeuralNetwork.FormGridSize + PuzzLearn.NeuralNetwork.FormGridSize + 1
	PuzzLearn.NeuralNetwork.NodeAreaEndX = PuzzLearn.NeuralNetwork.NodeAreaStartX + PuzzLearn.NeuralNetwork.NodeAreaWidth - PuzzLearn.NeuralNetwork.FormGridSize
	PuzzLearn.NeuralNetwork.NodeAreaEndY = PuzzLearn.NeuralNetwork.NodeAreaHeight - PuzzLearn.NeuralNetwork.FormGridSize
	
	-- Set vales for fixed node coordinates (inputs and outputs)
	PuzzLearn.NeuralNetwork.FixedNodeCoords = {}
	local yDraw = 0
	local rectSize = PuzzLearn.NeuralNetwork.FormGridSize - 1
	local nodeNumber = 1
	
	for i, addressPlane in ipairs(PuzzLearn.NeuralNetwork.Database.AddressPlanes) do
		local processedTable, tableWidth, tableHeight = PuzzLearn.MemoryStructure.ProcessAddressPlane(addressPlane)
		local startingPoint = gridWidth - tableWidth - 1
		for y = 1, tableHeight, 1 do
			for x = 1, tableWidth, 1 do
				local rectCornerX = (startingPoint + x) * PuzzLearn.NeuralNetwork.FormGridSize
				for j = 1, addressPlane.MaxValue do
					PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber] = {}
					PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber].X = rectCornerX
					PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber].Y = yDraw
					nodeNumber = nodeNumber + 1
				end
			end
			yDraw = yDraw + PuzzLearn.NeuralNetwork.FormGridSize
		end
		yDraw = yDraw + PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	for i, infoAddress in ipairs(PuzzLearn.NeuralNetwork.Database.InfoAddresses) do
		local infoArray = {}
		PuzzLearn.MemoryStructure.AddInfoAddressToResultArray(infoAddress, infoArray)
		
		local startingPoint = gridWidth - #infoArray - 1
		
		for i = 1, #infoArray, 1 do
			PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber] = {}
			PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber].X = (startingPoint + i) * PuzzLearn.NeuralNetwork.FormGridSize
			PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber].Y = yDraw
			nodeNumber = nodeNumber + 1
		end
		
		yDraw = yDraw + 2 * PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber] = {}
	PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber].X = (gridWidth - 1) * PuzzLearn.NeuralNetwork.FormGridSize
	PuzzLearn.NeuralNetwork.FixedNodeCoords[nodeNumber].Y = yDraw
	nodeNumber = nodeNumber + 1
	
	local outputNodeX = PuzzLearn.NeuralNetwork.NodeAreaEndX + 2 * PuzzLearn.NeuralNetwork.FormGridSize
	local outputNodeY = math.ceil((PuzzLearn.NeuralNetwork.NodeAreaHeight - PuzzLearn.NeuralNetwork.OutputCount * PuzzLearn.NeuralNetwork.FormGridSize)/ 2)
	for i = PuzzLearn.NeuralNetwork.MaxTotalNodes + 1, PuzzLearn.NeuralNetwork.MaxTotalNodes + PuzzLearn.NeuralNetwork.OutputCount do
		PuzzLearn.NeuralNetwork.FixedNodeCoords[i] = {}
		PuzzLearn.NeuralNetwork.FixedNodeCoords[i].X = outputNodeX
		PuzzLearn.NeuralNetwork.FixedNodeCoords[i].Y = outputNodeY
		outputNodeY = outputNodeY + PuzzLearn.NeuralNetwork.FormGridSize
	end
end

-- Updates the display form for the given genome based on the game's current state.
function PuzzLearn.NeuralNetwork.UpdateFormImage(genome)
	-- Draw nodes
	forms.clear(PuzzLearn.NeuralNetwork.DisplayForm.Picture, 0xFFF0F0F0)
	local picture = PuzzLearn.NeuralNetwork.DisplayForm.Picture
	local gridWidth = PuzzLearn.NeuralNetwork.DisplayForm.GridWidth
	local gridHeight = PuzzLearn.NeuralNetwork.DisplayForm.GridHeight
	local yDraw = 0
	local black = 0xFF000000
	local white = 0xFFFFFFFF
	local translBlack = 0x22000000
	local translWhite = 0x22FFFFFF
	local rectSize = PuzzLearn.NeuralNetwork.FormGridSize - 1
	
	for i, addressPlane in ipairs(PuzzLearn.NeuralNetwork.Database.AddressPlanes) do
		local processedTable, tableWidth, tableHeight = PuzzLearn.MemoryStructure.ProcessAddressPlane(addressPlane)
		local startingPoint = gridWidth - tableWidth - 1
		for y = 1, tableHeight, 1 do
			for x = 1, tableWidth, 1 do
				local rectCornerX = (startingPoint + x) * PuzzLearn.NeuralNetwork.FormGridSize				
				forms.drawRectangle(picture, rectCornerX, yDraw, rectSize, rectSize, black, PuzzLearn.NeuralNetwork.Database.ValueColors[processedTable[x][y]])
			end
			yDraw = yDraw + PuzzLearn.NeuralNetwork.FormGridSize
		end
		yDraw = yDraw + PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	for i, infoAddress in ipairs(PuzzLearn.NeuralNetwork.Database.InfoAddresses) do
		local infoArray = {}
		PuzzLearn.MemoryStructure.AddInfoAddressToResultArray(infoAddress, infoArray)
		
		local startingPoint = gridWidth - #infoArray - 1
		
		for i = 1, #infoArray, 1 do
			local color = black
			if infoArray[i] == 1 then color = white end
			
			forms.drawRectangle(picture, (startingPoint + i) * PuzzLearn.NeuralNetwork.FormGridSize, yDraw, rectSize, rectSize, black, color)
		end
		
		yDraw = yDraw + 2 * PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	forms.drawRectangle(picture, (gridWidth - 1) * PuzzLearn.NeuralNetwork.FormGridSize, yDraw, rectSize, rectSize, black, white)
	
	for i = PuzzLearn.NeuralNetwork.InputCount + 1, genome.TopNode do
		local node = genome.Nodes[i]
		local border = black
		local fill = white
		if node.Value <= 0 then
			border = translBlack
			fill = translBlack
		end
		
		forms.drawRectangle(picture, node.X, node.Y, rectSize, rectSize, border, fill)
	end
	
	local outputNodeX = PuzzLearn.NeuralNetwork.NodeAreaEndX + 2 * PuzzLearn.NeuralNetwork.FormGridSize
	local outputTextX = outputNodeX + PuzzLearn.NeuralNetwork.FormGridSize + 2
	local outputNodeY = math.ceil((PuzzLearn.NeuralNetwork.NodeAreaHeight - PuzzLearn.NeuralNetwork.OutputCount * PuzzLearn.NeuralNetwork.FormGridSize)/ 2)
	for i = 1, PuzzLearn.NeuralNetwork.OutputCount do
		local outputNode = genome.Nodes[PuzzLearn.NeuralNetwork.MaxTotalNodes + i]
		local color = white
		if outputNode.Value <= 0 then
			color = black
		end
		
		forms.drawRectangle(picture, outputNodeX, outputNodeY, rectSize, rectSize, black, color)
		forms.drawText(picture, outputTextX, outputNodeY, PuzzLearn.NeuralNetwork.ButtonNames[i], black, 0x00000000, PuzzLearn.NeuralNetwork.FormGridSize)
		
		outputNodeY = outputNodeY + PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	-- Draw links (must be done afterwards in order to have all links drawn above nodes)
	local centerAdjust = math.ceil(PuzzLearn.NeuralNetwork.FormGridSize / 2)
	local lPosOn = 0xAA00FF00
	local lPosOff = 0x2200FF00
	local lNegOn = 0xAAFF0000
	local lNegOff = 0x22FF0000
	
	for i = 1, genome.TopNode do
		local drawNode = genome.Nodes[i]
		local startX = drawNode.X + PuzzLearn.NeuralNetwork.FormGridSize - 1
		if i <= PuzzLearn.NeuralNetwork.InputCount then
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