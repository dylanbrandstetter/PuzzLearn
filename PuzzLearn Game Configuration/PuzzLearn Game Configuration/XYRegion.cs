using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class XYRegion : MemStructObject
    {
        private int startAddress;
        private int width;
        private int xOffset;
        private int height;
        private int yOffset;
        private int rowOffset;
        private IDictionary<int, int> valueCategories;
        private int defaultValue;

        public XYRegion(string Description, int StartAddr, int Width, int XOffset,
            int Height, int YOffset, int RowOffset, int DefaultValue, IDictionary<int, int> ValueCategories)
            : base(Description, MemStructObject.ObjectType.XYREGION)
        {
            startAddress = StartAddr;
            width = Width;
            xOffset = XOffset;
            height = Height;
            yOffset = YOffset;
            rowOffset = RowOffset;
            defaultValue = DefaultValue;
            valueCategories = new Dictionary<int, int>(ValueCategories);
        }

        public XYRegion(XYRegion copyXY)
            : base(copyXY)
        {
            startAddress = copyXY.startAddress;
            width = copyXY.width;
            xOffset = copyXY.xOffset;
            yOffset = copyXY.yOffset;
            height = copyXY.height;
            rowOffset = copyXY.rowOffset;
            defaultValue = copyXY.defaultValue;
            valueCategories = new Dictionary<int, int>(copyXY.valueCategories);
        }
        
        public int StartAddress { get { return startAddress; } set { startAddress = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int XOffset { get { return xOffset; } set { xOffset = value; } }
        public int Height { get { return height; } set { height = value; } }
        public int YOffset { get { return yOffset; } set { yOffset = value; } }
        public int RowOffset { get { return rowOffset; } set { rowOffset = value; } }
        public int DefaultValue { get { return defaultValue; } set { defaultValue = value; } }
        public IDictionary<int, int> ValueCategories { get => valueCategories; set => valueCategories = value; }

        public void CopyValues(XYRegion copyXY)
        {
            startAddress = copyXY.startAddress;
            width = copyXY.width;
            xOffset = copyXY.xOffset;
            yOffset = copyXY.yOffset;
            height = copyXY.height;
            rowOffset = copyXY.rowOffset;
            defaultValue = copyXY.defaultValue;
            ValueCategories = new Dictionary<int, int>(copyXY.ValueCategories);
            base.CopyValues(copyXY);
        }

        public override int GetMax()
        {
            if (ValueCategories.Count >= 1)
                return Math.Max(ValueCategories.Values.Max(), defaultValue);
            else
                return defaultValue;
        }

        public override object Clone()
        {
            return new XYRegion(this);
        }
    }
}
