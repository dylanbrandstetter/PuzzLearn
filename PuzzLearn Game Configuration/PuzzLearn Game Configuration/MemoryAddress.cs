using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class MemoryAddress : MemStructObject
    {
        protected int address;
        
        public int Address { get { return address; } set { address = value; } }
        public string AddressHex { get { return "0x" + address.ToString("X").PadLeft(8, '0'); } private set { } }

        public MemoryAddress(int Address, string Description, MemStructObject.ObjectType Type)
            : base(Description, Type)
        {
            address = Address;
        }

        public MemoryAddress(MemoryAddress copy)
            : base(copy)
        {
            address = copy.address;
        }

        public void CopyValues(MemoryAddress copyAddress)
        {
            address = copyAddress.address;
            base.CopyValues(copyAddress);
        }

        public override string ToString()
        {
            return "0x" + address.ToString("X") + " " + Description;
        }

        public override object Clone()
        {
            return new MemoryAddress(this);
        }

        //public override bool Equals(object obj)
        //{
        //    var ma = GameConfigStaticMethods.SameType<MemoryAddress>(obj);
        //    if (ma == null)
        //        return false;
        //    else
        //        return base.Equals(new MemoryAddress(ma)) && address == ma.address;
        //}
    }

    public class InformationAddress : MemoryAddress
    {
        private IDictionary<int, int> valueCategories;
        private int defaultValue;

        public InformationAddress(int address, string description, int DefaultValue = 0, IDictionary<int, int> ValueCategories = null)
            : base(address, description, ObjectType.INFORMATION)
        {
            defaultValue = DefaultValue;
            if (ValueCategories == null)
                valueCategories = new Dictionary<int, int>();
            else
                valueCategories = new Dictionary<int, int>(ValueCategories);
        }

        public InformationAddress(InformationAddress copy)
            : base(copy)
        {
            defaultValue = copy.defaultValue;
            valueCategories = new Dictionary<int, int>(copy.valueCategories);
        }

        public int DefaultValue { get { return defaultValue; } set { defaultValue = value; } }

        public IDictionary<int, int> ValueCategories { get { return valueCategories; } set { valueCategories = value; } }

        public override int GetMax()
        {
            if (valueCategories.Count >= 1)
                return Math.Max(valueCategories.Values.Max(), defaultValue);
            else
                return defaultValue;
        }

        public void CopyValues(InformationAddress copyInfo)
        {
            defaultValue = copyInfo.defaultValue;
            valueCategories = new Dictionary<int, int>(copyInfo.valueCategories);
            base.CopyValues(copyInfo);
        }

        public override object Clone()
        {
            return new InformationAddress(this);
        }
    }

    public class IntegerAddress : MemoryAddress
    {
        private int offset;
        private decimal multiply;

        public IntegerAddress(int address, string description, int Offset = 0, decimal Multiply = 1)
            : base(address, description, MemStructObject.ObjectType.INTEGER)
        {
            offset = Offset;
            multiply = Multiply;
        }

        public IntegerAddress(IntegerAddress copy)
            : base(copy)
        {
            offset = copy.offset;
            multiply = copy.multiply;
        }

        public int Offset { get { return offset; } set { offset = value; } }
        public decimal Multiply { get { return multiply; } set { multiply = value; } }

        public void CopyValues(IntegerAddress copyInt)
        {
            offset = copyInt.offset;
            multiply = copyInt.multiply;
            base.CopyValues(copyInt);
        }

        public override object Clone()
        {
            return new IntegerAddress(this);
        }
    }
}
