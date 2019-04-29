using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class SharedManager : ISharedManager
    {
        public SharedManager() { }

        public void DescriptionCharacterCheck(KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
        }

        public void HexCharacterCheck(KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), "[0-9a-fA-F\b]"))
                e.Handled = true;
            else
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
