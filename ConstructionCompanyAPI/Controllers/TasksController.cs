using System.Collections.Generic;
using AutoMapper;
using ConstructionCompany;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class TasksController : BaseCRUDController<TaskVM, Task, object, TaskSearch, TaskAddVM, TaskAddVM>
    {
        public TasksController(ICRUDService<Task, TaskSearch> service, IMapper mapper) : base(service, mapper)
        {
        }
        
        [HttpGet]
        [Authorize(Roles = "Worker")]
        public override List<TaskVM> Get([FromQuery]object searchVM)
        {
            int workerId = GetCurrentUserId();
            var search = new TaskSearch
            {
                WorkerId = workerId
            };
            List<Task> retrieved = _service.Get(search);
            return _mapper.Map<List<TaskVM>>(retrieved);
        }
    }
}