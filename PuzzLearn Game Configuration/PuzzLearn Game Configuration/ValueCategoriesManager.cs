using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public class ValueCategoriesharedManager
    {
        private IDictionary<int, int> valueCategories;

        public ValueCategoriesharedManager(IDictionary<int, int> vc)
        {
            ValueCategories = vc;
        }

        public IDictionary<int, int> ValueCategories { get => valueCategories; set => valueCategories = value; }

        public void AddOrUpdate(int value, int category)
        {
            ValueCategories[value] = category;
        }

        public void Delete(int addressValue)
        {
            valueCategories.Remove(addressValue);
        }

        public object UpdateValueCategories()
        {
            List<Tuple<int, int>> dataSource = new List<Tuple<int, int>>();

            foreach (int key in valueCategories.Keys)
            {
                dataSource.Add(new Tuple<int, int>(key, valueCategories[key]));
            }

            dataSource.Sort(delegate (Tuple<int, int> first, Tuple<int, int> second)
            {
                if (first.Item1 < second.Item1)
                    return -1;
                else if (first.Item1 > second.Item1)
                    return 1;
                else
                    return 0;
            });

            return dataSource;
        }
    }
}
