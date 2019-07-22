using System;
using System.Windows.Forms;
using ConstructionCompanyWinDesktop.ConstructionSiteManagers;
using ConstructionCompanyWinDesktop.ConstructionSites;
using ConstructionCompanyWinDesktop.Equipment;
using ConstructionCompanyWinDesktop.Managers;
using ConstructionCompanyWinDesktop.Materials;
using ConstructionCompanyWinDesktop.Users;
using ConstructionCompanyWinDesktop.Util;
using ConstructionCompanyWinDesktop.Worksheets;

namespace ConstructionCompanyWinDesktop
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();

            if (!CurrentUserManager.IsManager())
            {
                gradilisToolStripMenuItem.Visible = false;
                ConstructionSitesAddMenuItem.Visible = false;
                WorkerAddMenuItem.Visible = false;
                šefoviGradilištaToolStripMenuItem.Visible = false;
                administratoriToolStripMenuItem.Visible = false;
                materijaliToolStripMenuItem.Visible = false;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void WorksheetSearchMenuItem_Click(object sender, EventArgs e)
        {
            var korisniciPretraga = new frmWorksheetsList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            korisniciPretraga.Show();
        }
        

        private void WorksheetAddMenuItem_Click(object sender, EventArgs e)
        {
            var creationForm = new frmNewWorksheet(null, this);
            creationForm.ShowDialog();
        }

        private void ConstructionSitesSearchMenuItem_Click(object sender, EventArgs e)
        {
            var constructionSitesForm = new frmConstructionSitesList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
            };
            constructionSitesForm.Show();
        }

        private void ConstructionSiteAddMenuItem_Click(object sender, EventArgs e)
        {
            var creationForm = new frmNewConstructionSite(this);
            creationForm.ShowDialog();
        }

        private void WorkerAddMenuItem_Click(object sender, EventArgs e)
        {
            var creationForm = new frmNewWorker(this);
            creationForm.ShowDialog();
        }

        private void WorkerSearchMenuItem_Click(object sender, EventArgs e)
        {
            var usersForm = new frmWorkersList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
            };
            usersForm.Show();
        }

        private void ConstructionSiteManagerSearchMenuItem_Click(object sender, EventArgs e)
        {
            var usersForm = new frmConstructionSiteManagersList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
            };
            usersForm.Show();
        }

        private void ManagerSearchMenuItem_Click(object sender, EventArgs e)
        {
            var usersForm = new frmManagersList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
            };
            usersForm.Show();
        }

        private void ConstructionSiteManagerAddMenuItem_Click(object sender, EventArgs e)
        {
            var creationForm = new frmNewConstructionSiteManager(this);
            creationForm.ShowDialog();
        }

        private void MenuAddNewManager_Click(object sender, EventArgs e)
        {
            var creationForm = new frmNewManager(this);
            creationForm.ShowDialog();
        }

        private void MaterialsSearchMenuItem_Click(object sender, EventArgs e)
        {
            var materialsForm = new frmMaterialsList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
            };
            materialsForm.Show();
        }

        private void MaterialsAddMenuItem_Click(object sender, EventArgs e)
        {
            var creationForm = new frmNewMaterial(this);
            creationForm.ShowDialog();
        }

        private void OpremaSearchMenuItem_Click(object sender, EventArgs e)
        {
            var equipmentForm = new frmEquipmentList
            {
                MdiParent = this,
                Dock = DockStyle.Fill,
            };
            equipmentForm.Show();
        }
    }
}
