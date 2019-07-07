using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class worksheetTasksUserControl : UserControl
    {
        public worksheetTasksUserControl()
        {
            InitializeComponent();
        }
        private ListRenderer<TaskAddVM> _taskRenderer;
        private List<TaskAddVM> _tasks = new List<TaskAddVM>();


        public void SetTasks(List<TaskAddVM> tasks)
        {
            _tasks = tasks;
            RenderAddButtonTask();
            _taskRenderer = new ListRenderer<TaskAddVM>(ref _tasks, panelWorksheetTasks.Controls, AddNewTaskInput);
            Rerender();
        }

        private List<Control> AddNewTaskInput(TaskAddVM task, int i, Action rerenderTaskInputs)
        {
            var worksheetTaskUserControl = new worksheetTaskUserControl(
                    task,
                    Rerender,
                    (sender, args) =>
                    {
                        _tasks.Remove(task);
                        Rerender();
                    }
                );
            
            return new List<Control>{ worksheetTaskUserControl };
        }

        private void RenderAddButtonTask()
        {
            btnAddTask.Click += (object sender, EventArgs e) =>
            {
                _tasks.Add(new TaskAddVM());
            
                Rerender();
            };
        }

        private void Rerender()
        {
            _taskRenderer.RerenderInputs();
        }
    }
}
