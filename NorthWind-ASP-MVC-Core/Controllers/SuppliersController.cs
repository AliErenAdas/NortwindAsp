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
    public class SuppliersController : Controller
    {
        private readonly SupplierRepository s;

        public SuppliersController()
        {
            s= new SupplierRepository(new NORTHWNDContext());
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
              return View(await s.GetAll().ToListAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var supplier = s.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                s.Create(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var supplier = s.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    s.Update(supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (s.GetById(supplier.SupplierId)==null)
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
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var supplier = s.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (s.GetAll() == null)
            {
                return Problem("Entity set 'NORTHWNDContext.Suppliers'  is null.");
            }
            var supplier = s.GetById(id);
            if (supplier != null)
            {
                s.Delete(supplier);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
          return s.GetAll().Any(e => e.SupplierId == id);
        }
    }
}
