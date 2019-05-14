using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class UserManager : IUserManager
    {
        private IWin32Window lastOwner;
        private MainMenuFormManager mainManager;

        public UserManager(IWin32Window lo, MainMenuFormManager mm)
        {
            lastOwner = lo;
            mainManager = mm;
        }

        public void ConfirmAccount(UserForm f, string username, string password, string confirmPassword)
        {
            if (username == "" || password == "" || confirmPassword == "")
            {
                StaticGameConfig.ShowIncompleteDialog(f);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show(f, "Password and confirm password must match.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (username.Length < 8 || password.Length < 8)
            {
                MessageBox.Show(f, "Username and password must be at least 8 characters long.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    // Check that a user with that username does not already exist
                    connection.Open();
                    string commandString = "SELECT count(*) FROM users WHERE username = @username";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            int count = reader.GetInt32(0);
                            if (count != 0)
                            {
                                connection.Close();
                                MessageBox.Show(f, "A user with that username already exists.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                        }                        
                    }

                    // Generate a salt, salts the password, and hashes the salted password password
                    var random = new RNGCryptoServiceProvider();
                    var salt = new byte[16];
                    random.GetBytes(salt);

                    var pswdHasher = new Rfc2898DeriveBytes(password, salt, 10000);
                    byte[] hashedPswd = pswdHasher.GetBytes(32);

                    var pswdString = Convert.ToBase64String(hashedPswd);
                    var saltString = Convert.ToBase64String(salt);

                    // Add the new user
                    commandString = "INSERT INTO users(username, password, salt) VALUES (@username, @password, @salt)";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", pswdString);
                        command.Parameters.AddWithValue("@salt", saltString);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to create your account.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainManager.SetUsername(username);

            f.Close();
        }

        public void ConfirmLogin(UserForm f, string username, string password)
        {
            if (username == "" || password == "")
            {
                StaticGameConfig.ShowIncompleteDialog(f);
                return;
            }

            string saltString;
            string hashedPswdString;

            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    // Find the user with the given username's salt and salted password, if they exist
                    string commandString = "SELECT password, salt FROM users WHERE username = @username";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hashedPswdString = reader.GetString(0);
                                saltString = reader.GetString(1);

                                connection.Close();
                            }
                            else
                            {
                                connection.Close();
                                MessageBox.Show(f, "Invalid username.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to log in.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hashes the given password and checks that it matches the real password 
            byte[] salt = Convert.FromBase64String(saltString);
            byte[] hashedPswd = Convert.FromBase64String(hashedPswdString);
            
            var pswdHasher = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hashedGivenPswd = pswdHasher.GetBytes(32);
            
            for (int i = 0; i < 32; ++i)
            {
                if (hashedGivenPswd[i] != hashedPswd[i])
                {
                    MessageBox.Show(f, "Incorrect password for the given username.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            mainManager.SetUsername(username);

            f.Close();
        }

        public void CreateNewAccount(UserForm f)
        {
            f.SetCreateAccount();
        }

        public void Login(UserForm f)
        {
            f.SetLogin();
        }       
    }
}
