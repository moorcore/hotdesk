using HotDeskApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //        private IEmployeesService _service;

        private HotDeskDBContext db;

        public HomeController(ILogger<HomeController> logger, HotDeskDBContext context/*, IEmployeesService service*/)
        {
            _logger = logger;
            db = context;
            //            _service = service;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPanel()
        {
            return View();
        }

        [Authorize]
        public ActionResult EmployeePanel()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
