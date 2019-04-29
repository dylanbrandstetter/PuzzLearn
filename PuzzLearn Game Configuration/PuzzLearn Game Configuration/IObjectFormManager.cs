using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IObjectFormManager : IStructureObserver<IntegerAddress>, IStructureObserver<InformationAddress>, IStructureSubject<ObjectBlock>
    {
        void AddX(IWin32Window f);
        void EditX(object x, IWin32Window f);
        void DeleteX(object x);
        BindingList<IntegerAddress> GetXAddresses();

        void AddY(IWin32Window f);
        void EditY(object y, IWin32Window f);
        void DeleteY(object y);
        BindingList<IntegerAddress> GetYAddresses();

        void AddEditInfo(IWin32Window f);
        void DeleteInfo();
        string GetInfoString();

        bool Confirm(decimal fixedValueDec, string description);
    }
}
