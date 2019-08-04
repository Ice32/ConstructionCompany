using ConstructionCompanyMobile.ViewModels;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConstructionCompanyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorksheetsPage : ContentPage
    {
        WorksheetsViewModel viewModel;
        public WorksheetsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WorksheetsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as WorksheetVM;
            if (item == null)
                return;

            //await Navigation.PushAsync(new TaskPage(new TaskViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Worksheets.Count == 0) {
                viewModel.LoadWorksheetsCommand.Execute(null);
            }
        }
    }
}