using System;
using System.ComponentModel;
using ConstructionCompanyMobile.ViewModels;
using ConstructionCompanyModel.ViewModels.Tasks;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        TasksViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TasksViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as TaskVM;
            if (item == null)
                return;

            await Navigation.PushAsync(new TaskPage(new TaskViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Tasks.Count == 0)
            {
                //viewModel.LoadTasksCommand.Execute(null);
                viewModel.InitCommand.Execute(null);
                    
            }
        }
    }
}