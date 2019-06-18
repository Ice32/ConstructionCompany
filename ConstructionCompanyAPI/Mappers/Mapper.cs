using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyModel.ViewModels.Worksheets;
using MeasurementUnit = ConstructionCompanyModel.ViewModels.Worksheets.MeasurementUnit;

namespace ConstructionCompanyAPI.Mappers
{
    public class Mapper : Profile

    {
        public Mapper()
        {
            CreateMap<Worksheet, WorksheetVM>()
                .ForMember(w => w.Materials, mo =>
                {
                    mo.MapFrom(w => w.WorksheetMaterials.Select(wm => new MaterialVM
                    {
                        Id = wm.MaterialId,
                        Amount = wm.Amount,
                        Name = wm.Material.Name,
                        Unit = (MeasurementUnit) wm.Material.Unit,
                    }));
                });
            CreateMap<WorksheetVM, Worksheet>();
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
                })
                .ForMember(w => w.WorksheetMaterials, mo => 
                    mo.MapFrom(w => w.Materials.Select(m => new WorksheetMaterial
                    {
                        MaterialId = m.MaterialId,
                        Amount = m.Amount
                    })));
            CreateMap<Worksheet, WorksheetAddVM>();

            CreateMap<TaskAddVM, Task>()
                .ForMember(task => task.WorkerTasks,
                    mo => mo.MapFrom(taskVM =>
                        taskVM.WorkerIds.Select(workerId => new WorkerTask {WorkerId = workerId}).ToList()));
            CreateMap<Task, TaskAddVM>();
            CreateMap<Task, TaskVM>()
                .ForMember(task => task.Workers, mo => mo.MapFrom(task => task.WorkerTasks.Select<WorkerTask, Worker>(wt => wt.Worker)));
            CreateMap<TaskVM, Task>();

            CreateMap<ConstructionSiteVM, ConstructionSite>();
            CreateMap<ConstructionSite, ConstructionSiteVM>()
                .ForMember(cs => cs.ConstructionSiteManager, mo => mo.MapFrom(cs =>
                    new ConstructionSiteManagerVM
                    {
                        Id = cs.ConstructionSiteManagers[0].ConstructionSiteManagerId,
                        UserId = cs.ConstructionSiteManagers[0].ConstructionSiteManager.UserId,
                        User = new UserVM
                        {
                            DateOfBirth = cs.ConstructionSiteManagers[0].ConstructionSiteManager.User.DateOfBirth,
                            FirstName = cs.ConstructionSiteManagers[0].ConstructionSiteManager.User.FirstName,
                            Id = cs.ConstructionSiteManagers[0].ConstructionSiteManager.User.Id,
                            LastName = cs.ConstructionSiteManagers[0].ConstructionSiteManager.User.LastName,
                            UserName = cs.ConstructionSiteManagers[0].ConstructionSiteManager.User.UserName,
                        },
                    }));
            CreateMap<ConstructionSiteAddVM, ConstructionSite>()
                .ForMember(cs => cs.ConstructionSiteManagers, mo => mo.MapFrom(cs =>
                    new List<ConstructionSiteSiteManager>
                    {
                        new ConstructionSiteSiteManager
                        {
                            ConstructionSiteManagerId = cs.ConstructionSiteManagerId
                        }
                    }));
            CreateMap<ConstructionSite, ConstructionSiteAddVM>();

            CreateMap<Worker, WorkerVM>()
                .ForMember(workerVM => workerVM.FirstName, mo => mo.MapFrom(worker => worker.User.FirstName))
                .ForMember(workerVM => workerVM.LastName, mo => mo.MapFrom(worker => worker.User.LastName));
            CreateMap<WorkerVM, Worker>();
            
            CreateMap<MaterialVM, Material>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();
            CreateMap<ConstructionSiteManagerVM, ConstructionSiteManager>().ReverseMap();
        }
    }
}
