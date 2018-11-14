--[[

For testing purposes, values are hard coded
To be used with Tetris and Dr. Mario, Tetris mode

Structures used:

enum AddressType
	XPOSITION = 0
	YPOSITION = 1
	OTHER = 2

AddressInfo
	int Address
	string Description
	AddressType Type

AddressDatabase
	AddressInfo[] Addresses
	(Table) DisplayInfo[int address][int value]

]]--

AddressType = { XPOSITION = 0, YPOSITION = 1, OTHER = 2 }

AddressDatabase = {}
AddressDatabase.Addresses = {}

AddressDatabase.Addresses[1] = { Address = 0x317, Description = "Shape and orientation",
                                 Type = AddressType.OTHER }
AddressDatabase.Addresses[2] = { Address = 0x1910, Description = "Block 1 X",
                                 Type = AddressType.XPOSITION }
AddressDatabase.Addresses[3] = { Address = 0x1911, Description = "Block 1 Y",
                                 Type = AddressType.YPOSITION }
AddressDatabase.Addresses[4] = { Address = 0x1914, Description = "Block 2 X",
                                 Type = AddressType.XPOSITION }
AddressDatabase.Addresses[5] = { Address = 0x1915, Description = "Block 2 Y",
                                 Type = AddressType.YPOSITION }
AddressDatabase.Addresses[6] = { Address = 0x1918, Description = "Block 3 X",
                                 Type = AddressType.XPOSITION }
AddressDatabase.Addresses[7] = { Address = 0x1919, Description = "Block 3 Y",
                                 Type = AddressType.YPOSITION }
AddressDatabase.Addresses[8] = { Address = 0x191C, Description = "Block 4 X",
                                 Type = AddressType.XPOSITION }
AddressDatabase.Addresses[9] = { Address = 0x191D, Description = "Block 4 Y",
                                  Type = AddressType.YPOSITION }

AddressDatabase.XOffset = 88
AddressDatabase.XDivide = 8

AddressDatabase.YOffset = 47
AddressDatabase.YDivide = 8

AddressDatabase.DisplayInfo = {}
AddressDatabase.DisplayInfo[0x317] = { [0] = "T 0", [2] = "T 90", [4] = "T 180", [6] = "T 270",
									   [8] = "J 0", [10] = "J 90", [12] = "J 180", [14] = "J 270",
                                       [16] = "Z 0", [18] = "Z 90", [20] = "Z 180", [22] = "Z 270",
									   [24] = "Square 0", [26] = "Square 90", [28] = "Square 180", [30] = "Square 270",
									   [32] = "S 0", [34] = "S 90", [36] = "S 180", [38] = "S 270",
									   [40] = "L 0", [42] = "L 90", [44] = "L 180", [46] = "L 270",
									   [48] = "I 0", [50] = "I 90", [52] = "I 180", [54] = "I 270",
                                       [240] = "" }

displayByte = {}

displayByte[AddressType.XPOSITION] = function(ramByte, address)
    result = (ramByte - AddressDatabase.XOffset) / AddressDatabase.XDivide
	return result
end

displayByte[AddressType.YPOSITION] = function(ramByte, address)
    result = (ramByte - AddressDatabase.YOffset) / AddressDatabase.YDivide
	return result
end

displayByte[AddressType.OTHER] = function(ramByte, address)
    result = AddressDatabase.DisplayInfo[address.Address][ramByte]
	if result == nil then
	    result = ""
	end
	return result
end
									   
while true do
   for i,address in ipairs(AddressDatabase.Addresses) do
       ramByte = memory.readbyte(address.Address)
	   displayString = address.Description .. ": " .. displayByte[address.Type](ramByte, address)
	   
	   gui.text(2, 14 * i - 12, displayString)
   end
   
   emu.frameadvance()
end