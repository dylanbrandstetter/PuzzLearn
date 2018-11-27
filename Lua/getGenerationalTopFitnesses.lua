outputFilename = "GenerationalFitnesses.txt"
inputV1Filename = "proofOfConcept_ArchivePool"
inputV2Filename = "proofOfConceptV2_ArchivePool"

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

function getTopFitness(filename)
	local readFile = io.open(filename, "r")
	if readFile == nil then return nil end
	
	io.input(readFile)
	local poolSplitText = splitString(io.read(), ",")
	io.close(readFile)
	
	return poolSplitText[6]
end

function writeGenerationalFitnessFile()
	local writeFile = io.open(outputFilename, "w")
	io.output(writeFile)
	
	local i = 1
	local done = false
	while not done do
		local f1 = getTopFitness(inputV1Filename .. i .. ".txt")
		if f1 == nil then
			done = true
			break
		end
		
		local f2 = getTopFitness(inputV2Filename .. i .. ".txt")
		if f2 ~= nil then
			io.write(i, "\t", f1, "\t", f2, "\n")
		else
			io.write(i, "\t", f1, "\n")
		end
		
		i = i + 1
	end
	
	io.close(writeFile)
end

writeGenerationalFitnessFile()

while true do emu.frameadvance() end