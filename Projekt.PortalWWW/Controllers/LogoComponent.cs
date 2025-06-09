using Firma.Interfaces.CMS;
using FirmaData.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.PortalWWW.Controllers
{
    public class LogoComponent : ViewComponent
    {
        private readonly IContentImageService _contentImageService;
        public LogoComponent(IContentImageService contentImageService)
        {
            _contentImageService = contentImageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var modelLogo = await _contentImageService.CheckKeyImageFirst("logo_layout");

            return View("LogoComponent", modelLogo);
        }
    }
}
