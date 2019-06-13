using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class worksheetTaskUserControl : UserControl
    {
        public worksheetTaskUserControl()
        {
            InitializeComponent();
        }

        public worksheetTaskUserControl(TaskAddVM task, Action rerender, EventHandler removeHandler): this()
        {
            txtWorksheetTaskName.Text = task.Title;
            txtWorksheetTaskName.KeyUp += (sender, args) => { task.Title = ((TextBox) sender).Text; };
            btnWorksheetTaskEdit.Click += (sender, args) =>
            {
                Form editForm = new frmTaskCreateEdit(task);
                editForm.FormClosing += (o, eventArgs) => { rerender(); };
                editForm.Show();
            };
            btnWorksheetTaskRemove.Click += removeHandler;
        }
    }
}
