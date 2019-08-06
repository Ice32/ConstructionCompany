using ConstructionCompanyMobile.Services;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Worksheets;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    public class WorksheetViewModel : BaseViewModel
    {
        public WorksheetVM Worksheet { get; set; }
        public ObservableCollection<TaskVM> Tasks { get; set; }
        public Command LockWorksheetCommand { get; set; }
        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _worksheetsService = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");

        public WorksheetViewModel() { }
        public WorksheetViewModel(WorksheetVM worksheet = null)
        {
            Title = "Radni list";
            Worksheet = worksheet;
            LockWorksheetCommand = new Command(async () => await ExecuteLockWorksheetCommand());

            if (Tasks == null)
            {
                Tasks = new ObservableCollection<TaskVM>();
            }

            if (worksheet != null)
            {
                Title = "Radni list: " + worksheet.Date.ToString("dd. MM. yyyy");

                Tasks.Clear();
                foreach (TaskVM task in worksheet.Tasks)
                {
                    Tasks.Add(task);
                }

            }


        }

        private async Task ExecuteLockWorksheetCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var forUpdate = new WorksheetAddVM
                {
                    Id = Worksheet.Id,
                    ConstructionSiteId = Worksheet.ConstructionSite.Id,
                    Date = Worksheet.Date,
                    Equipment = Worksheet.Equipment.Select(e => new WorksheetEquipmentVM { EquipmentId = e.Id, Quantity = e.Quantity }).ToList(),
                    Materials = Worksheet.Materials.Select(m => new WorksheetMaterialVM { MaterialId = m.Id, Amount = m.Amount }).ToList(),
                    Tasks = Worksheet.Tasks.Select(t => new TaskAddVM { Id = t.Id, Description = t.Description, Rating = t.Rating, Title = t.Title, WorkerIds = t.Workers.Select(w => w.Id).ToList() }).ToList(),
                    Remarks = Worksheet.Remarks,
                    WeatherConditions = Worksheet.WeatherConditions,
                    IsLocked = true
                };
                await _worksheetsService.Update(Worksheet.Id, forUpdate);
                await Application.Current.MainPage.DisplayAlert("Rezultat", "Radni list zakljucen", "ok");
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
