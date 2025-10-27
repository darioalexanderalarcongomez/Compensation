using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Compensation.Data;
using Compensation.Models;

namespace Compensation.Controllers
{
    public class FaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fares
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var query = _context.Fare.OrderBy(x => x.Fare_Value).AsNoTracking();
            int pageSize = 10;
            var pagedList = await PaginatedList<Fare>.CreateAsync(query, pageNumber ?? 1, pageSize);
            return View(pagedList);
        }

        // GET: Fares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fare = await _context.Fare
                .FirstOrDefaultAsync(m => m.Fare_Id == id);
            if (fare == null)
            {
                return NotFound();
            }

            return View(fare);
        }

        // GET: Fares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fare_Id,Fare_Value")] Fare fare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fare);
        }

        // GET: Fares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fare = await _context.Fare.FindAsync(id);
            if (fare == null)
            {
                return NotFound();
            }
            return View(fare);
        }

        // POST: Fares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fare_Id,Fare_Value")] Fare fare)
        {
            if (id != fare.Fare_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FareExists(fare.Fare_Id))
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
            return View(fare);
        }

        // GET: Fares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fare = await _context.Fare
                .FirstOrDefaultAsync(m => m.Fare_Id == id);
            if (fare == null)
            {
                return NotFound();
            }

            return View(fare);
        }

        // POST: Fares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fare = await _context.Fare.FindAsync(id);
            if (fare != null)
            {
                _context.Fare.Remove(fare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FareExists(int id)
        {
            return _context.Fare.Any(e => e.Fare_Id == id);
        }
    }
}
