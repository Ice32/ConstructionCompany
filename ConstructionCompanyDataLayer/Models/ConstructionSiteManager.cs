using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class ConstructionSiteManager
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Worksheet> Worksheets { get; set; }
        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}
