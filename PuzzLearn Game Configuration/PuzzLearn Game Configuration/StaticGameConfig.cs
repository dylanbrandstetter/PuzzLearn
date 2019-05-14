using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public static class StaticGameConfig
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
            MessageBox.Show(owner, "Please input all required (*) data.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public const string ConnectionString = "Server=tcp:puzzlearnserver.database.windows.net,1433;Initial Catalog=PuzzLearnDB;Persist Security Info=False;User ID=puzzlearnguest;Password=dorwssaPsseuG25;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
