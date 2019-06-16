using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Controllers
{
    public class TasksController : BaseCRUDController<TaskVM, Task, object, TaskAddVM, TaskAddVM>
    {
        public TasksController(ICRUDService<Task, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}