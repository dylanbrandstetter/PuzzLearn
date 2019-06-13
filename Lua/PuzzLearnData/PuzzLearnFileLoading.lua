dofile("PuzzLearnData\\NeuralNetworkFunctions.lua")

PuzzLearn.FileManagement = {}

-- READING FILES

function PuzzLearn.FileManagement.ReadValueCategory(vcCount, valueCategories)
	for i = 1, vcCount do
		local vcLine = PuzzLearn.FileManagement.SplitLine()
		valueCategories[tonumber(vcLine[1])] = tonumber(vcLine[2])
	end
end

function PuzzLearn.FileManagement.ReadInformationAddress(infoLine)
	local desc = infoLine[2]
	local addr = tonumber(infoLine[3])
	local defVal = tonumber(infoLine[4])
	local maxVal = tonumber(infoLine[5])
	local vcCount = tonumber(infoLine[6])
	
	local valueCategories = {}
	PuzzLearn.FileManagement.ReadValueCategory(vcCount, valueCategories)
	
	return PuzzLearn.MemoryStructure.BuildInfo(desc, addr, valueCategories, defVal, maxVal)
end

function PuzzLearn.FileManagement.ReadIntegerAddress()
	local intLine = PuzzLearn.FileManagement.SplitLine()
	
	local desc = intLine[2]
	local addr = tonumber(intLine[3])
	local offset = tonumber(intLine[4])
	local mult = tonumber(intLine[5])
	
	return PuzzLearn.MemoryStructure.BuildInteger(desc, addr, offset, mult)
end

function PuzzLearn.FileManagement.ReadObject(objLine)
	local desc = objLine[2]
	local fixedVal = tonumber(objLine[3])
	local xCount = tonumber(objLine[4])
	local yCount = tonumber(objLine[5])
	local hasInfo = tonumber(objLine[6])
	
	local xAddr = {}
	for i = 1, xCount do
		table.insert(xAddr, PuzzLearn.FileManagement.ReadIntegerAddress())
	end
	
	local yAddr = {}
	for i = 1, yCount do
		table.insert(yAddr, PuzzLearn.FileManagement.ReadIntegerAddress())
	end
	
	local info = nil
	if hasInfo == 1 then
		local infoLine = PuzzLearn.FileManagement.SplitLine()
		info = PuzzLearn.FileManagement.ReadInformationAddress(infoLine)
	end
	
	return PuzzLearn.MemoryStructure.BuildObject(desc, xAddr, yAddr, info, fixedVal)
end

function PuzzLearn.FileManagement.ReadRegion(regLine)
	local desc = regLine[2]
	local startAddr = tonumber(regLine[3])
	local endAddr = tonumber(regLine[4])
	local increment = tonumber(regLine[5])
	local structCount = tonumber(regLine[6])
	
	local structs = {}
	for i = 1, structCount do
		local nextLine = PuzzLearn.FileManagement.SplitLine()
		local t = tonumber(nextLine[0])
		
		if     t == PuzzLearn.MemoryStructure.Category.OBJECT then
			table.insert(structs, PuzzLearn.FileManagement.ReadObject(nextLine))
		elseif t == PuzzLearn.MemoryStructure.Category.XYREGION then
			table.insert(structs, PuzzLearn.FileManagement.ReadXYRegion(nextLine))
		else
			error()
		end
	end
	
	return PuzzLearn.MemoryStructure.BuildRegion(desc, structs, increment, startAddr, endAddr)
end

function PuzzLearn.FileManagement.ReadXYRegion(xyLine)
	local desc = xyLine[2]
	local startAddr = tonumber(xyLine[3])
	local width = tonumber(xyLine[4])
	local xOffset = tonumber(xyLine[5])
	local height = tonumber(xyLine[6])
	local yOffset = tonumber(xyLine[7])
	local rowOffset = tonumber(xyLine[8])
	local defVal = tonumber(xyLine[9])
	local vcCount = tonumber(xyLine[10])
	
	local valueCategories = {}
	
	PuzzLearn.FileManagement.ReadValueCategory(vcCount, valueCategories)
	
	return PuzzLearn.MemoryStructure.BuildXYRegion(desc, startAddr, width, xOffset, height, yOffset, rowOffset, valueCategories, defVal)
end

function PuzzLearn.FileManagement.ReadAddressPlane(planeLine)
	local desc = planeLine[2]
	local xMin = tonumber(planeLine[3])
	local xMax = tonumber(planeLine[4])
	local yMin = tonumber(planeLine[5])
	local yMax = tonumber(planeLine[6])
	local dVal = tonumber(planeLine[7])
	local maxVal = tonumber(planeLine[8])
	local sCount = tonumber(planeLine[9])
	local xCount = tonumber(planeLine[10])
	local yCount = tonumber(planeLine[11])
	
	local structs = {}
	for i = 1, sCount do
		local nextLine = PuzzLearn.FileManagement.SplitLine()
		
		local t = tonumber(nextLine[1])
		
		if     t == PuzzLearn.MemoryStructure.Category.OBJECT then
			table.insert(structs, PuzzLearn.FileManagement.ReadObject(nextLine))
		elseif t == PuzzLearn.MemoryStructure.Category.REGION then
			table.insert(structs, PuzzLearn.FileManagement.ReadRegion(nextLine))
		elseif t == PuzzLearn.MemoryStructure.Category.XYREGION then
			table.insert(structs, PuzzLearn.FileManagement.ReadXYRegion(nextLine))
		else
			error()
		end
	end
	
	local xCenter = {}
	for i = 1, xCount do
		table.insert(xCenter, PuzzLearn.FileManagement.ReadIntegerAddress())
	end
	
	local yCenter = {}
	for i = 1, yCount do
		table.insert(yCenter, PuzzLearn.FileManagement.ReadIntegerAddress())
	end	
	
	return PuzzLearn.MemoryStructure.BuildAddressPlane(structs, xCenter, xMin, xMax, yCenter, yMin, yMax, dVal, maxVal)
end

function PuzzLearn.FileManagement.ReadDatabase()
	local dbLine = PuzzLearn.FileManagement.SplitLine()
	
	local endAddr = tonumber(dbLine[1])
	local endVal = tonumber(dbLine[2])
	local population = tonumber(dbLine[3])
	local stagnantGen = tonumber(dbLine[4])
	local timeout = tonumber(dbLine[5])
	local stagnantTimeout = tonumber(dbLine[6])
	local colorCount = tonumber(dbLine[7])
	local buttonCount = tonumber(dbLine[8])
	local structCount = tonumber(dbLine[9])
	local scoreCount = tonumber(dbLine[10])
	local releaseButtons = dbLine[11] == "1"
	
	local colors = {}
	for i = 1, colorCount do
		local colorLine = PuzzLearn.FileManagement.SplitLine()
		local col = 0xFF000000 + 0x010000 * tonumber(colorLine[2]) + 0x0100 * tonumber(colorLine[3]) + tonumber(colorLine[4])
		colors[tonumber(colorLine[1])] = col
	end
	
	local buttons = {}
	for i = 1, buttonCount do
		table.insert(buttons, PuzzLearn.FileManagement.FileToRead:read())
	end	
	
	local planes = {}
	local infos = {}
	for i = 1, structCount do
		local nextLine = PuzzLearn.FileManagement.SplitLine()
		local t = tonumber(nextLine[1])
		
		if     t == PuzzLearn.MemoryStructure.Category.ADDRESSPLANE then
			table.insert(planes, PuzzLearn.FileManagement.ReadAddressPlane(nextLine))
		elseif t == PuzzLearn.MemoryStructure.Category.INFORMATION then
			table.insert(infos, PuzzLearn.FileManagement.ReadInformationAddress(nextLine))
		else
			error()
		end
	end
	
	local scores = {}
	for i = 1, scoreCount do
		table.insert(scores, PuzzLearn.FileManagement.ReadIntegerAddress())
	end
	
	PuzzLearn.NeuralNetwork.Database = PuzzLearn.MemoryStructure.BuildAddressDatabase(planes, infos, scores, endAddr, endVal, colors)
	PuzzLearn.NeuralNetwork.Buttons = buttons
	PuzzLearn.NeuralNetwork.ReleaseButtons = releaseButtons

	PuzzLearn.NeuralNetwork.InputCount = PuzzLearn.MemoryStructure.GetResultArrayLength(PuzzLearn.NeuralNetwork.Database)
	PuzzLearn.NeuralNetwork.OutputCount = #PuzzLearn.NeuralNetwork.Buttons
	
	PuzzLearn.NeuralNetwork.Population = population
	PuzzLearn.NeuralNetwork.StagnantSpeciesThreshold = stagnantGen
	PuzzLearn.NeuralNetwork.FitnessTimeout = stagnantTimeout
	PuzzLearn.NeuralNetwork.TimeoutFrame = timeout
end

function PuzzLearn.FileManagement.ReadFile(filename)
	local readFile = io.open(filename, "r")
	if readFile ~= nil then
		PuzzLearn.FileManagement.FileToRead = readFile
		if not pcall(PuzzLearn.FileManagement.ReadDatabase) then
			io.close(readFile)
			return false
		end
		io.close(readFile)
		return true
	else
		return false
	end
end

function PuzzLearn.FileManagement.SplitLine()
	return PuzzLearn.SplitString(PuzzLearn.FileManagement.FileToRead:read(), ",")
end

-- FORMS

function PuzzLearn.FileManagement.RunNewSessionWindow()
	PuzzLearn.FileManagement.SelectedState = ""
	PuzzLearn.FileManagement.SelectedConfig = ""
	
	local function selectConfigFunc()
		PuzzLearn.FileManagement.ConfigPressed = true
	end
	
	local function selectStateFunc()
		PuzzLearn.FileManagement.StatePressed = true
	end
	
	local function confirmFunc()
		PuzzLearn.FileManagement.ConfirmPressed = true
	end
	
	local function cancelFunc()
		PuzzLearn.FileManagement.CancelPressed = true
	end
	
	PuzzLearn.FileManagement.NewSessionForm = forms.newform(633, 250, "PuzzLearn - New Session", cancelFunc)
	PuzzLearn.FileManagement.ConfigLabel = forms.label(PuzzLearn.FileManagement.NewSessionForm, "Configuration:", 20, 25, 75, 20)
	PuzzLearn.FileManagement.StateLabel = forms.label(PuzzLearn.FileManagement.NewSessionForm, "State:", 20, 75, 75, 20)
	PuzzLearn.FileManagement.FilenameLabel = forms.label(PuzzLearn.FileManagement.NewSessionForm, "File name:", 20, 125, 75, 20)
	PuzzLearn.FileManagement.ConfigContents = forms.label(PuzzLearn.FileManagement.NewSessionForm, "(Not specified)", 100, 25, 400, 50)
	PuzzLearn.FileManagement.StateContents = forms.label(PuzzLearn.FileManagement.NewSessionForm, "(Not specified)", 100, 75, 400, 50)
	PuzzLearn.FileManagement.FilenameTextBox = forms.textbox(PuzzLearn.FileManagement.NewSessionForm, "", 494, 20, nil, 100, 125)
	PuzzLearn.FileManagement.ConfigButton = forms.button(PuzzLearn.FileManagement.NewSessionForm, "Select", selectConfigFunc, 520, 25)
	PuzzLearn.FileManagement.StateButton = forms.button(PuzzLearn.FileManagement.NewSessionForm, "Select", selectStateFunc, 520, 75)
	PuzzLearn.FileManagement.ConfirmButton = forms.button(PuzzLearn.FileManagement.NewSessionForm, "Confirm", confirmFunc, 150, 175)
	PuzzLearn.FileManagement.CancelButton = forms.button(PuzzLearn.FileManagement.NewSessionForm, "Cancel", cancelFunc, 392, 175)
	
	local running = true
	while running do
		PuzzLearn.FileManagement.CancelPressed = false
		PuzzLearn.FileManagement.ConfigPressed = false
		PuzzLearn.FileManagement.StatePressed = false
		PuzzLearn.FileManagement.ConfirmPressed = false
		
		coroutine.yield()
		
		if PuzzLearn.FileManagement.CancelPressed then			
			forms.destroy(PuzzLearn.FileManagement.NewSessionForm)
			running = false
		elseif PuzzLearn.FileManagement.ConfigPressed then
			PuzzLearn.FileManagement.SelectedConfig = forms.openfile(nil, nil, "PuzzLearn config files (*.plcf)|*.plcf|All files (*.*)|*.*")
			
			local text = PuzzLearn.FileManagement.SelectedConfig
			if text == "" then text = "(Not specified)" end
			forms.settext(PuzzLearn.FileManagement.ConfigContents, text)
		elseif PuzzLearn.FileManagement.StatePressed then
			PuzzLearn.FileManagement.SelectedState = forms.openfile(nil, nil, "State files (*.state)|*.state|All files (*.*)|*.*")
			
			local text = PuzzLearn.FileManagement.SelectedState
			if text == "" then text = "(Not specified)" end
			forms.settext(PuzzLearn.FileManagement.StateContents, text)
		elseif PuzzLearn.FileManagement.ConfirmPressed then
			local text = forms.gettext(PuzzLearn.FileManagement.FilenameTextBox)
			if PuzzLearn.FileManagement.SelectedConfig ~= "" and PuzzLearn.FileManagement.SelectedState ~= "" and text ~= "" then			
				forms.destroy(PuzzLearn.FileManagement.NewSessionForm)
				PuzzLearn.FileManagement.NewSessionForm = nil
				PuzzLearn.FileManagement.ConfigLabel = nil
				PuzzLearn.FileManagement.StateLabel = nil
				PuzzLearn.FileManagement.FilenameLabel = nil
				PuzzLearn.FileManagement.ConfigContents = nil
				PuzzLearn.FileManagement.StateContents = nil
				PuzzLearn.FileManagement.FilenameTextBox = nil
				PuzzLearn.FileManagement.ConfigButton = nil
				PuzzLearn.FileManagement.StateButton = nil
				PuzzLearn.FileManagement.ConfirmButton = nil
				PuzzLearn.FileManagement.CancelButton = nil
				return text
			end		
		end
	end
end
