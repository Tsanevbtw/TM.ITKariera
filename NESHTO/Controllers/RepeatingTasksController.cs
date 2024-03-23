using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NESHTO.Data;
using NESHTO.Models;

namespace NESHTO.Controllers
{
    public class RepeatingTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepeatingTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepeatingTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepeatingTask.ToListAsync());
        }

        // GET: RepeatingTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repeatingTask = await _context.RepeatingTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repeatingTask == null)
            {
                return NotFound();
            }

            return View(repeatingTask);
        }

        // GET: RepeatingTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepeatingTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,PeriodBetween,IsCompleted")] RepeatingTask repeatingTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repeatingTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repeatingTask);
        }

        // GET: RepeatingTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repeatingTask = await _context.RepeatingTask.FindAsync(id);
            if (repeatingTask == null)
            {
                return NotFound();
            }
            return View(repeatingTask);
        }

        // POST: RepeatingTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,PeriodBetween,IsCompleted")] RepeatingTask repeatingTask)
        {
            if (id != repeatingTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repeatingTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepeatingTaskExists(repeatingTask.Id))
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
            return View(repeatingTask);
        }

        // GET: RepeatingTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repeatingTask = await _context.RepeatingTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repeatingTask == null)
            {
                return NotFound();
            }

            return View(repeatingTask);
        }

        // POST: RepeatingTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repeatingTask = await _context.RepeatingTask.FindAsync(id);
            if (repeatingTask != null)
            {
                _context.RepeatingTask.Remove(repeatingTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepeatingTaskExists(int id)
        {
            return _context.RepeatingTask.Any(e => e.Id == id);
        }
    }
}
