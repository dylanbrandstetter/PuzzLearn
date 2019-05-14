using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IOnlineFilesManager
    {
        object GetFileSource();
        object SearchResults(string searchString);
        void Download(Form f, DataGridView view);
        void Upload(Form f, string filename);
        void UpdateFile(Form f, DataGridView view);
        void Delete(Form f, DataGridView view);
        void SignOut(Form f);
    }
}
