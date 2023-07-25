using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public interface ISourceCourseFactory
    {
        //Abstract Product A
        ISource GetSource();
        //Abstract Product B
        ICourse GetCourse();
    }
}
