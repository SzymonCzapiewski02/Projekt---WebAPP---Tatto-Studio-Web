using FirmaData.Data;
using FirmaData.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Intranet.Report;

namespace Projekt.Intranet.Controllers
{
    public class KlientController : Controller
    {
        private readonly FormaContext _context;
        private readonly ExcelExportService _excelExportService;

        public KlientController(FormaContext context, ExcelExportService excelExportService)
        {
            _context = context;
            _excelExportService = excelExportService;
        }

        // GET: Klient
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klient.ToListAsync());
        }

        // GET: Klient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient
                .FirstOrDefaultAsync(m => m.IdKlient == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // GET: Klient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKlient,Imie,Nazwisko,NumerTelefonu,Email")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKlient,Imie,Nazwisko,NumerTelefonu,Email")] Klient klient)
        {
            if (id != klient.IdKlient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
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
            return View(klient);
        }

        // GET: Klient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient
                .FirstOrDefaultAsync(m => m.IdKlient == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klient = await _context.Klient.FindAsync(id);
            if (klient != null)
            {
                _context.Klient.Remove(klient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return _context.Klient.Any(e => e.IdKlient == id);
        }

        [HttpGet]
        public async Task<IActionResult> EksportExcelKlient()
        {
            var klienci = await _context.Klient.ToListAsync();
            var content = _excelExportService.GenerujKlientaExcel(klienci);
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Klienci.xlsx");
        }
    }
}
