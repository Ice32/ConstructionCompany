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
    public class TasksController : BaseCRUDController<TaskVM, Task, TaskSearchVM, TaskSearch, TaskAddVM, TaskAddVM>
    {
        public TasksController(ICRUDService<Task, TaskSearch> service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpPost]
        [Authorize(Roles = "Manager,ConstructionSiteManager")]
        public override TaskVM Insert(TaskAddVM request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,ConstructionSiteManager")]
        public override TaskVM Update(int id, TaskAddVM request)
        {
            return base.Update(id, request);
        }
    }
}