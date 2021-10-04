using HotDeskApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Controllers
{
    public class AdminPanelController : Controller
    {
        private HotDeskDBContext db;
        public AdminPanelController(HotDeskDBContext context)
        {
            db = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetRegisteredEmployees()
        {
            return View(await db.Employees.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateNewEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewEmployee(CreateNewEmpViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = await db.Employees.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (employee == null)
                {
                    employee = new Employee
                    {
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

                    return RedirectToAction("AdminPanel", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login and(or) password");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task <ActionResult> EditEmployee(int id)
        {
            Employee employee = await db.Employees.Where(s => s.EmployeeId == id).FirstOrDefaultAsync();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(Employee emp)
        {
            Employee employee = await db.Employees.Where(s => s.EmployeeId == emp.EmployeeId).FirstOrDefaultAsync();
            emp.Password = employee.Password;
            emp.RoleId = employee.RoleId;
            db.Employees.Remove(employee);
            db.Employees.Add(emp);

            await db.SaveChangesAsync();

            return RedirectToAction("AdminPanel", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployeeConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("AdminPanel", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetWorkplaces()
        {
            return View(await db.Workplaces.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddWorkplace()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkplace(AddWorkplaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Workplace workplace = await db.Workplaces.FirstOrDefaultAsync(u => u.ReservationId == model.ReservationId);
                if (workplace == null)
                {
                    workplace = new Workplace
                    {
                        Device = model.Device,
                        Reservation = model.Reservation,
                        Description = model.Description
                    };

                    db.Workplaces.Add(workplace);
                    await db.SaveChangesAsync();

                    return RedirectToAction("AdminPanel", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login and(or) password");
            }
            return View(model);
        }

/*        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditWorkplace(int id)
        {
            Workplace workplace = await db.Workplaces.Where(s => s.WorkplaceId == id).FirstOrDefaultAsync();
            return View(workplace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWorkplace(Workplace wp)
        {
            Workplace workplace = await db.Workplaces.Where(s => s.WorkplaceId == wp.WorkplaceId).FirstOrDefaultAsync();
            wp.Password = employee.Password;
            wp.RoleId = employee.RoleId;
            db.Employees.Remove(employee);
            db.Employees.Add(wp);

            await db.SaveChangesAsync();

            return RedirectToAction("AdminPanel", "Home");
        }*/

        [HttpGet]
        public async Task<ActionResult> DeleteWorkplace(int id)
        {
            Workplace workplace = await db.Workplaces.FindAsync(id);
            return View(workplace);
        }

        [HttpPost, ActionName("DeleteWorkplace")]
        public async Task<ActionResult> DeleteWorkplaceConfirmed(int id)
        {
            Workplace workplace = await db.Workplaces.FindAsync(id);

            db.Workplaces.Remove(workplace);
            db.SaveChanges();

            return RedirectToAction("AdminPanel", "Home");
        }
    }
}
