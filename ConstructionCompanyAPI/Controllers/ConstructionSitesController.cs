using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionCompanyAPI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ConstructionSitesController : BaseCRUDController<ConstructionSiteVM, ConstructionSite, object, object, ConstructionSiteAddVM, ConstructionSiteAddVM>
    {
        public ConstructionSitesController(ICRUDService<ConstructionSite, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}