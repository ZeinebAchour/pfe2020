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
    public class SsmsDatabasesController : Controller
    {
        private readonly BDStock1Context _context;

        public SsmsDatabasesController(BDStock1Context context)
        {
            _context = context;
        }

        // GET: SsmsDatabases
        public async Task<IActionResult> Index()
        {
            var bDStock1Context = _context.SsmsDatabases.Include(s => s.IdInstancesNavigation);
            return View(await bDStock1Context.ToListAsync());
        }

        // GET: SsmsDatabases/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsDatabases = await _context.SsmsDatabases
                .Include(s => s.IdInstancesNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsDatabases == null)
            {
                return NotFound();
            }

            return View(ssmsDatabases);
        }

        // GET: SsmsDatabases/Create
        public IActionResult Create()
        {
            ViewData["IdInstances"] = new SelectList(_context.SsmsInstances, "Id", "Title");
            return View();
        }

        // POST: SsmsDatabases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,InstanceName,IdInstances")] SsmsDatabases ssmsDatabases)
        {
            if (ModelState.IsValid)
            {
                ssmsDatabases.Id = Guid.NewGuid();
                _context.Add(ssmsDatabases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstances"] = new SelectList(_context.SsmsInstances, "Id", "Title", ssmsDatabases.IdInstances);
            return View(ssmsDatabases);
        }

        // GET: SsmsDatabases/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsDatabases = await _context.SsmsDatabases.FindAsync(id);
            if (ssmsDatabases == null)
            {
                return NotFound();
            }
            ViewData["IdInstances"] = new SelectList(_context.SsmsInstances, "Id", "Title", ssmsDatabases.IdInstances);
            return View(ssmsDatabases);
        }

        // POST: SsmsDatabases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,InstanceName,IdInstances")] SsmsDatabases ssmsDatabases)
        {
            if (id != ssmsDatabases.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ssmsDatabases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SsmsDatabasesExists(ssmsDatabases.Id))
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
            ViewData["IdInstances"] = new SelectList(_context.SsmsInstances, "Id", "Title", ssmsDatabases.IdInstances);
            return View(ssmsDatabases);
        }

        // GET: SsmsDatabases/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsDatabases = await _context.SsmsDatabases
                .Include(s => s.IdInstancesNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsDatabases == null)
            {
                return NotFound();
            }

            return View(ssmsDatabases);
        }

        // POST: SsmsDatabases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ssmsDatabases = await _context.SsmsDatabases.FindAsync(id);
            _context.SsmsDatabases.Remove(ssmsDatabases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SsmsDatabasesExists(Guid id)
        {
            return _context.SsmsDatabases.Any(e => e.Id == id);
        }
    }
}
