using System.Diagnostics;
using Firma.Interfaces.CMS;
using Firma.Interfaces.Sklep;
using Microsoft.AspNetCore.Mvc;
using Projekt.PortalWWW.Models;

namespace Projekt.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStronaService _stronaService;
    private readonly IContentStringService _contentStringService;
    private readonly IContentImageService _contentImageService;
    private readonly IContentInputService _contentInputService;
    private readonly IProduktService _produktService;
    private readonly IGaleriaService _galeriaService;
    private readonly ITattoService _tattoService;
    private readonly IRecenzjaService _recenzjaService;
    private readonly IZamowieniaService _zamowieniaService;

    public HomeController(ILogger<HomeController> logger, ITattoService tattoService,
        IStronaService stronaService, IZamowieniaService zamowieniaService,
        IProduktService produktService, IRecenzjaService recenzjaService,
        IContentImageService contentImageService, IContentInputService contentInputService,
        IContentStringService contentStringService, IGaleriaService galeriaService)
    {
        _logger = logger;
        _stronaService = stronaService;
        _zamowieniaService = zamowieniaService;
        _produktService = produktService;
        _recenzjaService = recenzjaService;
        _contentImageService = contentImageService;
        _contentInputService = contentInputService;
        _contentStringService = contentStringService;
        _galeriaService = galeriaService;
        _tattoService = tattoService;
    }

    private async Task LoadCommonViewData(string stronaLink)
    {
        ViewBag.Strona = await _stronaService.GetStronaImage(stronaLink);
    }

    public async Task<IActionResult> Index()
    {
        await LoadCommonViewData("Index");

        ViewBag.ModelTatto = await _tattoService.TattoToList(3);
        ViewBag.ModelTitle = await _contentStringService.CheckKeyStringFirst("IndexOstatnieTatto");
        ViewBag.ModelTitleOpis = await _contentStringService.CheckKeyStringFirst("IndexTitle");
        ViewBag.ModelButton = await _contentInputService.CheckKeyInputFirst("IndexButton");
        ViewBag.ModelDane = await _contentStringService.CheckKeyStringToList("IndexText");

        return View();
    }

    public async Task<IActionResult> Zaloga()
    {
        await LoadCommonViewData("Zaloga");

        ViewBag.ModelGaleria = await _galeriaService.GaleriaToList();
        ViewBag.ModelButton = await _contentInputService.CheckKeyInputFirst("InputZaloga");

        return View();
    }

    public async Task<IActionResult> Sklep()
    {
        await LoadCommonViewData("Sklep");

        ViewBag.ModelSklep = await _produktService.ProduktToList();

        return View();
    }

    public async Task<IActionResult> ONas()
    {
        await LoadCommonViewData("ONas");

        ViewBag.ModelRecenzje = await _recenzjaService.RecenzjeToListTake(3);
        ViewBag.ModelTitle = await _contentStringService.CheckKeyStringFirst("OstatnieRecenzjeONas");
        ViewBag.ModelTitleAcc = await _contentStringService.CheckKeyStringFirst("ONasTitle");
        ViewBag.ModelAcc = await _contentStringService.CheckKeyStringDwaToList("ONasPytania", "ONasTitleAcc");

        return View();
    }

    public async Task<IActionResult> Kontakt()
    {
        await LoadCommonViewData("Kontakt");

        ViewBag.ModelKontakt = await _contentInputService.CheckKeyInputToList("InputKontakt");
        ViewBag.ModelTitle = await _contentStringService.CheckKeyStringFirst("KontaktInputTitle");
        ViewBag.ModelButton = await _contentStringService.CheckKeyStringFirst("InputKontakt");
        ViewBag.ModelAdres = await _contentStringService.CheckKeyStringToList("adres_kontakt");
        ViewBag.ModelDane = await _contentStringService.CheckKeyStringToList("Konto_Kontakt");
        ViewBag.ModelImageX = await _contentImageService.CheckKeyImageFirst("foto_kontakt1");
        ViewBag.ModelImageZ = await _contentImageService.CheckKeyImageFirst("foto_kontakt2");

        return View();
    }

    public async Task<IActionResult> Koszyk()
    {
        await LoadCommonViewData("Koszyk");

        ViewBag.ModelKoszyk = await _zamowieniaService.KoszykToList();
        ViewBag.ModelButton = await _contentInputService.CheckKeyInputButtonToList("KoszykButtonPlus", "KoszykButtonMinus");
        ViewBag.ModelButtonRemove = await _contentStringService.CheckKeyStringFirst("KoszykButtonRemove");
        ViewBag.Modeltutle = await _contentStringService.CheckKeyStringFirst("KoszykTitle");
        ViewBag.ModelKupon = await _contentInputService.CheckKeyInputFirst("InputKoszyk");
        ViewBag.ModelButtons = await _contentStringService.CheckKeyStringToList("KoszykButton");
        ViewBag.ModelCena = await _zamowieniaService.KoszykCena();
        ViewBag.ModelTitlePods = await _contentStringService.CheckKeyStringFirst("KoszykTitlePod");
        ViewBag.ModelButtonPods = await _contentStringService.CheckKeyStringFirst("KoszykKosztButton");
        ViewBag.ModelKoszt = await _contentStringService.CheckKeyStringToList("KoszykKoszt");

        return View();
    }

    public async Task<IActionResult> Produkt(int id)
    {
        await LoadCommonViewData("Produkt");

        ViewBag.ModelButton = await _contentStringService.CheckKeyStringFirst("ProduktButton");
        var produkt = await _produktService.ProduktFirst(id);

        return View(produkt);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
