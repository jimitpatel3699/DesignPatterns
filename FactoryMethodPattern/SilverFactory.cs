using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class SilverFactory:CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard product = new SilverCard();
            return product;
        }
    }
}
