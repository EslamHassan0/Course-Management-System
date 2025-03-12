using CourseManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.DTO
{
    public class CourseDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int MaximumCapacity { get; set; }
        public string? Description { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
