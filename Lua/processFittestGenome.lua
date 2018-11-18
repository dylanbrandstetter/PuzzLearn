dofile("neuralNetworkFunctions.lua")

SessionFileName = "proofOfConcept_ArchivePool.txt"
loadFile(SessionFileName)

-- Find fittest genome
fittestFitness = 0
for i,species in ipairs(GenePool.Species) do
	for j,genome in ipairs(species.Genomes) do
		if genome.Fitness > fittestFitness then
			fittestFitness = genome.Fitness
			fittestGenome = genome
			break
		end
		if fittestGenome ~= nil then break end
	end
end

DisplayString = "Fittest Genome"

if fittestGenome == nil then error() end
processGenome(fittestGenome)

while true do
	emu.frameadvance()
end