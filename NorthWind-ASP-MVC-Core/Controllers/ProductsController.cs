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
    public class ProductsController : Controller
    {
        private readonly ProductRepository p;
        private readonly CategoryRepository c;
        private readonly SupplierRepository s;

        public ProductsController()
        {
            p= new ProductRepository(new NORTHWNDContext());
            c= new CategoryRepository(new NORTHWNDContext());
            s= new SupplierRepository(new NORTHWNDContext());
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var nORTHWNDContext = p.GetAll().Include(p => p.Category).Include(p => p.Supplier);
            return View(await nORTHWNDContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || p.GetAll().Count() == null)
            {
                return NotFound();
            }

            var product = p.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(c.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(s.GetAll(), "SupplierId", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                p.Create(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(c.GetAll(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(s.GetAll(), "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || s.GetAll().Count() == null)
            {
                return NotFound();
            }

            var product = p.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(c.GetAll(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(s.GetAll(), "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    p.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (p.GetById(product.ProductId)==null)
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
            ViewData["CategoryId"] = new SelectList(c.GetAll(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(s.GetAll(), "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || p.GetAll() == null)
            {
                return NotFound();
            }

            var product = p.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (p.GetAll() == null)
            {
                return Problem("Entity set 'NORTHWNDContext.Products'  is null.");
            }
            var product = p.GetById(id);
            if (product != null)
            {
                p.Delete(product);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
