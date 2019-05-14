using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IMainMenuFormManager : IStructureObserver<AddressPlane>, IStructureObserver<InformationAddress>, IStructureObserver<IntegerAddress>
    {
        void AddPlane(IWin32Window f);
        void AddInfo(IWin32Window f);
        void EditStruct(MemStructObject m, IWin32Window f);
        void DeleteStruct(MemStructObject m);
        BindingList<MemStructObject> GetDataSource();

        void AddScore(IWin32Window f);
        void EditScore(IntegerAddress i, IWin32Window f);
        void DeleteScore(IntegerAddress i);
        BindingList<IntegerAddress> GetScoreSource();

        void EditDatabaseSettings(IWin32Window f);

        void New(IWin32Window f);
        void Open(IWin32Window f);
        void Save(IWin32Window f);
        void SaveAs(IWin32Window f);
        bool SaveCheck(IWin32Window f);

        void Download(IWin32Window f);
        void MyFiles(IWin32Window f);
    }
}
