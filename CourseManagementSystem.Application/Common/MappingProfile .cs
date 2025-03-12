using AutoMapper;
using CourseManagementSystem.Application.DTO;
using CourseManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student , StudentDto>().ReverseMap();
            CreateMap<Course , CourseDto>().ReverseMap();
            CreateMap<Enrollment , EnrollmentDto>().ReverseMap();
        }
    }
}
