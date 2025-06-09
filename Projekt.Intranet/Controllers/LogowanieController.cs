using FirmaData.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Projekt.Intranet.Controllers
{
    public class LogowanieController : Controller
    {
        private readonly FormaContext _context;

        public LogowanieController(FormaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string login, string haslo)
        {
            Log.Information("Próba logowania użytkownika: {Login}", login);

            var user = await _context.User
                .SingleOrDefaultAsync(u => u.Login == login);

            if (user == null)
            {
                Log.Warning("Nie znaleziono użytkownika {Login}", login);
                ModelState.AddModelError("", "Niepoprawny login lub hasło");
                return View();
            }

            if (user.haslo != haslo)
            {
                Log.Warning("Błędne hasło dla użytkownika {Login}", login);
                ModelState.AddModelError("", "Niepoprawny login lub hasło");
                return View();
            }
            Log.Information("Użytkownik {Login} zalogowany pomyślnie", login);

            return RedirectToAction("Index", "Home");
        }
    }
}
