#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Data;
using FoodRecipe.Models;

namespace FoodRecipe.Controllers
{
    public class BaseIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseIngredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseIngredients.ToListAsync());
        }

        // GET: BaseIngredients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseIngredients = await _context.BaseIngredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseIngredients == null)
            {
                return NotFound();
            }

            return View(baseIngredients);
        }

        // GET: BaseIngredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] BaseIngredients baseIngredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseIngredients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseIngredients);
        }

        // GET: BaseIngredients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseIngredients = await _context.BaseIngredients.FindAsync(id);
            if (baseIngredients == null)
            {
                return NotFound();
            }
            return View(baseIngredients);
        }

        // POST: BaseIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description")] BaseIngredients baseIngredients)
        {
            if (id != baseIngredients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseIngredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseIngredientsExists(baseIngredients.Id))
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
            return View(baseIngredients);
        }

        // GET: BaseIngredients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseIngredients = await _context.BaseIngredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseIngredients == null)
            {
                return NotFound();
            }

            return View(baseIngredients);
        }

        // POST: BaseIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baseIngredients = await _context.BaseIngredients.FindAsync(id);
            _context.BaseIngredients.Remove(baseIngredients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseIngredientsExists(string id)
        {
            return _context.BaseIngredients.Any(e => e.Id == id);
        }
    }
}
