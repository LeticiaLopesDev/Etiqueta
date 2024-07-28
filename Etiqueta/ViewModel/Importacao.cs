namespace GestorDCSystem.ViewModel
{
    public class Importacao
    {
        public string URLForm { get; set; }
        public string Titulo { get; set; }
    }
    
    public class ImportacaoCSVErro
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }
    }
}