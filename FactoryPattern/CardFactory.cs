using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class CardFactory
    {
        public static ICreditCard GetCreditCard(string cardType)
        {
            ICreditCard cardDetails = null;
            if (cardType == "Silver")
            {
                cardDetails = new SilverCard();
            }
            else if (cardType == "Golden")
            {
                cardDetails = new GoldenCard();
            }
            else if (cardType == "Platinum")
            {
                cardDetails = new PlatinumCard();
            }
            return cardDetails;
        }
    }
}
