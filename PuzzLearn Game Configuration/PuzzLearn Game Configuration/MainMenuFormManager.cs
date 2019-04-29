using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class MainMenuFormManager : IMainMenuFormManager
    {
        ISharedManager sharedManager;
        DatabaseSettings settings;
        BindingList<MemStructObject> database;
        BindingList<IntegerAddress> scoreAddresses;

        public MainMenuFormManager()
        {
            sharedManager = new SharedManager();
            settings = new DatabaseSettings();
            settings.CategoryColors.Add(new CategoryColor(Color.Black, 0));
            database = new BindingList<MemStructObject>();
            scoreAddresses = new BindingList<IntegerAddress>();
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
                var removeStruct = (AddressPlane)(database.Where(s => s.Equals(oldStruct)).First());
                removeStruct.CopyValues(newStruct);
            }
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
        }

        public BindingList<MemStructObject> GetDataSource()
        {
            return database;
        }

        public void AddScore(IWin32Window f)
        {
            IIntFormManager ifm = new IntFormManager();
            ifm.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(ifm, sharedManager, "PuzzLearn - Add Score Address");
            intForm.ShowDialog(f);
        }

        public void EditScore(IntegerAddress i, IWin32Window f)
        {
            IIntFormManager ifm = new IntFormManager(i);
            ifm.Attach(this);

            IntegerAddressForm intForm = new IntegerAddressForm(ifm, sharedManager, "PuzzLearn - Edit Score Address", i);
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
            if (database.Count > 0)
            {
                while (settings.CategoryColors.Count <= database.Select(o => o.GetMax()).Max())
                {
                    settings.CategoryColors.Add(new CategoryColor(Color.White, settings.CategoryColors.Count));
                }
            }

            DatabaseSettingsFormManager sm = new DatabaseSettingsFormManager(settings);

            DatabaseSettingsForm sf = new DatabaseSettingsForm(sharedManager, sm, settings);
            sf.ShowDialog(f);
        }
    }
}
