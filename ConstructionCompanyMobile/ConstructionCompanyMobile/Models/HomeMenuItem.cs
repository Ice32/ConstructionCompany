namespace ConstructionCompanyMobile.Models
{
    public enum MenuItemType
    {
        Tasks,
        Logout,
        Worksheets
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
