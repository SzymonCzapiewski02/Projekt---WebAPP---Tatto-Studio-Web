using FirmaData.Data;
using FirmaData.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Intranet.Report;

namespace Projekt.Intranet.Controllers
{
    public class ProduktController : Controller
    {
        private readonly FormaContext _context;
        private readonly ExcelExportService _excelExportService;

        public ProduktController(FormaContext context, ExcelExportService excelExportService)
        {
            _context = context;
            _excelExportService = excelExportService;
        }

        // GET: Produkt
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produkt.ToListAsync());
        }

        // GET: Produkt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .FirstOrDefaultAsync(m => m.IdProdukt == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdukt,Nazwa,Opis,Cena,FotoUrl,IloscMagazynowa")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkt);
        }

        // GET: Produkt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }

        // POST: Produkt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProdukt,Nazwa,Opis,Cena,FotoUrl,IloscMagazynowa")] Produkt produkt)
        {
            if (id != produkt.IdProdukt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.IdProdukt))
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
            return View(produkt);
        }

        // GET: Produkt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .FirstOrDefaultAsync(m => m.IdProdukt == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt != null)
            {
                _context.Produkt.Remove(produkt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktExists(int id)
        {
            return _context.Produkt.Any(e => e.IdProdukt == id);
        }

        [HttpGet]
        public async Task<IActionResult> EksportExcelProduktu()
        {
            var produkt = await _context.Produkt.ToListAsync();
            var content = _excelExportService.GenerujProduktuExcel(produkt);
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Produkty.xlsx");
        }
    }
}
