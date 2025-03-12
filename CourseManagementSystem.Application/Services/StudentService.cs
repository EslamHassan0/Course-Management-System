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
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        private readonly IMapper _mapper;
        public StudentService(IGenericRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var allStudent = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(allStudent);
        }

        public async Task<StudentDto> GetAsync(int id)
        {
           var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return null;

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> AddAsync(StudentDto studentDto)
        {

            var student = _mapper.Map<Student>(studentDto);
            var result =  await _studentRepository.AddAsync(student);
            return _mapper.Map<StudentDto>(result);

        }

        public async Task<StudentDto> UpdateAsync(int id, StudentDto studentDto)
        {

            var getStudent = await _studentRepository.GetByIdAsync(id); 
            if(getStudent == null)
            {
                return null;
            }
            _mapper.Map(studentDto, getStudent);
            var result = await _studentRepository.UpdateAsync(getStudent);
            return _mapper.Map<StudentDto>(result);
        }
        public async Task DeleteAsync(int id)
        {
            var getStudent = await _studentRepository.GetByIdAsync(id);

            if(getStudent == null)
            {
                return;
            }
            await _studentRepository.DeleteAsync(getStudent);
        }

     
       
    }
}
