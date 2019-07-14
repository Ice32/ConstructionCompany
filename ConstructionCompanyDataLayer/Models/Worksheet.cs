using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class Worksheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string WeatherConditions { get; set; }
        public bool IsLocked { get; set; }
        public string Remarks { get; set; }
        public List<Task> Tasks { get; set; }
        public ConstructionSiteManager ConstructionSiteManager { get; set; }
        public List<WorksheetMaterial> WorksheetMaterials { get; set; }
        public List<WorksheetEquipment> WorksheetEquipment { get; set; }
        public int ConstructionSiteId { get; set; }
        public ConstructionSite ConstructionSite { get; set; }
    }
}
