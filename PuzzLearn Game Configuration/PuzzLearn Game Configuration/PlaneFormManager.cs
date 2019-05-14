using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class PlaneFormManager : IPlaneFormManager
    {
        ISharedManager sharedManager;
        IList<IStructureObserver<AddressPlane>> observers;
        BindingList<MemStructObject> structures;
        BindingList<IntegerAddress> xAddresses;
        BindingList<IntegerAddress> yAddresses;

        AddressPlane oldPlane;
        AddressPlane newPlane;
        bool xPending;

        public PlaneFormManager(ISharedManager sm, AddressPlane op = null)
        {
            sharedManager = sm;
            observers = new List<IStructureObserver<AddressPlane>>();
            oldPlane = op;

            if (op != null)
            {
                structures = new BindingList<MemStructObject>(op.Structures.Select(o => (MemStructObject)(o.Clone())).ToList());
                xAddresses = new BindingList<IntegerAddress>(op.XCenterAddress.Select(o => (IntegerAddress)o.Clone()).ToList());
                yAddresses = new BindingList<IntegerAddress>(op.YCenterAddress.Select(o => (IntegerAddress)o.Clone()).ToList());
            }
            else
            {
                structures = new BindingList<MemStructObject>();
                xAddresses = new BindingList<IntegerAddress>();
                yAddresses = new BindingList<IntegerAddress>();
            }

            xPending = false;
        }

        public void AddObject(IWin32Window f)
        {
            ObjectFormManager om = new ObjectFormManager(sharedManager);
            om.Attach(this);

            ObjectForm of = new ObjectForm(sharedManager, om, "PuzzLearn - Add Object");
            of.ShowDialog(f);
        }

        public void AddRegion(IWin32Window f)
        {
            RegionFormManager rm = new RegionFormManager(sharedManager);
            rm.Attach(this);

            RegionForm rf = new RegionForm(sharedManager, rm, "PuzzLearn - Add Region");
            rf.ShowDialog(f);
        }

        public void AddX(IWin32Window f)
        {
            xPending = true;

            IIntFormManager intManager = new IntFormManager();
            intManager.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(intManager, sharedManager, "PuzzLearn - Add X Coordinate");
            intForm.ShowDialog(f);
        }

        public void AddXYRegion(IWin32Window f)
        {
            IXYFormManager xyManager = new XYFormManager();
            xyManager.Attach(this);

            XYRegionForm xyForm = new XYRegionForm(sharedManager, xyManager, "PuzzLearn - Add XY Region");
            xyForm.ShowDialog(f);
        }

        public void AddY(IWin32Window f)
        {
            IIntFormManager intManager = new IntFormManager();
            intManager.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(intManager, sharedManager, "PuzzLearn - Add Y Coordinate");
            intForm.ShowDialog(f);
        }

        public void Attach(IStructureObserver<AddressPlane> o)
        {
            observers.Add(o);
        }

        public bool Confirm(decimal xMinDec, decimal xMaxDec, decimal yMinDec, decimal yMaxDec, decimal defaultValueDec, string description)
        {
            if (description == "")
                return false;

            int xMin = (int)Math.Round(xMinDec);
            int xMax = (int)Math.Round(xMaxDec);
            int yMin= (int)Math.Round(yMinDec);
            int yMax = (int)Math.Round(yMaxDec);
            int defaultValue = (int)Math.Round(defaultValueDec);

            newPlane = new AddressPlane(structures, description, xMin, xMax, yMin, yMax, defaultValue, xAddresses, yAddresses);
            Notify();

            return true;
        }

        public void DeleteStruct(MemStructObject o)
        {
            structures.Remove(o);
        }

        public void DeleteX(IntegerAddress i)
        {
            xAddresses.Remove(i);
        }

        public void DeleteY(IntegerAddress i)
        {
            yAddresses.Remove(i);
        }

        public void Detach(IStructureObserver<AddressPlane> o)
        {
            observers.Remove(o);
        }

        public void EditStruct(MemStructObject o, IWin32Window f)
        {
            switch (o.Type)
            {
                case MemStructObject.ObjectType.XYREGION:
                    IXYFormManager xyManager = new XYFormManager((XYRegion)o);
                    xyManager.Attach(this);

                    XYRegionForm xyForm = new XYRegionForm(sharedManager, xyManager, "PuzzLearn - Edit XY Region", (XYRegion)o);
                    xyForm.ShowDialog(f);

                    break;

                case MemStructObject.ObjectType.REGION:
                    RegionFormManager rm = new RegionFormManager(sharedManager, (AddressRegion)(o));
                    rm.Attach(this);

                    RegionForm rf = new RegionForm(sharedManager, rm, "PuzzLearn - Edit Region", (AddressRegion)(o));
                    rf.ShowDialog(f);

                    break;

                case MemStructObject.ObjectType.OBJECT:
                    ObjectFormManager om = new ObjectFormManager(sharedManager, (ObjectBlock)o);
                    om.Attach(this);

                    ObjectForm of = new ObjectForm(sharedManager, om, "PuzzLearn - Edit Object", (ObjectBlock)o);
                    of.ShowDialog(f);

                    break;
            }
        }

        public void EditX(IntegerAddress i, IWin32Window f)
        {
            IIntFormManager intManager = new IntFormManager(i);
            intManager.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(intManager, sharedManager, "PuzzLearn - Edit X Coordinate", i);
            intForm.ShowDialog(f);
        }

        public void EditY(IntegerAddress i, IWin32Window f)
        {
            IIntFormManager intManager = new IntFormManager(i);
            intManager.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(intManager, sharedManager, "PuzzLearn - Edit Y Coordinate", i);
            intForm.ShowDialog(f);
        }

        public BindingList<MemStructObject> GetStructureSource()
        {
            return structures;
        }

        public BindingList<IntegerAddress> GetXAddressSource()
        {
            return xAddresses;
        }

        public BindingList<IntegerAddress> GetYAddressSource()
        {
            return yAddresses;
        }

        public void Notify()
        {
            foreach (var o in observers)
            {
                o.Update(newPlane, oldPlane);
            }
        }

        public void Update(AddressRegion newStruct, AddressRegion oldStruct)
        {
            if (oldStruct == null)
                structures.Add(newStruct);
            else
                oldStruct.CopyValues(newStruct);
        }

        public void Update(XYRegion newStruct, XYRegion oldStruct)
        {
            if (oldStruct == null)
                structures.Add(newStruct);
            else
                oldStruct.CopyValues(newStruct);            
        }

        public void Update(ObjectBlock newStruct, ObjectBlock oldStruct)
        {
            if (oldStruct == null)
                structures.Add(newStruct);
            else
                oldStruct.CopyValues(newStruct);
        }

        public void Update(IntegerAddress newStruct, IntegerAddress oldStruct)
        {
            if (oldStruct == null)
            {
                if (xPending)
                {
                    xAddresses.Add(newStruct);
                    xPending = false;
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
