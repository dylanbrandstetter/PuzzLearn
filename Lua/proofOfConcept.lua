dofile("neuralNetworkFunctions.lua")

-- FINAL PREPARATION AND MAIN LOOP
loadFile(SessionFileName)

stateCheck = io.open(StateName, "r")
if stateCheck == nil then
	error()
end

while true do
	processPool()
	saveFile(PreviousGenerationFileName .. GenePool.Generation .. ".txt")
	saveFile(PreviousGenerationFileName .. ".txt")
	newGeneration()
	-- Code for if something crashes and I need to figure out why without somehow breaking anything
	-- while true do emu.frameadvance() end
end
