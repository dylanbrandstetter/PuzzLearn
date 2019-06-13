using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class CategoryColor : INotifyPropertyChanged, ICloneable
    {
        private int category;
        private Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ColorString"));
            }
        }

        public string ColorString
        {
            get
            {
                return "#" + color.R.ToString("X").PadLeft(2, '0') + color.G.ToString("X").PadLeft(2, '0') + color.B.ToString("X").PadLeft(2, '0');
            }
            private set { }
        }
        public CategoryColor(Color co, int ca = 0) { Category = ca; Color = co; }
        public CategoryColor(CategoryColor cc)
        {
            category = cc.category;
            color = cc.color;
        }

        public object Clone()
        {
            return new CategoryColor(this);
        }
    }

    public class DatabaseSettings
    {
        IList<CategoryColor> categoryColors;
        IList<string> buttons;
        int endAddress;
        int endValue;
        int population;
        int stagnantGeneration;
        decimal timeout;
        decimal stagnantTimeout;
        bool releaseButtons;

        public DatabaseSettings(IList<CategoryColor> cc = null, IList<string> b = null,
            int pop = 200, int sg = 15, int ea = 0, int ev = 0, decimal to = 600, decimal sto = 20,
            bool rb = false)
        {
            if (cc == null)
                CategoryColors = new List<CategoryColor>();
            else
                CategoryColors = cc;

            if (b == null)
                buttons = new List<string>();
            else
                buttons = b;

            Population = pop;
            StagnantGeneration = sg;
            EndAddress = ea;
            EndValue = ev;
            Timeout = to;
            StagnantTimeout = sto;
            ReleaseButtons = rb;
        }

        public IList<CategoryColor> CategoryColors { get => categoryColors; set => categoryColors = value; }
        public IList<string> Buttons { get => buttons; set => buttons = value; }
        public int Population { get => population; set => population = value; }
        public int StagnantGeneration { get => stagnantGeneration; set => stagnantGeneration = value; }
        public int EndAddress { get => endAddress; set => endAddress = value; }
        public int EndValue { get => endValue; set => endValue = value; }
        public decimal Timeout { get => timeout; set => timeout = value; }
        public decimal StagnantTimeout { get => stagnantTimeout; set => stagnantTimeout = value; }
        public bool ReleaseButtons { get => releaseButtons; set => releaseButtons = value; }
    }
}
