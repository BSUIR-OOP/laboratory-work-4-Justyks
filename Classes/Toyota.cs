using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public class Toyota: AutoBrands
    {
        public override string Move()
            => $"{BrandName} understand the philosophy behind everything we do, explore our history and get to know the people driving us into the future. ";
    }
}
