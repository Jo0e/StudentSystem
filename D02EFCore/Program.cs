using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Models;

namespace P01_StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //using (var context = new ApplicationDbContext())
            //{
            //    var entityToDelete = context.Resources.FirstOrDefault(e => e.ResourceId == 4);
            //    if (entityToDelete != null)
            //    {
            //        context.Remove(entityToDelete);
            //        context.SaveChanges();
            //        Console.WriteLine("Entity deleted successfully.");
            //    }
            //}


            //using (var context = new ApplicationDbContext())
            //{
            // context.StudentCourses.ExecuteDelete();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //}

            //USE THIS TO ADD DATA////

            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.EnsureCreated();
            //    context.Seed();
            //    Console.WriteLine("Database seeded with sample data.");
            //}


            //ApplicationDbContext context = new ApplicationDbContext();
            //var result = context.StudentCourses.Include(e => e.Student).Include(e => e.Course).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Student.Name} --- {item.Course.Name}");
            //}

            PresentStartPage presentStartPage = new PresentStartPage();
            presentStartPage.WelcomeBanner();
            presentStartPage.PresentStartPageCall();





        }
    }
}
