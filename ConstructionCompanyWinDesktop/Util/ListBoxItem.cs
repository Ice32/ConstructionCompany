namespace ConstructionCompanyWinDesktop.Util
{
    public class ListBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ListBoxItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ListBoxItem()
        {
            
        }
    }
}
