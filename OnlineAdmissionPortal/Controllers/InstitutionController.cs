using AutoMapper;
using Entity.Common;
using Entity.Institute;
using Entity.Student;
using Entity.User;
using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionPortal.Models;
using OnlineAdmissionPortal.Services.Institution;
using OnlineAdmissionPortal.Services.Student;

namespace OnlineAdmissionPortal.Controllers
{
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
            return View();
        }
        public IActionResult GetAll(InstituteModel model)
        { 
            List<InstituteModel> institutes = new List<InstituteModel>();
            var res = _mapper.Map<Institute>(model);
            var result = _institutionService.GetInstituteList(res);
            return View();
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
            return View(res);
        }
    }
}
