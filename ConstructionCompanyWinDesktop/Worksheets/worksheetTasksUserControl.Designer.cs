using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class worksheetTasksUserControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelWorksheetTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorksheetTasks
            // 
            this.panelWorksheetTasks.AutoScroll = true;
            this.panelWorksheetTasks.BackColor = System.Drawing.SystemColors.Control;
            this.panelWorksheetTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorksheetTasks.Location = new System.Drawing.Point(3, 2);
            this.panelWorksheetTasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelWorksheetTasks.Name = "panelWorksheetTasks";
            this.panelWorksheetTasks.Size = new System.Drawing.Size(1794, 716);
            this.panelWorksheetTasks.TabIndex = 0;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTask.Location = new System.Drawing.Point(3, 722);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(1794, 176);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Dodaj zadatak";
            this.btnAddTask.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelWorksheetTasks, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddTask, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1800, 900);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // worksheetTasksUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "worksheetTasksUserControl";
            this.Size = new System.Drawing.Size(1800, 900);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel panelWorksheetTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}