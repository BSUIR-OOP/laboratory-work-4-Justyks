using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public abstract class AutoBrands
    {
        public string BrandName { get; set; }

        public int YearOfCreation { get; set; }

        public string Country { get; set; }

        public AutoBrands() { }

        public string ShowInfo()
            => $"{BrandName} was founded in {Country} in {YearOfCreation}";

        public abstract string Move();
    }
}
