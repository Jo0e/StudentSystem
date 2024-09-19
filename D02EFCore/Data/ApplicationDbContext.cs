using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = . ;Initial Catalog=StudentSystem;Integrated Security = True ;TrustServerCertificate= True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .HasColumnType("nvarchar(100)");
            
            modelBuilder.Entity<Student>()
                .Property(e => e.PhoneNumber)
                .HasColumnType("varchar(10)");

            modelBuilder.Entity<Course>()
                .Property(e => e.Name)
                .HasColumnType("nvarchar(80)");

            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Resource>()
                .Property(e => e.Name)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<StudentCourse>()
                .HasKey(e  =>new {e.StudentId,e.CourseId});

           
                
        }

        // THE SEED METHOD TO ADD SAMPEL DATA
        public void Seed()
        {
            if (!Students.Any())
            {
                Students.AddRange(
                new Student { Name = "Youssef Khaled", RegisteredOn = DateTime.Now, Birthday = new DateTime(2001, 06, 27), PhoneNumber="10101010",Password="1234" },
                new Student { Name = "John Doe", RegisteredOn = DateTime.Now ,PhoneNumber = "383838380" ,Password = "0000" },
                new Student { Name = "Ali Mohamed", RegisteredOn = DateTime.Now.AddDays(-10), Birthday = new DateTime(2002, 04, 07), Password = "1111" }
                );
                SaveChanges();
            }
            if (!Courses.Any())
            {
                Courses.AddRange(
                new Course { Name = "Math", StartDate = DateTime.Now.AddDays(-20), EndDate = DateTime.Now.AddMonths(6), Price = 5000 },
                new Course { Name = "Science", StartDate = DateTime.Now.AddDays(-25), EndDate = DateTime.Now.AddMonths(5), Price = 3000 },
                new Course { Name = "English", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3), Price = 6000 }
                );
                SaveChanges();
            }
            if (!Resources.Any())
            {
                Resources.AddRange(
                new Resource { Name = "Math Video", Url = "https://math.com/video", ResourceType = ResourceType.Video, CourseId = 1 },
                new Resource { Name = "Science Presentation", Url = "https://science.com/presentation", ResourceType = ResourceType.Presentation, CourseId = 2 },
                new Resource { Name = "English Document", Url = "https://English.com/Document", ResourceType = ResourceType.Document, CourseId = 3 }
            );
                SaveChanges();
            }
            if (!Homeworks.Any())
            {
                Homeworks.AddRange(
                new Homework { Content = "Math Homework", ContentType = ContentType.Pdf, SubmissionTime = DateTime.Now, StudentId = 1, CourseId = 1 },
                new Homework { Content = "Science Homework", ContentType = ContentType.Zip, SubmissionTime = DateTime.Now, StudentId = 2, CourseId = 2 },
                new Homework { Content = "English Homework", ContentType = ContentType.Application, SubmissionTime = DateTime.Now, StudentId = 3, CourseId = 3 }
            );
                SaveChanges();
            }
            
        }
    }
}
