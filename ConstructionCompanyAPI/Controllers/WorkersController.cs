using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Workers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class WorkersController : BaseUserTypeController<WorkerVM, Worker, WorkerAddVM>
    {
        public WorkersController(IUserTypeService<Worker> service, IMapper mapper) : base(service, mapper)
        {
        }
        
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public override WorkerVM Insert(WorkerAddVM request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public override WorkerVM Update(int id, WorkerAddVM request)
        {
            return base.Update(id, request);
        }
    }
}
