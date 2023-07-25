using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class PlatinumCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 999;
        }

        public string GetCardType()
        {
            return "platinum";
        }

        public int GetCreditLimit()
        {
            return 500000;
        }
    }
}
