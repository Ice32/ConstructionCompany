using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public enum OpenStatus
    {
        Open,
        Closed,
    };
    public class ConstructionSite
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Address { get; set; }
        
        [Column(TypeName = "text")]
        public string Description { get; set; }

        public decimal ProjectWorth { get; set; }

        public OpenStatus OpenStatus { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public List<ConstructionSiteSiteManager> ConstructionSiteManagers { get; set; }
    }
}
