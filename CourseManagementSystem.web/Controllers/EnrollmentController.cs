using CourseManagementSystem.Application.DTO;
using CourseManagementSystem.Application.Interfaces;
using CourseManagementSystem.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagementSystem.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public EnrollmentController(
            IEnrollmentService enrollmentService,
            IStudentService studentService,
            ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

       
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {
            var enrollments= await _enrollmentService.GetAllAsync(pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = enrollments.TotalCount;

            return View(enrollments.items);
        }

         
        public async Task<IActionResult> Create()
        {
            var students = await _studentService.GetLookUpAsync() ?? new List<StudentDto>();
            var courses = await _courseService.GetLookUpAsync() ?? new List<CourseDto>();

            ViewBag.Students = students
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.FullName })
                .ToList();

            ViewBag.Courses = courses
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Title })
                .ToList();


            return View();
             
        }


      


        [HttpPost]
        public async Task<IActionResult> Create(EnrollmentDto enrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid input. Please check your entries.";
                ViewBag.Students = new SelectList(await _studentService.GetLookUpAsync(), "Id", "FullName");
                ViewBag.Courses = new SelectList(await _courseService.GetLookUpAsync(), "Id", "Title");
                return View(enrollmentDto);
            }

            var isEnrolled = await _enrollmentService.IsStudentEnrolledAsync(enrollmentDto.StudentId, enrollmentDto.CourseId);
            if (isEnrolled)
            {
                TempData["Error"] = "This student is already enrolled in the selected course.";
                return View(enrollmentDto);
            }

            var availableSlots = await _enrollmentService.GetAvailableSlotsAsync(enrollmentDto.CourseId);
            if (availableSlots <= 0)
            {
                TempData["Error"] = "No available slots in this course.";
                return View(enrollmentDto);
            }

            var success = await _enrollmentService.EnrollStudentAsync(enrollmentDto);
            TempData["Success"] = success ? "Student enrolled successfully!" : "Failed to enroll student.";
            return RedirectToAction(nameof(Index));
        }

         
        [HttpPost]
        public async Task<IActionResult> Unenroll(int id)
        {
            var success = await _enrollmentService.UnenrollStudentAsync(id);
            TempData["Success"] = success ? "Student unenrolled successfully!" : "Failed to unenroll student.";
            return RedirectToAction(nameof(Index));
        }

         
        [HttpGet]
        public async Task<JsonResult> GetAvailableSlots(int courseId)
        {
            var availableSlots = await _enrollmentService.GetAvailableSlotsAsync(courseId);
            return Json(new { availableSlots });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var enrollment = await _enrollmentService.GetAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }
    }
}
