using System.ComponentModel.DataAnnotations;

namespace Etiqueta.ViewModel;

public class EtiquetaFuncionario : IEtiqueta
{
    [Display(Name = "CNPJ Empresa")] 
    public string CnpjEmpresa { get; set; } = string.Empty;
    [Display(Name = "Nome Empresa")]
    public string NomeEmpresa { get; set; } = string.Empty;
    [Display(Name = "Período")]
    public string Periodo { get; set; } = string.Empty;
    [Display(Name = "Código Funcionário")]
    public string Codigo { get; set; } = string.Empty;
    [Display(Name = "Nome Funcionário")]
    public string Nome { get; set; } = string.Empty;
    public string CTPS { get; set; } = string.Empty;
    /*public string PIS { get; set; }
    public string CBOCodigo { get; set; }
    public string CBONome { get; set; }
    public string Reg { get; set; }
    public string Chapa { get; set; }*/
    [Display(Name = "Código Função")]
    public string CodigoFuncao { get; set; } = string.Empty;
    [Display(Name = "Nome Função")]
    public string NomeFuncao { get; set; } = string.Empty;
    [Display(Name = "Horário")]
    public string Horario { get; set; } = string.Empty;
}