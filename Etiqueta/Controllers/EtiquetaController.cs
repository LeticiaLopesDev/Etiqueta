using CsvHelper;
using Etiqueta.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Etiqueta.Controllers;
public class EtiquetaController : Controller
{
    private readonly ICSVService _csvService;

    public EtiquetaController(ICSVService csvService)
    {
        _csvService = csvService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult EtiquetaFuncionario()
    {
        return View(new EtiquetaFuncionario());
    }

    [HttpPost]
    public ActionResult EtiquetaFuncionario(IFormFile formFile, string periodo)
    {
        var funcionarios = _csvService.ReadCSV<EtiquetaFuncionario>(formFile.OpenReadStream());

        /*using (var reader = new StreamReader(formFile.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<dynamic>();
            
        }*/

        var model = new Config();
        model.Columns = 3;
        //CARTA
        /*model.MarginTop = 12.7m;
        model.MarginLeft = 4.8m;
        model.MarginRight = 4.8m;
        model.MarginBottom = 12.7m;*/
        /*model.Tag = new Tag()
        {
           Width = 66.7m,
           Height = 25.4m,
           MarginLeft = 3.2m
        };*/
        /* model.Height = 279.4m;
        model.Width = 215.9m;*/

        model.MarginTop = 10m;
        model.MarginLeft = 7m;
        model.MarginRight = 7m;
        model.MarginBottom = 7m;
       
        model.Tag = new Tag()
        {
            Width = 63.5m,
            Height = 25.4m,
            MarginLeft = 2.5m
        };
        model.Height = 297m;
        model.Width = 210m;
      
        model.ListModel = funcionarios.ToList().Select(x=>(IEtiqueta)x).ToList();
        model.PartialName = "_Funcionario";
        ViewBag.Periodo = "10/2025";

        return View("Impressao", model);
    }

}
