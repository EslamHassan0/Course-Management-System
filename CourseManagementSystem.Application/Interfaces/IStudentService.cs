﻿using CourseManagementSystem.Application.DTO;
using CourseManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetLookUpAsync();
        Task<ResponseDTO<StudentDto>> GetAllAsync(int pageNumber = 1, int pageSize = 5);
        Task<StudentDto> GetAsync(int id); 
        Task<StudentDto> AddAsync(StudentDto studentDto); 
        Task<StudentDto> UpdateAsync(int id,StudentDto studentDto); 
        Task DeleteAsync(int id); 
    }
}
