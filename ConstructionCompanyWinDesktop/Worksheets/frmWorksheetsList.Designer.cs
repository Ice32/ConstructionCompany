namespace ConstructionCompanyWinDesktop
{
    partial class frmWorksheetsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConstructionSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Workers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtWorksheetDate = new System.Windows.Forms.DateTimePicker();
            this.cmbConstructionSites = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ConstructionSite,
            this.Workers,
            this.Equipment,
            this.Remarks,
            this.Date});
            this.dgvMain.Location = new System.Drawing.Point(0, 45);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidth = 82;
            this.dgvMain.RowTemplate.Height = 33;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1512, 738);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMain_CellClick);
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
            // ConstructionSite
            // 
            this.ConstructionSite.DataPropertyName = "ConstructionSite";
            this.ConstructionSite.HeaderText = "Gradilište";
            this.ConstructionSite.MinimumWidth = 10;
            this.ConstructionSite.Name = "ConstructionSite";
            this.ConstructionSite.ReadOnly = true;
            this.ConstructionSite.Width = 200;
            // 
            // Workers
            // 
            this.Workers.DataPropertyName = "Workers";
            this.Workers.HeaderText = "Radnici";
            this.Workers.MinimumWidth = 10;
            this.Workers.Name = "Workers";
            this.Workers.ReadOnly = true;
            this.Workers.Width = 200;
            // 
            // Equipment
            // 
            this.Equipment.DataPropertyName = "Equipment";
            this.Equipment.HeaderText = "Oprema";
            this.Equipment.MinimumWidth = 10;
            this.Equipment.Name = "Equipment";
            this.Equipment.ReadOnly = true;
            this.Equipment.Width = 200;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Bilješke";
            this.Remarks.MinimumWidth = 10;
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 200;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Datum";
            this.Date.MinimumWidth = 10;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 200;
            // 
            // dtWorksheetDate
            // 
            this.dtWorksheetDate.Location = new System.Drawing.Point(446, 4);
            this.dtWorksheetDate.Name = "dtWorksheetDate";
            this.dtWorksheetDate.Size = new System.Drawing.Size(394, 31);
            this.dtWorksheetDate.TabIndex = 2;
            // 
            // cmbConstructionSites
            // 
            this.cmbConstructionSites.FormattingEnabled = true;
            this.cmbConstructionSites.Location = new System.Drawing.Point(121, 6);
            this.cmbConstructionSites.Name = "cmbConstructionSites";
            this.cmbConstructionSites.Size = new System.Drawing.Size(172, 33);
            this.cmbConstructionSites.TabIndex = 3;
            this.cmbConstructionSites.Text = "Gradilište";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gradilište";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datum";
            // 
            // frmWorksheetsList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1512, 783);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbConstructionSites);
            this.Controls.Add(this.dtWorksheetDate);
            this.Controls.Add(this.dgvMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorksheetsList";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConstructionSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Workers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DateTimePicker dtWorksheetDate;
        private System.Windows.Forms.ComboBox cmbConstructionSites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

