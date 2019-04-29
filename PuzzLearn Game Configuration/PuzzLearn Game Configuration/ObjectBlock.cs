using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class ObjectBlock : MemStructObject
    {
        private IList<IntegerAddress> xAddresses;
        private IList<IntegerAddress> yAddresses;
        private InformationAddress information;
        private int fixedValue;

        public ObjectBlock(string Description, IList<IntegerAddress> XAddresses, IList<IntegerAddress> YAddresses, InformationAddress Information, int FixedValue)
            : base(Description, MemStructObject.ObjectType.OBJECT)
        {
            xAddresses = XAddresses;
            yAddresses = YAddresses;
            information = Information;
            fixedValue = FixedValue;
        }

        public ObjectBlock(ObjectBlock copy)
            : base(copy)
        {
            fixedValue = copy.fixedValue;

            if(copy.information == null)
                information = null;
            else
                information = (InformationAddress)copy.information.Clone();

            xAddresses = new List<IntegerAddress>();
            foreach (IntegerAddress x in copy.xAddresses)
            {
                xAddresses.Add((IntegerAddress)x.Clone());
            }

            yAddresses = new List<IntegerAddress>();
            foreach (IntegerAddress y in copy.yAddresses)
            {
                yAddresses.Add((IntegerAddress)y.Clone());
            }
        }
        
        public IList<IntegerAddress> XAddresses { get { return xAddresses; } set { xAddresses = value; } }
        public IList<IntegerAddress> YAddresses { get { return yAddresses; } set { yAddresses = value; } }
        public InformationAddress Information { get { return information; } set { information = value; } }
        public int FixedValue { get { return fixedValue; } set { fixedValue = value; } }

        public void CopyValues(ObjectBlock copy)
        {
            fixedValue = copy.fixedValue;

            if (copy.information == null)
                information = null;
            else
                information = (InformationAddress)copy.information.Clone();

            xAddresses.Clear();
            foreach (IntegerAddress x in copy.xAddresses)
            {
                xAddresses.Add((IntegerAddress)x.Clone());
            }

            yAddresses.Clear();
            foreach (IntegerAddress y in copy.yAddresses)
            {
                yAddresses.Add((IntegerAddress)y.Clone());
            }

            base.CopyValues(copy);
        }

        public override object Clone()
        {
            return new ObjectBlock(this);
        }

        public override int GetMax()
        {
            if (information == null)
                return fixedValue;
            else
                return information.GetMax();
        }
    }
}
