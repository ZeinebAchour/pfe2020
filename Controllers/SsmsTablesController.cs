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
    public class SsmsTablesController : Controller
    {
        private readonly BDStock1Context _context;

        public SsmsTablesController(BDStock1Context context)
        {
            _context = context;
        }

        // GET: SsmsTables
        public async Task<IActionResult> Index()
        {
            var bDStock1Context = _context.SsmsTable.Include(s => s.IdBdsNavigation);
            return View(await bDStock1Context.ToListAsync());
        }

        // GET: SsmsTables/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsTable = await _context.SsmsTable
                .Include(s => s.IdBdsNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsTable == null)
            {
                return NotFound();
            }

            return View(ssmsTable);
        }

        // GET: SsmsTables/Create
        public IActionResult Create()
        {
            ViewData["IdBds"] = new SelectList(_context.SsmsDatabases, "Id", "Title");
            return View();
        }

        // POST: SsmsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IdBds")] SsmsTable ssmsTable)
        {
            if (ModelState.IsValid)
            {
                ssmsTable.Id = Guid.NewGuid();
                _context.Add(ssmsTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBds"] = new SelectList(_context.SsmsDatabases, "Id", "Title", ssmsTable.IdBds);
            return View(ssmsTable);
        }

        // GET: SsmsTables/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsTable = await _context.SsmsTable.FindAsync(id);
            if (ssmsTable == null)
            {
                return NotFound();
            }
            ViewData["IdBds"] = new SelectList(_context.SsmsDatabases, "Id", "Title", ssmsTable.IdBds);
            return View(ssmsTable);
        }

        // POST: SsmsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,IdBds")] SsmsTable ssmsTable)
        {
            if (id != ssmsTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ssmsTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SsmsTableExists(ssmsTable.Id))
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
            ViewData["IdBds"] = new SelectList(_context.SsmsDatabases, "Id", "Title", ssmsTable.IdBds);
            return View(ssmsTable);
        }

        // GET: SsmsTables/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssmsTable = await _context.SsmsTable
                .Include(s => s.IdBdsNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ssmsTable == null)
            {
                return NotFound();
            }

            return View(ssmsTable);
        }

        // POST: SsmsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ssmsTable = await _context.SsmsTable.FindAsync(id);
            _context.SsmsTable.Remove(ssmsTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SsmsTableExists(Guid id)
        {
            return _context.SsmsTable.Any(e => e.Id == id);
        }
    }
}
