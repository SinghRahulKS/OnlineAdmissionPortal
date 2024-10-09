using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionPortal.Models;
using OnlineAdmissionPortal.Services.Student;

namespace OnlineAdmissionPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStudents(StudentModel model)
        { 
           // var student = _mapper.Map<Student>(model);
            //var resp = _studentService.GetStudents(student);
            return View();
        }
        public IActionResult StudentDetails()
        { 
            return View();
        }
        public IActionResult RegisterStudent(StudentModel model) 
        {
            return Json(model);
        }
    }
}
