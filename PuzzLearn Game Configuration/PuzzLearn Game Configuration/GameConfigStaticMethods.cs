using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public static class GameConfigStaticMethods
    {
        public static T SameType<T>(object obj)
        {
            if (typeof(T) == obj.GetType())
                return (T)obj;
            else
                return default(T);
        }

        public static void ShowIncompleteDialog(Form owner)
        {
            MessageBox.Show(owner, "Please input all required (*) data.", "Error", MessageBoxButtons.OK);
        }
    }
}
