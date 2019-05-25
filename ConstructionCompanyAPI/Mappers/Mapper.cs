using AutoMapper;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Mappers
{
    public class Mapper : Profile

    {
        public Mapper()
        {
            CreateMap<Worksheet, WorksheetVM>().ReverseMap();
            CreateMap<WorksheetAddVM, Worksheet>().ReverseMap();
            
            CreateMap<TaskAddVM, Task>().ReverseMap();
            CreateMap<TaskVM, Task>().ReverseMap();
        }
    }
}
