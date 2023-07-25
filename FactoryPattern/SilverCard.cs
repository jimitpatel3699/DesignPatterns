using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class SilverCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 499;
        }

        public string GetCardType()
        {
            return "Silver";
        }

        public int GetCreditLimit()
        {
            return 150000;
        }
    }
}
