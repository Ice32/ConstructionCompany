using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Workers;

namespace ConstructionCompanyAPI.Controllers
{
    public class WorkersController : BaseUserTypeController<WorkerVM, Worker, WorkerAddVM>
    {
        public WorkersController(IUserTypeService<Worker> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
