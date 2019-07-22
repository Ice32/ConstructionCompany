namespace ConstructionCompanyWinDesktop
{
    partial class frmIndex
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreirajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradilisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConstructionSitesSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConstructionSitesAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.šefoviGradilištaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConstructionSiteManagerSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddConstructionSiteManager = new System.Windows.Forms.ToolStripMenuItem();
            this.administratoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManagerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddNewManager = new System.Windows.Forms.ToolStripMenuItem();
            this.materijaliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaterialsSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaterialsAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opremaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpremaSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EquipmentAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.gradilisToolStripMenuItem,
            this.korisniciToolStripMenuItem1,
            this.šefoviGradilištaToolStripMenuItem,
            this.administratoriToolStripMenuItem,
            this.materijaliToolStripMenuItem,
            this.opremaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 42);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.kreirajToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(164, 38);
            this.korisniciToolStripMenuItem.Text = "Radni listovi";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(237, 44);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.WorksheetSearchMenuItem_Click);
            // 
            // kreirajToolStripMenuItem
            // 
            this.kreirajToolStripMenuItem.Name = "kreirajToolStripMenuItem";
            this.kreirajToolStripMenuItem.Size = new System.Drawing.Size(237, 44);
            this.kreirajToolStripMenuItem.Text = "Dodaj";
            this.kreirajToolStripMenuItem.Click += new System.EventHandler(this.WorksheetAddMenuItem_Click);
            // 
            // gradilisToolStripMenuItem
            // 
            this.gradilisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConstructionSitesSearchMenuItem,
            this.ConstructionSitesAddMenuItem});
            this.gradilisToolStripMenuItem.Name = "gradilisToolStripMenuItem";
            this.gradilisToolStripMenuItem.Size = new System.Drawing.Size(133, 38);
            this.gradilisToolStripMenuItem.Text = "Gradilišta";
            // 
            // ConstructionSitesSearchMenuItem
            // 
            this.ConstructionSitesSearchMenuItem.Name = "ConstructionSitesSearchMenuItem";
            this.ConstructionSitesSearchMenuItem.Size = new System.Drawing.Size(237, 44);
            this.ConstructionSitesSearchMenuItem.Text = "Pretraga";
            this.ConstructionSitesSearchMenuItem.Click += new System.EventHandler(this.ConstructionSitesSearchMenuItem_Click);
            // 
            // ConstructionSitesAddMenuItem
            // 
            this.ConstructionSitesAddMenuItem.Name = "ConstructionSitesAddMenuItem";
            this.ConstructionSitesAddMenuItem.Size = new System.Drawing.Size(237, 44);
            this.ConstructionSitesAddMenuItem.Text = "Dodaj";
            this.ConstructionSitesAddMenuItem.Click += new System.EventHandler(this.ConstructionSiteAddMenuItem_Click);
            // 
            // korisniciToolStripMenuItem1
            // 
            this.korisniciToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerSearchMenuItem,
            this.WorkerAddMenuItem});
            this.korisniciToolStripMenuItem1.Name = "korisniciToolStripMenuItem1";
            this.korisniciToolStripMenuItem1.Size = new System.Drawing.Size(112, 38);
            this.korisniciToolStripMenuItem1.Text = "Radnici";
            // 
            // WorkerSearchMenuItem
            // 
            this.WorkerSearchMenuItem.Name = "WorkerSearchMenuItem";
            this.WorkerSearchMenuItem.Size = new System.Drawing.Size(237, 44);
            this.WorkerSearchMenuItem.Text = "Pretraga";
            this.WorkerSearchMenuItem.Click += new System.EventHandler(this.WorkerSearchMenuItem_Click);
            // 
            // WorkerAddMenuItem
            // 
            this.WorkerAddMenuItem.Name = "WorkerAddMenuItem";
            this.WorkerAddMenuItem.Size = new System.Drawing.Size(237, 44);
            this.WorkerAddMenuItem.Text = "Dodaj";
            this.WorkerAddMenuItem.Click += new System.EventHandler(this.WorkerAddMenuItem_Click);
            // 
            // šefoviGradilištaToolStripMenuItem
            // 
            this.šefoviGradilištaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConstructionSiteManagerSearchMenuItem,
            this.menuAddConstructionSiteManager});
            this.šefoviGradilištaToolStripMenuItem.Name = "šefoviGradilištaToolStripMenuItem";
            this.šefoviGradilištaToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.šefoviGradilištaToolStripMenuItem.Text = "Šefovi gradilišta";
            // 
            // ConstructionSiteManagerSearchMenuItem
            // 
            this.ConstructionSiteManagerSearchMenuItem.Name = "ConstructionSiteManagerSearchMenuItem";
            this.ConstructionSiteManagerSearchMenuItem.Size = new System.Drawing.Size(237, 44);
            this.ConstructionSiteManagerSearchMenuItem.Text = "Pretraga";
            this.ConstructionSiteManagerSearchMenuItem.Click += new System.EventHandler(this.ConstructionSiteManagerSearchMenuItem_Click);
            // 
            // menuAddConstructionSiteManager
            // 
            this.menuAddConstructionSiteManager.Name = "menuAddConstructionSiteManager";
            this.menuAddConstructionSiteManager.Size = new System.Drawing.Size(237, 44);
            this.menuAddConstructionSiteManager.Text = "Dodaj";
            this.menuAddConstructionSiteManager.Click += new System.EventHandler(this.ConstructionSiteManagerAddMenuItem_Click);
            // 
            // administratoriToolStripMenuItem
            // 
            this.administratoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerAddMenuItem,
            this.menuAddNewManager});
            this.administratoriToolStripMenuItem.Name = "administratoriToolStripMenuItem";
            this.administratoriToolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.administratoriToolStripMenuItem.Text = "Administratori";
            // 
            // ManagerAddMenuItem
            // 
            this.ManagerAddMenuItem.Name = "ManagerAddMenuItem";
            this.ManagerAddMenuItem.Size = new System.Drawing.Size(237, 44);
            this.ManagerAddMenuItem.Text = "Pretraga";
            this.ManagerAddMenuItem.Click += new System.EventHandler(this.ManagerSearchMenuItem_Click);
            // 
            // menuAddNewManager
            // 
            this.menuAddNewManager.Name = "menuAddNewManager";
            this.menuAddNewManager.Size = new System.Drawing.Size(237, 44);
            this.menuAddNewManager.Text = "Dodaj";
            this.menuAddNewManager.Click += new System.EventHandler(this.MenuAddNewManager_Click);
            // 
            // materijaliToolStripMenuItem
            // 
            this.materijaliToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaterialsSearchMenuItem,
            this.MaterialsAddMenuItem});
            this.materijaliToolStripMenuItem.Name = "materijaliToolStripMenuItem";
            this.materijaliToolStripMenuItem.Size = new System.Drawing.Size(134, 38);
            this.materijaliToolStripMenuItem.Text = "Materijali";
            // 
            // MaterialsSearchMenuItem
            // 
            this.MaterialsSearchMenuItem.Name = "MaterialsSearchMenuItem";
            this.MaterialsSearchMenuItem.Size = new System.Drawing.Size(237, 44);
            this.MaterialsSearchMenuItem.Text = "Pretraga";
            this.MaterialsSearchMenuItem.Click += new System.EventHandler(this.MaterialsSearchMenuItem_Click);
            // 
            // MaterialsAddMenuItem
            // 
            this.MaterialsAddMenuItem.Name = "MaterialsAddMenuItem";
            this.MaterialsAddMenuItem.Size = new System.Drawing.Size(237, 44);
            this.MaterialsAddMenuItem.Text = "Dodaj";
            this.MaterialsAddMenuItem.Click += new System.EventHandler(this.MaterialsAddMenuItem_Click);
            // 
            // opremaToolStripMenuItem
            // 
            this.opremaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpremaSearchMenuItem,
            this.EquipmentAddMenuItem});
            this.opremaToolStripMenuItem.Name = "opremaToolStripMenuItem";
            this.opremaToolStripMenuItem.Size = new System.Drawing.Size(121, 38);
            this.opremaToolStripMenuItem.Text = "Oprema";
            // 
            // OpremaSearchMenuItem
            // 
            this.OpremaSearchMenuItem.Name = "OpremaSearchMenuItem";
            this.OpremaSearchMenuItem.Size = new System.Drawing.Size(359, 44);
            this.OpremaSearchMenuItem.Text = "Pretraga";
            this.OpremaSearchMenuItem.Click += new System.EventHandler(this.OpremaSearchMenuItem_Click);
            // 
            // EquipmentAddMenuItem
            // 
            this.EquipmentAddMenuItem.Name = "EquipmentAddMenuItem";
            this.EquipmentAddMenuItem.Size = new System.Drawing.Size(359, 44);
            this.EquipmentAddMenuItem.Text = "Dodaj";
            this.EquipmentAddMenuItem.Click += new System.EventHandler(this.EquipmentAddMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 829);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(1264, 42);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(79, 32);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 871);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreirajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradilisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConstructionSitesSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConstructionSitesAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem WorkerAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem šefoviGradilištaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConstructionSiteManagerSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddConstructionSiteManager;
        private System.Windows.Forms.ToolStripMenuItem administratoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManagerAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddNewManager;
        private System.Windows.Forms.ToolStripMenuItem materijaliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaterialsSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaterialsAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opremaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpremaSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EquipmentAddMenuItem;
    }
}



