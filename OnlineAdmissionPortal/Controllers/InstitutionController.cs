using AutoMapper;
using Entity.Common;
using Entity.Institute;
using Entity.Student;
using Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionPortal.Models;
using OnlineAdmissionPortal.Services.Institution;
using OnlineAdmissionPortal.Services.Student;

namespace OnlineAdmissionPortal.Controllers
{
    //[Authorize]
    public class InstitutionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IMapper mapper, IInstitutionService institutionService)
        {
            _mapper = mapper;
            _institutionService = institutionService;
        }
        public ActionResult Index()
        {
            List<InstituteModel> institutes = new List<InstituteModel>();
            var institute = new Institute();
            var result = _institutionService.GetInstituteList(institute);
            var resp = _mapper.Map<List<InstituteModel>>(result);
            return View(resp);
        }
        public IActionResult GetAll(InstituteModel model)
        { 
            List<InstituteModel> institutes = new List<InstituteModel>();
            var institute = _mapper.Map<Institute>(model);
            var result = _institutionService.GetInstituteList(institute);
            var resp = _mapper.Map<List<InstituteModel>>(result);
            return Json(resp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterInstitute(InstituteModel model)
        {
            var resp = new BoolResponse();
            var institute = _mapper.Map<Institute>(model);
            resp = _institutionService.RegisterInstitute(institute);
            var res = _mapper.Map<BoolResponseModel>(resp);
            return RedirectToAction("Index");
        }
    }
}
