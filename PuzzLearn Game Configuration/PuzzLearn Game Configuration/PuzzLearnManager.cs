using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class PuzzLearnManager : IPuzzLearnManager
    {
        private BindingSource addresses;

        public BindingSource GetAddressListSource()
        {
            return addresses;
        }

        public PuzzLearnManager()
        {
            addresses = new BindingSource();
        }

        public void AddAddress(MemoryAddress address)
        {
            addresses.Add(address);
        }

        public void EditAddress(MemoryAddress oldAddress, MemoryAddress newAddress)
        {
            oldAddress.CopyValues(newAddress);
        }

        public void DeleteAddress(MemoryAddress address)
        {
            addresses.Remove(address);
        }

        public bool ValidStringCharacter(char character)
        {
            return character != ',';
        }

        public bool ValidAddressCharacter(char character)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(character.ToString(), @"[0-9A-F\b]");
        }
    }
}
