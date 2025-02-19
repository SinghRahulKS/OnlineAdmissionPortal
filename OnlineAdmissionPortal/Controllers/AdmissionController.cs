using AutoMapper;
using Entity.Admission;
using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionPortal.Models;
using OnlineAdmissionPortal.Services.Student;

namespace OnlineAdmissionPortal.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public AdmissionController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TakeAdmission(AdmissionModel model)
        {
            var admission = _mapper.Map<Admission>(model);
            var res = _studentService.TakeAdmission(admission);
            return View();
        }
    }
}
