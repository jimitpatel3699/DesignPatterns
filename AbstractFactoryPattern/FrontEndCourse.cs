using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class FrontEndCourse : ICourse
    {
        public string GetCourseName()
        {
            return "HTML, CSS, and Bootstrap";
        }
        public string GetCourseDuration()
        {
            return "6 Months";
        }
        public int GetCourseFee()
        {
            return 2000;
        }
    }
}
