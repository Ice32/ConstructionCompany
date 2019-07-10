using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ConstructionCompanyMobile.Services;
using ConstructionCompanyModel.ViewModels.Tasks;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<TaskVM> Tasks { get; set; }
        public Command LoadItemsCommand { get; set; }

        private readonly APIService<TaskVM, TaskAddVM, TaskAddVM> _tasksService = new APIService<TaskVM, TaskAddVM, TaskAddVM>("tasks");
        public ItemsViewModel()
        {
            Title = "Browse";
            Tasks = new ObservableCollection<TaskVM>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Tasks.Clear();
                List<TaskVM> tasks = await _tasksService.GetAll();
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
    }
}