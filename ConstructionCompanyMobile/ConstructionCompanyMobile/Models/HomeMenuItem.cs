namespace ConstructionCompanyMobile.Models
{
    public enum MenuItemType
    {
        Tasks,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
