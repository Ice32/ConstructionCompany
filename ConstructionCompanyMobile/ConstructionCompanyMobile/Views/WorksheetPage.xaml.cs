using ConstructionCompanyMobile.ViewModels;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Worksheets;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConstructionCompanyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorksheetPage : ContentPage
    {
        readonly WorksheetViewModel _viewModel;
        public WorksheetPage(WorksheetViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;

            if (viewModel.Worksheet.IsLocked)
            {
                LockWorksheetButton.IsVisible = false;
                LockWorksheetLabel.IsVisible = true;
            }
        }

        public WorksheetPage()
        {
            InitializeComponent();

            var worksheet = new WorksheetVM
            {
                Date = DateTime.Now,
                ConstructionSite = new ConstructionSiteVM
                {
                    Title = "Construction site"
                },
                Tasks = new List<TaskVM>()
            };

            _viewModel = new WorksheetViewModel(worksheet);
            BindingContext = _viewModel;
        }

        private async void OnTaskSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as TaskVM;
            if (item == null)
                return;
            item.Worksheet = _viewModel.Worksheet;
            await Navigation.PushAsync(new TaskPage(new TaskViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}