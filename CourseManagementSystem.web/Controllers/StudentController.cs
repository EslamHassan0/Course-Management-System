using CourseManagementSystem.Application.DTO;
using CourseManagementSystem.Application.Interfaces;
using CourseManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementSystem.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {



            var students = await _studentService.GetAllAsync(pageNumber , pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = students.TotalCount;


           
            return View(students.items); 
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddAsync(studentDto);
                return RedirectToAction(nameof(Index));  
            }
            return View(studentDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

         
        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                await _studentService.UpdateAsync(id, studentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetAsync(id);
            if (student == null)
                return NotFound();

            await _studentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
