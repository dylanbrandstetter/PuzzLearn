using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    class ObjectFormManager : IObjectFormManager
    {
        bool xPending;
        ISharedManager sharedManager;
        IList<IStructureObserver<ObjectBlock>> observers;
        BindingList<IntegerAddress> xAddresses;
        BindingList<IntegerAddress> yAddresses;
        InformationAddress info;
        ObjectBlock oldBlock;
        ObjectBlock newBlock;

        public ObjectFormManager(ISharedManager sm, ObjectBlock o = null)
        {
            observers = new List<IStructureObserver<ObjectBlock>>();
            oldBlock = o;
            sharedManager = sm;
            xAddresses = new BindingList<IntegerAddress>();
            yAddresses = new BindingList<IntegerAddress>();
            xPending = false;

            if (o != null)
            {
                if (o.Information == null)
                    info = null;
                else

                    info = (InformationAddress)o.Information.Clone();
                foreach (var x in o.XAddresses)
                    xAddresses.Add((IntegerAddress)x.Clone());
                foreach (var y in o.YAddresses)
                    yAddresses.Add((IntegerAddress)y.Clone());
            }
        }

        public void AddEditInfo(IWin32Window f)
        {
            InfoFormManager im = new InfoFormManager(info);
            im.Attach(this);

            string title;
            if (f == null)
                title = "PuzzLearn - Add Information";
            else
                title = "PuzzLearn - Edit Information";

            InformationAddressForm iaf = new InformationAddressForm(im, sharedManager, title, info);
            iaf.ShowDialog(f);
        }

        public void AddX(IWin32Window f)
        {
            xPending = true;

            IntFormManager im = new IntFormManager();
            im.Attach(this);

            IntegerAddressForm iaf = new IntegerAddressForm(im, sharedManager, "PuzzLearn - Add X");
            iaf.ShowDialog(f);
        }

        public void AddY(IWin32Window f)
        {
            IntFormManager im = new IntFormManager();
            im.Attach(this);

            IntegerAddressForm iaf = new IntegerAddressForm(im, sharedManager, "PuzzLearn - Add Y");
            iaf.ShowDialog(f);
        }

        public void Attach(IStructureObserver<ObjectBlock> o)
        {
            observers.Add(o);
        }

        public bool Confirm(decimal fixedValueDec, string description)
        {
            if (description == "")
                return false;

            int fixedValue = decimal.ToInt32(fixedValueDec);

            newBlock = new ObjectBlock(description, xAddresses, yAddresses, info, fixedValue);
            Notify();

            return true;
        }

        public void DeleteInfo()
        {
            info = null;
        }

        public void DeleteX(object x)
        {
            xAddresses.Remove((IntegerAddress)x);
        }

        public void DeleteY(object y)
        {
            yAddresses.Remove((IntegerAddress)y);
        }

        public void Detach(IStructureObserver<ObjectBlock> o)
        {
            observers.Remove(o);
        }

        private void editCoord(object coord, string title, IWin32Window f)
        {
            IntegerAddress ia = (IntegerAddress)coord;

            IntFormManager im = new IntFormManager(ia);
            im.Attach(this);

            IntegerAddressForm iaf = new IntegerAddressForm(im, sharedManager, title, ia);
            iaf.ShowDialog(f);
        }

        public void EditX(object x, IWin32Window f)
        {
            editCoord(x, "PuzzLearn - Edit X", f);
        }

        public void EditY(object y, IWin32Window f)
        {
            editCoord(y, "PuzzLearn - Edit Y", f);
        }

        public string GetInfoString()
        {
            if (info == null)
                return "(Not available)";
            else
                return info.ToString();
        }

        public BindingList<IntegerAddress> GetXAddresses()
        {
            return xAddresses;
        }

        public BindingList<IntegerAddress> GetYAddresses()
        {
            return yAddresses;
        }

        public void Notify()
        {
            foreach (var o in observers)
                o.Update(newBlock, oldBlock);
        }

        public void Update(InformationAddress newStruct, InformationAddress oldStruct)
        {
            info = newStruct;
        }

        public void Update(IntegerAddress newStruct, IntegerAddress oldStruct)
        {
            if (oldStruct == null)
            {
                if (xPending)
                {
                    xPending = false;
                    xAddresses.Add(newStruct);
                }
                else
                {
                    yAddresses.Add(newStruct);
                }
            }
            else
            {
                oldStruct.CopyValues(newStruct);
            }
        }
    }
}
