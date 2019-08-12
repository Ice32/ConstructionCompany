using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.WorkerSuggestions;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class frmTaskCreateEdit : Form
    {
        private readonly TaskAddVM _originalTask;
        private readonly TaskAddVM _taskCopy = new TaskAddVM();
        private readonly APIClient _workersClient = new APIClient("workers");
        private readonly APIClient _workersSuggestionsClient = new APIClient("workerSuggestions");
        private List<WorkerVM> _workers;
        private readonly ValidationUtil _validationUtil;
        public frmTaskCreateEdit(TaskAddVM task)
        {
            InitializeComponent();

            _originalTask = task;
            _taskCopy.Title = task.Title;

            txtTaskName.Text = task.Title;
            txtTaskName.KeyUp += OnTaskNameChange;

            txtTaskDescription.Text = task.Description;

            _validationUtil = new ValidationUtil(errorProviderTaskCreateEdit);
            LoadWorkers();
        }

        private void OnTaskNameChange(object sender, KeyEventArgs args)
        {
            _taskCopy.Title = txtTaskName.Text;
            LoadWorkers();
        }
        private async void LoadWorkers()
        {
            if (_workers == null)
            {
                _workers = await _workersClient.Get<List<WorkerVM>>("");
            }

            List<WorkerSuggestionVM> workerSuggestions = await GetSuggestedWorkers();

            List<WorkerVM> workersForList = workerSuggestions.Select(ws => ws.Worker).ToList();

            _workers.ForEach(worker =>
            {
                bool workerAlreadyInList = workersForList.Exists(w => w.Id == worker.Id);
                if (!workerAlreadyInList)
                {
                    workersForList.Add(worker);
                }
            });


            listTaskWorkers.DataSource = workersForList.Select(w => {
                bool workerIsRecommended = workerSuggestions.Exists(ws => ws.Worker.Id == w.Id);
                return new ListBoxItem
                {
                    Id = w.Id,
                    Name = w.User.FirstName + " " + w.User.LastName + (workerIsRecommended ? "*" : ""),
                };
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
                        if (((ListBoxItem)listTaskWorkers.Items[j]).Id == workerId)
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
        private async Task<List<WorkerSuggestionVM>> GetSuggestedWorkers()
        {
            _taskCopy.Title = txtTaskName.Text;
            string url = "?taskName=" + _taskCopy.Title;
            if (_originalTask.Id != default)
            {
                url += "&taskId=" + _originalTask.Id;
            }
            List<WorkerSuggestionVM> workerSuggestions = await _workersSuggestionsClient.Get<List<WorkerSuggestionVM>>(url);
            workerSuggestions.Sort((a, b) => a.Compatibility > b.Compatibility ? 1 : -1);
            return workerSuggestions;
        }

        private void BtnTaskSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
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
