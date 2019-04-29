using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class AddressPlane : MemStructObject
    {
        private IList<MemStructObject> structures;
        private int xMin;
        private int xMax;
        private int yMin;
        private int yMax;
        private int defaultValue;
        private IList<IntegerAddress> xCenterAddress;
        private IList<IntegerAddress> yCenterAddress;

        public AddressPlane(IList<MemStructObject> Objects, string Description, int XMin, int XMax, int YMin, int YMax,
            int DefaultValue, IList<IntegerAddress> XCenterAddress, IList<IntegerAddress> YCenterAddress)
            : base(Description, ObjectType.ADDRESSPLANE)
        {
            structures = Objects;
            xMin = XMin;
            xMax = XMax;
            yMin = YMin;
            yMax = YMax;
            defaultValue = DefaultValue;
            xCenterAddress = XCenterAddress;
            yCenterAddress = YCenterAddress;
        }

        public AddressPlane(AddressPlane copy)
            : base(copy)
        {
            structures = new List<MemStructObject>();
            xCenterAddress = new List<IntegerAddress>();
            yCenterAddress = new List<IntegerAddress>();

            CopyValues(copy);
        }

        public IList<MemStructObject> Structures { get => structures; set => structures = value; }
        public int XMin { get => xMin; set => xMin = value; }
        public int XMax { get => xMax; set => xMax = value; }
        public int YMin { get => yMin; set => yMin = value; }
        public int YMax { get => yMax; set => yMax = value; }
        public int DefaultValue { get => defaultValue; set => defaultValue = value; }
        
        public IList<IntegerAddress> XCenterAddress { get => xCenterAddress; set => xCenterAddress = value; }
        public IList<IntegerAddress> YCenterAddress { get => yCenterAddress; set => yCenterAddress = value; }

        public void CopyValues(AddressPlane copy)
        {
            xMin = copy.xMin;
            xMax = copy.xMax;
            yMin = copy.yMin;
            yMax = copy.yMax;
            defaultValue = copy.defaultValue;

            structures.Clear();
            xCenterAddress.Clear();
            yCenterAddress.Clear();

            foreach (MemStructObject o in copy.structures)
            {
                structures.Add((MemStructObject)o.Clone());
                //switch (o.Type)
                //{
                //    case ObjectType.OBJECT:
                //        objects.Add((ObjectBlock)o.Clone());
                //        break;

                //    case ObjectType.REGION:
                //        objects.Add((AddressRegion)o.Clone());
                //        break;

                //    case ObjectType.XYREGION:
                //        objects.Add((XYRegion)o.Clone());
                //        break;
                //}
            }

            foreach (IntegerAddress i in copy.xCenterAddress)
            {
                xCenterAddress.Add((IntegerAddress)i.Clone());
            }

            foreach (IntegerAddress i in copy.yCenterAddress)
            {
                yCenterAddress.Add((IntegerAddress)i.Clone());
            }
        }

        public override int GetMax()
        {
            if (structures.Count >= 1)
                return Math.Max(structures.Select(o => o.GetMax()).Max(), defaultValue);
            else
                return defaultValue;
        }
    }
}
