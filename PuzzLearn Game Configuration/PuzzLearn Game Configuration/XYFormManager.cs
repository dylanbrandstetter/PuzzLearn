using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class XYFormManager : IXYFormManager
    {
        List<IStructureObserver<XYRegion>> observers;
        ValueCategoriesharedManager vcm;
        XYRegion oldXY;
        XYRegion newXY;

        public XYFormManager(XYRegion ox = null)
        {
            oldXY = ox;

            if (oldXY != null)
                vcm = new ValueCategoriesharedManager(new Dictionary<int, int>(ox.ValueCategories));
            else
                vcm = new ValueCategoriesharedManager(new Dictionary<int, int>());

            observers = new List<IStructureObserver<XYRegion>>();
        }

        public void AddOrUpdate(decimal valueDec, decimal categoryDec)
        {
            vcm.AddOrUpdate((int)Math.Round(valueDec), (int)Math.Round(categoryDec));
        }

        public void Attach(IStructureObserver<XYRegion> o)
        {
            observers.Add(o);
        }

        public bool Confirm(string description, string addressString, decimal widthDec, decimal heightDec,
            decimal rowOffsetDec, decimal xStartDec, decimal yStartDec, decimal defaultValueDec)
        {
            if (description == "" || addressString == "")
                return false;

            int address = Convert.ToInt32(addressString, 16);
            int width = (int)Math.Round(widthDec);
            int height = (int)Math.Round(heightDec);
            int rowOffset = (int)Math.Round(rowOffsetDec);
            int xStart = (int)Math.Round(xStartDec);
            int yStart = (int)Math.Round(yStartDec);
            int defaultValue = (int)Math.Round(defaultValueDec);

            newXY = new XYRegion(description, address, width, xStart, height, yStart, rowOffset, defaultValue, vcm.ValueCategories);
            Notify();

            return true;
        }

        public void Delete(int addressValue)
        {
            vcm.Delete(addressValue);
        }

        public void Detach(IStructureObserver<XYRegion> o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (var o in observers)
            {
                o.Update(newXY, oldXY);
            }
        }

        public object UpdateValueCategories()
        {
            return vcm.UpdateValueCategories();
        }
    }
}
