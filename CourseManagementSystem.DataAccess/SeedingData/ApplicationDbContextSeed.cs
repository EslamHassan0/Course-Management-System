using CourseManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.web.SeedingData
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Student>().HasData(
              new Student { Id = 1, FullName = "Ahmed Ali", Email = "ahmed@example.com" },
              new Student { Id = 2, FullName = "Sara Mohamed", Email = "sara@example.com" }
                );

            
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# Basics", Description = "Learn the basics of C#" },
                new Course { Id = 2, Title = "ASP.NET Core", Description = "Build web apps with ASP.NET Core" }
            );

            
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.UtcNow },
                new Enrollment { Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.UtcNow }
            );
        }
    }
}
