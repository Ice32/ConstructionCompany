using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.ConstructionSites
{
    partial class frmConstructionSitesList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvConstructionSitesList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectWorth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstructionSitesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConstructionSitesList
            // 
            this.dgvConstructionSitesList.AllowUserToAddRows = false;
            this.dgvConstructionSitesList.AllowUserToDeleteRows = false;
            this.dgvConstructionSitesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstructionSitesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Address,
            this.ProjectWorth,
            this.CreatedBy});
            this.dgvConstructionSitesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConstructionSitesList.Location = new System.Drawing.Point(0, 0);
            this.dgvConstructionSitesList.MultiSelect = false;
            this.dgvConstructionSitesList.Name = "dgvConstructionSitesList";
            this.dgvConstructionSitesList.ReadOnly = true;
            this.dgvConstructionSitesList.RowHeadersWidth = 82;
            this.dgvConstructionSitesList.RowTemplate.Height = 33;
            this.dgvConstructionSitesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstructionSitesList.Size = new System.Drawing.Size(892, 430);
            this.dgvConstructionSitesList.TabIndex = 0;
            this.dgvConstructionSitesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMain_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 10;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 200;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Naziv";
            this.Title.MinimumWidth = 10;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 200;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Adresa";
            this.Address.MinimumWidth = 10;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 200;
            // 
            // ProjectWorth
            // 
            this.ProjectWorth.DataPropertyName = "ProjectWorth";
            this.ProjectWorth.HeaderText = "Vrijednost projekta";
            this.ProjectWorth.MinimumWidth = 10;
            this.ProjectWorth.Name = "ProjectWorth";
            this.ProjectWorth.ReadOnly = true;
            this.ProjectWorth.Width = 200;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "ConstructionSiteManager";
            this.CreatedBy.HeaderText = "Šef gradilišta";
            this.CreatedBy.MinimumWidth = 10;
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            this.CreatedBy.Width = 200;
            // 
            // frmConstructionSitesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(892, 430);
            this.Controls.Add(this.dgvConstructionSitesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConstructionSitesList";
            this.Text = "frmConstructionSitesList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstructionSitesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectWorth;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridView dgvConstructionSitesList;
    }
}