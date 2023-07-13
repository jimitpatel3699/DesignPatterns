using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    internal class ConcreteFacebookGroupMediator : IFacebookGroupMediator
    {
        private List<User> UsersList = new List<User>();
        public void RegisterUser(User user)
        {
            UsersList.Add(user);
            user.Mediator = this;
        }

        public void SendMessage(string msg, User user)
        {
            foreach (User u in UsersList)
            {
                if (u != user)
                {
                    u.Receive(msg);
                }
            }
        }
    }
}
