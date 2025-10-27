using Compensation.Data;
using Compensation.Models;
using Compensation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Compensation.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index(string sortOrder, int? pageNumber)
        {
            ViewBag.EventSortParam = sortOrder == "Event" ? "Event" : "";
            ViewBag.ClockInSortParam = sortOrder == "ClockIn" ? "ClockIn" : "";
            ViewBag.CurrentSort = sortOrder;

            var query = from t1 in _context.Event.Include(x => x.Employee)
                .Include(x => x.Fare)
                .Include(x => x.Venue)
                        where !(
                            from t2 in _context.Payment
                            select t2.Event_Id
                        ).Contains(t1.Event_Id)
                        orderby t1.ClockIn_Event descending
                        select t1;

            switch (sortOrder)
            {
                case "Event":
                    query = query.OrderBy(x => x.Description_Event);
                    break;
                case "ClockIn":
                    query = query.OrderBy(x => x.ClockIn_Event);
                    break;
                default:
                    query = query.OrderByDescending(x => x.ClockIn_Event);
                    break;
            }

            int pageSize = 10; // items per page
            var pagedList = await PaginatedList<Event>.CreateAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(pagedList);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(x => x.Employee)
                .Include(x => x.Fare)
                .Include(x => x.Venue)
                .FirstOrDefaultAsync(m => m.Event_Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        } 

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "FullName" );
            ViewData["Fare_Id"] = new SelectList(_context.Fare.OrderBy(x => x.Fare_Value), "Fare_Id", "Fare_Value");
            ViewData["Venue_Id"] = new SelectList(_context.Venue.OrderBy(x => x.Description), "Venue_Id", "Description");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Event_Id,Description_Event,ClockIn_Event,ClockOut_Event,Fare_Id,Employee_Id,Venue_Id")] EventViewModel viewModel)
        {
            int differenceDates = 0;
            decimal profit = 0;
            int fareId = viewModel.Fare_Id;
            if (ModelState.IsValid)
            {
                differenceDates = (int) viewModel.ClockOut_Event.Subtract(viewModel.ClockIn_Event).TotalMinutes;
                if (differenceDates > 480)
                    differenceDates -= 30;
                if( _context != null)
                {
                    Fare fare = await _context.Fare.FindAsync(fareId);
                    if (fare != null)
                        profit = differenceDates * (fare.Fare_Value / 60);
                    Event @event = new Event()
                    {
                        Description_Event = viewModel.Description_Event,
                        ClockIn_Event = viewModel.ClockIn_Event,
                        ClockOut_Event = viewModel.ClockOut_Event,
                        Profit = profit,
                        MinutesWorked = differenceDates,
                        Fare_Id = fareId,
                        Employee_Id = viewModel.Employee_Id,
                        Venue_Id = viewModel.Venue_Id
                    };
                    _context.Add(@event);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "FullName", viewModel.Employee_Id);
            ViewData["Fare_Id"] = new SelectList(_context.Fare.OrderBy(x => x.Fare_Value), "Fare_Id", "Fare_Value", fareId);
            ViewData["Venue_Id"] = new SelectList(_context.Venue.OrderBy(x => x.Description), "Venue_Id", "Description", viewModel.Venue_Id);

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(viewModel);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            var viewModel = new EventViewModel()
            {
                Event_Id = @event.Event_Id,
                ClockIn_Event = @event.ClockIn_Event,
                ClockOut_Event =@event.ClockOut_Event,  
                Description_Event = @event.Description_Event,
                Employee_Id = @event.Employee_Id,
                Fare_Id = @event.Fare_Id,
                MinutesWorked = @event.MinutesWorked,
                Profit = @event.Profit,
                Venue_Id = @event.Venue_Id
            };
            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "FullName", @event.Employee_Id);
            ViewData["Fare_Id"] = new SelectList(_context.Fare.OrderBy(x => x.Fare_Value), "Fare_Id", "Fare_Value", @event.Fare_Id);
            ViewData["Venue_Id"] = new SelectList(_context.Venue.OrderBy(x => x.Description), "Venue_Id", "Description", @event.Venue_Id);
            return View(viewModel);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Event_Id,Description_Event,ClockIn_Event,ClockOut_Event,Fare_Id,Employee_Id,Venue_Id")] EventViewModel viewModel)
        {
            decimal profit = 0;
            int differenceDates = 0;
            int fareId = viewModel.Fare_Id;
            if (id != viewModel.Event_Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    differenceDates = (int) viewModel.ClockOut_Event.Subtract(viewModel.ClockIn_Event).TotalMinutes;
                    if (differenceDates > 480)
                        differenceDates -= 30;
                    if(_context != null)
                    {
                        Fare fare = await _context.Fare.FindAsync (fareId);
                        if (fare != null) 
                            profit = differenceDates * (fare.Fare_Value / 60);

                        Event @event = new Event()
                        {
                            Event_Id = id,
                            ClockIn_Event = viewModel.ClockIn_Event,
                            ClockOut_Event = viewModel.ClockOut_Event,
                            Description_Event = viewModel.Description_Event,
                            Employee_Id = viewModel.Employee_Id,
                            Fare_Id = fareId,
                            MinutesWorked = differenceDates,
                            Profit = profit,
                            Venue_Id = viewModel.Venue_Id,
                        };
                        _context.Update(@event);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(viewModel.Event_Id))
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
            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "FullName", viewModel.Employee_Id);
            ViewData["Fare_Id"] = new SelectList(_context.Fare.OrderBy(x => x.Fare_Value), "Fare_Id", "Fare_Value", fareId);
            ViewData["Venue_Id"] = new SelectList(_context.Venue.OrderBy(x => x.Description), "Venue_Id", "Description", viewModel.Venue_Id);
            return View(viewModel);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(x => x.Employee)
                .Include(x => x.Fare)
                .Include(x => x.Venue)
                .FirstOrDefaultAsync(m => m.Event_Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Event_Id == id);
        }
    }
}
