using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Managers;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionCompanyAPI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagersController : BaseUserTypeController<ManagerVM, Manager, ManagerAddVM>
    {
        public ManagersController(IUserTypeService<Manager> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
