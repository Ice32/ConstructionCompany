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
            CreateMap<WorksheetAddVM, Worksheet>().ReverseMap();

            CreateMap<TaskAddVM, Task>()
                .ForMember(task => task.WorkerTasks,
                    mo => mo.MapFrom(taskVM =>
                        taskVM.WorkerIds.Select(workerId => new WorkerTask {WorkerId = workerId}).ToList()));
            CreateMap<Task, TaskAddVM>();
            CreateMap<TaskVM, Task>().ReverseMap();

            CreateMap<ConstructionSiteVM, ConstructionSite>().ReverseMap();

            CreateMap<Worker, WorkerVM>()
                .ForMember(workerVM => workerVM.FirstName, mo => mo.MapFrom(worker => worker.User.FirstName))
                .ForMember(workerVM => workerVM.LastName, mo => mo.MapFrom(worker => worker.User.LastName));
            CreateMap<WorkerVM, Worker>();
        }
    }
}
