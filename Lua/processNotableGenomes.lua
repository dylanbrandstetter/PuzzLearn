dofile("neuralNetworkFunctions.lua")

-- Find fittest genome
function findFittestGenome()
	local fittestGenome = nil
	fittestFitness = 0
	for i,species in ipairs(GenePool.Species) do
		for j,genome in ipairs(species.Genomes) do
			if genome.Fitness > fittestFitness then
				fittestFitness = genome.Fitness
				fittestGenome = genome
			end
		end
	end
	return fittestGenome
end


loadFile("proofOfConcept_ArchivePool1.txt")
FitnessTimeout = 1020

DisplayString = "Sample early genome"
processGenome(GenePool.Species[1].Genomes[1])

fitGenome = findFittestGenome()

DisplayString = "Generation 1 fittest"
processGenome(fitGenome)

loadFile("proofOfConcept_ArchivePool5.txt")
fitGenome = findFittestGenome()
DisplayString = "Generation 5 fittest"
processGenome(fitGenome)

loadFile("proofOfConcept_ArchivePool29.txt")
fitGenome = findFittestGenome()
DisplayString = "Generation 29 fittest"
processGenome(fitGenome)

loadFile("proofOfConcept_ArchivePool43.txt")
fitGenome = findFittestGenome()
DisplayString = "Generation 43 fittest"
processGenome(fitGenome)

loadFile("proofOfConcept_ArchivePool74.txt")
fitGenome = findFittestGenome()
DisplayString = "Generation 74 fittest"
processGenome(fitGenome)

loadFile("proofOfConcept_ArchivePool.txt")
fitGenome = findFittestGenome()
DisplayString = "Generation " .. GenePool.Generation .. " fittest"
processGenome(fitGenome)


while true do
	emu.frameadvance()
end