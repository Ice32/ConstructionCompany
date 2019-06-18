using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel.ViewModels.ConstructionSiteManagers
{
    public class ConstructionSiteManagerVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
//        public List<Worksheet> Worksheets { get; set; }
//        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}