using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public class Audi: AutoBrands
    {
        public override string Move()
            => $"{BrandName} stands for sporty vehicles, high build quality and progressive design .";
    }
}
