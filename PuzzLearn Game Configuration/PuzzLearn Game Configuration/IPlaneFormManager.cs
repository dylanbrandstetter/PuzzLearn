using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IPlaneFormManager : IStructureSubject<AddressPlane>, IStructureObserver<AddressRegion>, IStructureObserver<XYRegion>, IStructureObserver<ObjectBlock>, IStructureObserver<IntegerAddress>
    {
        void AddObject(IWin32Window f);
        void AddRegion(IWin32Window f);
        void AddXYRegion(IWin32Window f);
        void EditStruct(MemStructObject o, IWin32Window f);
        void DeleteStruct(MemStructObject o);

        void AddX(IWin32Window f);
        void EditX(IntegerAddress i, IWin32Window f);
        void DeleteX(IntegerAddress i);

        void AddY(IWin32Window f);
        void EditY(IntegerAddress i, IWin32Window f);
        void DeleteY(IntegerAddress i);
        
        bool Confirm(decimal xMinDec, decimal xMaxDec, decimal yMinDec, decimal yMaxDec, decimal defaultValueDec, string description);

        BindingList<MemStructObject> GetStructureSource();
        BindingList<IntegerAddress> GetXAddressSource();
        BindingList<IntegerAddress> GetYAddressSource();
    }
}
