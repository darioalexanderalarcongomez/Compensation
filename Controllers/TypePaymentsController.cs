using Compensation.Data;
using Compensation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Compensation.Controllers
{
    public class TypePaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypePaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypePayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypePayment.ToListAsync());
        }

        // GET: TypePayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePayment = await _context.TypePayment
                .FirstOrDefaultAsync(m => m.TypePayment_Id == id);
            if (typePayment == null)
            {
                return NotFound();
            }

            return View(typePayment);
        }

        // GET: TypePayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypePayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypePayment_Id,DescriptionType")] TypePayment typePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typePayment);
        }

        // GET: TypePayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePayment = await _context.TypePayment.FindAsync(id);
            if (typePayment == null)
            {
                return NotFound();
            }
            return View(typePayment);
        }

        // POST: TypePayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypePayment_Id,DescriptionType")] TypePayment typePayment)
        {
            if (id != typePayment.TypePayment_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypePaymentExists(typePayment.TypePayment_Id))
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
            return View(typePayment);
        }

        // GET: TypePayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePayment = await _context.TypePayment
                .FirstOrDefaultAsync(m => m.TypePayment_Id == id);
            if (typePayment == null)
            {
                return NotFound();
            }

            return View(typePayment);
        }

        // POST: TypePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typePayment = await _context.TypePayment.FindAsync(id);
            if (typePayment != null)
            {
                _context.TypePayment.Remove(typePayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypePaymentExists(int id)
        {
            return _context.TypePayment.Any(e => e.TypePayment_Id == id);
        }
    }
}
