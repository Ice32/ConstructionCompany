using System;
using System.Collections.Generic;

namespace ConstructionCompanyModel.ViewModels.Worksheets
{
    public class WorksheetAddVM
    {
        public int? Id;
        public int ConstructionSiteId { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public List<TaskAddVM> Tasks { get; set; }
        public List<WorksheetMaterialVM> Materials { get; set; }
        public List<EquipmentVM> Equipment { get; set; }
        public bool IsLocked { get; set; }
        public string WeatherConditions { get; set; }
    }
}
