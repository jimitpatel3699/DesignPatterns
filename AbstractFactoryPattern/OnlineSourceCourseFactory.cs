using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class OnlineSourceCourseFactory : ISourceCourseFactory
    {
        public ISource GetSource()
        {
            //if (type == Type.online)
            //{
            //    return new Online();
            //}
            return new Online();
        }
        public ICourse GetCourse()
        {
            return new BackEndCourse();
        }
    }
}
