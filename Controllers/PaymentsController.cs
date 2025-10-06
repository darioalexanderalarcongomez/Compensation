using Compensation.Data;
using Compensation.Models;
using Compensation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Compensation.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Payment.Include(p => p.Event).Include(p => p.TypePayment).OrderByDescending(x=>x.Event_Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Event)
                .Include(p => p.TypePayment)
                .FirstOrDefaultAsync(m => m.Payment_Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            var query = from t1 in _context.Event
                        where !(
                            from t2 in _context.Payment
                            select t2.Event_Id
                        ).Contains(t1.Event_Id)
                        orderby t1.ClockIn_Event descending
                        select t1;
            ViewData["Event_Id"] = new SelectList(query, "Event_Id", "Description_Event");
            ViewData["TypePayment_Id"] = new SelectList(_context.TypePayment, "TypePayment_Id", "DescriptionType");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Payment_Id,TypePayment_Id,Event_Id,PaymentOrder")] PaymentViewModel paymentView)
        {
            if (ModelState.IsValid)
            {
                Payment payment = new Payment()
                {
                    Event_Id = paymentView.Event_Id,
                    TypePayment_Id = paymentView.TypePayment_Id,
                    PaymentOrder = paymentView.PaymentOrder,
                };
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var query = from t1 in _context.Event
                        where !(
                            from t2 in _context.Payment
                            select t2.Event_Id
                        ).Contains(t1.Event_Id)
                        orderby t1.ClockIn_Event descending
                        select t1;
            ViewData["Event_Id"] = new SelectList(query, "Event_Id", "Description_Event", paymentView.Event_Id);
            ViewData["TypePayment_Id"] = new SelectList(_context.TypePayment, "TypePayment_Id", "DescriptionType", paymentView.TypePayment_Id);
            return View(paymentView);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var query = from t1 in _context.Event
                        where !(
                            from t2 in _context.Payment
                            select t2.Event_Id
                        ).Contains(t1.Event_Id)
                        orderby t1.ClockIn_Event descending
                        select t1;
            ViewData["Event_Id"] = new SelectList(query, "Event_Id", "Description_Event",payment.Event_Id);
            ViewData["TypePayment_Id"] = new SelectList(_context.TypePayment, "TypePayment_Id", "DescriptionType", payment.TypePayment_Id);
            PaymentViewModel paymentView = new PaymentViewModel()
            {
                Event_Id = payment.Event_Id,
                TypePayment_Id = payment.TypePayment_Id,
                PaymentOrder = payment.PaymentOrder
            };
            return View(paymentView);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Payment_Id,TypePayment_Id,Event_Id,PaymentOrder")] PaymentViewModel paymentView)
        {
            if (id != paymentView.Payment_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Payment payment = new Payment()
                    {
                        Payment_Id = paymentView.Payment_Id,
                        Event_Id = paymentView.Event_Id,
                        TypePayment_Id = paymentView.TypePayment_Id
                    };
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(paymentView.Payment_Id))
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
            var query = from t1 in _context.Event
                        where !(
                            from t2 in _context.Payment
                            select t2.Event_Id
                        ).Contains(t1.Event_Id)
                        orderby t1.ClockIn_Event descending
                        select t1;
            ViewData["Event_Id"] = new SelectList(query, "Event_Id", "Description_Event", paymentView.Event_Id);
            ViewData["TypePayment_Id"] = new SelectList(_context.TypePayment, "TypePayment_Id", "DescriptionType", paymentView.TypePayment_Id);
            return View(paymentView);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Event)
                .Include(p => p.TypePayment)
                .FirstOrDefaultAsync(m => m.Payment_Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.Payment_Id == id);
        }
    }
}
