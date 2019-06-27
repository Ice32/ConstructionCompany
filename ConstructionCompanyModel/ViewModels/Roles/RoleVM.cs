namespace ConstructionCompanyModel.ViewModels.Roles
{
    public class RoleVM
    {
        public enum RoleEnum
        {
            Manager,
            ConstructionSiteManager,
            Worker
        }
        public int Id { get; set; }
        
        public string Description { get; set; }
        public RoleEnum Name { get; set; }
    }
}