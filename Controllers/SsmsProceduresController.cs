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
    public class SsmsProceduresController : Controller
    {
        private readonly BDStock1Context _context;

        public SsmsProceduresController(BDStock1Context context)
        {
            _context = context;
        }

        // GET: SsmsProcedures
        public async Task<IActionResult> Index()
        {
            var bDStock1Context = _context.SsmsProcedures.Include(s => s.IdBdNavigation);
            return View(await bDStock1Context.ToListAsync());
        }

        // GET: SsmsProcedures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsProcedures = await _context.SsmsProcedures
                .Include(s => s.IdBdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsProcedures == null)
            {
                return NotFound();
            }

            return View(ssmsProcedures);
        }

        // GET: SsmsProcedures/Create
        public IActionResult Create()
        {
            ViewData["IdBd"] = new SelectList(_context.SsmsDatabases, "Id", "Title");
            return View();
        }

        // POST: SsmsProcedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IdBd")] SsmsProcedures ssmsProcedures)
        {
            if (ModelState.IsValid)
            {
                ssmsProcedures.Id = Guid.NewGuid();
                _context.Add(ssmsProcedures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBd"] = new SelectList(_context.SsmsDatabases, "Id", "Title", ssmsProcedures.IdBd);
            return View(ssmsProcedures);
        }

        // GET: SsmsProcedures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsProcedures = await _context.SsmsProcedures.FindAsync(id);
            if (ssmsProcedures == null)
            {
                return NotFound();
            }
            ViewData["IdBd"] = new SelectList(_context.SsmsDatabases, "Id", "Title", ssmsProcedures.IdBd);
            return View(ssmsProcedures);
        }

        // POST: SsmsProcedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,IdBd")] SsmsProcedures ssmsProcedures)
        {
            if (id != ssmsProcedures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ssmsProcedures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SsmsProceduresExists(ssmsProcedures.Id))
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
            ViewData["IdBd"] = new SelectList(_context.SsmsDatabases, "Id", "Title", ssmsProcedures.IdBd);
            return View(ssmsProcedures);
        }

        // GET: SsmsProcedures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsProcedures = await _context.SsmsProcedures
                .Include(s => s.IdBdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsProcedures == null)
            {
                return NotFound();
            }

            return View(ssmsProcedures);
        }

        // POST: SsmsProcedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ssmsProcedures = await _context.SsmsProcedures.FindAsync(id);
            _context.SsmsProcedures.Remove(ssmsProcedures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SsmsProceduresExists(Guid id)
        {
            return _context.SsmsProcedures.Any(e => e.Id == id);
        }
    }
}
