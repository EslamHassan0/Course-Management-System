using CourseManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(14)]
        public string NationalIDNo { get; set; }

        [MaxLength(11)]
        public string? PhoneNumber { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }

    }
}
