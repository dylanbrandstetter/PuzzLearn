using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public interface IUserManager
    {
        void CreateNewAccount(UserForm f);
        void Login(UserForm f);

        void ConfirmLogin(UserForm f, string username, string password);
        void ConfirmAccount(UserForm f, string username, string password, string confirmPassword);
    }
}
