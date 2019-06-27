using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Managers;

namespace ConstructionCompanyAPI.Controllers
{
    public class ManagersController : BaseUserTypeController<ManagerVM, Manager, ManagerAddVM>
    {
        public ManagersController(IUserTypeService<Manager> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
