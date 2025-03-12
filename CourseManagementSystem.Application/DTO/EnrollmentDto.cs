using CourseManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.DTO
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; } 
        public int CourseId { get; set; }
        public string? CourseTitle { get; set; }  
        public DateTime EnrollmentDate { get; set; }
    }
}
