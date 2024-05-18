

namespace project.utils.catalogues;

public partial class CatalogType : CommonsModel<ulong>
{
    public string code { get; set; } = null!;
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public virtual ICollection<Catalogue> catalogues { get; set; } = new List<Catalogue>();
}
