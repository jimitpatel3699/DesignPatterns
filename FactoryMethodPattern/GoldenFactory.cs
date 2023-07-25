namespace FactoryMethodPattern
{
    public class GoldenFactory :CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard product = new GoldenCard();
            return product;
        }
    }
}
