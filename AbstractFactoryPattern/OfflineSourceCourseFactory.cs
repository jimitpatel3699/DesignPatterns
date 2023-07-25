using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class OfflineSourceCourseFactory : ISourceCourseFactory
    {
        public ISource GetSource()
        {
            //public ISource GetSource(Type type)
            //if(type==Type.online)
            //{
            //    return new Online();
            //}
            //this can make appication tightly coupled.
            return new Offline();
        }
        public ICourse GetCourse()
        {
            return new FrontEndCourse();
        }
    }
}
