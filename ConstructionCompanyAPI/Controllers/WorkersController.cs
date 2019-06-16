using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Controllers
{
    public class WorkersController : BaseController<WorkerVM, Worker, object>
    {
        public WorkersController(IService<Worker, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
