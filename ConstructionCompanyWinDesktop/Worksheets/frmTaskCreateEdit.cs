using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class frmTaskCreateEdit : Form
    {
        private TaskAddVM _originalTask;
        private TaskAddVM _taskCopy = new TaskAddVM();
        private APIClient _workersClient = new APIClient("workers");
        private ValidationUtil _validationUtil;
        public frmTaskCreateEdit(TaskAddVM task)
        {
            InitializeComponent();

            _originalTask = task;
            _taskCopy.Title = task.Title;

            txtTaskName.Text = task.Title;
            txtTaskName.KeyUp += (sender, args) => { _taskCopy.Title = txtTaskName.Text; };

            txtTaskDescription.Text = task.Description;

            _validationUtil = new ValidationUtil(errorProviderTaskCreateEdit);
            LoadWorkers();
        }

        private async void LoadWorkers()
        {
            List<WorkerVM> workers = await _workersClient.Get<List<WorkerVM>>("");
            listTaskWorkers.DataSource = workers.Select(w => new ListBoxItem
            {
                Id = w.Id,
                Name = w.User.FirstName + " " + w.User.LastName,
            }).ToList();
            listTaskWorkers.DisplayMember = "Name";
            listTaskWorkers.ValueMember = "Id";
            if (_originalTask.WorkerIds != null)
            {
                listTaskWorkers.SelectedIndices.Clear();
                foreach (int workerId in _originalTask.WorkerIds)
                {
                    int indexInList = -1;
                    for (var j = 0; j < listTaskWorkers.Items.Count; j++)
                    {
                        if (((ListBoxItem) listTaskWorkers.Items[j]).Id == workerId)
                        {
                            indexInList = j;
                        }
                    }

                    if (indexInList != -1)
                    {
                        listTaskWorkers.SelectedIndices.Add(indexInList);
                    }
                }
            }
        }
        

        private void BtnTaskSave_Click(object sender, EventArgs e)
        {
            _originalTask.Title = _taskCopy.Title;
            _originalTask.WorkerIds = new List<int>();
            foreach (ListBoxItem selectedItem in listTaskWorkers.SelectedItems)
            {
                _originalTask.WorkerIds.Add(selectedItem.Id);
            }
            _originalTask.Description = txtTaskDescription.Text;
            Close();
        }

        private void TxtTaskName_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            _validationUtil.AssertLength(3, textBox, e);
        }

        private void ListTaskWorkers_Validating(object sender, CancelEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            _validationUtil.AssertItemSelected(listBox, e);
        }
    }
}
