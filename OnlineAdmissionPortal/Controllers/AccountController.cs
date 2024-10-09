using AutoMapper;
using Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineAdmissionPortal.Models;
using OnlineAdmissionPortal.Services.Account;

namespace OnlineAdmissionPortal.Controllers
{
   // [Authorize(Roles = "SuperAdmin")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IConfiguration configuration, ILogger<AccountController> logger, IAccountService accountService , IMapper  mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _accountService = accountService;
            _mapper = mapper;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        //Getting registered users from database
       // [Authorize]
        [HttpPost]
        public ActionResult GetUsers([FromBody] UserModel model)
        {
            List<UserModel> users = new List<UserModel>();
            model.PageSize = model.PageSize == 0 ? _configuration.GetValue<int>("Pagination:PageSize") : model.PageSize;
            model.CurrentPage = model.CurrentPage == 0 ? 1 : model.CurrentPage;
            var user = _mapper.Map<ApplicationUser>(model);
            var resp = _accountService.GetUsers(user);
            users = _mapper.Map<List<UserModel>>(resp);
            _logger.LogInformation("Error processing GetUser: Page Number : {ExceptionMessage},UserName:  {UserName}", model.CurrentPage, User.Identity?.Name);
            
            return Json(users);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
