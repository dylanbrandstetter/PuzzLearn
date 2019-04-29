using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class MemStructObject : ICloneable, INotifyPropertyChanged
    {
        public enum ObjectType
        {
            INFORMATION = 0,
            INTEGER = 1,
            OBJECT = 2,
            REGION = 3,
            XYREGION = 4,
            ADDRESSPLANE = 5
        }

        static protected string[] typeStrings = { "Information", "Integer", "Object", "Region", "XY Region", "Address Plane" };

        private string description;
        private ObjectType type;

        public event PropertyChangedEventHandler PropertyChanged;

        protected MemStructObject(string Description, ObjectType Type)
        {
            description = Description;
            type = Type;
        }

        protected MemStructObject(MemStructObject copy)
        {
            description = copy.Description;
            type = copy.Type;
        }

        public string Description { get { return description; } set { description = value; } }
        public ObjectType Type { get { return type; } set { type = value; } }
        public string TypeString { get { return typeStrings[(int)type]; } private set { } }
        public string AsString { get { return this.ToString(); } private set { } }

        public virtual object Clone()
        {
            return new MemStructObject(this);
        }

        public void CopyValues(MemStructObject copy)
        {
            description = copy.description;
            type = copy.type;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AsString"));
        }

        public override string ToString()
        {
            return TypeString + " " + description;
        }

        public virtual int GetMax()
        {
            return 0; ;
        }

        //public override bool Equals(object obj)
        //{
        //    var mso = GameConfigStaticMethods.SameType<MemoryAddress>(obj);
        //    if (mso == null)
        //        return false;
        //    else
        //        return description == mso.description && type == mso.type;
        //}
    }
}
