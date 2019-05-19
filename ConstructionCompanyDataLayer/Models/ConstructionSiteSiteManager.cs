using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class ConstructionSiteSiteManager
    {
        public int ConstructionSiteId { get; set; }
        public ConstructionSite ConstructionSite { get; set; }
        public int ConstructionSiteManagerId { get; set; }
        public ConstructionSiteManager ConstructionSiteManager { get; set; }
    }
}
