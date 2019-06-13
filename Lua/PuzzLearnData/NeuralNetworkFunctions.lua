dofile("PuzzLearnData\\ReadMemoryStructure.lua")

PuzzLearn.NeuralNetwork = {}

PuzzLearn.NeuralNetwork.FormGridSize = 10


PuzzLearn.NeuralNetwork.NodeAreaWidth = 300
PuzzLearn.NeuralNetwork.NodeAreaHeight = 200
PuzzLearn.NeuralNetwork.NodeAreaStartX = 1
PuzzLearn.NeuralNetwork.NodeAreaStartY = 1
PuzzLearn.NeuralNetwork.NodeAreaEndX = PuzzLearn.NeuralNetwork.NodeAreaWidth - PuzzLearn.NeuralNetwork.FormGridSize
PuzzLearn.NeuralNetwork.NodeAreaEndY = PuzzLearn.NeuralNetwork.NodeAreaHeight - PuzzLearn.NeuralNetwork.FormGridSize


PuzzLearn.NeuralNetwork.DisplayString = ""

-- Setting up the settings for a neural network

PuzzLearn.NeuralNetwork.ArchiveLocation = ""
PuzzLearn.NeuralNetwork.StateName = ""
PuzzLearn.NeuralNetwork.SessionFileName = ""
PuzzLearn.NeuralNetwork.ConfigFile = ""

PuzzLearn.NeuralNetwork.Population = 200
PuzzLearn.NeuralNetwork.FitnessTimeout = 2000
PuzzLearn.NeuralNetwork.TimeoutFrame = 18000
PuzzLearn.NeuralNetwork.StagnantSpeciesThreshold = 15

PuzzLearn.NeuralNetwork.DisjointCoefficient = 1.0
PuzzLearn.NeuralNetwork.ExcessCoefficient = 1.0
PuzzLearn.NeuralNetwork.WeightCoefficient = 0.4
PuzzLearn.NeuralNetwork.CompatibilityThreshold = 3.0

PuzzLearn.NeuralNetwork.MutateWeightChance = 0.80
PuzzLearn.NeuralNetwork.PerturbChance = 0.90
PuzzLearn.NeuralNetwork.CrossoverChance = 0.75
PuzzLearn.NeuralNetwork.CrossoverEnableChance = 0.25
PuzzLearn.NeuralNetwork.MutateLinkChance = 1
PuzzLearn.NeuralNetwork.MutateNodeChance = 0.25

PuzzLearn.NeuralNetwork.MaxTotalNodes = 500000


function PuzzLearn.NeuralNetwork.SigmoidalTransferFunction(x)
	return 2/(1 + math.exp(-4.9*x)) - 1
end



-- BASIC CONSTRUCTORS AND OBJECT FUNCTIONS
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
	node.Value = 0
	node.X = math.random(PuzzLearn.NeuralNetwork.NodeAreaStartX, PuzzLearn.NeuralNetwork.NodeAreaEndX)
	node.Y = math.random(PuzzLearn.NeuralNetwork.NodeAreaStartY, PuzzLearn.NeuralNetwork.NodeAreaEndY)
	
	return node
end

-- Builds a default network.
function PuzzLearn.NeuralNetwork.BuildNetwork()
	local network = {}
	network.Links = {}
	network.Fitness = 0
	network.AdjustedFitness = 0
	network.TopNode = PuzzLearn.NeuralNetwork.InputCount
	
	network.Nodes = {}
	
	if PuzzLearn.NeuralNetwork.FixedNodeCoords == nil then
		for i = 1,PuzzLearn.NeuralNetwork.InputCount do
			network.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
		end
		for i = PuzzLearn.NeuralNetwork.MaxTotalNodes + 1, PuzzLearn.NeuralNetwork.MaxTotalNodes + PuzzLearn.NeuralNetwork.OutputCount do
			network.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
		end
	else
		for i = 1,PuzzLearn.NeuralNetwork.InputCount do
			network.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
			network.Nodes[i].X = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].X
			network.Nodes[i].Y = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].Y
		end
		for i = PuzzLearn.NeuralNetwork.MaxTotalNodes + 1, PuzzLearn.NeuralNetwork.MaxTotalNodes + PuzzLearn.NeuralNetwork.OutputCount do
			network.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
			network.Nodes[i].X = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].X
			network.Nodes[i].Y = PuzzLearn.NeuralNetwork.FixedNodeCoords[i].Y
		end
	end
	
	return network
end

-- Inserts a link into a network.
function PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(network, link)
	local i = network.Nodes[link.InNode]
	local o = network.Nodes[link.OutNode]
	table.insert(network.Links, link)
	table.insert(i.OutLinks, link)
	table.insert(o.InLinks, link)
end

-- Copies a network, creating an identical but seperate output.
function PuzzLearn.NeuralNetwork.DuplicateNetwork(network)
	local newNetwork = PuzzLearn.NeuralNetwork.BuildNetwork()
	newNetwork.Fitness = network.Fitness
	newNetwork.AdjustedFitness = network.AdjustedFitness
	while newNetwork.TopNode < network.TopNode do
		PuzzLearn.NeuralNetwork.GetNextNode(newNetwork, network)
	end
	for i,link in ipairs(network.Links) do
		local tempLink = PuzzLearn.NeuralNetwork.CopyLink(link)
		PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(newNetwork, tempLink)
	end
	
	return newNetwork
end

-- Gets the next node by incrementing the top node of a network.
-- If the optional second input is set, it will copy the X and Y values of the next network's equivalent nodes.
function PuzzLearn.NeuralNetwork.GetNextNode(network, copyNetwork)
	network.TopNode = network.TopNode + 1
	network.Nodes[network.TopNode] = PuzzLearn.NeuralNetwork.BuildNode()
	if copyNetwork ~= nil then
		network.Nodes[network.TopNode].X = copyNetwork.Nodes[network.TopNode].X
		network.Nodes[network.TopNode].Y = copyNetwork.Nodes[network.TopNode].Y
	end
	return network.TopNode
end

-- Sets the value for all nodes in a network back to 0
function PuzzLearn.NeuralNetwork.ResetNetworkNodes(network)
	for key,node in pairs(network.Nodes) do
		node.Value = 0
	end
end

-- Builds a new species with its defining network as the input network.
function PuzzLearn.NeuralNetwork.BuildSpecies(network)
	local species = {}
	species.DefiningNetwork = network
	species.Networks = {}
	species.TopFitness = 0
	species.TotalFitness = 0
	species.TotalAdjustedFitness = 0
	species.StagnantGenerations = 0
	species.IsStagnant = true
	
	return species
end

-- Creates a new species based on a previous species.
function PuzzLearn.NeuralNetwork.DeriveSpecies(species)
	local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies()
	newSpecies.TopFitness = species.TopFitness
	newSpecies.StagnantGenerations = species.StagnantGenerations
	if #species.Networks < 1 then
		newSpecies.DefiningNetwork = species.DefiningNetwork
	else
		newSpecies.DefiningNetwork = species.Networks[math.random(1,#species.Networks)]
	end
	
	return newSpecies
end

-- Builds a new network pool.
function PuzzLearn.NeuralNetwork.BuildNetworkPool()
	local pool = {}
	pool.Species = {}
	pool.GlobalInnovationNumber = 0
	pool.Generation = 1
	pool.CurrentSpecies = 1
	pool.CurrentNetwork = 1
	pool.OverallNetwork = 1
	pool.TopFitness = 0
	pool.TopSpecies = 1
	pool.TopNetwork = 1
	pool.TotalAdjustedFitness = 0
	
	return pool
end

-- Retreives the next innovation number from the global network pool and increments it.
function PuzzLearn.NeuralNetwork.GetNextInnovationNumber()
	PuzzLearn.NeuralNetwork.NetworkPool.GlobalInnovationNumber = PuzzLearn.NeuralNetwork.NetworkPool.GlobalInnovationNumber + 1
	return PuzzLearn.NeuralNetwork.NetworkPool.GlobalInnovationNumber
end



-- MUTATION RELATED FUNCTIONS
-- Retrieves a random entry from a given table.
function PuzzLearn.NeuralNetwork.GetRandomEntry(tbl)
	return tbl[math.random(#tbl)]
end

-- Produces a random weight between -1 and 1.
function PuzzLearn.NeuralNetwork.GetRandomWeight()
	return 2*math.random() - 1
end

-- Mutates a given weight.
function PuzzLearn.NeuralNetwork.MutateWeight(weight)
	local p = math.random()
	if p < PuzzLearn.NeuralNetwork.PerturbChance then
		return weight + 0.2*math.random() - 0.1
	else
		return PuzzLearn.NeuralNetwork.GetRandomWeight()
	end
end

-- Mutates every link in the network's weight.
function PuzzLearn.NeuralNetwork.MutateWeights(network)
	for i, link in ipairs(network.Links) do
		link.Weight = PuzzLearn.NeuralNetwork.MutateWeight(link.Weight)
	end
end

-- Adds a link between two random, valid nodes.
function PuzzLearn.NeuralNetwork.MutateLink(network)
	local topHiddenNode = network.TopNode
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
	PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(network, newLink)
end

-- Adds a node with two links that replaces a random link.
-- Disables the replaced link.
function PuzzLearn.NeuralNetwork.MutateNode(network)
	-- If the program has run long enough to max out the number of nodes,
	-- do nothing and return
	if network.TopNode >= PuzzLearn.NeuralNetwork.MaxTotalNodes then return end	

	local link = PuzzLearn.NeuralNetwork.GetRandomEntry(network.Links)

	local inNodeID = link.InNode
	local outNodeID = link.OutNode
	
	local newNodeID = PuzzLearn.NeuralNetwork.GetNextNode(network)
	
	local inLink = PuzzLearn.NeuralNetwork.BuildLink(inNodeID, newNodeID, 1, true, PuzzLearn.NeuralNetwork.GetNextInnovationNumber())
	local outLink = PuzzLearn.NeuralNetwork.BuildLink(newNodeID, outNodeID, link.Weight, link.Enabled, PuzzLearn.NeuralNetwork.GetNextInnovationNumber())
	
	PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(network, inLink)
	PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(network, outLink)
	
	link.Enabled = false
end

-- Generic function to run the given mutation function with the given probability.
function PuzzLearn.NeuralNetwork.RunMutation(network, prob, mutateFunction)
	if math.random() <= prob then
		mutateFunction(network)
	end
end

-- Mutates a network.
function PuzzLearn.NeuralNetwork.MutateNetwork(network)
	PuzzLearn.NeuralNetwork.RunMutation(network, PuzzLearn.NeuralNetwork.MutateNodeChance, PuzzLearn.NeuralNetwork.MutateNode)
	PuzzLearn.NeuralNetwork.RunMutation(network, PuzzLearn.NeuralNetwork.MutateWeightChance, PuzzLearn.NeuralNetwork.MutateWeights)
	PuzzLearn.NeuralNetwork.RunMutation(network, PuzzLearn.NeuralNetwork.MutateLinkChance, PuzzLearn.NeuralNetwork.MutateLink)
	
	network.Fitness = 0
	network.AdjustedFitness = 0
end



-- SPECIES AND NETWORK POOL FUNCTIONS
-- Creates a new 1st-generation network, with few features.
function PuzzLearn.NeuralNetwork.CreateSimpleNetwork()
	local network = PuzzLearn.NeuralNetwork.BuildNetwork()
	
	PuzzLearn.NeuralNetwork.MutateLink(network)
	PuzzLearn.NeuralNetwork.MutateLink(network)
	
	return network
end

-- Processes the necessary values used when determining if two networks are the same species.
function PuzzLearn.NeuralNetwork.ProcessDisjointExcessAndWeightMean(network1, network2)
	-- Double-check that both networks have their links ordered from lowest innovation to highest
	-- (Should happen by default, but there may be edge cases I haven't considered)
	local sortFunction = function(a,b)
		return a.InnovationNumber < b.InnovationNumber
	end
	
	local networkLinks1 = network1.Links
	local networkLinks2 = network2.Links
	table.sort(networkLinks1, sortFunction)
	table.sort(networkLinks2, sortFunction)
	
	local sharedCount = 0
	local disjointCount = 0
	local sumOfWeightDifferences = 0
	
	local i1, i2 = 1, 1
	while i1 <= #networkLinks1 and i2 <= #networkLinks2 do
		local link1 = networkLinks1[i1]
		local link2 = networkLinks2[i2]
		
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
	while i1 <= #networkLinks1 do
		excessCount =  excessCount + 1
		i1 = i1 + 1
	end
	while i2 <= #networkLinks2 do
		excessCount =  excessCount + 1
		i2 = i2 + 1
	end
	
	local maxLinkCount = math.max(#network1.Links, #network2.Links)
	
	local weightMean = 999999999999
	if sharedCount ~= 0 then weightMean = sumOfWeightDifferences / sharedCount end
	
	return disjointCount / maxLinkCount, excessCount / maxLinkCount, weightMean
end

-- Checks if two networks are the same species.
function PuzzLearn.NeuralNetwork.SameSpeciesCheck(network1, network2)
	if network1 == network2 then return true end
	local disjoint, excess, weight = PuzzLearn.NeuralNetwork.ProcessDisjointExcessAndWeightMean(network1, network2)
	return disjoint*PuzzLearn.NeuralNetwork.DisjointCoefficient + excess*PuzzLearn.NeuralNetwork.ExcessCoefficient + weight*PuzzLearn.NeuralNetwork.WeightCoefficient < PuzzLearn.NeuralNetwork.CompatibilityThreshold
end

-- Adds a network to an existing species or, if none can be found, creates a new species based on the network.
function PuzzLearn.NeuralNetwork.AddNetworkToSpecies(network)
	local sorted = false
	for i, species in ipairs(PuzzLearn.NeuralNetwork.NetworkPool.Species) do
		local same = PuzzLearn.NeuralNetwork.SameSpeciesCheck(network, species.DefiningNetwork)
		if same then
			table.insert(species.Networks, network)
			sorted = true
			break
		end
	end
	
	if not sorted then
		local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies(network)
		table.insert(newSpecies.Networks, network)
		table.insert(PuzzLearn.NeuralNetwork.NetworkPool.Species, newSpecies)
	end
end

-- Calculates the adjusted fitness for a network.
-- Adjusted fitness is fitness / number of networks that share a species with it.
function PuzzLearn.NeuralNetwork.CalculateNetworkAdjustedFitness(network)
	local numSharedSpecies = 0
	for i,species in ipairs(PuzzLearn.NeuralNetwork.NetworkPool.Species) do
		for j, subNetwork in ipairs(species.Networks) do
			if PuzzLearn.NeuralNetwork.SameSpeciesCheck(network, subNetwork) then
				numSharedSpecies = numSharedSpecies + 1
			end
		end
	end
	
	network.AdjustedFitness = network.Fitness / numSharedSpecies
end

-- Calculates the total adjusted fitness of a species.
function PuzzLearn.NeuralNetwork.CalculateSpeciesTotalAdjustedFitness(species)
	species.TotalAdjustedFitness = 0
	
	for i,network in ipairs(species.Networks) do
		PuzzLearn.NeuralNetwork.CalculateNetworkAdjustedFitness(network)
		species.TotalAdjustedFitness = species.TotalAdjustedFitness + network.AdjustedFitness
	end
end

-- Calculates the total adjusted fitness of the whole network pool.
function PuzzLearn.NeuralNetwork.CalculatePoolTotalAdjustedFitness()
	PuzzLearn.NeuralNetwork.NetworkPool.TotalAdjustedFitness = 0
	
	for i,species in ipairs(PuzzLearn.NeuralNetwork.NetworkPool.Species) do
		PuzzLearn.NeuralNetwork.CalculateSpeciesTotalAdjustedFitness(species)
		PuzzLearn.NeuralNetwork.NetworkPool.TotalAdjustedFitness = PuzzLearn.NeuralNetwork.NetworkPool.TotalAdjustedFitness + species.TotalAdjustedFitness
	end
end

-- Creates a new network pool containing simple networks.
function PuzzLearn.NeuralNetwork.CreateFirstNetworkPool()
	PuzzLearn.NeuralNetwork.NetworkPool = PuzzLearn.NeuralNetwork.BuildNetworkPool()
	
	for i = 1,PuzzLearn.NeuralNetwork.Population do
		local network = PuzzLearn.NeuralNetwork.CreateSimpleNetwork()
		local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies(network)
		table.insert(newSpecies.Networks, network)
		table.insert(PuzzLearn.NeuralNetwork.NetworkPool.Species, newSpecies)
	end
end

-- Combines two selected networks into a new network.
function PuzzLearn.NeuralNetwork.NetworkCrossover(network1, network2)
	-- Double-check that both networks have their links ordered from lowest innovation to highest
	-- (Should happen by default, but there may be edge cases I haven't considered)
	local sortFunction = function(a,b)
		return a.InnovationNumber < b.InnovationNumber
	end
	
	local networkLinks1 = network1.Links
	local networkLinks2 = network2.Links
	
	table.sort(network1.Links, sortFunction)
	table.sort(network2.Links, sortFunction)
	
	local newNetwork = PuzzLearn.NeuralNetwork.BuildNetwork()
	
	
	-- Populate nodes
	local newTopNode
	local copyNetwork
	if network1.TopNode >= network2.TopNode then
		newTopNode = network1.TopNode
		copyNetwork = network1
	else
		newTopNode = network2.TopNode
		copyNetwork = network2
	end
	while newNetwork.TopNode < newTopNode do
		PuzzLearn.NeuralNetwork.GetNextNode(newNetwork, PuzzLearn.NeuralNetwork.CopyNetwork)
	end
	
	-- Handle shared and disjoint innovations between the two networks
	local newI = 1
	local i1 = 1
	local i2 = 1
	
	while i1 <= #networkLinks1 and i2 <= #networkLinks2 do
		local link1 = networkLinks1[i1]
		local link2 = networkLinks2[i2]
		local tempLink = nil
		
		if link1.InnovationNumber == link2.InnovationNumber then
			if math.random(1,2) == 1 then
				tempLink = PuzzLearn.NeuralNetwork.CopyLink(link1)
			else
				tempLink = PuzzLearn.NeuralNetwork.CopyLink(link2)
			end
			
			i1 = i1 + 1
			i2 = i2 + 1
		elseif link1.InnovationNumber < link2.InnovationNumber then
			tempLink = PuzzLearn.NeuralNetwork.CopyLink(link1)
			i1 = i1 + 1
		else
			tempLink = PuzzLearn.NeuralNetwork.CopyLink(link2)
			i2 = i2 + 1
		end
		
		-- Randomly enables the link if the crossover enable chance is met.
		if not tempLink.Enabled and math.random() < PuzzLearn.NeuralNetwork.CrossoverEnableChance then
			tempLink.Enabled = true
		end
		
		PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(newNetwork, tempLink)
	end
	
	-- Handle excess innovation numbers
	while i1 <= #networkLinks1 do
		local tempLink = PuzzLearn.NeuralNetwork.CopyLink(networkLinks1[i1])
		if not tempLink.Enabled and math.random() < PuzzLearn.NeuralNetwork.CrossoverEnableChance then
			tempLink.Enabled = true
		end
		i1 = i1 + 1
		PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(newNetwork, tempLink)
	end
	while i2 <= #networkLinks2 do
		local tempLink = PuzzLearn.NeuralNetwork.CopyLink(networkLinks2[i2])
		if not tempLink.Enabled and math.random() < PuzzLearn.NeuralNetwork.CrossoverEnableChance then
			tempLink.Enabled = true
		end
		i2 = i2 + 1
		PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(newNetwork, tempLink)
	end
	
	return newNetwork
end

-- Creates a new child from a given species.
function PuzzLearn.NeuralNetwork.GetChild(species)
	local child
	if math.random() < PuzzLearn.NeuralNetwork.CrossoverChance then
		local network1 = species.Networks[math.random(1, #species.Networks)]
		local network2 = species.Networks[math.random(1, #species.Networks)]
		child = PuzzLearn.NeuralNetwork.NetworkCrossover(network1, network2)
	else
		child = PuzzLearn.NeuralNetwork.DuplicateNetwork(species.Networks[math.random(1, #species.Networks)])
	end
	
	PuzzLearn.NeuralNetwork.MutateNetwork(child)
	
	return child
end

-- Removes the weaker half of networks within each species
function PuzzLearn.NeuralNetwork.RemoveBottomFromSpecies()
	local sortFunction = function(a,b)
		return a.Fitness > b.Fitness
	end
	
	for i, species in ipairs(PuzzLearn.NeuralNetwork.NetworkPool.Species) do	
		table.sort(species.Networks, sortFunction)
		
		local remaining = math.ceil(#species.Networks / 2)
		
		while #species.Networks > remaining do
			table.remove(species.Networks)
		end
	end
end

-- Removes networks that are sufficiently less fit than the fittest network of a species for each species.
function PuzzLearn.NeuralNetwork.RemoveUnfitFromSpecies()
	local sortFunction = function(a,b)
		return a.Fitness > b.Fitness
	end
	
	for i, species in ipairs(PuzzLearn.NeuralNetwork.NetworkPool.Species) do	
		table.sort(species.Networks, sortFunction)
		
		local bottomAllowedFitness = species.Networks[1].Fitness * 0.9
		
		local removing = true
		while removing do
			local unfitNetwork = species.Networks[#species.Networks]
			if unfitNetwork.Fitness < bottomAllowedFitness then
				table.remove(species.Networks)
			else
				removing = false
			end
		end
	end
end

-- Removes species that have not advanced within a certain number of generations.
-- Excludes the species with the fittest network.
function PuzzLearn.NeuralNetwork.RemoveStagnantSpecies()
	local survivingSpecies = {}
	for i,species in ipairs(PuzzLearn.NeuralNetwork.NetworkPool.Species) do
		if species.StagnantGenerations < PuzzLearn.NeuralNetwork.StagnantSpeciesThreshold or species.TopFitness >= PuzzLearn.NeuralNetwork.NetworkPool.TopFitness then
			table.insert(survivingSpecies, species)
		end
	end
	PuzzLearn.NeuralNetwork.NetworkPool.Species = survivingSpecies
end

-- Creates a new generation of networks from the network pool.
function PuzzLearn.NeuralNetwork.NewGeneration()
	local networkPool = PuzzLearn.NeuralNetwork.NetworkPool
	
	PuzzLearn.NeuralNetwork.RemoveStagnantSpecies()
	PuzzLearn.NeuralNetwork.RemoveBottomFromSpecies()
	PuzzLearn.NeuralNetwork.CalculatePoolTotalAdjustedFitness()
	
		
	-- Must include the event (possible early on) that networkPool.TotalAdjustedFitness = 0
	if networkPool.TotalAdjustedFitness == 0 then
		-- All species performed identically (no fitness)
		-- Mutate each species and continue
		local populationResult = math.floor(PuzzLearn.NeuralNetwork.Population / #networkPool.Species + 0.5)
		local newSpecies = {}
		for i,species in ipairs(networkPool.Species) do
			local newNetwork = PuzzLearn.NeuralNetwork.GetChild(species)
			local nextSpecies = PuzzLearn.NeuralNetwork.BuildSpecies(newNetwork)
			table.insert(nextSpecies.Networks, newNetwork)
			table.insert(newSpecies, nextSpecies)
		end
		
		networkPool.Species = newSpecies
	else
		-- Get populations for each species
		local speciesPopulations = {}
		local populationSum = 0
		
		local sortFunction = function(a,b)
			return a.TotalAdjustedFitness > b.TotalAdjustedFitness
		end
		
		table.sort(networkPool.Species, sortFunction)
		
		local i = #networkPool.Species
		while i >= 1 do
			local species = networkPool.Species[i]
			local populationResult = math.floor(species.TotalAdjustedFitness / networkPool.TotalAdjustedFitness * PuzzLearn.NeuralNetwork.Population + 0.5)
			if populationResult >= 2 then
				speciesPopulations[i] = populationResult
				populationSum = populationSum + populationResult
			else
				networkPool.TotalAdjustedFitness = networkPool.TotalAdjustedFitness - species.TotalAdjustedFitness
				table.remove(networkPool.Species, i)
				--Technically more accurate, but prohibitively slow for large populations
					--PuzzLearn.NeuralNetwork.CalculatePoolTotalAdjustedFitness()
					--table.sort(networkPool.Species, sortFunction)
			end
			i = i - 1
		end
		
		-- Adjust for discrepency between populationSum and the desired population
		-- Largest population will be the least relatively affected by a change
		local popAdjustment = PuzzLearn.NeuralNetwork.Population - populationSum
		speciesPopulations[1] = speciesPopulations[1] + popAdjustment
		
		-- Breed for every species
		local newSpecies = {}
		local newNetworks = {}
		
		-- Sort species table by top fitness
		local topFitnessSort = function(a,b)
			return a.TopFitness > b.TopFitness
		end
		
		table.sort(networkPool.Species, topFitnessSort)
		
		for i,species in pairs(networkPool.Species) do
			local tempSpecies = PuzzLearn.NeuralNetwork.DeriveSpecies(species)
			table.insert(newSpecies, tempSpecies)
			-- Always insert the fittest network from each species, for future breeding purposes
			table.insert(newNetworks, PuzzLearn.NeuralNetwork.DuplicateNetwork(species.Networks[1]))
			
			-- First, create half from the top half of the networks in a species
			-- (found from earlier culling)
			for j = 2, math.ceil(speciesPopulations[i] / 2) do
				table.insert(newNetworks, PuzzLearn.NeuralNetwork.GetChild(species))
			end
		end
		
		-- Then, create half from only networks close enough to the top fitness of each species
		PuzzLearn.NeuralNetwork.RemoveUnfitFromSpecies()
		
		for i,species in pairs(networkPool.Species) do
			for j = math.ceil(speciesPopulations[i] / 2) + 1, speciesPopulations[i] do
				table.insert(newNetworks, PuzzLearn.NeuralNetwork.GetChild(species))
			end
		end
		
		-- Finally, readjust the pool	
		networkPool.Species = newSpecies
		for i,network in ipairs(newNetworks) do
			PuzzLearn.NeuralNetwork.AddNetworkToSpecies(network)
		end
	end
	
	-- Reset pool settings
	networkPool.Generation = networkPool.Generation + 1
	networkPool.CurrentSpecies = 1
	networkPool.CurrentNetwork = 1
	networkPool.OverallNetwork = 1
	networkPool.TotalAdjustedFitness = 0
	networkPool.TopSpecies = 1
	networkPool.TopNetwork = 1
end



-- FILE SAVE/LOAD FUNCTIONS
-- All lower-level functions assume a proper value has been stored in io.output/input

-- Saves the relevant information for an individual link.
function PuzzLearn.NeuralNetwork.SaveLinkAsText(link)
	local enabledNumber = 0
	if link.Enabled then enabledNumber = 1 end
	io.write(link.InNode, ",", link.OutNode, ",", link.Weight, ",", enabledNumber, ",", link.InnovationNumber, "\n")
end

-- Saves the relevant information for an individual network, including all nodes and links.
function PuzzLearn.NeuralNetwork.SaveNetworkAsText(network)	
	io.write(network.Fitness, ",", network.TopNode, ",", #network.Links, "\n")
	
	for i = PuzzLearn.NeuralNetwork.InputCount + 1, network.TopNode do
		io.write(network.Nodes[i].X, ",", network.Nodes[i].Y, "\n")
	end

	for i,link in ipairs(network.Links) do
		PuzzLearn.NeuralNetwork.SaveLinkAsText(link)
	end
end

-- Saves the relevant information for an individual species, including all networks.
function PuzzLearn.NeuralNetwork.SaveSpeciesAsText(species)	
	local isStagnantNumber = 0
	if species.IsStagnant then isStagnantNumber = 1 end
	io.write(species.TopFitness, ",", species.TotalFitness, ",", species.StagnantGenerations, ",", isStagnantNumber, ",", #species.Networks, "\n")
	
	PuzzLearn.NeuralNetwork.SaveNetworkAsText(species.DefiningNetwork)
	for i,network in ipairs(species.Networks) do
		PuzzLearn.NeuralNetwork.SaveNetworkAsText(network)
	end
end

-- Saves all data from a given pool.
function PuzzLearn.NeuralNetwork.SavePoolAsText(pool)
	io.write(PuzzLearn.NeuralNetwork.ConfigFile, "\n", PuzzLearn.NeuralNetwork.ArchiveLocation, "\n", PuzzLearn.NeuralNetwork.StateName, "\n")
	io.write(pool.Generation, ",", pool.GlobalInnovationNumber, ",", pool.CurrentSpecies, ",", pool.CurrentNetwork, ",", pool.OverallNetwork, ",",
			pool.TopFitness, ",", #pool.Species, ",", pool.TopSpecies, ",", pool.TopNetwork, "\n")
	for i,species in ipairs(pool.Species) do
		PuzzLearn.NeuralNetwork.SaveSpeciesAsText(species)
	end
end

-- Saves the global network pool at the given file name.
function PuzzLearn.NeuralNetwork.SaveFile(filename)
	local fileSave = io.open(filename, "w")
	io.output(fileSave)
	PuzzLearn.NeuralNetwork.SavePoolAsText(PuzzLearn.NeuralNetwork.NetworkPool)
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

-- Loads a network from the default input, including all nodes and links.
function PuzzLearn.NeuralNetwork.LoadNetworkFromText()
	local networkSplitText = PuzzLearn.SplitString(io.read(), ",")
	local newNetwork = PuzzLearn.NeuralNetwork.BuildNetwork()
	newNetwork.Fitness = tonumber(networkSplitText[1])
	newNetwork.TopNode = tonumber(networkSplitText[2])	
	
	for i = PuzzLearn.NeuralNetwork.InputCount + 1, newNetwork.TopNode do
		newNetwork.Nodes[i] = PuzzLearn.NeuralNetwork.BuildNode()
		local nodeSplitText = PuzzLearn.SplitString(io.read(), ",")
		newNetwork.Nodes[i].X = tonumber(nodeSplitText[1])
		newNetwork.Nodes[i].Y = tonumber(nodeSplitText[2])
	end
	
	for i = 1, tonumber(networkSplitText[3]) do
		local newLink = PuzzLearn.NeuralNetwork.LoadLinkFromText()
		PuzzLearn.NeuralNetwork.InsertLinkIntoNetwork(newNetwork, newLink)
	end
	
	return newNetwork
end

-- Loads a species from the default IO, including all networks.
function PuzzLearn.NeuralNetwork.LoadSpeciesFromText()
	local newSpecies = PuzzLearn.NeuralNetwork.BuildSpecies(nil)
	local speciesSplitText = PuzzLearn.SplitString(io.read(), ",")
	
	newSpecies.TopFitness = tonumber(speciesSplitText[1])
	newSpecies.TotalFitness = tonumber(speciesSplitText[2])
	newSpecies.StagnantGenerations = tonumber(speciesSplitText[3])
	newSpecies.IsStagnant = tonumber(speciesSplitText[4]) == 1
	
	newSpecies.DefiningNetwork = PuzzLearn.NeuralNetwork.LoadNetworkFromText()
	for i = 1, tonumber(speciesSplitText[5]) do
		table.insert(newSpecies.Networks, PuzzLearn.NeuralNetwork.LoadNetworkFromText())
	end
	
	return newSpecies
end

-- Loads a network pool from the default IO and sets the global network pool to it.
function PuzzLearn.NeuralNetwork.LoadPoolFromText()
	local newPool = PuzzLearn.NeuralNetwork.BuildNetworkPool()
	PuzzLearn.NeuralNetwork.ConfigFile = io.read()
	PuzzLearn.NeuralNetwork.ArchiveLocation = io.read()
	PuzzLearn.NeuralNetwork.StateName = io.read()
	
	PuzzLearn.FileManagement.ReadFile(PuzzLearn.NeuralNetwork.ConfigFile)
	PuzzLearn.NeuralNetwork.CreateDisplayForm()
	
	local line = io.read()
	local poolSplitText = PuzzLearn.SplitString(line, ",")
	
	newPool.Generation = tonumber(poolSplitText[1])
	newPool.GlobalInnovationNumber = tonumber(poolSplitText[2])
	newPool.CurrentSpecies = tonumber(poolSplitText[3])
	newPool.CurrentNetwork = tonumber(poolSplitText[4])
	newPool.OverallNetwork = tonumber(poolSplitText[5])
	newPool.TopFitness = tonumber(poolSplitText[6])
	newPool.TopSpecies = tonumber(poolSplitText[8])
	newPool.TopNetwork = tonumber(poolSplitText[9])
	
	for i=1, tonumber(poolSplitText[7]) do
		table.insert(newPool.Species, PuzzLearn.NeuralNetwork.LoadSpeciesFromText())
	end
	
	PuzzLearn.NeuralNetwork.NetworkPool = newPool
end

-- Loads a given file to retrieve a network pool.
-- Returns true if it succeeds, false otherwise.
function PuzzLearn.NeuralNetwork.LoadFile(filename)
	local readFile = io.open(filename, "r")
	if readFile ~= nil then
		io.input(readFile)
		--PuzzLearn.NeuralNetwork.LoadPoolFromText()
		if not pcall(PuzzLearn.NeuralNetwork.LoadPoolFromText) then
			io.close(readFile)
			return false
		end--]]
		io.close(readFile)
		return true
	else
		return false
	end
end



-- NETWORK PROCESSING FUNCTIONS

-- Sets the input nodes of the array.
function PuzzLearn.NeuralNetwork.ProcessInputNodes(network, inputArray)
	for i = 1, #inputArray do
		if inputArray[i] == 1 then
			network.Nodes[i].Value = 1
		end
	end
end

-- Processes an individual node within a network.
function PuzzLearn.NeuralNetwork.ProcessNode(evalNode, network)
	if #evalNode.InLinks > 0 then
		local valueSum = 0
		for linkID, link in ipairs(evalNode.InLinks) do
			if link.Enabled then
				local inNode = network.Nodes[link.InNode]
				valueSum = valueSum + inNode.Value * link.Weight
			end
		end
		evalNode.Value = PuzzLearn.NeuralNetwork.SigmoidalTransferFunction(valueSum)
	end
end

-- Processes all nodes within a network and retrieves outputs.
function PuzzLearn.NeuralNetwork.GetOutputs(network, inputArray)	
	PuzzLearn.NeuralNetwork.ResetNetworkNodes(network)
	PuzzLearn.NeuralNetwork.ProcessInputNodes(network, inputArray)
	
	-- Run through the network 2 times to compensate for loops
	for i=1,2 do
		for j=PuzzLearn.NeuralNetwork.InputCount + 1, network.TopNode do
			local evalNode = network.Nodes[j]
			PuzzLearn.NeuralNetwork.ProcessNode(evalNode, network)
		end
		
		for j=PuzzLearn.NeuralNetwork.MaxTotalNodes+1,PuzzLearn.NeuralNetwork.MaxTotalNodes+PuzzLearn.NeuralNetwork.OutputCount do
			local evalNode = network.Nodes[j]
			PuzzLearn.NeuralNetwork.ProcessNode(evalNode, network)
		end
	end
	
	local outputs = {}
	
	for i, name in ipairs(PuzzLearn.NeuralNetwork.Buttons) do
		if network.Nodes[PuzzLearn.NeuralNetwork.MaxTotalNodes + i].Value > 0 then
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

-- Processes the given network, loading a state and playing until a timer runs out or a failure state is reached,
-- then updates its score.
function PuzzLearn.NeuralNetwork.ProcessNetwork(network)
	local processed = false
	local maxFitness
	
	while not processed do
		if PuzzLearn.NeuralNetwork.FittestPending then
			PuzzLearn.NeuralNetwork.FittestPending = false
			if not PuzzLearn.NeuralNetwork.ShowingFittestNetwork then
				PuzzLearn.NeuralNetwork.ShowingFittestNetwork = true
				local newDisplayString = "Fittest: Species: " .. PuzzLearn.NeuralNetwork.NetworkPool.TopSpecies .. " | Network: " .. PuzzLearn.NeuralNetwork.NetworkPool.TopNetwork .. " | Fitness: " .. PuzzLearn.NeuralNetwork.NetworkPool.TopFitness
				forms.settext(PuzzLearn.NeuralNetwork.DisplayForm.Info, newDisplayString)
				
				PuzzLearn.NeuralNetwork.ProcessNetwork(PuzzLearn.NeuralNetwork.NetworkPool.Species[PuzzLearn.NeuralNetwork.NetworkPool.TopSpecies].Networks[PuzzLearn.NeuralNetwork.NetworkPool.TopNetwork])
				
				forms.settext(PuzzLearn.NeuralNetwork.DisplayForm.Info, PuzzLearn.NeuralNetwork.DisplayString)
				PuzzLearn.NeuralNetwork.ShowingFittestNetwork = false
			end
		end
		local ended = false
		local frameCount = 0
		local fitnessIncreaseFrame = 0
		maxFitness = 0
		savestate.load(PuzzLearn.NeuralNetwork.StateName)
		
		while not ended do
			local outputs = PuzzLearn.NeuralNetwork.GetOutputs(network, PuzzLearn.MemoryStructure.ProcessAddressDatabase(PuzzLearn.NeuralNetwork.Database))
			PuzzLearn.NeuralNetwork.UpdateFormImage(network)
			
			joypad.set(outputs)
			emu.frameadvance()
			if not PuzzLearn.NeuralNetwork.ReleaseButtons then
				joypad.set(outputs)
			end
			emu.frameadvance()
			
			frameCount = frameCount + 2
			fitnessIncreaseFrame = fitnessIncreaseFrame + 2
			
			local currentFitness = PuzzLearn.MemoryStructure.ProcessScore(PuzzLearn.NeuralNetwork.Database)
			if currentFitness > maxFitness then
				maxFitness = currentFitness
				fitnessIncreaseFrame = 0
			end
				
			coroutine.yield()
				
			if frameCount > PuzzLearn.NeuralNetwork.TimeoutFrame or fitnessIncreaseFrame > PuzzLearn.NeuralNetwork.FitnessTimeout
				or PuzzLearn.NeuralNetwork.TerminateLearning or PuzzLearn.MemoryStructure.RunEnded(PuzzLearn.NeuralNetwork.Database) then
				ended = true
				processed = true
			elseif PuzzLearn.NeuralNetwork.FittestPending then
				ended = true
			end			
		end
	end
	if not PuzzLearn.NeuralNetwork.TerminateLearning then
		network.Fitness = maxFitness
	end
end

-- Processes a whole species, starting at the network marked by CurrentNetwork.
function PuzzLearn.NeuralNetwork.ProcessSpecies(species)
	local networkPool = PuzzLearn.NeuralNetwork.NetworkPool
	local displayStringFirstPart = "Generation: " .. networkPool.Generation .. " | Species: " .. networkPool.CurrentSpecies .. " | Network: "
	
	while not PuzzLearn.NeuralNetwork.TerminateLearning and networkPool.CurrentNetwork <= #species.Networks do
		local i = networkPool.CurrentNetwork
		local network = species.Networks[i]
		
		PuzzLearn.NeuralNetwork.DisplayString = displayStringFirstPart .. networkPool.CurrentNetwork .. " | Overall: " .. networkPool.OverallNetwork .. " | Top fitness: " .. networkPool.TopFitness
		forms.settext(PuzzLearn.NeuralNetwork.DisplayForm.Info, PuzzLearn.NeuralNetwork.DisplayString)
		
		PuzzLearn.NeuralNetwork.ProcessNetwork(network)
		
		if not PuzzLearn.NeuralNetwork.TerminateLearning then
			species.TotalFitness = species.TotalFitness + network.Fitness
			
			if network.Fitness > species.TopFitness then
				species.TopFitness = network.Fitness
				species.StagnantGenerations = 0
				species.IsStagnant = false
				
				if species.TopFitness > networkPool.TopFitness then
					networkPool.TopFitness = species.TopFitness
					networkPool.TopSpecies = networkPool.CurrentSpecies
					networkPool.TopNetwork = networkPool.CurrentNetwork
				end
			end
			
			networkPool.CurrentNetwork = networkPool.CurrentNetwork + 1
			networkPool.OverallNetwork = networkPool.OverallNetwork + 1
			
			PuzzLearn.NeuralNetwork.SaveFile(PuzzLearn.NeuralNetwork.SessionFileName)
		end
	end
	
	if species.IsStagnant then species.StagnantGenerations = species.StagnantGenerations + 1 end
end

-- Processes the entire network pool, starting at the species marked by CurrentSpecies.
function PuzzLearn.NeuralNetwork.ProcessPool()
	local networkPool = PuzzLearn.NeuralNetwork.NetworkPool
	while not PuzzLearn.NeuralNetwork.TerminateLearning and networkPool.CurrentSpecies <= #networkPool.Species do
		local species = networkPool.Species[networkPool.CurrentSpecies]
		PuzzLearn.NeuralNetwork.ProcessSpecies(species)
		
		networkPool.CurrentNetwork = 1		
		networkPool.CurrentSpecies = networkPool.CurrentSpecies + 1
	end
end

-- Continually processes the network pool, producing new generations when it is done processing.
function PuzzLearn.NeuralNetwork.ProcessGenerations()
	PuzzLearn.NeuralNetwork.TerminateLearning = false
	while true do
		PuzzLearn.NeuralNetwork.ProcessPool()
		if not PuzzLearn.NeuralNetwork.TerminateLearning then
			PuzzLearn.NeuralNetwork.SaveFile(PuzzLearn.NeuralNetwork.ArchiveLocation .. PuzzLearn.NeuralNetwork.NetworkPool.Generation .. ".pls")
			PuzzLearn.NeuralNetwork.SaveFile(PuzzLearn.NeuralNetwork.ArchiveLocation .. ".pls")
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
	
	local newFormHandle = forms.newform(formWidth, formHeight, "PuzzLearn", displayFormCloseFunction)
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

-- Updates the display form for the given network based on the game's current state.
function PuzzLearn.NeuralNetwork.UpdateFormImage(network)
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
	local gridSize = PuzzLearn.NeuralNetwork.FormGridSize
	local rectSize = gridSize - 1
	
	local zeroColor = PuzzLearn.NeuralNetwork.Database.ValueColors[0]
	
	for i, addressPlane in ipairs(PuzzLearn.NeuralNetwork.Database.AddressPlanes) do
		local processedTable, tableWidth, tableHeight = PuzzLearn.MemoryStructure.ProcessAddressPlane(addressPlane)
		local startingPoint = gridWidth - tableWidth - 1
		forms.drawRectangle(picture, (startingPoint + 1) * gridSize, yDraw, (rectSize + 1) * tableWidth - 1, (rectSize + 1) * tableHeight - 1, zeroColor, zeroColor)
		for y = 1, tableHeight, 1 do
			for x = 1, tableWidth, 1 do
				local value = processedTable[x][y]
				if value ~= 0 then
					local rectCornerX = (startingPoint + x) * gridSize			
					forms.drawRectangle(picture, rectCornerX, yDraw, rectSize, rectSize, zeroColor, PuzzLearn.NeuralNetwork.Database.ValueColors[value])
				end
			end
			yDraw = yDraw + gridSize
		end
		yDraw = yDraw + gridSize
	end
	
	for i, infoAddress in ipairs(PuzzLearn.NeuralNetwork.Database.InfoAddresses) do
		local infoArray = {}
		PuzzLearn.MemoryStructure.AddInfoAddressToResultArray(infoAddress, infoArray)
		
		local startingPoint = gridWidth - #infoArray - 1
		
		forms.drawRectangle(picture, (startingPoint + 1) * gridSize, yDraw, (rectSize + 1) * infoAddress.MaxValue - 1, rectSize, black, black) 
		
		for i = 1, #infoArray, 1 do
			if infoArray[i] == 1 then
				forms.drawRectangle(picture, (startingPoint + i) * gridSize, yDraw, rectSize, rectSize, black, white)
				break
			end
		end
		
		yDraw = yDraw + 2 * PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	forms.drawRectangle(picture, (gridWidth - 1) * PuzzLearn.NeuralNetwork.FormGridSize, yDraw, rectSize, rectSize, black, white)
	
	for i = PuzzLearn.NeuralNetwork.InputCount + 1, network.TopNode do
		local node = network.Nodes[i]
		local border = black
		local fill = white
		if node.Value == 0 then
			border = translBlack
			fill = translBlack
		elseif node.Value < 0 then
			fill = black
		end
		
		
		forms.drawRectangle(picture, node.X, node.Y, rectSize, rectSize, border, fill)
	end
	
	local outputNodeX = PuzzLearn.NeuralNetwork.NodeAreaEndX + 2 * PuzzLearn.NeuralNetwork.FormGridSize
	local outputTextX = outputNodeX + PuzzLearn.NeuralNetwork.FormGridSize + 2
	local outputNodeY = math.ceil((PuzzLearn.NeuralNetwork.NodeAreaHeight - PuzzLearn.NeuralNetwork.OutputCount * PuzzLearn.NeuralNetwork.FormGridSize)/ 2)
	for i = 1, PuzzLearn.NeuralNetwork.OutputCount do
		local outputNode = network.Nodes[PuzzLearn.NeuralNetwork.MaxTotalNodes + i]
		local color = white
		if outputNode.Value <= 0 then
			color = black
		end
		
		forms.drawRectangle(picture, outputNodeX, outputNodeY, rectSize, rectSize, black, color)
		forms.drawText(picture, outputTextX, outputNodeY, PuzzLearn.NeuralNetwork.Buttons[i], black, 0x00000000, PuzzLearn.NeuralNetwork.FormGridSize)
		
		outputNodeY = outputNodeY + PuzzLearn.NeuralNetwork.FormGridSize
	end
	
	-- Draw links (must be done afterwards in order to have all links drawn above nodes)
	local centerAdjust = math.ceil(PuzzLearn.NeuralNetwork.FormGridSize / 2)
	local lPosOn = 0xAA00FF00
	local lPosOff = 0x2200FF00
	local lNegOn = 0xAAFF0000
	local lNegOff = 0x22FF0000
	
	for i = 1, network.TopNode do
		local drawNode = network.Nodes[i]
		local startX = drawNode.X + PuzzLearn.NeuralNetwork.FormGridSize - 1
		if i <= PuzzLearn.NeuralNetwork.InputCount then
			startX = drawNode.X + centerAdjust
		end
		local startY = drawNode.Y + centerAdjust
		if drawNode.Value == 0 then
			for j, link in ipairs(drawNode.OutLinks) do
				if link.Enabled and link.Weight ~= 0 then
					local endNode = network.Nodes[link.OutNode]
					local endNodeXAdjusted
					if link.OutNode > network.TopNode then
						endNodeXAdjusted = endNode.X + centerAdjust
					else
						endNodeXAdjusted = endNode.X
					end
					local linkColor
					local weightedNode
					if link.Weight > 0 then
						linkColor = lPosOff
					else
						linkColor = lNegOff
					end
					
					forms.drawLine(picture, startX, startY, endNodeXAdjusted, endNode.Y + centerAdjust, linkColor)
				end
			end
		else
			for j, link in ipairs(drawNode.OutLinks) do
				if link.Enabled and link.Weight ~= 0 then
					local endNode = network.Nodes[link.OutNode]
					local endNodeXAdjusted
					if link.OutNode > network.TopNode then
						endNodeXAdjusted = endNode.X + centerAdjust
					else
						endNodeXAdjusted = endNode.X
					end
					local linkColor
					local weightedValue = drawNode.Value * link.Weight
					if weightedValue > 0 then
						linkColor = lPosOn
					else
						linkColor = lNegOn
					end
					
					forms.drawLine(picture, startX, startY, endNodeXAdjusted, endNode.Y + centerAdjust, linkColor)
				end
			end
		end
		
	end
				
	
	forms.refresh(picture)
end

-- COMPLETE RUN FUNCTION

function PuzzLearn.NeuralNetwork.RunFile(fileName)
	PuzzLearn.NeuralNetwork.SessionFileName = fileName
	if PuzzLearn.NeuralNetwork.LoadFile(fileName) then
		stateCheck = io.open(PuzzLearn.NeuralNetwork.StateName, "r")
		if stateCheck ~= nil then
			io.close(stateCheck)
			
			PuzzLearn.NeuralNetwork.ProcessGenerations()				
		end
	end
end
