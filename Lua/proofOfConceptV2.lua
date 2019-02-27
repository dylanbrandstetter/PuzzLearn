dofile("neuralNetworkFunctionsV2.lua")

-- FINAL PREPARATION AND MAIN LOOP
createDisplayForm()

if not loadFile(SessionFileName) then
	initializePool()
end

stateCheck = io.open(StateName, "r")
if stateCheck == nil then
	error()
end
io.close(stateCheck)

processGenerations()

while true do
	emu.frameadvance()
end
