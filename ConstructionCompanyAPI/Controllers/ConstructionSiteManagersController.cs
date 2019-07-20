using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionCompanyAPI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ConstructionSiteManagersController : BaseUserTypeController<ConstructionSiteManagerVM, ConstructionSiteManager, ConstructionSiteManagerAddVM>
    {
        public ConstructionSiteManagersController(IMapper mapper, IUserTypeService<ConstructionSiteManager> constructionSiteManagersService) : base(constructionSiteManagersService, mapper)
        {
        }
    }
}
