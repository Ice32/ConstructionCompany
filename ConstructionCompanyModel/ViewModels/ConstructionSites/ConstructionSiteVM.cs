using System;

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

        public decimal ProjectWorth { get; set; }

        public OpenStatus OpenStatus { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }

        //public List<ConstructionSiteSiteManager> ConstructionSiteManagers { get; set; }
    }
}
