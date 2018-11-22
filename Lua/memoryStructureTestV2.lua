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

while true do
	viewGrid, width, height = processAddressPlane(MainPlane)
	otherRow = {}
	addInfoAddressToResultArray(ShapeAndOrientation, otherRow)
	
	if runEnded(Database) then
		gui.text(2, 2, "Ended")
	else
		local score = processScore(Database)
		gui.text(2, 2, score)		
	end
	
	for i = 1, height, 1 do
		row = ""
		for j = 1, width, 1 do
			row = row .. viewGrid[j][i]
		end
		
		gui.text(2, 14 * i, row)
	end
	
	row = ""
	for i,val in ipairs(otherRow) do
		row = row .. val
	end
	gui.text(2, 14*height + 14, row)
	local orientationByte = memory.readbyte(ShapeAndOrientation.Address)
	gui.text(2, 14*height + 28, orientationByte)
	gui.text(2, 14*height + 42, ShapeAndOrientation.ValueCategory[orientationByte])
	gui.text(2, 14*height + 56, getResultArrayLength(Database))
   
	emu.frameadvance()
end
