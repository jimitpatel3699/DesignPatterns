namespace FactoryMethodPattern
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
