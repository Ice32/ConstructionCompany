using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel.ViewModels.Managers
{
    public class ManagerAddVM: IUserTypeAddVM
    {
        public int? Id { get; set; }
        public UserAddVM User { get; set; }
//        public List<Worksheet> Worksheets { get; set; }
//        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}