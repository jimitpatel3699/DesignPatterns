using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class GoldenCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 599;
        }

        public string GetCardType()
        {
            return "Golden";
        }

        public int GetCreditLimit()
        {
            return 300000;
        }
    }
}
