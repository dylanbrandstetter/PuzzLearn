using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IPuzzLearnManager
    {
        BindingSource GetAddressListSource();
        void AddAddress(MemoryAddress address);
        void EditAddress(MemoryAddress oldAddress, MemoryAddress newAddress);
        void DeleteAddress(MemoryAddress address);
        bool ValidStringCharacter(char character);
        bool ValidAddressCharacter(char character);
    }
}
