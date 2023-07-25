namespace FactoryMethodPattern
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
