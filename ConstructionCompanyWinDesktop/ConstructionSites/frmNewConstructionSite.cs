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

        public frmNewConstructionSite(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            LoadConstructionSiteManagers();
        }

        public frmNewConstructionSite(ConstructionSiteVM constructionSite, Form parent) : this(parent)
        {
            _originalConstructionSite = constructionSite;

            txtConstructionSiteTitle.Text = constructionSite.Title;
            txtConstructionSiteAddress.Text = constructionSite.Address;
            txtConstructionSiteDescription.Text = constructionSite.Description;
            numConstructionSiteWorth.Value = constructionSite.ProjectWorth;

            lblNewConstructionSite.Text = "Uredi gradilište";
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
            var constructionSite = new ConstructionSiteAddVM
            {
                Title = txtConstructionSiteTitle.Text,
                Description = txtConstructionSiteDescription.Text,
                ProjectWorth = numConstructionSiteWorth.Value,
                Address = txtConstructionSiteAddress.Text,
                ConstructionSiteManagerId = ((ListBoxItem)listConstructionSiteManager.SelectedItem).Id
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
    }
}
