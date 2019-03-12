if PuzzLearn == nil then
	PuzzLearn = {}
end

PuzzLearn.MemoryStructure = {}

--[[

Structures used:

enum Category
	INFORMATION = 0,
	INTEGER = 1,
	OBJECT = 2,
	REGION = 3,
	XYREGION = 4

Address classes:

	InfoAddress
		Category Type = INFORMATION
		string Description
		int Address
		int[] ValueCategory		Assign the index with a certain byte to a value to be read by the program
		int NilValue            For byte values without an equivalent ValueCategory
		int MaxValue			Maximum possible value returned by ValueCategory or NilValue

	IntegerAddress
	    Category Type = INTEGER
		string Description
		int Address
		int Offset
		int Multiply
	
	ObjectBlock
		Category Type = OBJECT
		string Description
		IntegerAddress[] XPosition          Must be arrays for the (possibly unlikely) scenario where position takes more than one byte to store
		IntegerAddress[] YPosition
		InfoAddress Information
		int FixedValue                      For situations where no information is needed, only some default value
		
	AddressRegion
	    Constructor takes (string Description, Address[] StartAddresses, int Increment, int startAddress, int FinalAddress)
		Category Type = REGION
		string Description
		Address[] Addresses
		
	XYRegion
		Category Type = XYREGION
		string Description
		int StartAddress
		int Width
		int XOffset
		int Height
		int YOffset
		int RowOffset
		int[] ValueCategory
		int NilValue

--]]

PuzzLearn.MemoryStructure.Category = { 
	INFORMATION = 0,
	INTEGER = 1,
	OBJECT = 2,
	REGION = 3,
	XYREGION = 4
	}

function PuzzLearn.MemoryStructure.BuildInfo(description, address, valueCategory, nilValue, maxValue)
	local temp = {}
	temp.Type = PuzzLearn.MemoryStructure.Category.INFORMATION
	temp.Description = description
	temp.Address = address
	temp.ValueCategory = valueCategory
	temp.NilValue = nilValue
	temp.MaxValue = maxValue
	
	return temp
end

function PuzzLearn.MemoryStructure.BuildInteger(description, address, offset, multiply)
    local temp = {}
	temp.Type = PuzzLearn.MemoryStructure.Category.INTEGER
	temp.Description = description
	temp.Address = address
	temp.Offset = offset
	temp.Multiply = multiply
	
	return temp
end

-- Note: MUST assign infoAddress and fixedValue the correct (nil) value even when not used
function PuzzLearn.MemoryStructure.BuildObject(description, xAddresses, yAddresses, infoAddress, fixedValue)
    local temp = {}
	temp.Type = PuzzLearn.MemoryStructure.Category.OBJECT
	temp.Description = description
	temp.XPosition = xAddresses
	temp.YPosition = yAddresses
	temp.Information = infoAddress
	temp.FixedValue = fixedValue
	
	return temp
end

function PuzzLearn.MemoryStructure.RecursiveIncrementCopy(address, incrementValue, incrementNumber)
    if address == nil then
	    return nil
    end
	local newDescription = address.Description .. incrementNumber
	local increment = (incrementNumber - 1) * incrementValue
	
	if address.Type == PuzzLearn.MemoryStructure.Category.OBJECT then
	    local tempX = {}
	    for i, v in ipairs(address.XPosition) do
		    tempX[i] = PuzzLearn.MemoryStructure.RecursiveIncrementCopy(v, incrementValue, incrementNumber)
		end
		
	    local tempY = {}
	    for i, v in ipairs(address.YPosition) do
		    tempY[i] = PuzzLearn.MemoryStructure.RecursiveIncrementCopy(v, incrementValue, incrementNumber)
		end
		
		local tempInfo = PuzzLearn.MemoryStructure.RecursiveIncrementCopy(address.Information, incrementValue, incrementNumber)
		
		return PuzzLearn.MemoryStructure.BuildObject(newDescription, tempX, tempY, tempInfo, address.FixedValue)
	elseif address.Type == PuzzLearn.MemoryStructure.Category.INFORMATION then
	    return PuzzLearn.MemoryStructure.BuildInfo(newDescription, address.Address + increment, address.ValueCategory, address.NilValue)
	elseif address.Type == PuzzLearn.MemoryStructure.Category.INTEGER then
	    return PuzzLearn.MemoryStructure.BuildInteger(newDescription, address.Address + increment, address.Offset, address.Multiply)
	end
	
	return nil
end

function PuzzLearn.MemoryStructure.BuildRegion(description, startAddresses, increment, startAddress, finalAddress)
	local temp = {}
    temp.Type = PuzzLearn.MemoryStructure.Category.REGION
	temp.Description = description
	temp.Addresses = {}
	local i = 1
	local addressIndex = 1
	while startAddress + (i - 1) * increment <= finalAddress do
	    for j, v in ipairs(startAddresses) do
			temp.Addresses[addressIndex] = PuzzLearn.MemoryStructure.RecursiveIncrementCopy(v, increment, i)
			addressIndex = addressIndex + 1
		end
		i = i + 1
	end
	
	return temp
end

function PuzzLearn.MemoryStructure.BuildXYRegion(description, startAddress, width, xOffset, height, yOffset, rowOffset, valueCategory, nilValue)
    local temp = {}
	temp.Type = PuzzLearn.MemoryStructure.Category.XYREGION
	temp.Description = description
	temp.StartAddress = startAddress
	temp.Width = width
	temp.XOffset = xOffset
	temp.Height = height
	temp.YOffset = yOffset
	temp.RowOffset = rowOffset
	temp.ValueCategory = valueCategory
	temp.NilValue = nilValue
	
	return temp
end

--[[

AddressPlane
	Address[] Addresses
	IntegerAddress XCenterAddress		For cases where the decision making process should be centered around a specific address
	int XMin		                    If _CenterAddress = nil, these will be absolute; otherwise, they will be relative.
	int XMax
	IntegerAddress YCenterAddress
	int YMin
	int YMax
	int DefaultValue
	int MaxValue

function GetTable(AddressPlane database)


--]]

function PuzzLearn.MemoryStructure.BuildAddressPlane(addresses, xCenter, xMin, xMax, yCenter, yMin, yMax, defaultValue, maxValue)
	local temp = {}
	temp.Addresses = addresses
	temp.XCenter = xCenter
	temp.XMin = xMin
	temp.XMax = xMax
	temp.YCenter = yCenter
	temp.YMin = yMin
	temp.YMax = yMax
	temp.DefaultValue = defaultValue
	temp.MaxValue = maxValue
	
	
	return temp
end

function PuzzLearn.MemoryStructure.ProcessIntegerAddress(intAddr)
	local intByte = memory.readbyte(intAddr.Address)
	local intValue = math.floor((intByte + intAddr.Offset) * intAddr.Multiply + 0.5)
	return intValue
end

function PuzzLearn.MemoryStructure.ProcessIntegerAddressArray(intAddresses)
	local value = 0
	for i, v in ipairs(intAddresses) do
		value = value + PuzzLearn.MemoryStructure.ProcessIntegerAddress(v)
	end
	return value
end

function PuzzLearn.MemoryStructure.ProcessAddress(processTable, xMin, xMax, yMin, yMax, address)
	if address.Type == PuzzLearn.MemoryStructure.Category.OBJECT then
		local xValue = PuzzLearn.MemoryStructure.ProcessIntegerAddressArray(address.XPosition)
		local yValue = PuzzLearn.MemoryStructure.ProcessIntegerAddressArray(address.YPosition)
		
		if xValue >= xMin and xValue <= xMax and yValue >= yMin and yValue <= yMax then
			local xIndex = xValue - xMin + 1
			local yIndex = yValue - yMin + 1
			
			if address.FixedValue ~= nil then
				processTable[xIndex][yIndex] = address.FixedValue
			else
				local infoByte = memory.readbyte(address.Information.Address)
				local infoValue = address.Information.ValueCategory[infoByte] or address.Information.NilValue
				if infoValue ~= nil then
					processTable[xIndex][yIndex] = infoValue
				end
			end
		end
	elseif address.Type == PuzzLearn.MemoryStructure.Category.REGION then
	    i = 1
		for i,v in ipairs(address.Addresses) do
			PuzzLearn.MemoryStructure.ProcessAddress(processTable, xMin, xMax, yMin, yMax, v)
		end
	elseif address.Type == PuzzLearn.MemoryStructure.Category.XYREGION then
		for i = 1, address.Width, 1 do
			local xValue = i - 1 + address.XOffset
			for j = 1, address.Height, 1 do
				local yValue = j - 1 + address.YOffset
				if xValue >= xMin and xValue <= xMax and yValue >= yMin and yValue <= yMax then
					local xIndex = xValue - xMin + 1
					local yIndex = yValue - yMin + 1
					
					local tempAddress = address.StartAddress + i - 1 + (j - 1)*address.RowOffset
					local addressByte = memory.readbyte(tempAddress)
					local tableValue = address.ValueCategory[addressByte] or address.NilValue
					
					if tableValue ~= -1 then
						processTable[xIndex][yIndex] = tableValue
					end
				end
			end
		end
	end
end

function PuzzLearn.MemoryStructure.ProcessAddressPlane(addressPlane)
	local xMin = 0
	local xMax = 0
	local yMin = 0
	local yMax = 0
	
	if addressPlane.XCenter == nil then
	    xMin = addressPlane.XMin
		xMax = addressPlane.XMax
	else
		local xCenterValue = PuzzLearn.MemoryStructure.ProcessIntegerAddress(addressPlane.XCenter)
		xMin = xCenterValue + addressPlane.XMin
		xMax = xCenterValue + addressPlane.XMax
	end
	
	if addressPlane.YCenter == nil then
	    yMin = addressPlane.YMin
		yMax = addressPlane.YMax
	else
		local yCenterValue = PuzzLearn.MemoryStructure.ProcessIntegerAddress(addressPlane.YCenter)
		yMin = yCenterValue + addressPlane.YMin
		yMax = yCenterValue + addressPlane.YMax
	end
	
	local xRange = xMax - xMin + 1
	local yRange = yMax - yMin + 1
	
	local processedTable = {}
	for i=1, xRange, 1 do
		processedTable[i] = {}
		for j=1, yRange, 1 do
			processedTable[i][j] = addressPlane.DefaultValue
		end
	end
	
	for i,v in ipairs(addressPlane.Addresses) do
		PuzzLearn.MemoryStructure.ProcessAddress(processedTable, xMin, xMax, yMin, yMax, v)
	end
	
	return processedTable, xMax - xMin + 1, yMax - yMin + 1
end

function PuzzLearn.MemoryStructure.AddPlaneToResultArray(addressPlane, resultArray)
	local processedTable = PuzzLearn.MemoryStructure.ProcessAddressPlane(addressPlane)
	local inputYDimension = addressPlane.YMax - addressPlane.YMin + 1
	local inputXDimension = addressPlane.XMax - addressPlane.XMin + 1
	
	for iy = 1, inputYDimension do
		for ix = 1, inputXDimension do
			for iVal = 1, addressPlane.MaxValue do
				if processedTable[ix][iy] == iVal then
					resultArray[#resultArray + 1] = 1
				else
					resultArray[#resultArray + 1] = 0
				end
			end
		end
	end
end

function PuzzLearn.MemoryStructure.AddInfoAddressToResultArray(infoAddress, resultArray)
	local initialLength = #resultArray
	
	for i = initialLength + 1, initialLength + infoAddress.MaxValue do
		resultArray[i] = 0
	end
	
	local infoByte = memory.readbyte(infoAddress.Address)
	local infoVal = infoAddress.ValueCategory[infoByte] 
	if not infoVal then infoVal = infoAddress.NilValue end
	
	if infoVal and infoVal > 0 and infoVal <= infoAddress.MaxValue then
		resultArray[initialLength + infoVal] = 1
	end
end

--[[
	AddressDatabase
	AddressPlane[] AddressPlanes
	InfoAddress[] InfoAddresses
	IntegerAddress[] ScoreAddresses
	int EndAddress
	int EndValue
	int[] ValueColors
--]]

function PuzzLearn.MemoryStructure.BuildAddressDatabase(addressPlanes, infoAddresses, scoreAddresses, endAddress, endValue, valueColors)
	local temp = {}
	temp.AddressPlanes = addressPlanes
	temp.InfoAddresses = infoAddresses
	temp.ScoreAddresses = scoreAddresses
	temp.EndAddress = endAddress
	temp.EndValue = endValue
	temp.ValueColors = valueColors
	
	return temp	
end

function PuzzLearn.MemoryStructure.ProcessAddressDatabase(addressDatabase)
	local resultArray = {}
	
	for i,plane in ipairs(addressDatabase.AddressPlanes) do
		PuzzLearn.MemoryStructure.AddPlaneToResultArray(plane, resultArray)
	end
	
	for i,info in ipairs(addressDatabase.InfoAddresses) do
		PuzzLearn.MemoryStructure.AddInfoAddressToResultArray(info, resultArray)
	end
	
	resultArray[#resultArray + 1] = 1
	
	return resultArray
end

function PuzzLearn.MemoryStructure.GetResultArrayLength(addressDatabase)
	local length = 1	-- Default of 1 includes the bias node
	
	for i,plane in ipairs(addressDatabase.AddressPlanes) do
		length = length + (plane.XMax - plane.XMin + 1) * (plane.YMax - plane.YMin + 1) * plane.MaxValue
	end
	
	for i,info in ipairs(addressDatabase.InfoAddresses) do
		length = length + info.MaxValue
	end
	
	return length
end

function PuzzLearn.MemoryStructure.RunEnded(addressDatabase)
	return memory.readbyte(addressDatabase.EndAddress) == addressDatabase.EndValue
end

function PuzzLearn.MemoryStructure.ProcessScore(addressDatabase)
	return PuzzLearn.MemoryStructure.ProcessIntegerAddressArray(addressDatabase.ScoreAddresses)
end
