namespace MediatorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFacebookGroupMediator facebookMediator = new ConcreteFacebookGroupMediator();
            User Ram = new ConcreteUser("Ram",1);
            User Dave = new ConcreteUser("Dave",2);
            User Smith = new ConcreteUser("Smith",3);
            User Rajesh = new ConcreteUser("Rajesh",4);

            facebookMediator.RegisterUser(Ram);
            facebookMediator.RegisterUser(Dave);
            facebookMediator.RegisterUser(Smith);
            facebookMediator.RegisterUser(Rajesh);

            Dave.Send("Design Pattern");

            Rajesh.Send("What is Design Patterns? Please explain ");
        }
    }
}