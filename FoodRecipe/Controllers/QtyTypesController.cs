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
    public class QtyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QtyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QtyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.QtyTypes.ToListAsync());
        }

        // GET: QtyTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtyType = await _context.QtyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qtyType == null)
            {
                return NotFound();
            }

            return View(qtyType);
        }

        // GET: QtyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QtyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortForm")] QtyType qtyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qtyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qtyType);
        }

        // GET: QtyTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtyType = await _context.QtyTypes.FindAsync(id);
            if (qtyType == null)
            {
                return NotFound();
            }
            return View(qtyType);
        }

        // POST: QtyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,ShortForm")] QtyType qtyType)
        {
            if (id != qtyType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qtyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QtyTypeExists(qtyType.Id))
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
            return View(qtyType);
        }

        // GET: QtyTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtyType = await _context.QtyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qtyType == null)
            {
                return NotFound();
            }

            return View(qtyType);
        }

        // POST: QtyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qtyType = await _context.QtyTypes.FindAsync(id);
            _context.QtyTypes.Remove(qtyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QtyTypeExists(string id)
        {
            return _context.QtyTypes.Any(e => e.Id == id);
        }
    }
}
