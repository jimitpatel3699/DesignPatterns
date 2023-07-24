using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class Online : ISource
    {
        public string GetSourceName()
        {
            return "Online Class Room Training";
        }
    }
}
