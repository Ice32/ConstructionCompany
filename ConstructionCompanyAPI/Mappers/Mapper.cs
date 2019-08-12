using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ConstructionCompany;
using ConstructionCompany.BR.Workers;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.WorkerSuggestions;
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
                })
                .ForMember(w => w.Equipment, mo =>
                {
                    mo.MapFrom(w => w.WorksheetEquipment.Select(we => new EquipmentVM
                    {
                        Id = we.EquipmentId,
                        Quantity = we.Quantity,
                        Name = we.Equipment.Name,
                    }));
                });
            CreateMap<WorksheetVM, Worksheet>();
            CreateMap<WorksheetAddVM, Worksheet>()
                .ForMember(w => w.WorksheetMaterials, mo =>
                    mo.MapFrom(w => w.Materials.Select(m => new WorksheetMaterial
                    {
                        MaterialId = m.MaterialId,
                        Amount = m.Amount
                    })))
                .ForMember(w => w.WorksheetEquipment, mo =>
                    mo.MapFrom(w => w.Equipment.Select(m => new WorksheetEquipment
                    {
                        EquipmentId = m.EquipmentId,
                        Quantity = Convert.ToInt32(m.Quantity)
                    })));
            CreateMap<Worksheet, WorksheetAddVM>();

            CreateMap<TaskAddVM, Task>()
                .ForMember(task => task.WorkerTasks,
                    mo => mo.MapFrom(taskVM =>
                        taskVM.WorkerIds.Select(workerId => new WorkerTask {WorkerId = workerId}).ToList()))
                .EqualityComparison((n, o) => n.Id == o.Id);
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
                .ForPath(workerVM => workerVM.User.FirstName, mo => mo.MapFrom(worker => worker.User.FirstName))
                .ForPath(workerVM => workerVM.User.LastName, mo => mo.MapFrom(worker => worker.User.LastName));
            CreateMap<WorkerVM, Worker>();
            
            CreateMap<MaterialVM, Material>().ReverseMap();
            CreateMap<MaterialAddVM, Material>().ReverseMap();

            CreateMap<EquipmentVM, Equipment>().ReverseMap();
            CreateMap<EquipmentAddVM, Equipment>().ReverseMap();

            CreateMap<User, UserVM>()
                .ForMember(u => u.Active, mo => mo.MapFrom(u => !u.IsDeleted));
            CreateMap<UserVM, User>()
                .ForMember(u => u.IsDeleted, mo => mo.MapFrom(u => !u.Active));
            CreateMap<UserAddVM, User>()
                .ForMember(u => u.IsDeleted, mo => mo.MapFrom(u => !u.Active));
            CreateMap<User, UserAddVM>();
            
            CreateMap<WorkerAddVM, Worker>().ReverseMap();
            CreateMap<WorkerVM, Worker>().ReverseMap();
            
            CreateMap<ManagerAddVM, Manager>().ReverseMap();
            CreateMap<ManagerVM, Manager>().ReverseMap();
            
            CreateMap<ConstructionSiteManagerAddVM, ConstructionSiteManager>().ReverseMap();
            CreateMap<ConstructionSiteManagerVM, ConstructionSiteManager>().ReverseMap();

            CreateMap<TaskSearchVM, TaskSearch>();
            CreateMap<WorkerSuggestion, WorkerSuggestionVM>();
        }
    }
}
