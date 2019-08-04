using ConstructionCompanyMobile.ViewModels;
using ConstructionCompanyModel.ViewModels.Tasks;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TasksPage : ContentPage
    {
        TasksViewModel viewModel;

        public TasksPage()
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.InitCommand.Execute(null);
        }
    }
}