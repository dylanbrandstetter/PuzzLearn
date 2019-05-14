using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface ISharedManager
    {
        void DescriptionPressCheck(KeyPressEventArgs e);
        void HexPressCheck(KeyPressEventArgs e);
        void SqlPressCheck(KeyPressEventArgs e);

        void DescriptionDownCheck(object sender, KeyEventArgs e);
        void HexDownCheck(object sender, KeyEventArgs e);
        void SqlDownCheck(object sender, KeyEventArgs e);
    }
}
