using Etiqueta.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Etiqueta.Controllers;
public class EtiquetaController : Controller
{
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
    public ActionResult ImprimirEtiquetaFuncionario(EtiquetaFuncionario form)
    {
        
        var model = new Config<EtiquetaFuncionario>();
        model.Columns = 3;
        model.MarginTop = 12.7m;
        model.MarginLeft = 4.8m;
        model.MarginRight = 4.8m;
        model.MarginBottom = 12.7m;
        model.Tag = new Tag()
        {
            Width = 66.7m,
            Height = 24.4m,
            MarginLeft = 2.74m
        };
        model.Height = 279.4m;
        model.Width = 215.9m;
        
        return View("Impressao", model);
    }
}
