using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class frmNewWorksheet
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
            this.lblWorksheetCreateEditHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtWorksheetDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveEditWorksheet = new System.Windows.Forms.Button();
            this.lblWorksheetRemarks = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userControlWorksheetTasks = new ConstructionCompanyWinDesktop.Worksheets.worksheetTasksUserControl();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.userControlWorksheetMaterials = new ConstructionCompanyWinDesktop.Worksheets.worksheetMaterialsUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.listWorksheetConstructionSite = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtWorksheetRemarks = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWorksheetCreateEditHeader
            // 
            this.lblWorksheetCreateEditHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorksheetCreateEditHeader.Location = new System.Drawing.Point(647, 67);
            this.lblWorksheetCreateEditHeader.Name = "lblWorksheetCreateEditHeader";
            this.lblWorksheetCreateEditHeader.Size = new System.Drawing.Size(348, 43);
            this.lblWorksheetCreateEditHeader.TabIndex = 0;
            this.lblWorksheetCreateEditHeader.Text = "Novi radni list";
            this.lblWorksheetCreateEditHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum";
            // 
            // dtWorksheetDate
            // 
            this.dtWorksheetDate.Location = new System.Drawing.Point(290, 39);
            this.dtWorksheetDate.Name = "dtWorksheetDate";
            this.dtWorksheetDate.Size = new System.Drawing.Size(411, 31);
            this.dtWorksheetDate.TabIndex = 2;
            // 
            // btnSaveEditWorksheet
            // 
            this.btnSaveEditWorksheet.Location = new System.Drawing.Point(3, 900);
            this.btnSaveEditWorksheet.Name = "btnSaveEditWorksheet";
            this.btnSaveEditWorksheet.Size = new System.Drawing.Size(143, 47);
            this.btnSaveEditWorksheet.TabIndex = 8;
            this.btnSaveEditWorksheet.Text = "Spremi";
            this.btnSaveEditWorksheet.UseVisualStyleBackColor = true;
            this.btnSaveEditWorksheet.Click += new System.EventHandler(this.BtnSaveEditWorksheet_Click);
            // 
            // lblWorksheetRemarks
            // 
            this.lblWorksheetRemarks.Location = new System.Drawing.Point(22, 46);
            this.lblWorksheetRemarks.Name = "lblWorksheetRemarks";
            this.lblWorksheetRemarks.Size = new System.Drawing.Size(109, 32);
            this.lblWorksheetRemarks.TabIndex = 10;
            this.lblWorksheetRemarks.Text = "Bilješke";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtWorksheetDate);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 100);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.userControlWorksheetTasks);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 209);
            this.panel2.TabIndex = 14;
            // 
            // userControlWorksheetTasks
            // 
            this.userControlWorksheetTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlWorksheetTasks.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userControlWorksheetTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlWorksheetTasks.Location = new System.Drawing.Point(290, 6);
            this.userControlWorksheetTasks.MinimumSize = new System.Drawing.Size(500, 200);
            this.userControlWorksheetTasks.Name = "userControlWorksheetTasks";
            this.userControlWorksheetTasks.Size = new System.Drawing.Size(500, 200);
            this.userControlWorksheetTasks.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Zadaci";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveEditWorksheet);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(477, 132);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1299, 1168);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.userControlWorksheetMaterials);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 324);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(793, 206);
            this.panel4.TabIndex = 16;
            // 
            // userControlWorksheetMaterials
            // 
            this.userControlWorksheetMaterials.AutoSize = true;
            this.userControlWorksheetMaterials.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlWorksheetMaterials.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userControlWorksheetMaterials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlWorksheetMaterials.Location = new System.Drawing.Point(290, 3);
            this.userControlWorksheetMaterials.MinimumSize = new System.Drawing.Size(500, 200);
            this.userControlWorksheetMaterials.Name = "userControlWorksheetMaterials";
            this.userControlWorksheetMaterials.Size = new System.Drawing.Size(500, 200);
            this.userControlWorksheetMaterials.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Materijali";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.listWorksheetConstructionSite);
            this.panel5.Location = new System.Drawing.Point(3, 536);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(716, 176);
            this.panel5.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gradilište";
            // 
            // listWorksheetConstructionSite
            // 
            this.listWorksheetConstructionSite.FormattingEnabled = true;
            this.listWorksheetConstructionSite.ItemHeight = 25;
            this.listWorksheetConstructionSite.Location = new System.Drawing.Point(290, 46);
            this.listWorksheetConstructionSite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listWorksheetConstructionSite.Name = "listWorksheetConstructionSite";
            this.listWorksheetConstructionSite.Size = new System.Drawing.Size(414, 79);
            this.listWorksheetConstructionSite.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtWorksheetRemarks);
            this.panel3.Controls.Add(this.lblWorksheetRemarks);
            this.panel3.Location = new System.Drawing.Point(3, 718);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 176);
            this.panel3.TabIndex = 15;
            // 
            // txtWorksheetRemarks
            // 
            this.txtWorksheetRemarks.Location = new System.Drawing.Point(290, 47);
            this.txtWorksheetRemarks.Multiline = true;
            this.txtWorksheetRemarks.Name = "txtWorksheetRemarks";
            this.txtWorksheetRemarks.Size = new System.Drawing.Size(411, 126);
            this.txtWorksheetRemarks.TabIndex = 11;
            // 
            // frmNewWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1639, 1139);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.lblWorksheetCreateEditHeader);
            this.Name = "frmNewWorksheet";
            this.ShowInTaskbar = false;
            this.Text = "Novi radni list";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWorksheetCreateEditHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtWorksheetDate;
        private System.Windows.Forms.Label lblWorksheetRemarks;
        private System.Windows.Forms.Button btnSaveEditWorksheet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ConstructionCompanyWinDesktop.Worksheets.worksheetTasksUserControl userControlWorksheetTasks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ConstructionCompanyWinDesktop.Worksheets.worksheetMaterialsUserControl userControlWorksheetMaterials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listWorksheetConstructionSite;
        private System.Windows.Forms.TextBox txtWorksheetRemarks;
    }
}