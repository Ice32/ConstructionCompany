using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public enum OpenStatus
    {
        Open,
        Closed,
    };
    public class ConstructionSite
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public decimal ProjectWorth { get; set; }

        public OpenStatus OpenStatus { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }

        public string UserId { get; set; }
        public User CreatedBy { get; set; }

        public List<ConstructionSiteSiteManager> ConstructionSiteManagers { get; set; }
    }
}
