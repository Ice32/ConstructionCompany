using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ConstructionCompanyMobile.Services;
using ConstructionCompanyMobile.Util;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        public TaskVM Task { get; set; }
        public ObservableCollection<string> Workers { get; set; }
        public ObservableCollection<string> Materials { get; set; }
        public ObservableCollection<string> Equipment { get; set; }
        public Command RateTaskCommand { get; set; }
        private readonly TasksService _tasksService = new TasksService();
        public ObservableCollection<int> TaskRatings { get; set; }
        public int SelectedRating { get; set; }

        public TaskViewModel() { }
        public TaskViewModel(TaskVM task = null)
        {
            Title = "Zadatak: " + task?.Title;
            Task = task;
            RateTaskCommand = new Command(async () => await ExecuteRateTaskCommand());
            if (TaskRatings == null)
            {
                TaskRatings = new ObservableCollection<int>();

                for (int i = 1; i <= 5; i++)
                {
                    TaskRatings.Add(i);
                }
            }
            if (Workers == null)
            {
                Workers = new ObservableCollection<string>();
                Materials = new ObservableCollection<string>();
                Equipment = new ObservableCollection<string>();

            }

            if (task != null)
            {
                if (task.Rating != default)
                {
                    SelectedRating = task.Rating;
                }
                Workers.Clear();
                foreach (WorkerVM worker in task.Workers)
                {
                    Workers.Add(worker.User.FullName);
                }

                Materials.Clear();
                foreach (MaterialVM material in task.Worksheet.Materials)
                {
                    Materials.Add(material.PrettyPrint());
                }

                Equipment.Clear();
                foreach (EquipmentVM equipment in task.Worksheet.Equipment)
                {
                    Equipment.Add(equipment.PrettyPrint());
                }
            }


        }

        private async Task ExecuteRateTaskCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var forUpdate = new TaskAddVM
                {
                    Id = Task.Id,
                    Description = Task.Description,
                    Title = Task.Title,
                    WorkerIds = Task.Workers.Select(w => w.Id).ToList(),
                    Rating = SelectedRating
                };
                await _tasksService.Update(Task.Id, forUpdate);
                await Application.Current.MainPage.DisplayAlert("Rezultat", "Zadatak ocijenjen", "Uredu");
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
