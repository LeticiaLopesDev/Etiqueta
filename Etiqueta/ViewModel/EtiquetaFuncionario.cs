namespace Etiqueta.ViewModel;

public class EtiquetaFuncionario
{
    public string CnpjEmpresa { get; set; }
    public string NomeEmpresa { get; set; }
    public string Periodo { get; set; }
    public List<Funcionario> Funcionarios { get; set; }
}

public class Funcionario
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string CTPS { get; set; }
    public string PIS { get; set; }
    public string CBO { get; set; }
    public string Reg { get; set; }
    public string Chapa { get; set; }
    public string Horario { get; set; }
}