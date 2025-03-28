﻿using AutoMapper;
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
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;

        private readonly IMapper _mapper;
        public CourseService(IGenericRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDto>> GetLookUpAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<ResponseDTO<CourseDto>> GetAllAsync(int pageNumber = 1, int pageSize = 5)
        {

            var courses = await _courseRepository.GetAllAsync();

            int totalRecords = courses.Count();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);


            var paginatedCourses = courses
                .OrderBy(e => e.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();


            var courseDto = _mapper.Map<List<CourseDto>>(paginatedCourses);
            return new ResponseDTO<CourseDto>
            {
                items = courseDto,
                TotalCount = totalPages
            };
        }
        public async Task<CourseDto> GetAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> AddAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var result = await _courseRepository.AddAsync(course);
            return _mapper.Map<CourseDto>(result);

        }

        public async Task<CourseDto> UpdateAsync(int id, CourseDto courseDto)
        {
            var getCourse = await _courseRepository.GetByIdAsync(id);
            if (getCourse == null)
            {
                return null;
            }
            _mapper.Map(courseDto, getCourse);
            var result = await _courseRepository.UpdateAsync(getCourse);
            return _mapper.Map<CourseDto>(result);
        }

        public async  Task DeleteAsync(int id)
        {
            var getCourse = await _courseRepository.GetByIdAsync(id);

            if (getCourse == null)
            {
                return;
            }
            await _courseRepository.DeleteAsync(getCourse);
        }

     
      

    
    }
}
