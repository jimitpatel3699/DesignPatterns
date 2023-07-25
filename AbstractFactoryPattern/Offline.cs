using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class Offline : ISource
    {
        public string GetSourceName()
        {
            return "Offline Class Room Training";
        }
    }
}
