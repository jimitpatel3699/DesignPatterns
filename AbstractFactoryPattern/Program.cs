namespace AbstractFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true) 
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("1.Backend Course(.NET,Java,Python) Training");
                Console.WriteLine("2.Frontend Course(Javascript,Typescript,Jquery) Training");
                Console.WriteLine("========================================================");
                Console.Write("Enter your choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Choice choice;
                Enum.TryParse(ch.ToString(), out choice);
                switch(choice) 
                {
                    case Choice.Backend:
                        {
                            ISourceCourseFactory onlineSourceCourseFactory = new OnlineSourceCourseFactory();
                            var course = onlineSourceCourseFactory.GetCourse();
                            Console.WriteLine($"Course = {course.GetCourseName()}");
                            Console.WriteLine($"Fee = {course.GetCourseFee()}");
                            Console.WriteLine($"Duration ={course.GetCourseDuration()}");
                            var source = onlineSourceCourseFactory.GetSource();
                            Console.WriteLine($"Mode = {source.GetSourceName()}");
                            break;
                        }
                    case Choice.Frondend:
                        {
                            ISourceCourseFactory offlineSourceCourseFactory = new OfflineSourceCourseFactory();
                            var course = offlineSourceCourseFactory.GetCourse();
                            Console.WriteLine($"Course = {course.GetCourseName()}");
                            Console.WriteLine($"Fee = {course.GetCourseFee()}");
                            Console.WriteLine($"Duration ={course.GetCourseDuration()}");
                            var source = offlineSourceCourseFactory.GetSource();
                            Console.WriteLine($"Mode = {source.GetSourceName()}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option");
                            break;
                        }
                }
            }
        }
    }
}