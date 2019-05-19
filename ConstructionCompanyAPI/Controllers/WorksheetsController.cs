using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ConstructionCompany.BR.Worksheets.Interfaces;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksheetsController : ControllerBase
    {
        private readonly IWorksheetService _worksheetService;
        private readonly IMapper _mapper;


        public WorksheetsController(IWorksheetService worksheetService, IMapper mapper)
        {
            _worksheetService = worksheetService;
            _mapper = mapper;
        }


        [HttpPost]
        public WorksheetVM Add(WorksheetAddVM model)
        {
            Worksheet worksheet = _mapper.Map<Worksheet>(model);
            Worksheet inserted = _worksheetService.AddWorksheet(worksheet);
            return _mapper.Map<WorksheetVM>(inserted);
        }
        [HttpDelete]
        public void Delete(int worksheetId)
        {
            _worksheetService.RemoveWorksheet(worksheetId);
        }

        [HttpGet]
        public List<WorksheetVM> GetAllWorksheets()
        {
            return _worksheetService.GetAll().Select(w => _mapper.Map<WorksheetVM>(w)).ToList();
        }

        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public WorksheetVM GetWorksheetById([FromRoute]int Id)
        {
            Worksheet worksheet = _worksheetService.GetById(Id);
            return _mapper.Map<WorksheetVM>(worksheet);
        }

    }
}
