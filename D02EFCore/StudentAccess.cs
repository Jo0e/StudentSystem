using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.ForManger;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem
{
    public class StudentAccess
    { 
        PresentStartPage PresentStartPage { get; set; }
        ApplicationDbContext Context { get; set; }
        public int StudentId { get; set; }
        public void Verifying()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"                                        ->Enter your id: ");
            Console.ResetColor();
            StudentId = int.Parse( Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"                                        ->Enter Your Password: ");
            Console.ResetColor();
            string password = Console.ReadLine();
            Context = new ApplicationDbContext();
            using (var context = new ApplicationDbContext())
            {
                var idVerify = Context.Students.FirstOrDefault(s => s.StudentId == StudentId && s.Password == password);
                if (idVerify != null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"                                        ->Access Gained");
                    Console.WriteLine($"                                        ->Welcome {idVerify.Name}");
                    Console.ResetColor();
                    Thread.Sleep(1300);
                    Actions();
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                        ->Invalid ID or Password. Please try again.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.Clear();
                    // IF LOGIN INFORMATION WRONG U WILL GET BACK TO MAIN MENU
                    PresentStartPage= new PresentStartPage();
                    PresentStartPage.PresentStartPageCall();
                }
            }
        }
        public void Actions() 
        {
            #region BANNER
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string banner = $"\r\n                           ___ _           _         _     __  __              \r\n                          / __| |_ _  _ __| |___ _ _| |_  |  \\/  |___ _ _ _  _ \r\n                          \\__ |  _| || / _` / -_| ' |  _| | |\\/| / -_| ' | || |\r\n                          |___/\\__|\\_,_\\__,_\\___|_||_\\__| |_|  |_\\___|_||_\\_,_|\r\n                                                                               \r\n";
            Console.WriteLine(banner);
            string menu = $" \t\t\t\t   ╔════════════════════════════╗\r\n \t\t\t\t   ║\t\t\t        ║\r\n \t\t\t\t   ║    1 - To Assign Course    ║\r\n  \t\t\t\t   ║    2 - To Add Homework     ║\r\n  \t\t\t\t   ║    3 - To View Resource    ║\r\n  \t\t\t\t   ║    4 - Back to last menu   ║\r\n \t\t\t\t   ║ \t\t\t        ║\r\n\t\t\t\t   ╚════════════════════════════╝";
            Console.WriteLine(menu);
            Console.Write($"                                        ->Enter Your chose: ");
            Console.ResetColor();
            string typeOfAction = Console.ReadLine();
            while (typeOfAction != "1" && typeOfAction != "2" && typeOfAction != "3" && typeOfAction != "4")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->PLeas Enter One of Above: ");
                Console.ResetColor();
                typeOfAction = Console.ReadLine();
            }
            #endregion
            // GOD HELP US WITH ALL THOSE BANNERS ⁠(ノ⁠ಠ⁠_⁠ಠ⁠ノ⁠)
            if (typeOfAction == "1")
            { 
                var courses = Context.Courses.ToList();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Currently Available Courses:-  ");
                Console.ResetColor();  
                foreach (var item in courses)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor(); 
                    
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine($"\tId: {item.CourseId}, Name: {item.Name}, Start date:{item.StartDate.Date}, End date:{item.EndDate.Date}, Price: {item.Price}");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"                                        ->Enter the Id of the Course you want: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int selectedCourseId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("                                        ->Invalid input, Try Again: ");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
                var checkCourse = Context.Courses.FirstOrDefault(c => c.CourseId == selectedCourseId);
                if (checkCourse == null)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("                                        ->Course not found.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Actions();

                }
                if (Context.StudentCourses.Any(e => e.CourseId == selectedCourseId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                        ->Student is already enrolled in this course.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Actions();
                }
                Context.StudentCourses.Add(new StudentCourse {StudentId=StudentId, CourseId = selectedCourseId });
                Context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Congratulation you have Enrolled in the Course of {checkCourse.Name}");
                Console.ResetColor();
                Thread.Sleep(1100);
                Actions();
            }


            else if (typeOfAction == "2")
            {
                var AssignedCourses = Context.StudentCourses.Include(e=>e.Course).Include(e=>e.Student).Where(e=>e.StudentId==StudentId).ToList();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Currently Available Courses:-  ");
                Console.ResetColor();

                foreach (var item in AssignedCourses)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"________________________________________________________________________________________________________________________");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\tId: {item.CourseId}, Name: {item.Course.Name}");
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Enter the Course Id you want");
                Console.Write($"                                          to attach the homework to: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int selectedCourseId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                        ->Invalid input, Try Again: ");
                    Console.ResetColor();
                }

                var checkCourse = AssignedCourses.FirstOrDefault(c => c.CourseId == selectedCourseId);
                if (checkCourse == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                        ->Course not found, Or you are not enrolled in.");
                    Console.ResetColor();
                    Thread.Sleep(1100);
                    Actions();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"                                        ->Enter the Content of the home Work");
                Console.ResetColor();
                string content = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                        ->Homework content cannot be empty, Try again:-.");
                    Console.ResetColor();
                    content = Console.ReadLine();
                }

                DateTime submissionTime = DateTime.Now;

                Context.Homeworks.Add(new Homework { Content = content, CourseId = selectedCourseId, SubmissionTime = submissionTime, ContentType= ContentType.Pdf });
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Congratulation you have submitted the Homework for {checkCourse.Course.Name}");
                Console.ResetColor();
                Thread.Sleep(1100);
                Actions();
            }
            else if (typeOfAction == "3")
            {
                //THIS ONLY SHOW THE RESOURCE THAT THIS.STUDENT HAVE
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Your Courses:-");
                Console.ResetColor();
                var allActivities = Context.StudentCourses.Include(e => e.Course).Include(e=>e.Student).Where(e=>e.StudentId==StudentId).ToList();
                List<int> courseIds = new List<int>();
                Console.WriteLine($"__________________________________");
                Console.WriteLine();
                foreach (var studentCourse in allActivities)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Course: {studentCourse.Course.Name}");
                    Console.ResetColor();
                    courseIds.Add(studentCourse.CourseId);
                }   
                Console.WriteLine($"*__________________________________*");
                var recourse = Context.Resources.Include(e=>e.Course).ToList();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Your resources:-");
                Console.ResetColor();
                Console.WriteLine($"*____________________________________________________________________*");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (var id in courseIds) 
                {
                    foreach (var item in recourse)
                    {
                        if (item.CourseId == id)
                        {
                            Console.WriteLine($"Recourse Name: {item.Name}, URl: {item.Url} ");
                        }
                    }
                }
                Console.ResetColor();
                Console.WriteLine($"*____________________________________________________________________*");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                                        ->Press Enter to continue");
                Console.ResetColor();
                Console.ReadLine();
                Actions();
            }
            else
            {
                PresentStartPage = new PresentStartPage();
                PresentStartPage.PresentStartPageCall();
            }
        }
    }
}
