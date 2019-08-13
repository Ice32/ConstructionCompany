using AutoMapper;
using ConstructionCompany;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Controllers
{
    public class WorksheetsController :
        BaseCRUDController<WorksheetVM, Worksheet, WorksheetSearchVM, WorksheetSearch, WorksheetAddVM, WorksheetAddVM>
    {
        public WorksheetsController(ICRUDService<Worksheet, WorksheetSearch> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}