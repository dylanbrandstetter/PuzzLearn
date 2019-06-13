using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class OnlineFilesManager : IOnlineFilesManager
    {
        public struct FileData
        {
            private string filename;
            private int id;

            public FileData(string fn = "", int i = 0)
            {
                filename = fn;
                id = i;
            }

            public string Filename { get => filename; private set { } }
            public int Id { get => id; private set { } }
        }

        MainMenuFormManager main;
        BindingList<FileData> files;

        public OnlineFilesManager(MainMenuFormManager m, BindingList<FileData> f)
        {
            main = m;
            files = f;
        }

        public void Delete(Form f, DataGridView view)
        {
            var rows = view.SelectedRows;
            if (rows.Count == 1)
            {
                FileData selectedObject = (FileData)rows[0].DataBoundItem;

                DialogResult result = MessageBox.Show(f, "The file \"" + selectedObject.Filename + "\" will be deleted permanently.\nContinue?", "PuzzLearn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    deleteFile(selectedObject.Id, f);
                }
            }
        }

        public void Download(Form f, DataGridView view)
        {
            var rows = view.SelectedRows;
            if (rows.Count == 1)
            {
                if (main.SaveCheck(f))
                {
                    FileData selectedObject = (FileData)rows[0].DataBoundItem;

                    downloadFile(selectedObject.Id, f);
                }
            }
        }

        public object GetFileSource()
        {
            return files;
        }

        public void UpdateFile(Form f, DataGridView view)
        {
            var rows = view.SelectedRows;
            if (rows.Count == 1)
            {
                FileData selectedObject = (FileData)rows[0].DataBoundItem;

                DialogResult result = MessageBox.Show(f, "The contents of \"" + selectedObject.Filename + "\" will be changed permanently.\nContinue?", "PuzzLearn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    updateFile(selectedObject.Id, main.GetDatabaseAsText(), f);
                }
            }
        }

        public object SearchResults(string searchString)
        {
            if (searchString == "")
                return files;
            else
            {
                string searchLower = searchString.ToLower();
                return files.Where(f => f.Filename.ToLower().Contains(searchString)).ToList();
            }
        }

        public void SignOut(Form f)
        {
            main.SetUsername("");
            f.Close();
        }

        public void Upload(Form f, string filename)
        {
            if (filename == "")
            {
                MessageBox.Show(f, "You must enter a file name.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileData existingFile = files.Where(fi => fi.Filename == filename).FirstOrDefault();
            if (existingFile.Filename != null)
            {
                DialogResult result = MessageBox.Show(f, "A file with the name \"" + filename + "\" already exists for the current user.\nProceeding will permanently change its contents.\nContinue?", "PuzzLearn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    updateFile(existingFile.Id, main.GetDatabaseAsText(), f);
                }
            }
            else
            {
                uploadFile(main.GetDatabaseAsText(), filename, main.GetUsername(), f);
            }
        }

        private void deleteFile(int id, Form f)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    string commandString = "DELETE FROM files WHERE id = " + id;
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                files.Remove(files.Where(fd => fd.Id == id).FirstOrDefault());

                MessageBox.Show(f, "File successfully deleted.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to delete the file.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void downloadFile(int id, Form f)
        {
            string contents = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    string commandString = "SELECT contents FROM files WHERE id = " + id;
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        contents = reader.GetString(0);
                        connection.Close();
                    }
                }

                MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(contents));

                main.OpenStream(ms);
                main.FilePath = "";

                MessageBox.Show(f, "File successfully downloaded and placed into the configuration file builder.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to download the file.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateFile(int id, string contents, Form f)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    string commandString = "UPDATE files SET contents = @cont WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@cont", contents);
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                MessageBox.Show(f, "File successfully updated.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to update the file.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uploadFile(string contents, string filename, string user, Form f)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    string commandString = "INSERT INTO files (filename, contents, associateduser) VALUES (@file, @cont, @user)";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@file", filename);
                        command.Parameters.AddWithValue("@cont", contents);
                        command.Parameters.AddWithValue("@user", user);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                BindingList<FileData> data = new BindingList<FileData>();
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    string commandString = "SELECT id, filename FROM files WHERE associateduser = @username";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@username", main.GetUsername());

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string fn = reader.GetString(1);

                            data.Add(new FileData(fn, id));
                        }

                        connection.Close();
                    }
                }
                files = data;

                MessageBox.Show(f, "File successfully uploaded.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to upload the file.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
