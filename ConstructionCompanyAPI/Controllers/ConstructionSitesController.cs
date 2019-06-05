using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;

namespace ConstructionCompanyAPI.Controllers
{
    public class ConstructionSitesController : BaseCRUDController<ConstructionSiteVM, ConstructionSite, object, ConstructionSiteAddVM, ConstructionSiteAddVM>
    {
        public ConstructionSitesController(ICRUDService<ConstructionSite, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}