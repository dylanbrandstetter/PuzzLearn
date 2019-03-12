using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class MemoryAddress
    {

        public enum Type
        {
            Placeholder
        };

        protected Type addressType;
        protected string typeString;
        protected int address;
        protected string label;
        
        [Browsable(false)]
        public Type AddressType { get { return addressType; } private set { } }
        [Browsable(false)]
        public string TypeString { get { return typeString; } private set { } }
        [Browsable(false)]
        public int Address { get { return address; } set { address = value; } }
        public string AddressHex { get { return "0x" + address.ToString("X"); } private set { } }
        public string Label { get { return label; } set { label = value; } }

        

        public MemoryAddress(Type aType, string tString)
        {
            addressType = aType;
            typeString = tString;
        }

        public override string ToString()
        {
            return "0x" + address.ToString("X") + " " + label;
        }

        public void CopyValues(MemoryAddress copyAddress)
        {
            this.address = copyAddress.address;
            this.label = copyAddress.label;
        }
    }

    public class PlaceholderAddress : MemoryAddress
    {
        public PlaceholderAddress() : base(Type.Placeholder, "Placeholder") { }
    }
}
