dofile("readMemoryStructure.lua")

CursorX = buildInteger("Cursor X", 0x326, -96, 1/8)
CursorY = buildInteger("Cursor Y", 0x327, -48, 1/8)
CursorBlockXStart = buildInteger("Cursor Block X ", 0x1910, -96, 1/8)
CursorBlockYStart = buildInteger("Cursor Block Y ", 0x1911, -55, 1/8)

cursorXTable = { CursorX }
cursorYTable = { CursorY }
cursorBlockXTable = { CursorBlockXStart }
cursorBlockYTable = { CursorBlockYStart }
Cursor = buildObject("Cursor", cursorXTable, cursorYTable, nil, 1)
CursorBlockStart = buildObject("Cursor Block ", cursorBlockXTable, cursorBlockYTable, nil, 1)

cursorBlockTable = { CursorBlockStart }
CursorBlockRegion = buildRegion("Cursor Blocks", cursorBlockTable, 4, 0x1910, 0x191C)

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
AddressTable[2] = CursorBlockRegion

Database = buildAddressDatabase(AddressTable, CursorX, -5, 5, CursorY, -2, 8, 1, ScoreAddresses, 0x1912, 80)

while true do
	viewGrid, width, height = processAddressDatabase(Database)
	
	if memory.readbyte(Database.EndAddress) == Database.EndValue then
		gui.text(2, 2, "Ended")
	else
		local score = processIntegerAddressArray(Database.Score)
		gui.text(2, 2, score)		
	end
	
	for i = 1, height, 1 do
		row = ""
		for j = 1, width, 1 do
			row = row .. viewGrid[j][i]
		end
		
		gui.text(2, 14 * i, row)
	end
   
   emu.frameadvance()
end
