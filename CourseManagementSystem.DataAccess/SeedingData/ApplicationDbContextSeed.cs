using CourseManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.web.SeedingData
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Students.Any())   
            {
                await context.Students.AddRangeAsync(
                    new Student { Id = 1, FullName = "Ahmed Ali", Email = "ahmed@example.com", Birthdate = DateTime.UtcNow, NationalIDNo = "123", PhoneNumber = "01022336478" },
                    new Student { Id = 2, FullName = "Sara Mohamed", Email = "sara@example.com", Birthdate = DateTime.UtcNow, NationalIDNo = "321", PhoneNumber = "01022336478" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Courses.Any())
            {
                await context.Courses.AddRangeAsync(
                    new Course { Id = 1, Title = "C# Basics", Description = "Learn the basics of C#" , MaximumCapacity = 10 },
                    new Course { Id = 2, Title = "ASP.NET Core", Description = "Build web apps with ASP.NET Core" , MaximumCapacity = 12 }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Enrollments.Any())
            {
               
                //var course = new Course { Id = 3, Title = "ASP.NET Core", MaximumCapacity = 10 };
                //context.Courses.Add(course);

               
                var enrollment = new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.UtcNow };
                context.Enrollments.Add(enrollment);

                 
                await context.SaveChangesAsync();

            }

        }
    }
}
