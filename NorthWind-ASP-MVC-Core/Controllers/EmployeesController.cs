using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;
using Base.Repositories;

namespace NorthWind_ASP_MVC_Core.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository e;

        public EmployeesController()
        {
            e= new EmployeeRepository(new NORTHWNDContext());
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var nORTHWNDContext = e.GetAll().Include(e => e.ReportsToNavigation);
            return View(await nORTHWNDContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || e.GetAll().Count() == null)
            {
                return NotFound();
            }

            var employee = e.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["ReportsTo"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                e.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReportsTo"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName", employee.ReportsTo);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || e.GetAll() == null)
            {
                return NotFound();
            }

            var employee = e.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["ReportsTo"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName", employee.ReportsTo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    e.Update(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (e.GetById(employee.EmployeeId)==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReportsTo"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName", employee.ReportsTo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || e.GetAll() == null)
            {
                return NotFound();
            }

            var employee = e.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (e.GetAll() == null)
            {
                return Problem("Entity set 'NORTHWNDContext.Employees'  is null.");
            }
            var employee = e.GetById(id);
            if (employee != null)
            {
                e.Delete(employee);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
