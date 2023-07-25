namespace FactoryMethodPattern
{
    public class PlatinumFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard product = new PlatinumCard();
            return product;
        }
    }
}
