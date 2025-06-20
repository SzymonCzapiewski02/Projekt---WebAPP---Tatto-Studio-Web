﻿using FirmaData.Data;
using FirmaData.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Intranet.Report;

namespace Projekt.Intranet.Controllers
{
    public class TattoArtistController : Controller
    {
        private readonly FormaContext   _context;
        private readonly ExcelExportService _excelExportService;

        public TattoArtistController(FormaContext context, ExcelExportService excelExportService)
        {
            _context = context;
            _excelExportService = excelExportService;
        }

        // GET: TattoArtist
        public async Task<IActionResult> Index()
        {
            return View(await _context.TattoArtists.ToListAsync());
        }

        // GET: TattoArtist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tattoArtists = await _context.TattoArtists
                .FirstOrDefaultAsync(m => m.IdTattoArtists == id);
            if (tattoArtists == null)
            {
                return NotFound();
            }

            return View(tattoArtists);
        }

        // GET: TattoArtist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TattoArtist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTattoArtists,Imie,Nazwisko,Przydomek,LataDoswiatczenia,Specjalizacja,Opis,NumerTelefonu,Email,NumerKonta")] TattoArtists tattoArtists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tattoArtists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tattoArtists);
        }

        // GET: TattoArtist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tattoArtists = await _context.TattoArtists.FindAsync(id);
            if (tattoArtists == null)
            {
                return NotFound();
            }
            return View(tattoArtists);
        }

        // POST: TattoArtist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTattoArtists,Imie,Nazwisko,Przydomek,LataDoswiatczenia,Specjalizacja,Opis,NumerTelefonu,Email,NumerKonta")] TattoArtists tattoArtists)
        {
            if (id != tattoArtists.IdTattoArtists)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tattoArtists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TattoArtistsExists(tattoArtists.IdTattoArtists))
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
            return View(tattoArtists);
        }

        // GET: TattoArtist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tattoArtists = await _context.TattoArtists
                .FirstOrDefaultAsync(m => m.IdTattoArtists == id);
            if (tattoArtists == null)
            {
                return NotFound();
            }

            return View(tattoArtists);
        }

        // POST: TattoArtist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tattoArtists = await _context.TattoArtists.FindAsync(id);
            if (tattoArtists != null)
            {
                _context.TattoArtists.Remove(tattoArtists);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TattoArtistsExists(int id)
        {
            return _context.TattoArtists.Any(e => e.IdTattoArtists == id);
        }

        [HttpGet]
        public async Task<IActionResult> EksportExcelTattoArtist()
        {
            var tattoArtist = await _context.TattoArtists.ToListAsync();
            var content = _excelExportService.GenerujPracownikaExcel(tattoArtist);
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Pracownicy.xlsx");
        }
    }
}
