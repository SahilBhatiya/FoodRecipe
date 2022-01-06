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
    public class RequiredStepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequiredStepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequiredSteps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Steps.Include(r => r.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RequiredSteps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requiredSteps = await _context.Steps
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requiredSteps == null)
            {
                return NotFound();
            }

            return View(requiredSteps);
        }

        // GET: RequiredSteps/Create
        public IActionResult Create()
        {
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
            return View();
        }

        // POST: RequiredSteps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,SerialNumber,HeadingName,Description,RTLower,RTUpper,RecipeId")] RequiredSteps requiredSteps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requiredSteps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", requiredSteps.RecipeId);
            return View(requiredSteps);
        }

        // GET: RequiredSteps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requiredSteps = await _context.Steps.FindAsync(id);
            if (requiredSteps == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", requiredSteps.RecipeId);
            return View(requiredSteps);
        }

        // POST: RequiredSteps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Image,SerialNumber,HeadingName,Description,RTLower,RTUpper,RecipeId")] RequiredSteps requiredSteps)
        {
            if (id != requiredSteps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requiredSteps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequiredStepsExists(requiredSteps.Id))
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
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", requiredSteps.RecipeId);
            return View(requiredSteps);
        }

        // GET: RequiredSteps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requiredSteps = await _context.Steps
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requiredSteps == null)
            {
                return NotFound();
            }

            return View(requiredSteps);
        }

        // POST: RequiredSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var requiredSteps = await _context.Steps.FindAsync(id);
            _context.Steps.Remove(requiredSteps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequiredStepsExists(string id)
        {
            return _context.Steps.Any(e => e.Id == id);
        }
    }
}
