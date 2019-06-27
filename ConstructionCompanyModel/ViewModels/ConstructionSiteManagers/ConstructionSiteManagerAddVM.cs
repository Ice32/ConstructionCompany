using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel.ViewModels.ConstructionSiteManagers
{
    public class ConstructionSiteManagerAddVM: IUserTypeAddVM
    {
        public int? Id { get; set; }
        public UserAddVM User { get; set; }
//        public List<Worksheet> Worksheets { get; set; }
//        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}