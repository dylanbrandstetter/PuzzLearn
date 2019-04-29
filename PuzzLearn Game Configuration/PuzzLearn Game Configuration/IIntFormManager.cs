using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public interface IIntFormManager : IStructureSubject<IntegerAddress>
    {
        bool Confirm(string addressString, string description, decimal offsetDecimal, decimal multFactor);
    }
}
