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
    public class ShippersController : Controller
    {
        private readonly ShipperRepository s;

        public ShippersController()
        {
            s= new ShipperRepository(new NORTHWNDContext());
        }

        // GET: Shippers
        public async Task<IActionResult> Index()
        {
              return View(await s.GetAll().ToListAsync());
        }

        // GET: Shippers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var shipper = s.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }

            return View(shipper);
        }

        // GET: Shippers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shippers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipperId,CompanyName,Phone")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                s.Create(shipper);
                return RedirectToAction(nameof(Index));
            }
            return View(shipper);
        }

        // GET: Shippers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var shipper = s.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipperId,CompanyName,Phone")] Shipper shipper)
        {
            if (id != shipper.ShipperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    s.Update(shipper);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (s.GetById(shipper.ShipperId)==null)
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
            return View(shipper);
        }

        // GET: Shippers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var shipper = s.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }

            return View(shipper);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (s.GetAll() == null)
            {
                return Problem("Entity set 'NORTHWNDContext.Shippers'  is null.");
            }
            var shipper = s.GetById(id);
            if (shipper != null)
            {
                s.Delete(shipper);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
