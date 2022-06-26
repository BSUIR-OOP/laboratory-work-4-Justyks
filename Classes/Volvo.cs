using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public class Volvo: AutoBrands
    {
        public override string Move()
            => $" {BrandName}  Our products help ensure that you have food on the table, transport to the airport and newly constructed roads to drive on.";
    }
}
