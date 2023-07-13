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
            User Sam = new ConcreteUser("Sam",5);
            User Pam = new ConcreteUser("Pam",6);
            User Anurag = new ConcreteUser("Anurag",7);
            User John = new ConcreteUser("John",8);

            facebookMediator.RegisterUser(Ram);
            facebookMediator.RegisterUser(Dave);
            facebookMediator.RegisterUser(Smith);
            facebookMediator.RegisterUser(Rajesh);
            facebookMediator.RegisterUser(Sam);
            facebookMediator.RegisterUser(Pam);
            facebookMediator.RegisterUser(Anurag);
            facebookMediator.RegisterUser(John);

            Dave.Send("Design Pattern");

            Rajesh.Send("What is Design Patterns? Please explain ");
        }
    }
}