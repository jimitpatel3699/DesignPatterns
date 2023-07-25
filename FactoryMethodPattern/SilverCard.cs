namespace FactoryMethodPattern
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
