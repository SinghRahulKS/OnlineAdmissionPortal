using AutoMapper;
using Entity.Institute;
using Entity.Student;
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
        public IActionResult GetAll()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterInstitute()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterInstitute(InstituteModel model)
        {
            var resp = new BoolResponseModel();
            var institute = _mapper.Map<Institute>(model);
            var resp = _institutionService.RegisterInstitute(institute);
            var res = _mapper.Map<BoolResponseModel>(resp);
            return View(res);
        }
    }
}
