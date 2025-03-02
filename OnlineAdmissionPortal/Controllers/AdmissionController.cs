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
            var res = _studentService.GetAllAdmissions();
            var admissions = _mapper.Map<List<AdmissionModel>>(res);
            return View(admissions);
        }
        public JsonResult TakeAdmission(AdmissionModel model)
        {
            var admission = _mapper.Map<Admission>(model);
            var res = _studentService.TakeAdmission(admission);
            return Json(res);
        }
    }
}
