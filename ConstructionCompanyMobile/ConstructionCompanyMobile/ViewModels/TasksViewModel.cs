using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ConstructionCompanyMobile.Services;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public ObservableCollection<TaskVM> Tasks { get; set; }
        public ObservableCollection<WorkerVM> Workers { get; set; }
        public Command LoadTasksCommand { get; set; }
        public Command LoadWorkersCommand { get; set; }
        public Command InitCommand { get; set; }

        private WorkerVM _selectedWorker;
        public WorkerVM SelectedWorker
        {
            get => _selectedWorker;
            set => SetProperty(ref _selectedWorker, value, "", () => LoadTasksCommand.Execute(null));
        }

        private readonly TasksService _tasksService = new TasksService();
        private readonly APIService<WorkerVM, WorkerAddVM, WorkerAddVM> _workersService = new APIService<WorkerVM, WorkerAddVM, WorkerAddVM>("workers");
        public TasksViewModel()
        {
            Title = "Tasks for today";
            Tasks = new ObservableCollection<TaskVM>();
            Workers = new ObservableCollection<WorkerVM>();
            InitCommand = new Command(async () =>
            {
                await ExecuteLoadTasksCommand();
                await ExecuteLoadWorkersCommand();
            });
            LoadTasksCommand = new Command(async () => await ExecuteLoadTasksCommand());
            LoadWorkersCommand = new Command(async () => await ExecuteLoadWorkersCommand());
        }

        private async Task ExecuteLoadTasksCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Tasks.Clear();

                List<TaskVM> tasks = await _tasksService.GetByWorkerAndConstructionSite(
                    _selectedWorker?.Id
                );
                foreach (TaskVM task in tasks)
                {
                    Tasks.Add(task);
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
        
        private async Task ExecuteLoadWorkersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Workers.Clear();

                List<WorkerVM> workers = await _workersService.GetAll();
                foreach (WorkerVM worker in workers)
                {
                    Workers.Add(worker);
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