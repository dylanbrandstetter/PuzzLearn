dofile("PuzzLearnData\\PuzzLearnFileLoading.lua")
emu.limitframerate(true)

PuzzLearn.MainMenu = {}

-- Creates the main menu form.
function PuzzLearn.MainMenu.BuildMenuForm()
	local function newsessfunc()
		PuzzLearn.MainMenu.NewSession = true	
	end

	local function loadsessfunc()
		PuzzLearn.MainMenu.LoadSession = true
	end
	
	PuzzLearn.MainMenu.Form = forms.newform(400, 200, "PuzzLearn")
	PuzzLearn.MainMenu.NewSessionButton = forms.button(PuzzLearn.MainMenu.Form, "New Session", newsessfunc, 50, 100, 100, 23)
	PuzzLearn.MainMenu.LoadSessionButton = forms.button(PuzzLearn.MainMenu.Form, "Load Session", loadsessfunc, 225, 100, 100, 23)
	PuzzLearn.MainMenu.TextLabel = forms.label(PuzzLearn.MainMenu.Form, "Select an option:", 150, 50)
end

PuzzLearn.MainMenu.BuildMenuForm()

while true do
	PuzzLearn.MainMenu.LoadSession = false
	PuzzLearn.MainMenu.NewSession = false
	
	coroutine.yield()
	
	if PuzzLearn.MainMenu.NewSession then
		forms.destroy(PuzzLearn.MainMenu.Form)

		local fileName = PuzzLearn.FileManagement.RunNewSessionWindow()
		if fileName then
			local stateCheck = io.open(PuzzLearn.FileManagement.SelectedState, "r")
			if stateCheck ~= nil then
				io.close(stateCheck)
				if PuzzLearn.FileManagement.ReadFile(PuzzLearn.FileManagement.SelectedConfig) then
					if string.sub(fileName, -4) ~= ".pls" then
						fileName = fileName .. ".pls"
					end
					
					local splitName = PuzzLearn.SplitString(fileName, "\\")
					local finalFilePart = splitName[#splitName]
					
					PuzzLearn.NeuralNetwork.ArchiveLocation = "PuzzLearnData\\ArchivedSessions\\" .. string.sub(finalFilePart, 1, #finalFilePart - 4) .. "_archive"
					PuzzLearn.NeuralNetwork.StateName = PuzzLearn.FileManagement.SelectedState
					PuzzLearn.NeuralNetwork.SessionFileName = fileName
					PuzzLearn.NeuralNetwork.ConfigFile = PuzzLearn.FileManagement.SelectedConfig
					
					PuzzLearn.NeuralNetwork.CreateDisplayForm()
					PuzzLearn.NeuralNetwork.CreateFirstNetworkPool()
					emu.limitframerate(false)
					PuzzLearn.NeuralNetwork.ProcessGenerations()				
					emu.limitframerate(true)
				end
			end
		end
		
		PuzzLearn.MainMenu.BuildMenuForm()
	elseif PuzzLearn.MainMenu.LoadSession then
		forms.destroy(PuzzLearn.MainMenu.Form)
		local fileName = forms.openfile(nil, nil, "PuzzLearn session files (*.pls)|*.pls|All files (*.*)|*.*")
		if fileName ~= "" then
			emu.limitframerate(false)
			PuzzLearn.NeuralNetwork.RunFile(fileName)
			emu.limitframerate(true)
		end
		PuzzLearn.MainMenu.BuildMenuForm()
	else
		emu.frameadvance()
	end
end