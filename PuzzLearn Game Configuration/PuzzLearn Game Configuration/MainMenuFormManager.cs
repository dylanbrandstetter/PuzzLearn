using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class MainMenuFormManager : IMainMenuFormManager
    {
        static string filterString = "PuzzLearn Configuration Files (*.plcf)|*.plcf";
        string username;
        ISharedManager sharedManager;
        DatabaseSettings settings;
        BindingList<MemStructObject> database;
        BindingList<IntegerAddress> scoreAddresses;

        string filePath;
        bool edited;

        public string FilePath { get => filePath; set => filePath = value; }

        public MainMenuFormManager()
        {
            sharedManager = new SharedManager();
            settings = new DatabaseSettings();
            settings.CategoryColors.Add(new CategoryColor(Color.Black, 0));
            database = new BindingList<MemStructObject>();
            scoreAddresses = new BindingList<IntegerAddress>();

            filePath = "";
            username = "";
            edited = false;
        }

        public void AddInfo(IWin32Window f)
        {
            IInfoFormManager inManager = new InfoFormManager();
            inManager.Attach(this);

            InformationAddressForm inForm = new InformationAddressForm(inManager, sharedManager, "PuzzLearn - Add Information");
            inForm.ShowDialog(f);
        }

        public void AddPlane(IWin32Window f)
        {
            IPlaneFormManager pManager = new PlaneFormManager(sharedManager);
            pManager.Attach(this);

            PlaneForm pForm = new PlaneForm(sharedManager, pManager, "PuzzLearn - Add Plane");
            pForm.ShowDialog(f);
        }

        public void EditStruct(MemStructObject m, IWin32Window f)
        {
            if (m.Type == MemStructObject.ObjectType.INFORMATION)
            {
                IInfoFormManager inManager = new InfoFormManager((InformationAddress)m);
                inManager.Attach(this);

                InformationAddressForm inForm = new InformationAddressForm(inManager, sharedManager, "PuzzLearn - Edit Information", (InformationAddress)m);
                inForm.ShowDialog(f);
            }
            else
            {
                IPlaneFormManager pManager = new PlaneFormManager(sharedManager, (AddressPlane)m);
                pManager.Attach(this);

                PlaneForm pForm = new PlaneForm(sharedManager, pManager, "PuzzLearn - Edit Plane", (AddressPlane)m);
                pForm.ShowDialog(f);
            }
        }

        public void DeleteStruct(MemStructObject m)
        {
            database.Remove(m);
        }

        public void Update(AddressPlane newStruct, AddressPlane oldStruct)
        {
            if (oldStruct == null)
            {
                database.Add(newStruct);
            }
            else
            {
                oldStruct.CopyValues(newStruct);
            }

            edited = true;
        }

        public void Update(InformationAddress newStruct, InformationAddress oldStruct)
        {
            if (oldStruct == null)
            {
                database.Add(newStruct);
            }
            else
            {
                oldStruct.CopyValues(newStruct);
            }

            edited = true;
        }

        public void Update(IntegerAddress newStruct, IntegerAddress oldStruct)
        {
            if (oldStruct == null)
            {
                scoreAddresses.Add(newStruct);
            }
            else
            {
                oldStruct.CopyValues(newStruct);
            }

            edited = true;
        }

        public BindingList<MemStructObject> GetDataSource()
        {
            return database;
        }

        public void AddScore(IWin32Window f)
        {
            IIntFormManager ifm = new IntFormManager();
            ifm.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(ifm, sharedManager, "PuzzLearn - Add Score");
            intForm.ShowDialog(f);
        }

        public void EditScore(IntegerAddress i, IWin32Window f)
        {
            IIntFormManager ifm = new IntFormManager(i);
            ifm.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(ifm, sharedManager, "PuzzLearn - Edit Score", i);
            intForm.ShowDialog(f);
        }

        public void DeleteScore(IntegerAddress i)
        {
            scoreAddresses.Remove(i);
        }

        public BindingList<IntegerAddress> GetScoreSource()
        {
            return scoreAddresses;
        }

        public void EditDatabaseSettings(IWin32Window f)
        {
            var planes = database.Where(o => o.Type == MemStructObject.ObjectType.ADDRESSPLANE);
            if (planes.Count() > 0)
            {
                while (settings.CategoryColors.Count <= planes.Select(o => o.GetMax()).Max())
                {
                    settings.CategoryColors.Add(new CategoryColor(Color.White, settings.CategoryColors.Count));
                }
            }

            DatabaseSettingsFormManager sm = new DatabaseSettingsFormManager(settings);

            DatabaseSettingsForm sf = new DatabaseSettingsForm(sharedManager, sm, settings);
            sf.ShowDialog(f);

            if (sm.Edited)
                edited = true;
        }

        public void New(IWin32Window f)
        {
            if (!SaveCheck(f))
                return;

            filePath = "";
            database.Clear();
            scoreAddresses.Clear();
            settings = new DatabaseSettings();
        }

        public void OpenStream(Stream st)
        {
            Tuple<IList<MemStructObject>, IList<IntegerAddress>, DatabaseSettings> results = null;
            
            results = FileManager.ReadFile(st);            

            database.Clear();
            foreach (var s in results.Item1) database.Add(s);

            scoreAddresses.Clear();
            foreach (var s in results.Item2) scoreAddresses.Add(s);

            settings = results.Item3;
        }

        public void Open(IWin32Window f)
        {
            if (!SaveCheck(f))
                return;

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = filterString;
            of.ShowDialog(f);

            if (of.FileName == "")
                return;

            try
            {
                OpenStream(of.OpenFile());
                filePath = of.FileName;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(f, "Unable to open file:\n" + fe.Message, "PuzzLearn",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void Save(IWin32Window f)
        {
            if (filePath == "")
            {
                SaveAs(f);
                return;
            }

            FileStream fStream = new FileStream(filePath, FileMode.Create);
            saveFile(fStream);
            edited = false;
        }

        private bool saveBool(IWin32Window f)
        {
            if (filePath == "")
            {
                return saveFromDialog(f);
            }

            FileStream fStream = new FileStream(filePath, FileMode.Create);
            saveFile(fStream);
            edited = false;
            return true;
        }

        public void SaveAs(IWin32Window f)
        {
            saveFromDialog(f);
        }

        public bool SaveCheck(IWin32Window f)
        {
            if (edited)
            {
                DialogResult result = MessageBox.Show(f, "Unsaved edits will be lost. Save?",
                    "PuzzLearn", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                    return false;

                if (result == DialogResult.Yes)
                {
                    return saveBool(f);
                }
            }

            return true;
        }

        private bool saveFromDialog(IWin32Window f)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            sDialog.Filter = filterString;
            sDialog.ShowDialog(f);

            if (sDialog.FileName == "")
                return false;

            try
            {
                saveFile(sDialog.OpenFile());
                edited = false;
                filePath = sDialog.FileName;
            }
            catch
            {
                MessageBox.Show(f, "Unable to save file", "PuzzLearn",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void saveFile(Stream fStream)
        {
            FileManager.WriteFile(database, scoreAddresses, settings, fStream);
        }

        public void SetUsername(string un)
        {
            username = un;
        }

        public string GetUsername()
        {
            return username;
        }

        public void Download(IWin32Window f)
        {
            BindingList<OnlineFilesManager.FileData> data = new BindingList<OnlineFilesManager.FileData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                {
                    string commandString = "SELECT id, filename FROM files";
                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string filename = reader.GetString(1);

                            data.Add(new OnlineFilesManager.FileData(filename, id));
                        }

                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(f, "An error occured while attempting to access the database.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OnlineFilesManager ofm = new OnlineFilesManager(this, data);
            OnlineFilesForm off = new OnlineFilesForm(ofm, false);

            off.ShowDialog(f);
        }

        public void MyFiles(IWin32Window f)
        {
            bool processing = true;
            while (processing)
            {
                if (username == "")
                {
                    UserManager um = new UserManager(f, this);

                    UserForm uf = new UserForm(um, sharedManager);
                    uf.ShowDialog();

                    if (username == "")
                        processing = false;
                }
                else
                {
                    BindingList<OnlineFilesManager.FileData> data = new BindingList<OnlineFilesManager.FileData>();
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(StaticGameConfig.ConnectionString))
                        {
                            string commandString = "SELECT id, filename FROM files WHERE associateduser = @username";
                            using (SqlCommand command = new SqlCommand(commandString, connection))
                            {
                                command.Parameters.AddWithValue("@username", username);

                                connection.Open();
                                SqlDataReader reader =  command.ExecuteReader();

                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string filename = reader.GetString(1);

                                    data.Add(new OnlineFilesManager.FileData(filename, id));
                                }

                                connection.Close();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(f, "An error occured while attempting to access your files.", "PuzzLearn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    OnlineFilesManager ofm = new OnlineFilesManager(this, data);
                    OnlineFilesForm off = new OnlineFilesForm(ofm, true);

                    off.ShowDialog(f);

                    if (username != "")
                        processing = false;
                }
            }
        }

        public string GetDatabaseAsText()
        {
            return FileManager.WriteDatabase(database, scoreAddresses, settings);
        }
    }
}
