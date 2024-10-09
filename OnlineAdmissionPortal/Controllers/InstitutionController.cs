using Microsoft.AspNetCore.Mvc;

namespace OnlineAdmissionPortal.Controllers
{
    public class InstitutionController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
