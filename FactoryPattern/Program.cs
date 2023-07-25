namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=====================");
                Console.WriteLine("1.PlatinumCard");
                Console.WriteLine("2.GoldenCard");
                Console.WriteLine("3.SilverCard");
                Console.WriteLine("Select Card Type.");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("=====================");
                ICreditCard cardDetails = null;
                switch (choice)
                {
                    case 1:
                        {
                            cardDetails = CardFactory.GetCreditCard("Platinum");
                            break;
                        }
                    case 2:
                        {
                            cardDetails = CardFactory.GetCreditCard("Golden");
                            break;
                        }
                    case 3:
                        {
                            cardDetails = CardFactory.GetCreditCard("Silver");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Card Type");
                            break;
                        }
                }
                

                if (cardDetails != null)
                {
                    Console.WriteLine("CardType : " + cardDetails.GetCardType());
                    Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                    Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
                }
               
            }

        }
    }
}