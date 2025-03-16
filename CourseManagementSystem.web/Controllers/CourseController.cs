using CourseManagementSystem.Application.DTO;
using CourseManagementSystem.Application.Interfaces;
using CourseManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementSystem.web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

    
       
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {
            var courses = await _courseService.GetAllAsync(pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = courses.TotalCount;

            return View(courses.items);
        }


        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddAsync(courseDto);
                return RedirectToAction(nameof(Index));
            }
            return View(courseDto);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

         
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                await _courseService.UpdateAsync(id, courseDto);
                return RedirectToAction(nameof(Index));
            }
            return View(courseDto);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetAsync(id);
            if (course == null)
                return NotFound();

            await _courseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
