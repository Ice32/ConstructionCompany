using System;

namespace ConstructionCompanyModel.ViewModels.ConstructionSites
{
    public class ConstructionSiteAddVM
    {
        public int? Id { get; set; }
        
        public string Title { get; set; }
        
        public string Address { get; set; }
        
        public string Description { get; set; }

        public decimal ProjectWorth { get; set; }


        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
        
        public int ConstructionSiteManagerId { get; set; }

        public int CreatedById { get; set; }

        //public List<ConstructionSiteSiteManager> ConstructionSiteManagers { get; set; }
    }
}
