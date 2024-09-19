using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Models;

namespace P01_StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////USE THIS TO ADD DATA FROM THE SEED METHOD////

            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.EnsureCreated();
            //    context.Seed();
            //    Console.WriteLine("Database seed done.");
            //}

            PresentStartPage presentStartPage = new PresentStartPage();
            presentStartPage.WelcomeBanner();
            presentStartPage.PresentStartPageCall();





        }
    }
}
