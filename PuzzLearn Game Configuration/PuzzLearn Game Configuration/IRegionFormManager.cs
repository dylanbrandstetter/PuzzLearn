using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IRegionFormManager : IStructureSubject<AddressRegion>, IStructureObserver<AddressRegion>, IStructureObserver<ObjectBlock>
    {
        void AddObject(IWin32Window f);
        void AddRegion(IWin32Window f);
        void Edit(object mem, IWin32Window f);
        void Delete(object mem);

        bool Confirm(string startAdrStr, string endAdrStr, string description, decimal incrementDec);

        BindingList<MemStructObject> GetDataSource();
    }
}