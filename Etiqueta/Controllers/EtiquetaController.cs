using System.ComponentModel.DataAnnotations;
using CsvHelper;
using Etiqueta.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using GestorDCSystem.ViewModel;

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
    
    /// <summary>
    /// Retorna a view de importação de itens para a vinculação das colunas do arquivo excel
    /// </summary>
    public ActionResult Importacao()
    {
        return PartialView("_Importacao", new EtiquetaFuncionario());
    }
    
    /// <summary>
    /// Converte a lista de itens para a interface <see cref="IItemImportacao"/> e chama o método para importar os itens
    /// </summary>
    /// <param name="itens">Lista de <see cref="ItemImportacao">itens</see> que serão importados</param>
    [HttpPost]
    public async Task<ActionResult> BuildImportacaoExcel(List<EtiquetaFuncionario> itens)
    {
        var model = itens.Select(i => (IEtiqueta)i).ToList();
        return await ImportarExcelCsv(model);
    }
    
    /// <summary>
    /// Faz a importação dos itens a partir de um arquivo excel ou csv,
    /// atualiza o item caso já exista ou cria um novo caso não exista
    /// </summary>
    /// <param name="itens">Lista de <see cref="IItemImportacao">itens</see> que serão importados</param>
    [HttpPost]
    public async Task<ActionResult> ImportarExcelCsv(List<IEtiqueta> itens)
    {
        var erros         = new List<ImportacaoCSVErro>();
        var qtdSucesso    = 0;
        var qtdAtualizado = 0;

        var listFuncionarios = new List<ViewModel.EtiquetaFuncionario>();

        foreach (var item in itens)
        {
            try
            {
                var error   = new List<string>();
                var ctx     = new ValidationContext(item);
                var results = new List<ValidationResult>();
                
                if (!Validator.TryValidateObject(item, ctx, results, true))
                {
                    foreach (var errors in results)
                        error.Add(errors.ToString());

                    throw new Exception(string.Join("<br>", error.ToArray()));
                }

                var itemImportacao = (EtiquetaFuncionario) item;
                listFuncionarios.Add(itemImportacao);
                
            }
            catch (Exception ex)
            {
                erros.Add(new ImportacaoCSVErro
                {
                    Codigo = item.Codigo,
                    Descricao = item.Nome,
                    Mensagem = ex.Message
                });
            }
        }
        return Json(new { erros = erros, qtdSucesso });
    }

    /*[HttpGet]
    public ActionResult EtiquetaFuncionario()
    {
        return View(new EtiquetaFuncionario());
    }*/

    [HttpPost]
    public ActionResult EtiquetaFuncionario(IFormFile formFile)
    {
        var funcionarios = _csvService.ReadCSV<EtiquetaFuncionario>(formFile.OpenReadStream());

        /*using (var reader = new StreamReader(formFile.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<dynamic>();
            
        }*/

        var model = new Config();
        model.Columns = 3;
        model.MarginTop = 12.7m;
        model.MarginLeft = 4.8m;
        model.MarginRight = 4.8m;
        model.MarginBottom = 12.7m;
        model.Tag = new Tag()
        {
            Width = 66.7m,
            Height = 25.4m,
            MarginLeft = 3.2m
        };
        model.Height = 279.4m;
        model.Width = 215.9m;
        model.ListModel = funcionarios.ToList().Select(x=>(IEtiqueta)x).ToList();
        model.PartialName = "_Funcionario";

        return View("Impressao", model);
    }

}
