
using Microsoft.AspNetCore.Mvc;
using SGS.Application.Interfaces;
using SGS.Domain.Entities;

namespace SGS.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Display all students
        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        // Display add student form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save new student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            try
            {
                _studentService.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(student);
            }
        }

        // Display average grade
        public IActionResult AverageGrade()
        {
            var average = _studentService.GetAverageGrade();
            return View(average);
        }

        // Display highest-grade student
        public IActionResult HighestGrade()
        {
            var student = _studentService.GetHighestGradeStudent();
            return View(student);
        }
    }
}
