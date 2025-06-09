using Firma.Interfaces.CMS;
using FirmaData.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.PortalWWW.Controllers
{
    public class FooterComponent : ViewComponent
    {
        private readonly IContentStringService _contentStringService;
        public FooterComponent( IContentStringService contentStringService)
        {
            _contentStringService = contentStringService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var modelFooter = await _contentStringService.CheckKeyStringToList("footer_layout");

            return View("FooterComponent", modelFooter);
        }
    }
}
