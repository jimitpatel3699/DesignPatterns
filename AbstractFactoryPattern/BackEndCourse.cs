using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class BackEndCourse : ICourse
    {
        public string GetCourseDuration()
        {
            return "6 Months";
        }
        public int GetCourseFee()
        {
            return 1000;
        }
        public string GetCourseName()
        {
            return "C#, Java, and Python";
        }
    }
}
