dofile("neuralNetworkFunctionsV2.lua")
emu.limitframerate(true)


onExit = function ()
	onExit()
	forms.destroy(form)
end

function uitest_learnfunc()
	forms.destroy(uitest_form)
	uitest_learning = true
end

function uitest_fittestfunc()
	forms.destroy(uitest_form)
	uitest_fittest = true	
end

uitest_form = forms.newform(400, 300, "Main menu test")
uitest_learnButton = forms.button(uitest_form, "Learn", uitest_learnfunc, 50, 200)
uitest_fittestButton = forms.button(uitest_form, "Fittest", uitest_fittestfunc, 250, 200)
uitest_textLabel = forms.label(uitest_form, "Select an option", 150, 50, 0xFF000000)
-- uitest_pictureBoxHandle = forms.pictureBox(uitest_form, 0,0, 10, 10)
-- forms.clear(uitest_pictureBoxHandle, 0xFFFF0000)
-- forms.drawRectangle(uitest_pictureBoxHandle, 0,0,9,9, 0xFF00FF00,0xFF0000FF)

uitest_learning = false
uitest_fittest = false

while true do
	if uitest_learning then
		emu.limitframerate(false)
		
		createDisplayForm()
		
		if not loadFile(SessionFileName) then
			initializePool()
		end

		stateCheck = io.open(StateName, "r")
		if stateCheck == nil then
			error()
		end
		
		while true do
			processPool()
			saveFile(PreviousGenerationFileName .. GenePool.Generation .. ".txt")
			saveFile(PreviousGenerationFileName .. ".txt")
			newGeneration()
		end
	elseif uitest_fittest then
		SessionFileName = "proofOfConceptV2_ArchivePool.txt"
		
		createDisplayForm()
		
		if loadFile(SessionFileName) then
			-- Find fittest genome
			fittestFitness = 0
			for i,species in ipairs(GenePool.Species) do
				for j,genome in ipairs(species.Genomes) do
					if genome.Fitness > fittestFitness then
						fittestFitness = genome.Fitness
						fittestGenome = genome
						break
					end
					if fittestGenome ~= nil then break end
				end
			end

			DisplayString = "Fittest Genome"

			if fittestGenome == nil then error() end
			
			processGenome(fittestGenome)
		end		
		neuralNetworkDisplayForm = nil
	else
		emu.frameadvance()
	end
	
	uitest_learning = false
	uitest_fittest = false
	
	coroutine.yield()
end