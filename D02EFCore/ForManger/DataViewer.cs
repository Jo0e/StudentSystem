using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.ForManger
{
    public class DataViewer
    {
        MangerAccess MangerAccess { get; set; }

        ApplicationDbContext Context { get; set; }

        public DataViewer(ApplicationDbContext context)
        {
            Context = context;
        }

        public void DataView()
        {
            Console.Clear();
            #region MENU
            Console.ForegroundColor = ConsoleColor.Green;
            string menu = $" \t\t\t\t   ╔════════════════════════════╗\r\n \t\t\t\t   ║\t\t\t        ║\r\n \t\t\t\t   ║    1 - To View Activities  ║\r\n \t\t\t\t   ║    2 - To View Course      ║\r\n  \t\t\t\t   ║    3 - To View Students    ║\r\n  \t\t\t\t   ║    4 - To View Homework    ║\r\n  \t\t\t\t   ║    5 - To View Resources   ║\r\n  \t\t\t\t   ║    6 - Back to last menu   ║\r\n \t\t\t\t   ║ \t\t\t        ║\r\n\t\t\t\t   ╚════════════════════════════╝";
            Console.WriteLine($"{menu}");
            Console.Write($"                                        ->Enter Your chose: ");
            Console.ResetColor();
            string typeOfAction = Console.ReadLine();
            while (typeOfAction != "1" && typeOfAction != "2" && typeOfAction != "3" && typeOfAction != "4" && typeOfAction != "5" && typeOfAction != "6")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->PLeas Enter One of Above: ");
                Console.ResetColor();
                typeOfAction = Console.ReadLine();
            }
            #endregion
            Context = new ApplicationDbContext();
            if (typeOfAction == "1")
            {
                // THIS VIEWS EVERY STUDENT AND EVERY COURSE THEY ASSIGNED TO

                var studentCourse = Context.StudentCourses.Include(e=>e.Student).Include(e=>e.Course).ToList();
                foreach (var item in studentCourse)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine($"\t\t\tStudent Id:{item.StudentId}, Student: {item.Student.Name} Assigned To {item.Course.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"Press Enter to continue");
                Console.ReadLine();
                DataView();

            }
            else if (typeOfAction == "2")
            {
                var courses = Context.Courses.ToList();
                foreach (var item in courses)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine($"\tId: {item.CourseId}, Name: {item.Name}, Start date:{item.StartDate.Date}, End date:{item.EndDate.Date}, Price: {item.Price}");
                }
                Console.WriteLine();
                Console.WriteLine($"Press Enter to continue");
                Console.ReadLine();
                DataView();
            }
            else if (typeOfAction == "3")
            {
                var students = Context.Students.ToList();
                foreach (var item in students)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine($"\t\tId: {item.StudentId}, Name: {item.Name}, Registered On: {item.RegisteredOn}, Phone Number: {item.PhoneNumber}");
                }
                Console.WriteLine();
                Console.WriteLine($"Press Enter to continue");
                Console.ReadLine();
                DataView();

            }
            else if (typeOfAction == "4")
            {
                var homework = Context.Homeworks.Include(e => e.Student).Include(r => r.Course).ToList();
                foreach (var item in homework)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine($"Id: {item.HomeworkId}, Content: {item.Content}, Submission time:{item.SubmissionTime}, Student Name:{item.Student.Name}, Course Name:{item.Course.Name} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Press Enter to continue");
                Console.ReadLine();
                DataView();
            }
            else if (typeOfAction == "5")
            {
                var resource = Context.Resources.Include(e => e.Course).ToList();
                foreach (var item in resource)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine($"\t\tId: {item.ResourceId}, Name:{item.Name}, URL: {item.Url},Course Name: {item.Course.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"Press Enter to continue");
                Console.ReadLine();
                DataView();
            }
            
            else
            {
                // BACK AGAIN TO LAST MENU
                MangerAccess = new MangerAccess();
                MangerAccess.Actions();
            }

        }
    }
}
