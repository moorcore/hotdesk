using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Controllers
{
    public class EmployeePanelController : Controller
    {
        private HotDeskDBContext db;
        public EmployeePanelController(HotDeskDBContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
