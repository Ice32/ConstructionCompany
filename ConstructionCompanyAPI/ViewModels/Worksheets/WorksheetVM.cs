using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionCompanyAPI.ViewModels.Worksheets
{
    public class WorksheetVM
    {
        public WorksheetVM() { }
        public WorksheetVM(Worksheet worksheet)
        {
            this.Id = worksheet.Id;
            this.ConstructionSiteId = worksheet.ConstructionSiteId;
            this.Date = worksheet.Date;
            this.Remark = worksheet.Remarks;
            this.Tasks = worksheet.Tasks?.Select(t => new TaskVM(t)).ToList();
            //this.Materials = worksheet.Materials;
            //this.Equipment = worksheet.Equipment;
            this.IsLocked = worksheet.IsLocked;
            this.WeatherConditions = worksheet.WeatherConditions;
            //this.Workers = worksheet.Workers;
        }
        public int Id { get; set; }
        public int ConstructionSiteId { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public List<TaskVM> Tasks { get; set; }
        public List<MaterialVM> Materials { get; set; }
        public List<EquipmentVM> Equipment { get; set; }
        public bool IsLocked { get; set; }
        public string WeatherConditions { get; set; }
        public List<WorkerVM> Workers { get; set; }
    }
}
