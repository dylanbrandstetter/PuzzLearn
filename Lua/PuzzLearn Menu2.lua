dofile("NeuralNetworkFunctions.lua")
emu.limitframerate(true)

PuzzLearn.MainMenu = {}

-- Creates the main menu form.
function PuzzLearn.MainMenu.BuildMenuForm()
	local function newsessfunc()
	end

	local function loadsessfunc()
		forms.destroy(PuzzLearn.MainMenu.Form)
		PuzzLearn.MainMenu.LoadSession = true	
	end
	
	PuzzLearn.MainMenu.Form = forms.newform(400, 200, "Main menu test")
	PuzzLearn.MainMenu.NewSessionButton = forms.button(PuzzLearn.MainMenu.Form, "New Session", newsessfunc, 50, 100, 100, 23)
	PuzzLearn.MainMenu.LoadSessionButton = forms.button(PuzzLearn.MainMenu.Form, "Load Session", loadsessfunc, 225, 100, 100, 23)
	PuzzLearn.MainMenu.TextLabel = forms.label(PuzzLearn.MainMenu.Form, "Select an option", 150, 50, 0xFF000000)
	-- pzlrn_pictureBoxHandle = forms.pictureBox(PuzzLearn.MainMenu.Form, 0,0, 10, 10)
	-- forms.clear(pzlrn_pictureBoxHandle, 0xFFFF0000)
	-- forms.drawRectangle(pzlrn_pictureBoxHandle, 0,0,9,9, 0xFF00FF00,0xFF0000FF)
end

PuzzLearn.MainMenu.BuildMenuForm()

while true do
	PuzzLearn.MainMenu.LoadSession = false
	
	coroutine.yield()
	
	if PuzzLearn.MainMenu.LoadSession then
		emu.limitframerate(false)
		
		PuzzLearn.NeuralNetwork.CreateDisplayForm()
		
		if not PuzzLearn.NeuralNetwork.LoadFile(PuzzLearn.NeuralNetwork.SessionFileName) then
			PuzzLearn.NeuralNetwork.InitializePool()
		end

		stateCheck = io.open(PuzzLearn.NeuralNetwork.StateName, "r")
		if stateCheck == nil then
			error()
		end
		io.close(stateCheck)
		
		emu.limitframerate(false)
		PuzzLearn.NeuralNetwork.ProcessGenerations()
		
		emu.limitframerate(true)
		PuzzLearn.MainMenu.BuildMenuForm()
	else
		emu.frameadvance()
	end
end