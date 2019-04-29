using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class IntFormManager : IIntFormManager
    {
        IList<IStructureObserver<IntegerAddress>> observers;
        IntegerAddress oldAddress;
        IntegerAddress newAddress;

        public IntFormManager(IntegerAddress oa = null)
        {
            observers = new List<IStructureObserver<IntegerAddress>>();
            oldAddress = oa;
        }

        public bool Confirm(string addressString, string description, decimal offsetDecimal, decimal multFactor)
        {
            if (addressString == "" || description == "")
                return false;

            int address = Convert.ToInt32(addressString, 16);
            int offset = (int)Math.Round(offsetDecimal);

            newAddress = new IntegerAddress(address, description, offset, multFactor);
            Notify();

            return true;
        }

        public void Attach(IStructureObserver<IntegerAddress> o)
        {
            observers.Add(o);
        }

        public void Detach(IStructureObserver<IntegerAddress> o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            if (newAddress != null)
            {
                foreach (IStructureObserver<IntegerAddress> o in observers)
                {
                    o.Update(newAddress, oldAddress);
                }
            }
        }
    }
}
