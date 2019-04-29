using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public interface IXYFormManager : IStructureSubject<XYRegion>
    {
        bool Confirm(string description, string addressString,
            decimal widthDec, decimal heightDec, decimal rowOffsetDec,
            decimal xStartDec, decimal yStartDec, decimal defaultValueDec);
        void AddOrUpdate(decimal valueDec, decimal categoryDec);
        void Delete(int addressValue);


        object UpdateValueCategories();
    }
}
