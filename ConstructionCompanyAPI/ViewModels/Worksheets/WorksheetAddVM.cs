using System;
using System.Collections.Generic;

namespace ConstructionCompanyAPI.ViewModels.Worksheets
{
    public class WorksheetAddVM
    {
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
