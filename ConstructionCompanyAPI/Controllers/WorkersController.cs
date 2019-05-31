using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ConstructionCompany.BR.Workers.Interfaces;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersService _workersService;
        private readonly IMapper _mapper;


        public WorkersController(IWorkersService workersService, IMapper mapper)
        {
            _workersService = workersService;
            _mapper = mapper;
        }


        [HttpGet]
        public List<WorkerVM> GetAllWorksheets()
        {
            var workers = _workersService.GetAll().Select(w => _mapper.Map<WorkerVM>(w)).ToList();
            return workers;
        }
    }
}
