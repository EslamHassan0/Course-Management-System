using AutoMapper;
using CourseManagementSystem.Application.DTO;
using CourseManagementSystem.Application.Interfaces;
using CourseManagementSystem.DataAccess.Entities;
using CourseManagementSystem.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        //
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IGenericRepository<Course> _courseRepository;
       

        private readonly IMapper _mapper;
        public EnrollmentService(
         IEnrollmentRepository enrollmentRepository,
          IGenericRepository<Course> courseRepository,
          IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<bool>EnrollStudentAsync(EnrollmentDto enrollmentDto)
        {
           var course = await _courseRepository.GetByIdAsync(enrollmentDto.CourseId);
            if (course == null || course.MaximumCapacity <= 0)
                return false;

            var existingStudentEnrollment = await _enrollmentRepository.ExistsAsync(e =>
                 e.StudentId == enrollmentDto.StudentId && e.CourseId == enrollmentDto.CourseId);

            if (existingStudentEnrollment)
                return false;

            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);

            await _enrollmentRepository.AddAsync(enrollment);
            return true;
        
        }
        public async Task<bool> UnenrollStudentAsync(int enrollmentId)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId);
            if (enrollment == null)
                return false;

            await _enrollmentRepository.DeleteAsync(enrollment);
            return true;
        }

        public async Task<int> GetAvailableSlotsAsync(int courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
                return 0;

            var enrolledCount = await _enrollmentRepository.GetEnrollmentCountByCourseIdAsync(courseId);
            return course.MaximumCapacity - enrolledCount;
        }

        public async Task<bool> IsStudentEnrolledAsync(int studentId, int courseId)
        {
            return await _enrollmentRepository.ExistsAsync(e =>
                e.StudentId == studentId && e.CourseId == courseId);
        }

        
    }
}
