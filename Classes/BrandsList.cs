using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3.Classes
{
    public class BrandsList: IEnumerable
    {
        private List<AutoBrands> AutoBrands = new List<AutoBrands>();

        public int Count
            => AutoBrands.Count;

        public void Add(AutoBrands l)
            => AutoBrands.Add(l);

        public void Remove(AutoBrands l)
            => AutoBrands.Remove(l);

        public List<AutoBrands> GetTransports()
            => AutoBrands;

        public AutoBrands Get(int index)
            => AutoBrands[index];

        public IEnumerator GetEnumerator()
            => AutoBrands.GetEnumerator();
    }
}
