using Microsoft.IdentityModel.Tokens;
using P01_StudentSystem.Data;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.ForManger
{
    public class DataManger
    {
        MangerAccess MangerAccess { get; set; }
        private ApplicationDbContext Context;
        //USED THE OLD WAY CUZ THE get; set; WAY GET SOME ERRORS ¯⁠\⁠_⁠ಠ⁠_⁠ಠ⁠_⁠/⁠¯
        public DataManger(ApplicationDbContext context)
        {
            Context = context;
        }
        
        public void AddData()
        {
            #region MENU
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string menu = " \t\t\t\t   ╔════════════════════════════╗\r\n \t\t\t\t   ║\t\t\t        ║\r\n \t\t\t\t   ║    1 - To Add Course       ║\r\n \t\t\t\t   ║    2 - To Add Student\t║\r\n  \t\t\t\t   ║    3 - To Mange Resource   ║\r\n  \t\t\t\t   ║    4 - Back to last menu   ║\r\n \t\t\t\t   ║ \t\t\t        ║\r\n\t\t\t\t   ╚════════════════════════════╝\r\n";
            Console.WriteLine($"{menu}");
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
            if (typeOfAction == "1")
            {
                AddCourse();
            }
            else if (typeOfAction == "2")
            {
                AddStudent();

            }
            else if (typeOfAction == "3")
            {
                MangeResource();

            }
            else
            {
                //TO GET BACK TO LAST MENU
                MangerAccess = new MangerAccess();
                MangerAccess.Actions();
            }
        }

        public void AddCourse()
        {
            #region BARRIERS
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"*======================================================================================================================*");
            Console.ResetColor();
            Console.WriteLine();
            #endregion
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter course name: ");
            Console.ResetColor();
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Course name cannot be empty, Try again: ");
                Console.ResetColor();
                name = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter start date (yyyy-mm-dd): ");
            Console.ResetColor();
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Invalid date format, Try again: ");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter end date (yyyy-mm-dd): ");
            Console.ResetColor();
            DateTime endDate;
            while (true)
            {
                if (!DateTime.TryParse(Console.ReadLine(), out endDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"                                        ->Invalid date format, Try again: ");
                    Console.ResetColor();
                }
                else if (endDate < startDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"                                        ->End date cannot be earlier than start date, Try again: ");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter price:");
            Console.ResetColor();
            double price;
            while (!double.TryParse(Console.ReadLine(), out price) || price <=0 )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Invalid format or negative Value, Try again: ");
                Console.ResetColor();
            }

            var course = new Course
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            };
            Context.Courses.Add(course);
            Context.SaveChanges();
            var idForCourse = course.CourseId;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"                                        ->The id for this Course is: {idForCourse}");
            Console.WriteLine($"                                        ->Course added successfully.");
            Console.ResetColor();
            Console.WriteLine($"Prese Enter to continue.");
            Console.ReadLine();
            AddData();
        }

        public void AddStudent()
        {
            #region BARRIERS
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"*======================================================================================================================*");
            Console.ResetColor();
            Console.WriteLine();
            #endregion
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter student name: ");
            Console.ResetColor();

            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Course name cannot be empty, Try again: ");
                Console.ResetColor();
                name = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter Phone Number Or press Enter to skip: ");
            Console.ResetColor();
            string phone = Console.ReadLine();
            while (phone.Length! > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Phone number has to 10 or less numbers, Try again: ");
                Console.ResetColor();
                phone = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Add Password: ");
            Console.ResetColor();
            string password = Console.ReadLine();
            
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Course name cannot be empty, Try again: ");
                Console.ResetColor();
                password = Console.ReadLine();
            }

            DateTime registeredOn = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"                                        ->registration date: {registeredOn}");
            Console.ResetColor();

            

            DateTime? birthday = null;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                                        ->Enter birthday (yyyy-mm-dd) or press Enter to skip: ");
                Console.ResetColor();
                string birthdayInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(birthdayInput))
                {
                    break;
                }
                // ALL OF THAT TO MAKE THE BIRTHDAY OPTIONAL ಠ⁠_⁠ಠ
                if (DateTime.TryParse(birthdayInput, out DateTime parsedBirthday))
                {
                    birthday = parsedBirthday;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("                                        ->Invalid date format. Please try again: ");
                    Console.ResetColor();
                }
            }

            var student = new Student
            {
                Name = name,
                RegisteredOn = registeredOn,
                Birthday = birthday,
                PhoneNumber = phone,
                Password = password
            };
            Context.Students.Add(student);
            Context.SaveChanges();
            var idForStudent = student.StudentId;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"                                        ->The id for this student is: {idForStudent}");
                                                                        // YOU WILL NEED THE ID TO LOGIN AS STUDENT LATER
            Console.WriteLine($"                                        ->Student added successfully.");
            Console.ResetColor();
            Console.WriteLine($"Prese Enter to continue.");
            Console.ReadLine();
            AddData();
        }

        public void MangeResource()
        {
            #region BARRIERS
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"*======================================================================================================================*");
            Console.ResetColor();
            Console.WriteLine();
            #endregion
            // I GOTTA DO LESS BANNERS AND COLORS I KNOW (⁠●⁠_⁠_⁠●⁠) 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter Resource name: ");
            Console.ResetColor();
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name)) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Resource name cannot be empty, Try again: ");
                Console.ResetColor();
                name = Console.ReadLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Available Courses:-");
            var courses = Context.Courses.ToList();
            foreach (var item in courses)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($"________________________________________________________________________________________________________________________");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Id: {item.CourseId} , Name: {item.Name}");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"                                        ->Enter the Id of the Course you want");
            Console.Write($"                                          to assign the resource for: ");
            Console.ResetColor();

            int courseId;
            while (!int.TryParse(Console.ReadLine(), out courseId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Invalid format or negative Value, Try again:-");
                Console.ResetColor();
            }

            var checkCourse = Context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (checkCourse == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                        ->Course not found.");
                Console.ResetColor();
                Thread.Sleep(1500);
                AddData();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"                                        ->Enter URL: ");
            Console.ResetColor();
            string url = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(url))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->Url cannot be empty, Try again: ");
                Console.ResetColor();
                url = Console.ReadLine();

            }
            
            ResourceType resourceType;
            if (url.Contains("video"))
            {
                resourceType = ResourceType.Video;
            }
            else if (url.Contains("presentation"))
            {
                resourceType = ResourceType.Presentation;
            }
            else if (url.Contains("document"))
            {
                resourceType = ResourceType.Document;
            }
            else
            {
                resourceType = ResourceType.Other;
            }

            var resource = new Resource
            {
                Name = name,
                Url = url,
                ResourceType = resourceType,
                CourseId = courseId,
            };
            Context.Resources.Add(resource);
            Context.SaveChanges();
            Console.WriteLine($"                                        ->Resources added successfully.");
            Thread.Sleep(1100);
            AddData();
        }
    }
}
