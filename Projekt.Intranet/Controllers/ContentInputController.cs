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
    public class ContentInputController : Controller
    {
        private readonly FormaContext _context;

        public ContentInputController(FormaContext context)
        {
            _context = context;
        }

        // GET: ContentInput
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentInput.ToListAsync());
        }

        // GET: ContentInput/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentInput = await _context.ContentInput
                .FirstOrDefaultAsync(m => m.IdContentInput == id);
            if (contentInput == null)
            {
                return NotFound();
            }

            return View(contentInput);
        }

        // GET: ContentInput/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentInput/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContentInput,Key,Input,Value")] ContentInput contentInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentInput);
        }

        // GET: ContentInput/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentInput = await _context.ContentInput.FindAsync(id);
            if (contentInput == null)
            {
                return NotFound();
            }
            return View(contentInput);
        }

        // POST: ContentInput/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContentInput,Key,Input,Value")] ContentInput contentInput)
        {
            if (id != contentInput.IdContentInput)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentInput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentInputExists(contentInput.IdContentInput))
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
            return View(contentInput);
        }

        // GET: ContentInput/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentInput = await _context.ContentInput
                .FirstOrDefaultAsync(m => m.IdContentInput == id);
            if (contentInput == null)
            {
                return NotFound();
            }

            return View(contentInput);
        }

        // POST: ContentInput/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentInput = await _context.ContentInput.FindAsync(id);
            if (contentInput != null)
            {
                _context.ContentInput.Remove(contentInput);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentInputExists(int id)
        {
            return _context.ContentInput.Any(e => e.IdContentInput == id);
        }
    }
}
