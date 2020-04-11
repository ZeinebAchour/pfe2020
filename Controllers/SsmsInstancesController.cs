using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pfeProject2020.Models;

namespace pfeProject2020.Controllers
{
    public class SsmsInstancesController : Controller
    {
        private readonly BDStock1Context _context;

        public SsmsInstancesController(BDStock1Context context)
        {
            _context = context;
        }

        // GET: SsmsInstances
        public async Task<IActionResult> Index()
        {
            return View(await _context.SsmsInstances.ToListAsync());
        }

        // GET: SsmsInstances/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsInstances = await _context.SsmsInstances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsInstances == null)
            {
                return NotFound();
            }

            return View(ssmsInstances);
        }

        // GET: SsmsInstances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SsmsInstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] SsmsInstances ssmsInstances)
        {
            if (ModelState.IsValid)
            {
                ssmsInstances.Id = Guid.NewGuid();
                _context.Add(ssmsInstances);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ssmsInstances);
        }

        // GET: SsmsInstances/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsInstances = await _context.SsmsInstances.FindAsync(id);
            if (ssmsInstances == null)
            {
                return NotFound();
            }
            return View(ssmsInstances);
        }

        // POST: SsmsInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title")] SsmsInstances ssmsInstances)
        {
            if (id != ssmsInstances.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ssmsInstances);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SsmsInstancesExists(ssmsInstances.Id))
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
            return View(ssmsInstances);
        }

        // GET: SsmsInstances/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsInstances = await _context.SsmsInstances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsInstances == null)
            {
                return NotFound();
            }

            return View(ssmsInstances);
        }

        // POST: SsmsInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ssmsInstances = await _context.SsmsInstances.FindAsync(id);
            _context.SsmsInstances.Remove(ssmsInstances);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SsmsInstancesExists(Guid id)
        {
            return _context.SsmsInstances.Any(e => e.Id == id);
        }
    }
}
