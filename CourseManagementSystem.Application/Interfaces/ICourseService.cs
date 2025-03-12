using CourseManagementSystem.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> GetAsync(int id);
        Task<CourseDto> AddAsync(CourseDto courseDto);
        Task<CourseDto> UpdateAsync(int id, CourseDto courseDto);
        Task DeleteAsync(int id);
    }
}
