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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstructionSitesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConstructionSitesList
            // 
            this.dgvConstructionSitesList.AllowUserToAddRows = false;
            this.dgvConstructionSitesList.AllowUserToDeleteRows = false;
            this.dgvConstructionSitesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConstructionSitesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstructionSitesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Address,
            this.ProjectWorth,
            this.CreatedBy});
            this.dgvConstructionSitesList.Location = new System.Drawing.Point(0, 49);
            this.dgvConstructionSitesList.MultiSelect = false;
            this.dgvConstructionSitesList.Name = "dgvConstructionSitesList";
            this.dgvConstructionSitesList.ReadOnly = true;
            this.dgvConstructionSitesList.RowHeadersWidth = 82;
            this.dgvConstructionSitesList.RowTemplate.Height = 33;
            this.dgvConstructionSitesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstructionSitesList.Size = new System.Drawing.Size(892, 381);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pretraga";
            // 
            // frmConstructionSitesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(892, 430);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvConstructionSitesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConstructionSitesList";
            this.Text = "frmConstructionSitesList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstructionSitesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectWorth;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridView dgvConstructionSitesList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}