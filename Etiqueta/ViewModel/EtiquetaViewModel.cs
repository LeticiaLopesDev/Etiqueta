namespace Etiqueta.ViewModel;

public class Config
{
    public int Columns { get; set; }
    public decimal MarginTop { get; set; }
    public decimal MarginLeft { get; set; }
    public decimal MarginRight { get; set; }
    public decimal MarginBottom { get; set; }
    public decimal MarginHeader { get; set; }
    public decimal MarginFooter { get; set; }
    public Tag Tag { get; set; }
    public string PartialName { get; set; }
    public List<IEtiqueta> ListModel { get; set; }
    public decimal Height { get; set; }
    public decimal Width { get; set; }
}

public class Tag
{
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Border { get; set; }
    public decimal MarginLeft { get; set; }
}