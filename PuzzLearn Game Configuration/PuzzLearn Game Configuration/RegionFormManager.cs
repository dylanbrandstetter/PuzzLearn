using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class RegionFormManager : IRegionFormManager
    {
        private List<IStructureObserver<AddressRegion>> observers;
        private BindingList<MemStructObject> structures;
        private ISharedManager sharedManager;
        private AddressRegion oldRegion;
        private AddressRegion newRegion;

        public RegionFormManager(ISharedManager sm, AddressRegion or = null)
        {
            sharedManager = sm;
            oldRegion = or;
            observers = new List<IStructureObserver<AddressRegion>>();

            structures = new BindingList<MemStructObject>();
            if (or != null)
            {
                foreach (var o in or.Structures)
                {
                    structures.Add((MemStructObject)o.Clone());
                }
            }
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

        public void Attach(IStructureObserver<AddressRegion> o)
        {
            observers.Add(o);
        }

        public bool Confirm(string startAdrStr, string endAdrStr, string description, decimal incrementDec)
        {
            if (startAdrStr == "" || endAdrStr == "" || description == "")
                return false;

            int startAdr = Convert.ToInt32(startAdrStr, 16);
            int endAdr = Convert.ToInt32(endAdrStr, 16);
            int increment = Convert.ToInt32(incrementDec);

            newRegion = new AddressRegion(description, structures, startAdr, endAdr, increment);
            Notify();

            return true;
        }

        public void Delete(object mem)
        {
            structures.Remove((MemStructObject)mem);
        }

        public void Detach(IStructureObserver<AddressRegion> o)
        {
            observers.Remove(o);
        }

        public void Edit(object mem, IWin32Window f)
        {
            MemStructObject o = (MemStructObject)mem;

            switch (o.Type)
            {
                case MemStructObject.ObjectType.OBJECT:
                    ObjectBlock b = (ObjectBlock)o;

                    ObjectFormManager om = new ObjectFormManager(sharedManager, b);
                    om.Attach(this);

                    ObjectForm of = new ObjectForm(sharedManager, om, "PuzzLearn - Edit Object", b);
                    of.ShowDialog(f);

                    break;

                case MemStructObject.ObjectType.REGION:
                    AddressRegion r = (AddressRegion)o;

                    RegionFormManager rm = new RegionFormManager(sharedManager, r);
                    rm.Attach(this);

                    RegionForm rf = new RegionForm(sharedManager, rm, "PuzzLearn - Edit Region", r);
                    rf.ShowDialog(f);

                    break;
            }
        }

        public BindingList<MemStructObject> GetDataSource()
        {
            return structures;
        }

        public void Notify()
        {
            foreach (var o in observers)
            {
                o.Update(newRegion, oldRegion);
            }
        }

        public void Update(AddressRegion newStruct, AddressRegion oldStruct)
        {
            if (oldStruct == null)
            {
                structures.Add(newStruct);
            }
            else
            {
                oldStruct.CopyValues(newStruct);
            }
        }

        public void Update(ObjectBlock newStruct, ObjectBlock oldStruct)
        {
            if (oldStruct == null)
            {
                structures.Add(newStruct);

            }
            else
            {
                oldStruct.CopyValues(newStruct);
            }
        }
    }
}
