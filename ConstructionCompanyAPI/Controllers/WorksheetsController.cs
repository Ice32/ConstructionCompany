using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var worksheets = _worksheetService.GetAll();
                
                var mapped = worksheets.Select(w => _mapper.Map<WorksheetVM>(w)).ToList();

            return mapped;
        }

        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public WorksheetVM GetWorksheetById([FromRoute]int id)
        {
            Worksheet worksheet = _worksheetService.GetById(id);
            return _mapper.Map<WorksheetVM>(worksheet);
        }
        
        [HttpPost]
        [Route("/api/[controller]/{id}")]
        public WorksheetVM Update([FromRoute]int id, WorksheetAddVM model)
        {
            Worksheet existing = _worksheetService.GetById(id);
            if (existing == null)
            {
                throw new HttpRequestException();
            }
            Worksheet worksheet = _mapper.Map(model, existing);
            worksheet.Id = id;
            _worksheetService.UpdateWorksheet(worksheet);
            Worksheet updated = _worksheetService.GetById(id);
            return _mapper.Map<WorksheetVM>(updated);
        }

    }
}
