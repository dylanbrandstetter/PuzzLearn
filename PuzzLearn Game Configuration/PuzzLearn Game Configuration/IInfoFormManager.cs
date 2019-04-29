using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public interface IInfoFormManager : IStructureSubject<InformationAddress>
    {
        void AddOrUpdate(int value, int category);
        void Delete(int index);
        bool Confirm(string address, string description, decimal defaultValue);

        object UpdateValueCategories();
    }
}
