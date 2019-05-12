using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionCompanyAPI.BR.Worksheets.Interfaces;
using ConstructionCompanyAPI.ViewModels.Worksheets;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksheetsController : ControllerBase
    {
        private readonly IWorksheetService worksheetService;


        public WorksheetsController(IWorksheetService worksheetService)
        {
            this.worksheetService = worksheetService;
        }


        [HttpPost]
        public WorksheetVM Add(WorksheetAddVM model)
        {
            Worksheet worksheet = new Worksheet
            {
                ConstructionSiteId = model.ConstructionSiteId,
                Date = model.Date,
                Remarks = model.Remark,
            };
            Worksheet inserted = worksheetService.AddWorksheet(worksheet);
            return new WorksheetVM(inserted);
        }
        public void Delete(int worksheetId)
        {
            worksheetService.RemoveWorksheet(worksheetId);
        }

        ///Worksheets/Complete? worksheetId = @Model.WorkSheetId
        public IActionResult Complete(int worksheetId)
        {
            worksheetService.CompleteWorksheet(worksheetId);
            return RedirectToAction("Add", new { worksheetId = worksheetId });
        }

        /////Worksheets/DeleteControlEntity? entityId = @item.ControleEntitiesId
        //public IActionResult DeleteControlEntity(int entityId)
        //{
        //    int worksheetId = worksheetService.RemoveControlEntity(entityId);
        //    return RedirectToAction("ControlEntities", new { worksheetId = worksheetId });
        //}


        ////http://localhost:52140/Worksheets/ControlEntities?worksheetId=1
        //public IActionResult ControlEntities(int worksheetId)
        //{
        //    ControlEntitiesAddVM vm = new ControlEntitiesAddVM
        //    {
        //        DateTime = DateTime.Now,
        //        Text = "",
        //        WorksheetId = worksheetId
        //    };
        //    return View(vm);
        //}
        //public async Task<ActionResult> AddControlEntity(ControlEntitiesAddVM vm, IFormFile file)
        //{
        //    await worksheetService.AddControlEntity(vm, file);
        //    return RedirectToAction("ControlEntities", new { worksheetId = vm.WorksheetId });
        //}

        //public FileResult DownloadEntries(int entryId)
        //{
        //    Document d = worksheetService.GetDocument(entryId);
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(d.Location);
        //    return File(fileBytes, d.ContentType, d.FileName);
        //}

    }
}
