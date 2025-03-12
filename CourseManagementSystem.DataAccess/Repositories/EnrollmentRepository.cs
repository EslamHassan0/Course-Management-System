using CourseManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.DataAccess.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext context)  :base(context)
        {
            _context = context;
        }
        public async Task<int> GetEnrollmentCountByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments.CountAsync(a => a.CourseId == courseId);
        }
    }
}
