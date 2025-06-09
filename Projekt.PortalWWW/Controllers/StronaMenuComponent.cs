using Firma.Interfaces.CMS;
using FirmaData.Data;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.PortalWWW.Controllers
{
    public class StronaMenuComponent : ViewComponent
    {
        private readonly IStronaService _stronaService;
        public StronaMenuComponent(IStronaService stronaService)
        {
            _stronaService = stronaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var modelStrony = ViewBag.ModelStrony = _context.Strona
            //.OrderBy(s => s.Pozycja)
            //.ToList();
            var modelStrony = await _stronaService.GetStronaPozycja();

            return View("StronaMenuComponent", modelStrony);
        }
    }
}
