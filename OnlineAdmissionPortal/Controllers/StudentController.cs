using AutoMapper;
using Entity.Student;
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
           var student = _mapper.Map<StudentInfo>(model);
           var resp = _studentService.GetStudents(student);
            return View();
        }
        public IActionResult StudentDetails(int id)
        {
            var resp = _studentService.GetStudentDetails(id);
            return View();
        }
        public IActionResult RegisterStudent(StudentModel model) 
        {
            var student = _mapper.Map<StudentInfo>(model);
            var resp = _studentService.RegisterStudent(student);
            return View();
            return Json(model);
        }
    }
}
