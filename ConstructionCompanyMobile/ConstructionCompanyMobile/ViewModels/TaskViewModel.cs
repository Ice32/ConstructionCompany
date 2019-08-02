using System.Collections.ObjectModel;
using ConstructionCompanyMobile.Util;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyMobile.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        public TaskVM Task { get; set; }
        public ObservableCollection<string> Workers { get; set; }
        public ObservableCollection<string> Materials { get; set; }
        public ObservableCollection<string> Equipment { get; set; }
        public TaskViewModel(TaskVM task = null)
        {
            Title = "Zadatak: " + task?.Title;
            Task = task;
            if (Workers == null)
            {
                Workers = new ObservableCollection<string>();
                Materials = new ObservableCollection<string>();
                Equipment = new ObservableCollection<string>();

            }

            if (task != null)
            {
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

    }
}
