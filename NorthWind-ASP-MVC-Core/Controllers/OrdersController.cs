using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;
using Base.Repositories;
using System.Runtime.CompilerServices;

namespace NorthWind_ASP_MVC_Core.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderRepository o;
        private readonly CustomerRepository c;
        private readonly EmployeeRepository e;
        private readonly ShipperRepository  s;
       

        public OrdersController()
        {
            o= new OrderRepository(new NORTHWNDContext());
            c= new CustomerRepository(new NORTHWNDContext());
            e= new EmployeeRepository(new NORTHWNDContext());
            s= new ShipperRepository(new NORTHWNDContext());
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var nORTHWNDContext = o.GetAll().Include(o => o.Customer).Include(o => o.Employee).Include(o => o.ShipViaNavigation);
            return View(await nORTHWNDContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || o.GetAll().Count() == null)
            {
                return NotFound();
            }

            var order = o.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(c.GetAll(), "CustomerId", "CustomerId");
            ViewData["EmployeeId"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName");
            ViewData["ShipVia"] = new SelectList(s.GetAll(), "ShipperId", "CompanyName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,EmployeeId,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                o.Create(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(c.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(s.GetAll(), "ShipperId", "CompanyName", order.ShipVia);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || o.GetAll() == null)
            {
                return NotFound();
            }

            var order = o.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(c.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(s.GetAll(), "ShipperId", "CompanyName", order.ShipVia);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,EmployeeId,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    o.Update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (o.GetById(order.OrderId)==null)
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
            ViewData["CustomerId"] = new SelectList(c.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(e.GetAll(), "EmployeeId", "FirstName", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(s.GetAll(), "ShipperId", "CompanyName", order.ShipVia);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || o.GetAll() == null)
            {
                return NotFound();
            }

            var order = o.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (o.GetAll() == null)
            {
                return Problem("Entity set 'NORTHWNDContext.Orders'  is null.");
            }
            var order = o.GetById(id);
            if (order != null)
            {
                o.Delete(order);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
