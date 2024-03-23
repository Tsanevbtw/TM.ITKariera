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
    public class SingleTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingleTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SingleTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SingleTask.ToListAsync());
        }

        // GET: SingleTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTask = await _context.SingleTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singleTask == null)
            {
                return NotFound();
            }

            return View(singleTask);
        }

        // GET: SingleTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SingleTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,IsCompleted")] SingleTask singleTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singleTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singleTask);
        }

        // GET: SingleTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTask = await _context.SingleTask.FindAsync(id);
            if (singleTask == null)
            {
                return NotFound();
            }
            return View(singleTask);
        }

        // POST: SingleTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,IsCompleted")] SingleTask singleTask)
        {
            if (id != singleTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singleTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingleTaskExists(singleTask.Id))
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
            return View(singleTask);
        }

        // GET: SingleTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTask = await _context.SingleTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singleTask == null)
            {
                return NotFound();
            }

            return View(singleTask);
        }

        // POST: SingleTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singleTask = await _context.SingleTask.FindAsync(id);
            if (singleTask != null)
            {
                _context.SingleTask.Remove(singleTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingleTaskExists(int id)
        {
            return _context.SingleTask.Any(e => e.Id == id);
        }
    }
}
