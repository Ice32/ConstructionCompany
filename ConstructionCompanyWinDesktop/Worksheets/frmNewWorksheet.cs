using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private readonly List<TaskAddVM> _tasks = new List<TaskAddVM> {
            new TaskAddVM(),
        };

        private readonly APIClient _apiClient = new APIClient("worksheets");
        private readonly Form _parent;

        private readonly ListRenderer<TaskAddVM> _taskRenderer;

        public frmNewWorksheet(WorksheetAddVM worksheet = null, Form parent = null)
        {
            InitializeComponent();
            _parent = parent;
            if (worksheet != null)
            {
                _tasks = worksheet.Tasks.Select(task => new TaskAddVM
                {
                    Title = task.Title,
                })
                    .ToList();
                dtWorksheetDate.Value = worksheet.Date;
                lblWorksheetCreateEditHeader.Text = "Uredi radni list";

            }
            _taskRenderer = new ListRenderer<TaskAddVM>(ref _tasks, Controls, AddNewTaskInput);
            
            _taskRenderer.RerenderTaskInputs();
        }



        private void BtnDodajZadatak_Click(object sender, EventArgs e)
        {
            _tasks.Add(new TaskAddVM());
            
            _taskRenderer.RerenderTaskInputs();
           
        }

        private List<Control> AddNewTaskInput(TaskAddVM task, int i, Action rerenderTaskInputs)
        {
            int rowStart = FormStartY + (i * RowSize);
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
                ReadOnly = true,
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
                    rerenderTaskInputs();
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
                rerenderTaskInputs();
            };

            btnDodajZadatak.Location = new Point
            {
                X = TxtNameX,
                Y = secondRowStart + RowSize
            };
            return new List<Control>
            {
                btnEdit,
                btnRemove,
                textBox,
            };
        }

        private async void BtnSaveEditWorksheet_Click(object sender, EventArgs e)
        {
            WorksheetAddVM worksheet = new WorksheetAddVM
            {
                Date = dtWorksheetDate.Value,
                Tasks = _tasks,
                ConstructionSiteId = 3,
            };
            await _apiClient.Post<WorksheetVM>("", worksheet);
            Form listForm = new frmWorksheetsList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true};
            Close();
            listForm.Show();
        }
    }
}