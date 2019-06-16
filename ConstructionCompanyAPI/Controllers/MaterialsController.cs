using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Controllers
{
    public class MaterialsController : BaseCRUDController<MaterialVM, Material, object, MaterialAddVM, MaterialAddVM>
    {
        public MaterialsController(ICRUDService<Material, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
