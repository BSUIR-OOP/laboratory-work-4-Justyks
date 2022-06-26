using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public class BMW: AutoBrands
    {
        public override string Move()
            => $"{BrandName}: automated driving, electro-mobility, on-demand mobility and connectivity-mobility have never been so fascinating.";
    }
}
