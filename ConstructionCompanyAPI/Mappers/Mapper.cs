using System.Linq;
using AutoMapper;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Mappers
{
    public class Mapper : Profile

    {
        public Mapper()
        {
            CreateMap<Worksheet, WorksheetVM>().ReverseMap();
            CreateMap<WorksheetAddVM, Worksheet>()
                .ForMember(w => w.Tasks, mo =>
                {
                    mo.MapFrom(w => w.Tasks.Select(t => new Task
                    {
                        Id = t.Id.GetValueOrDefault(),
                        Description = t.Description,
                        Title = t.Title,
                        WorkerTasks = t.WorkerIds.Select(workerId => new WorkerTask {WorkerId = workerId}).ToList()
                    }));
                });
            CreateMap<Worksheet, WorksheetAddVM>();

            CreateMap<TaskAddVM, Task>()
                .ForMember(task => task.WorkerTasks,
                    mo => mo.MapFrom(taskVM =>
                        taskVM.WorkerIds.Select(workerId => new WorkerTask {WorkerId = workerId}).ToList()));
            CreateMap<Task, TaskAddVM>();
            CreateMap<Task, TaskVM>()
                .ForMember(task => task.Workers, mo => mo.MapFrom(task => task.WorkerTasks.Select<WorkerTask, Worker>(wt => wt.Worker)));
            CreateMap<TaskVM, Task>();

            CreateMap<ConstructionSiteVM, ConstructionSite>().ReverseMap();

            CreateMap<Worker, WorkerVM>()
                .ForMember(workerVM => workerVM.FirstName, mo => mo.MapFrom(worker => worker.User.FirstName))
                .ForMember(workerVM => workerVM.LastName, mo => mo.MapFrom(worker => worker.User.LastName));
            CreateMap<WorkerVM, Worker>();
        }
    }
}
