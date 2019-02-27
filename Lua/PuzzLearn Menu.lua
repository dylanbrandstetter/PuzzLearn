dofile("neuralNetworkFunctionsV2.lua")
emu.limitframerate(true)


onExit = function ()
	onExit()
	forms.destroy(pzlrn_form)
end

function pzlrn_newsessfunc()
end

function pzlrn_loadsessfunc()
	forms.destroy(pzlrn_form)
	pzlrn_loadsess = true	
end

function pzlrn_buildMenuForm()
	pzlrn_form = forms.newform(400, 200, "Main menu test")
	pzlrn_newSessButton = forms.button(pzlrn_form, "New Session", pzlrn_newsessfunc, 50, 100, 100, 23)
	pzlrn_loadSessButton = forms.button(pzlrn_form, "Load Session", pzlrn_loadsessfunc, 225, 100, 100, 23)
	pzlrn_textLabel = forms.label(pzlrn_form, "Select an option", 150, 50, 0xFF000000)
	-- pzlrn_pictureBoxHandle = forms.pictureBox(pzlrn_form, 0,0, 10, 10)
	-- forms.clear(pzlrn_pictureBoxHandle, 0xFFFF0000)
	-- forms.drawRectangle(pzlrn_pictureBoxHandle, 0,0,9,9, 0xFF00FF00,0xFF0000FF)

	pzlrn_learning = false
	pzlrn_fittest = false
end

pzlrn_buildMenuForm()

while true do
	pzlrn_loadsess = false
	
	coroutine.yield()
	
	if pzlrn_loadsess then
		emu.limitframerate(false)
		
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
		
		emu.limitframerate(true)
		pzlrn_buildMenuForm()
	else
		emu.frameadvance()
	end
end