using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;

namespace ConstructionCompanyAPI.Controllers
{
    public class ConstructionSiteManagersController : BaseController<ConstructionSiteManagerVM, ConstructionSiteManager, object>
    {
        public ConstructionSiteManagersController(IService<ConstructionSiteManager, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
