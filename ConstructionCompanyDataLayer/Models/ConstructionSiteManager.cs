using System.Collections.Generic;

namespace ConstructionCompanyDataLayer.Models
{
    public class ConstructionSiteManager: IUserType
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Worksheet> Worksheets { get; set; }
        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}
