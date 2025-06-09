using Firma.Interfaces.CMS;
using FirmaData.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.PortalWWW.Controllers
{
    public class IconComponent : ViewComponent
    {
        private readonly IContentStringService _contentStringService;
        public IconComponent(IContentStringService contentStringService)
        {
            _contentStringService = contentStringService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var modelLink = await _contentStringService.CheckKeyStringToList("icon_layout");
            ViewBag.ModelMenu = await _contentStringService.CheckKeyStringFirst("Button_Layout");

            return View("IconComponent", modelLink);
        }
    }
}
