using AutoMapper;
using ConstructionCompany.BR.Worksheets.Interfaces;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IMapper _mapper;


        public TasksController(ITasksService tasksService, IMapper mapper)
        {
            _tasksService = tasksService;
            _mapper = mapper;
        }


        [HttpPost]
        public TaskVM CreateTask(TaskAddVM task)
        {
            Task inserted = _tasksService.AddTask(_mapper.Map<Task>(task));
            return _mapper.Map<TaskVM>(inserted);
        }
        
        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public TaskVM GetById(int id)
        {
            Task task = _tasksService.GetById(id);
            return _mapper.Map<TaskVM>(task);
        }
        

    }
}
