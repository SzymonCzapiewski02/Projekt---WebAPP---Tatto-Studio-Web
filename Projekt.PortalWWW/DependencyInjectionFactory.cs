using Firma.Interfaces.CMS;
using Firma.Interfaces.Sklep;
using Firma.Services.CMS;
using Firma.Services.Sklep;

namespace Projekt.PortalWWW
{
    public static class DependencyInjectionFactory
    {
        public static void Resolve(IServiceCollection services, IConfiguration conf)
        {
            services.AddScoped<IStronaService, StronaService>();
            services.AddScoped<IContentImageService, ContentImageService>();
            services.AddScoped<IContentStringService, ContentStringService>();
            services.AddScoped<IContentInputService, ContentInputService>();
            services.AddScoped<IProduktService, ProduktService>();
            services.AddScoped<IZamowieniaService, ZamowieniaService>();
            services.AddScoped<IGaleriaService, GaleriaService>();
            services.AddScoped<ITattoService, TattoService>();
            services.AddScoped<IRecenzjaService, RecenzjaService>();
        }
    }
}
