using FirmaData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Services.Abstrakcja
{
    public class BaseService
    {
        protected readonly FormaContext _context;
        //protected readonly IServiceProvider serviceProvider;
        //protected readonly Lazy<IUzytkownikService> uzytkownik;
        //protected readonly Lazy<ICacheProvider> cacheProvider;
        //protected readonly Lazy<DapperProvider> dapperProvider;
        //protected readonly Lazy<IConfiguration> configuration;
        //protected readonly Lazy<IWyjatekObslugaService> wyjatekObslugaService;

        public BaseService(FormaContext context)
        {
            _context = context;
        }
    }
}
