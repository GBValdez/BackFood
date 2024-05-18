using AutoMapper;
using project.utils.catalogues.dto;

namespace project.utils.catalogues
{
    public class cataloguesController : controllerCommons<Catalogue, catalogueCreationDto, catalogueDto, object, object, ulong>
    {
        protected string codCatalogue { get; set; }
        public cataloguesController(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
        // protected override async Task modifyPost(Catalogo entity, object queryParams)
        // {
        //     entity.CatalogoTipoId = (await getCatalogueType()).Id;
        // }

        // protected Task<CatalogoTipo> getCatalogueType()
        // {
        //     return context.CatalogoTipos.Where(db => db.Codigo == codCatalogue).FirstAsync();
        // }

        // protected override async Task<IQueryable<Catalogo>> modifyGet(IQueryable<Catalogo> query, object queryParams)
        // {
        //     CatalogoTipo catalogueType = await getCatalogueType();
        //     return query.Where(db => db.CatalogoTipoId == catalogueType.Id);
        // }
    }
}
