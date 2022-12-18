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
    public class CustomersController : Controller
    {
        private readonly CustomerRepository c;

        public CustomersController()
        {
            c= new CustomerRepository(new NORTHWNDContext());
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await c.GetAll().ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || c.GetAll().Count() == null)
            {
                return NotFound();
            }

            var customer = c.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [Route("Olustur")]
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
               c.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || c.GetAll() == null)
            {
                return NotFound();
            }

            var customer = c.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    c.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (c.GetById(customer.CustomerId)==null)
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || c.GetAll() == null)
            {
                return NotFound();
            }

            var customer = c.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (c.GetAll() == null)
            {
                return Problem("Entity set 'NORTHWNDContext.Customers'  is null.");
            }
            var customer = c.GetById(id);
            if (customer != null)
            {
                c.Delete(customer);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

    
    }
}
