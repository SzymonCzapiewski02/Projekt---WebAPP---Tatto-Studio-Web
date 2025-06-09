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
    public class ContentImageController : Controller
    {
        private readonly FormaContext _context;

        public ContentImageController(FormaContext context)
        {
            _context = context;
        }

        // GET: ContentImage
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentImage.ToListAsync());
        }

        // GET: ContentImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentImage = await _context.ContentImage
                .FirstOrDefaultAsync(m => m.IdContentImage == id);
            if (contentImage == null)
            {
                return NotFound();
            }

            return View(contentImage);
        }

        // GET: ContentImage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContentImage,Key,Image")] ContentImage contentImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentImage);
        }

        // GET: ContentImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentImage = await _context.ContentImage.FindAsync(id);
            if (contentImage == null)
            {
                return NotFound();
            }
            return View(contentImage);
        }

        // POST: ContentImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContentImage,Key,Image")] ContentImage contentImage)
        {
            if (id != contentImage.IdContentImage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentImageExists(contentImage.IdContentImage))
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
            return View(contentImage);
        }

        // GET: ContentImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentImage = await _context.ContentImage
                .FirstOrDefaultAsync(m => m.IdContentImage == id);
            if (contentImage == null)
            {
                return NotFound();
            }

            return View(contentImage);
        }

        // POST: ContentImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentImage = await _context.ContentImage.FindAsync(id);
            if (contentImage != null)
            {
                _context.ContentImage.Remove(contentImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentImageExists(int id)
        {
            return _context.ContentImage.Any(e => e.IdContentImage == id);
        }
    }
}
