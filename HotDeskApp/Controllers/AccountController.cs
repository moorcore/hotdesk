using HotDeskApp.Models;
using HotDeskApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace HotDeskApp.Controllers
{
    public class AccountController : Controller
    {
        private HotDeskDBContext db;
        public AccountController(HotDeskDBContext context)
        {
            db = context;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee =
                    await db.Employees.Include(u => u.Role).FirstOrDefaultAsync(u =>
                        u.Login == model.Login && u.Password == model.Password);

                if (employee != null)
                {
                    await Authenticate(employee);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login and(or) password");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = await db.Employees.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (employee == null)
                {
                    employee = new Employee {
                        EmployeeName = model.EmployeeName,
                        EmployeeSurname = model.EmployeeSurname,
                        Login = model.Login, 
                        Password = model.Password
                    };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.RoleName == "Employee");
                    if (userRole != null)
                        employee.Role = userRole;

                    db.Employees.Add(employee);
                    await db.SaveChangesAsync();

                    await Authenticate(employee);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login and(or) password");
            }
            return View(model);
        }

        private async Task Authenticate(Employee employee)
        {
            var claims = new List<Claim>
            {
                //new Claim(ClaimsIdentity.DefaultNameClaimType, employee.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, employee.Role?.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
