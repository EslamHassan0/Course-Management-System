using CourseManagementSystem.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollStudentAsync(EnrollmentDto enrollmentDto);
        Task<bool> UnenrollStudentAsync(int enrollmentId);
        Task<int> GetAvailableSlotsAsync(int courseId);
        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
    }
}
