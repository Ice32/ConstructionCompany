using System;
using System.Collections.Generic;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;

namespace ConstructionCompanyModel.ViewModels.Worksheets
{
    public class WorksheetVM
    {
        public int Id { get; set; }
        public ConstructionSiteVM ConstructionSite { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public List<TaskVM> Tasks { get; set; }
        public List<MaterialVM> Materials { get; set; }
        public List<EquipmentVM> Equipment { get; set; }
        public bool IsLocked { get; set; }
        public string WeatherConditions { get; set; }
    }
}
