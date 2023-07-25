using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public abstract class CreditCardFactory
    {
        protected abstract ICreditCard MakeProduct();
        public ICreditCard CreateProduct()
        {
            ICreditCard creditCard = MakeProduct();
            return creditCard;
        }
    }
}
