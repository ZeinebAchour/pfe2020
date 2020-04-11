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
    public class SsmsColumnsController : Controller
    {
        private readonly BDStock1Context _context;

        public SsmsColumnsController(BDStock1Context context)
        {
            _context = context;
        }

        // GET: SsmsColumns
        public async Task<IActionResult> Index()
        {
            var bDStock1Context = _context.SsmsColumn.Include(s => s.IdTabNavigation);
            return View(await bDStock1Context.ToListAsync());
        }

        // GET: SsmsColumns/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsColumn = await _context.SsmsColumn
                .Include(s => s.IdTabNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsColumn == null)
            {
                return NotFound();
            }

            return View(ssmsColumn);
        }

        // GET: SsmsColumns/Create
        public IActionResult Create()
        {
            ViewData["IdTab"] = new SelectList(_context.SsmsTable, "Id", "Id");
            return View();
        }

        // POST: SsmsColumns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,TableName,IdTab")] SsmsColumn ssmsColumn)
        {
            if (ModelState.IsValid)
            {
                ssmsColumn.Id = Guid.NewGuid();
                _context.Add(ssmsColumn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTab"] = new SelectList(_context.SsmsTable, "Id", "Id", ssmsColumn.IdTab);
            return View(ssmsColumn);
        }

        // GET: SsmsColumns/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsColumn = await _context.SsmsColumn.FindAsync(id);
            if (ssmsColumn == null)
            {
                return NotFound();
            }
            ViewData["IdTab"] = new SelectList(_context.SsmsTable, "Id", "Id", ssmsColumn.IdTab);
            return View(ssmsColumn);
        }

        // POST: SsmsColumns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,TableName,IdTab")] SsmsColumn ssmsColumn)
        {
            if (id != ssmsColumn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ssmsColumn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SsmsColumnExists(ssmsColumn.Id))
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
            ViewData["IdTab"] = new SelectList(_context.SsmsTable, "Id", "Id", ssmsColumn.IdTab);
            return View(ssmsColumn);
        }

        // GET: SsmsColumns/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsColumn = await _context.SsmsColumn
                .Include(s => s.IdTabNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsColumn == null)
            {
                return NotFound();
            }

            return View(ssmsColumn);
        }

        // POST: SsmsColumns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ssmsColumn = await _context.SsmsColumn.FindAsync(id);
            _context.SsmsColumn.Remove(ssmsColumn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SsmsColumnExists(Guid id)
        {
            return _context.SsmsColumn.Any(e => e.Id == id);
        }
    }
}
