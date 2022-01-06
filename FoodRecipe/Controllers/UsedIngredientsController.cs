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
    public class UsedIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsedIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsedIngredients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ingredients.Include(u => u.Recipe).Include(u => u.baseIngredients).Include(u => u.qtyType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UsedIngredients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedIngredients = await _context.Ingredients
                .Include(u => u.Recipe)
                .Include(u => u.baseIngredients)
                .Include(u => u.qtyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usedIngredients == null)
            {
                return NotFound();
            }

            return View(usedIngredients);
        }

        // GET: UsedIngredients/Create
        public IActionResult Create()
        {
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
            ViewData["BaseIndredientsId"] = new SelectList(_context.BaseIngredients, "Id", "Id");
            ViewData["QtyTypeId"] = new SelectList(_context.QtyTypes, "Id", "Id");
            return View();
        }

        // POST: UsedIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qty,BaseIndredientsId,RecipeId,QtyTypeId")] UsedIngredients usedIngredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usedIngredients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", usedIngredients.RecipeId);
            ViewData["BaseIndredientsId"] = new SelectList(_context.BaseIngredients, "Id", "Id", usedIngredients.BaseIndredientsId);
            ViewData["QtyTypeId"] = new SelectList(_context.QtyTypes, "Id", "Id", usedIngredients.QtyTypeId);
            return View(usedIngredients);
        }

        // GET: UsedIngredients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedIngredients = await _context.Ingredients.FindAsync(id);
            if (usedIngredients == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", usedIngredients.RecipeId);
            ViewData["BaseIndredientsId"] = new SelectList(_context.BaseIngredients, "Id", "Id", usedIngredients.BaseIndredientsId);
            ViewData["QtyTypeId"] = new SelectList(_context.QtyTypes, "Id", "Id", usedIngredients.QtyTypeId);
            return View(usedIngredients);
        }

        // POST: UsedIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Qty,BaseIndredientsId,RecipeId,QtyTypeId")] UsedIngredients usedIngredients)
        {
            if (id != usedIngredients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usedIngredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsedIngredientsExists(usedIngredients.Id))
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
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", usedIngredients.RecipeId);
            ViewData["BaseIndredientsId"] = new SelectList(_context.BaseIngredients, "Id", "Id", usedIngredients.BaseIndredientsId);
            ViewData["QtyTypeId"] = new SelectList(_context.QtyTypes, "Id", "Id", usedIngredients.QtyTypeId);
            return View(usedIngredients);
        }

        // GET: UsedIngredients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedIngredients = await _context.Ingredients
                .Include(u => u.Recipe)
                .Include(u => u.baseIngredients)
                .Include(u => u.qtyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usedIngredients == null)
            {
                return NotFound();
            }

            return View(usedIngredients);
        }

        // POST: UsedIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usedIngredients = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Remove(usedIngredients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsedIngredientsExists(string id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
