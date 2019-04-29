using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class InfoFormManager : IInfoFormManager
    {
        private IList<IStructureObserver<InformationAddress>> infoObservers;
        private InformationAddress editAddress;
        private InformationAddress newAddress;
        private ValueCategoriesharedManager vcm;

        public InfoFormManager(InformationAddress ea = null)
        {
            editAddress = ea;
            infoObservers = new List<IStructureObserver<InformationAddress>>();
            if (editAddress != null)
                vcm = new ValueCategoriesharedManager(new Dictionary<int, int>(ea.ValueCategories));
            else
                vcm = new ValueCategoriesharedManager(new Dictionary<int, int>());
        }

        public void AddOrUpdate(int value, int category)
        {
            vcm.AddOrUpdate(value, category);
        }

        public void Attach(IStructureObserver<InformationAddress> o)
        {
            infoObservers.Add(o);
        }

        public bool Confirm(string address, string description, decimal defaultValue)
        {
            if (address == "" || description == "")
                return false;

            int intValue = (int)Math.Round(defaultValue);
            int intAddress = Convert.ToInt32(address, 16);
            newAddress = new InformationAddress(intAddress, description, intValue, vcm.ValueCategories);
            Notify();

            return true;
        }

        public void Delete(int index)
        {
            vcm.Delete(index);
        }

        public void Detach(IStructureObserver<InformationAddress> o)
        {
            infoObservers.Remove(o);
        }

        public void Notify()
        {
            if (newAddress != null)
            {
                foreach (IStructureObserver<InformationAddress> o in infoObservers)
                {
                    o.Update(newAddress, editAddress);
                }
            }
        }

        public object UpdateValueCategories()
        {
            return vcm.UpdateValueCategories();
        }
    }
}
