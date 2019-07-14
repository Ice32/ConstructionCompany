using AutoMapper;
using ConstructionCompany;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Tasks;

namespace ConstructionCompanyAPI.Controllers
{
    public class TasksController : BaseCRUDController<TaskVM, Task, TaskSearchVM, TaskSearch, TaskAddVM, TaskAddVM>
    {
        public TasksController(ICRUDService<Task, TaskSearch> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}