using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class frmTaskCreateEdit : Form
    {
        public frmTaskCreateEdit(TaskAddVM task)
        {
            InitializeComponent();
            txtTaskName.Text = task.Title;

            txtTaskName.KeyUp += (sender, args) => { task.Title = txtTaskName.Text; };
        }
    }
}
