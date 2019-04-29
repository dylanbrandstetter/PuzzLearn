using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class AddressRegion : MemStructObject
    {
        private IList<MemStructObject> structures;
        private int startAddress;
        private int endAddress;
        private int increment;

        public AddressRegion(string Description, IList<MemStructObject> Structures, int StartAddress, int EndAddress, int Increment)
            : base(Description, MemStructObject.ObjectType.REGION)
        {
            structures = Structures;
            startAddress = StartAddress;
            endAddress = EndAddress;
            increment = Increment;
        }

        public AddressRegion(AddressRegion copy)
            : base(copy)
        {
            startAddress = copy.startAddress;
            endAddress = copy.endAddress;
            increment = copy.increment;

            structures = new List<MemStructObject>();

            foreach (MemStructObject o in copy.structures)
            {
                structures.Add((MemStructObject)o.Clone());
            }
        }
        
        public IList<MemStructObject> Structures { get { return structures; } set { structures = value; } }

        public int StartAddress { get => startAddress; set => startAddress = value; }
        public int EndAddress { get => endAddress; set => endAddress = value; }
        public int Increment { get => increment; set => increment = value; }

        public void CopyValues(AddressRegion copy)
        {
            startAddress = copy.startAddress;
            endAddress = copy.endAddress;
            increment = copy.increment;

            structures.Clear();

            foreach (MemStructObject o in copy.structures)
            {
                structures.Add((MemStructObject)o.Clone());
            }

            base.CopyValues(copy);
        }

        public override int GetMax()
        {
            if (structures.Count >= 1)
                return structures.Select(s => s.GetMax()).Max();
            else
                return 0;
        }

        public override object Clone()
        {
            return new AddressRegion(this);
        }
    }
}
