using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IDatabaseSettingsFormManager
    {
        void AddCategory();
        void EditColor(object color, IWin32Window f);

        void AddButton(string buttonName);
        void RemoveButton(object button);
        object UpdateButtons();
        List<string> GetValidButtons();

        bool Confirm(string endAddressString, decimal endValueDecimal, decimal populationDecimal, decimal staleGenerationsDecimal, decimal timeout, decimal staleTimeout);

        BindingList<CategoryColor> GetCategoryColors();
    }
}
