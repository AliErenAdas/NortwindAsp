using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;
using Base.Repositories;
using DatabaseFirst.IRepositories;

namespace NorthWind_ASP_MVC_Core.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository c;
        public CategoriesController(ICategoryRepository category)
        {

            c= category;
            
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              return View(await c.GetAll().ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || c.GetAll().Count() == null)
            {
                return NotFound();
            }

            var category = c.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [Route("Kategori Ekle")]
        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description,Picture")] Category category)
        {
            if (ModelState.IsValid)
            {
                c.Create(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || c.GetAll() == null)
            {
                return NotFound();
            }

            var category = c.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description,Picture")] Category category)
        {
            if (id!= category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Category category1 = c.GetById(id);
                    category1.Picture = category.Picture;
                    category1.Description= category.Description;
                    category1.CategoryName= category.CategoryName;

                    c.Update(category1);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (c.GetById(category.CategoryId)==null)
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || c.GetAll() == null)
            {
                return NotFound();
            }

            var category = c.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (c.GetAll()==null)
            {
                return Problem("Entity set 'NORTHWNDContext.Categories'  is null.");
            }
            var category = c.GetById(id);
            if (category != null)
            {
                c.Delete(category);
            }
            
            
            return RedirectToAction(nameof(Index));
        }
    }
}
