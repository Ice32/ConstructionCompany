using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ConstructionCompanyMobile.Services;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    public class WorksheetsViewModel : BaseViewModel
    {
        public Command LoadWorksheetsCommand { get; set; }
        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _worksheetsService = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
        public ObservableCollection<WorksheetVM> Worksheets { get; set; }
        public ObservableCollection<string> WorksheetsItems { get; set; }
        public WorksheetsViewModel()
        {
            Title = "Radni listovi";

            LoadWorksheetsCommand = new Command(async () => await ExecuteLoadWorksheetsCommand());

            if (Worksheets == null)
            {
                Worksheets = new ObservableCollection<WorksheetVM>();
                WorksheetsItems = new ObservableCollection<string>();
            }
        }

        private async Task ExecuteLoadWorksheetsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Worksheets.Clear();

                List<WorksheetVM> worksheets = await _worksheetsService.GetAll();
                foreach (WorksheetVM worksheet in worksheets)
                {
                    Worksheets.Add(worksheet);
                    WorksheetsItems.Add($"{worksheet.ConstructionSite.Title} - {worksheet.Date.ToString("dd. MM. yyyy")}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
