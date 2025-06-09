using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirmaData.Data;
using FirmaData.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class ContentStringController : Controller
    {
        private readonly FormaContext _context;

        public ContentStringController(FormaContext context)
        {
            _context = context;
        }

        // GET: ContentString
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentString.ToListAsync());
        }

        // GET: ContentString/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentString = await _context.ContentString
                .FirstOrDefaultAsync(m => m.IdContentString == id);
            if (contentString == null)
            {
                return NotFound();
            }

            return View(contentString);
        }

        // GET: ContentString/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentString/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContentString,Key,Value")] ContentString contentString)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentString);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentString);
        }

        // GET: ContentString/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentString = await _context.ContentString.FindAsync(id);
            if (contentString == null)
            {
                return NotFound();
            }
            return View(contentString);
        }

        // POST: ContentString/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContentString,Key,Value")] ContentString contentString)
        {
            if (id != contentString.IdContentString)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentString);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentStringExists(contentString.IdContentString))
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
            return View(contentString);
        }

        // GET: ContentString/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentString = await _context.ContentString
                .FirstOrDefaultAsync(m => m.IdContentString == id);
            if (contentString == null)
            {
                return NotFound();
            }

            return View(contentString);
        }

        // POST: ContentString/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentString = await _context.ContentString.FindAsync(id);
            if (contentString != null)
            {
                _context.ContentString.Remove(contentString);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentStringExists(int id)
        {
            return _context.ContentString.Any(e => e.IdContentString == id);
        }
    }
}
