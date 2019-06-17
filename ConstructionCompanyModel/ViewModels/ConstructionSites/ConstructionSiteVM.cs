using System;
using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel.ViewModels.ConstructionSites
{
    public enum OpenStatus
    {
        Open,
        Closed,
    };
    public class ConstructionSiteVM
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Address { get; set; }
        
        public string Description { get; set; }

        public decimal ProjectWorth { get; set; }

        public OpenStatus OpenStatus { get; set; }
        
        public UserVM CreatedBy { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }

        //public List<ConstructionSiteSiteManager> ConstructionSiteManagers { get; set; }
    }
}
