using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    internal abstract class User
    {
        public User(string name,int Id)
        {
            this.Id = Id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IFacebookGroupMediator Mediator { get; set; }
        public abstract void Send(string message);
        public abstract void Receive(string message);
    }
}
