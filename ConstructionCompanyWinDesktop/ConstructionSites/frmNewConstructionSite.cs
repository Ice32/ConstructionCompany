using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.ConstructionSites
{
    public partial class frmNewConstructionSite : Form
    {
        private readonly Form _parent;
        private readonly ConstructionSiteVM _originalConstructionSite;
        private readonly APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM> _constructionSitesService = new APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM>("constructionSites");
        private readonly APIService<ConstructionSiteManagerVM, object, object> _constructionSitesManagersService = new APIService<ConstructionSiteManagerVM, object, object>("constructionSiteManagers");
        private readonly ValidationUtil _validationUtil;

        public frmNewConstructionSite(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            LoadConstructionSiteManagers();
            _validationUtil = new ValidationUtil(errorProvider1);
        }

        public frmNewConstructionSite(ConstructionSiteVM constructionSite, Form parent) : this(parent)
        {
            _originalConstructionSite = constructionSite;

            txtConstructionSiteTitle.Text = constructionSite.Title;
            txtConstructionSiteAddress.Text = constructionSite.Address;
            txtConstructionSiteDescription.Text = constructionSite.Description;
            numConstructionSiteWorth.Value = constructionSite.ProjectWorth;

            lblNewConstructionSite.Text = "Uredi gradilište";

            if (!CurrentUserManager.IsManager())
            {
                btnSaveConstructionSite.Visible = false;
            }
        }
        
        private async void LoadConstructionSiteManagers()
        {
            List<ConstructionSiteManagerVM> constructionSiteManagers = await _constructionSitesManagersService.GetAll();
            listConstructionSiteManager.DataSource = constructionSiteManagers.Select(csm => new ListBoxItem
            {
                Id = csm.Id,
                Name = csm.User.FullName
            }).ToList();
            listConstructionSiteManager.DisplayMember = "Name";
            listConstructionSiteManager.ValueMember = "Id";
            if (_originalConstructionSite != null)
            {
                listConstructionSiteManager.SelectedValue = _originalConstructionSite.ConstructionSiteManager.Id;

            }
        }

        private async void BtnSaveConstructionSite_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            var constructionSite = new ConstructionSiteAddVM
            {
                Title = txtConstructionSiteTitle.Text,
                Description = txtConstructionSiteDescription.Text,
                ProjectWorth = numConstructionSiteWorth.Value,
                Address = txtConstructionSiteAddress.Text,
                ConstructionSiteManagerId = ((ListBoxItem)listConstructionSiteManager.SelectedItem).Id,
                CreatedById = CurrentUserManager.GetUser().Id
            };
            if (_originalConstructionSite != null)
            {
                constructionSite.Id = _originalConstructionSite.Id;
                await _constructionSitesService.Update(_originalConstructionSite.Id, constructionSite);
            }
            else
            {
                await _constructionSitesService.Create(constructionSite);
            }
            Form listForm = new frmConstructionSitesList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true};
            Close();
            listForm.Show();
        }

        private void TxtConstructionSiteTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }

        private void TxtConstructionSiteDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }

        private void ListConstructionSiteManager_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            _validationUtil.AssertItemSelected(comboBox, e);
        }
    }
}
