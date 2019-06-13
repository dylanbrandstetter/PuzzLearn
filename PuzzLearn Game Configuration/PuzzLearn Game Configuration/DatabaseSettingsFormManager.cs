using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class DatabaseSettingsFormManager : IDatabaseSettingsFormManager
    {
        private BindingList<CategoryColor> categoryColors;
        private BindingList<string> buttons;
        private List<string> validButtons;
        private DatabaseSettings oldSettings;

        private bool edited;
        public bool Edited { get => edited; private set { } }

        public DatabaseSettingsFormManager(DatabaseSettings os)
        {
            oldSettings = os;

            categoryColors = new BindingList<CategoryColor>();
            foreach (var c in os.CategoryColors)
                categoryColors.Add((CategoryColor)c.Clone());

            buttons = new BindingList<string>();
            foreach (var s in os.Buttons)
                buttons.Add(s);

            validButtons = new List<string>();
            string[] prefixes = { "P1 ", "P2 ", "P3 ", "P4 " };
            string[] suffixes = { "Left", "Right", "Up", "Down", "A", "B", "X", "Y", "L", "R", "Start", "Select" };

            foreach (string p in prefixes)
            {
                foreach (string s in suffixes)
                {
                    validButtons.Add(p + s);
                }
            }
        }

        public void AddCategory()
        {
            categoryColors.Add(new CategoryColor(Color.White, categoryColors.Count));
        }

        public bool Confirm(string endAddressString, decimal endValueDecimal,
            decimal populationDecimal, decimal stagnantGenerationsDecimal,
            decimal timeout, decimal stagnantTimeout, bool release)
        {
            if (endAddressString == "")
                return false;

            int endAddress = Convert.ToInt32(endAddressString, 16);
            int endValue = decimal.ToInt32(endValueDecimal);
            int population = decimal.ToInt32(populationDecimal);
            int stagnantGenerations = decimal.ToInt32(stagnantGenerationsDecimal);

            oldSettings.CategoryColors = categoryColors;
            oldSettings.Buttons = buttons;
            oldSettings.EndAddress = endAddress;
            oldSettings.EndValue = endValue;
            oldSettings.Population = population;
            oldSettings.StagnantGeneration = stagnantGenerations;
            oldSettings.Timeout = timeout;
            oldSettings.StagnantTimeout = stagnantTimeout;
            oldSettings.ReleaseButtons = release;

            edited = true;

            return true;
        }

        public void EditColor(object color, IWin32Window f)
        {
            CategoryColor cc = (CategoryColor)color;

            ColorDialog cd = new ColorDialog();
            cd.Color = cc.Color;

            DialogResult dr = cd.ShowDialog(f);
            if (dr == DialogResult.OK)
                cc.Color = cd.Color;
        }

        public BindingList<CategoryColor> GetCategoryColors()
        {
            return categoryColors;
        }

        public void AddButton(string buttonName)
        {
            if (!buttons.Contains(buttonName))
                buttons.Add(buttonName);
        }

        public void RemoveButton(object button)
        {
            buttons.Remove(((Tuple<string>)button).Item1);
        }

        public object UpdateButtons()
        {
            return buttons.Select(s => new Tuple<string>(s)).ToList();
        }

        public List<string> GetValidButtons()
        {
            return validButtons;
        }
    }
}
