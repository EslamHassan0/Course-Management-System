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
        private readonly IGenericRepository<Student> _studentRepository;
       

        private readonly IMapper _mapper;
        public EnrollmentService(
         IEnrollmentRepository enrollmentRepository,
          IGenericRepository<Course> courseRepository,
          IMapper mapper,
          IGenericRepository<Student> studentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<(IEnumerable<EnrollmentDto> Enrollments, int TotalPages)> GetAllAsync(int pageNumber = 1, int pageSize = 5)
        {
            var allEnrollment = await _enrollmentRepository.GetAllWithDetailsAsync();

            int totalRecords = allEnrollment.Count();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);


            var paginatedEnrollments = allEnrollment
                .OrderBy(e => e.EnrollmentDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (_mapper.Map<IEnumerable<EnrollmentDto>>(paginatedEnrollments), totalPages);

             
        }

        public async Task<EnrollmentDto> GetAsync(int id)
        {
            var allEnrollment = await _enrollmentRepository.GetByIdAsync(id);
            return _mapper.Map<EnrollmentDto>(allEnrollment);
        }

        public async Task<bool>EnrollStudentAsync(EnrollmentDto enrollmentDto)
        {
           var course = await _courseRepository.GetByIdAsync(enrollmentDto.CourseId);
            if (course == null || course.MaximumCapacity <= 0)
                return false;

            var student = await _studentRepository.GetByIdAsync(enrollmentDto.StudentId);
            if (student == null)
                return false;

            var existingStudentEnrollment = await _enrollmentRepository.ExistsAsync(e =>
                 e.StudentId == enrollmentDto.StudentId && e.CourseId == enrollmentDto.CourseId);

            if (existingStudentEnrollment)
                return false;

            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);

            enrollment.Course = course;
            enrollment.Student = student;
            enrollment.EnrollmentDate = DateTime.Now;
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
