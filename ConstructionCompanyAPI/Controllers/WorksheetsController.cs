using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyAPI.Controllers
{
    public class WorksheetsController :
        BaseCRUDController<WorksheetVM, Worksheet, object, object, WorksheetAddVM, WorksheetAddVM>
    {
        public WorksheetsController(ICRUDService<Worksheet, object> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}