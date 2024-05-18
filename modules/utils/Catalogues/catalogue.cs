namespace project.utils.catalogues;
public partial class Catalogue : CommonsModel<ulong>
{
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public ulong catalogTypeId { get; set; }
    public virtual CatalogType catalogType { get; set; } = null!;
}
