using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class frmNewWorksheet : Form
    {
        private const int RowSize = 30;
        private const int TxtNameX = 280;
        private const int BtnEditX = 408;
        private const int BtnRemoveX = 488;

        private const int TextInputHeight = 20;
        private const int ButtonInputHeight = 24;
        private const int FormStartY = 93;
        
        private readonly APIClient _apiClient = new APIClient("worksheets");

        private readonly List<TaskAddVM> _tasks = new List<TaskAddVM> {
            new TaskAddVM(),
        };

        private readonly List<Control> _controls = new List<Control>();
        public frmNewWorksheet()
        {
            InitializeComponent();
            RerenderTaskInputs();
        }

        private void BtnDodajZadatak_Click(object sender, EventArgs e)
        {
            _tasks.Add(new TaskAddVM());
            
            RerenderTaskInputs();
           
        }

        private void ClearTaskInputs()
        {
            _controls.ForEach(control =>
            {
                Controls.Remove(control);
            });
        }

        private void RerenderTaskInputs()
        {
            ClearTaskInputs();  
            for (var i = 0; i < _tasks.Count; i++)
            {
                AddNewTaskInput(_tasks[i], FormStartY + ( i * RowSize ));
            }
        }

        private void AddNewTaskInput(TaskAddVM task, int rowStart)
        {
            int secondRowStart = rowStart + 38;
            TextBox textBox = new TextBox
            {
                Location = new Point
                {
                    X = TxtNameX,
                    Y = rowStart + RowSize
                },
                Height =  TextInputHeight,
                Text = task.Title,
            };
            textBox.KeyUp += (sender, args) =>
            {
                task.Title = textBox.Text;
            };

            Button btnEdit = new Button
            {
                Location = new Point
                {
                    X = BtnEditX,
                    Y = rowStart + RowSize,
                },
                Height =  ButtonInputHeight,
                Text = "Uredi",
            };
            btnEdit.Click += (sender, args) =>
            {
                Form editForm = new frmTaskCreateEdit(task);
                editForm.FormClosing += (o, eventArgs) => {
                    RerenderTaskInputs();
                };
                editForm.Show();
            };

            Button btnRemove = new Button
            {
                Location = new Point
                {
                    X = BtnRemoveX,
                    Y = rowStart + RowSize,
                },
                Height = ButtonInputHeight,
                Text = "Ukloni",
            };
            btnRemove.Click += (sender, args) =>
            {
                _tasks.Remove(task);
                RerenderTaskInputs();
            };

            btnDodajZadatak.Location = new Point
            {
                X = TxtNameX,
                Y = secondRowStart + RowSize
            };
            Controls.Add(btnEdit);
            Controls.Add(btnRemove);
            Controls.Add(textBox);

            _controls.Add(btnEdit);
            _controls.Add(btnRemove);
            _controls.Add(textBox);
        }

        private async void BtnSaveEditWorksheet_Click(object sender, EventArgs e)
        {
            WorksheetAddVM worksheet = new WorksheetAddVM
            {
                Tasks = _tasks,
                ConstructionSiteId = 3,
            };
            WorksheetVM created = await _apiClient.Post<WorksheetVM>("", worksheet);
        }
    }
}