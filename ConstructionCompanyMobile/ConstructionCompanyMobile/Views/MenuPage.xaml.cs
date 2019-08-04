using System.Collections.Generic;
using System.ComponentModel;
using ConstructionCompanyMobile.Models;
using ConstructionCompanyMobile.Util;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>();
            menuItems.Add(new HomeMenuItem {Id = MenuItemType.Tasks, Title="Zadaci" });
            if (!CurrentUserManager.IsWorker())
            {
                menuItems.Add(new HomeMenuItem {Id = MenuItemType.Worksheets, Title="Radni listovi" });
            }
            menuItems.Add(new HomeMenuItem {Id = MenuItemType.Logout, Title="Odjavi se" });

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}