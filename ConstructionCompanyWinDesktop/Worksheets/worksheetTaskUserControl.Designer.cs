using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class worksheetTaskUserControl
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
            this.txtWorksheetTaskName = new System.Windows.Forms.TextBox();
            this.btnWorksheetTaskEdit = new System.Windows.Forms.Button();
            this.btnWorksheetTaskRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWorksheetTaskName
            // 
            this.txtWorksheetTaskName.Location = new System.Drawing.Point(0, 13);
            this.txtWorksheetTaskName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWorksheetTaskName.Name = "txtWorksheetTaskName";
            this.txtWorksheetTaskName.Size = new System.Drawing.Size(163, 31);
            this.txtWorksheetTaskName.TabIndex = 0;
            // 
            // btnWorksheetTaskEdit
            // 
            this.btnWorksheetTaskEdit.Location = new System.Drawing.Point(169, 14);
            this.btnWorksheetTaskEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWorksheetTaskEdit.Name = "btnWorksheetTaskEdit";
            this.btnWorksheetTaskEdit.Size = new System.Drawing.Size(99, 38);
            this.btnWorksheetTaskEdit.TabIndex = 1;
            this.btnWorksheetTaskEdit.Text = "Uredi";
            this.btnWorksheetTaskEdit.UseVisualStyleBackColor = true;
            // 
            // btnWorksheetTaskRemove
            // 
            this.btnWorksheetTaskRemove.Location = new System.Drawing.Point(274, 13);
            this.btnWorksheetTaskRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWorksheetTaskRemove.Name = "btnWorksheetTaskRemove";
            this.btnWorksheetTaskRemove.Size = new System.Drawing.Size(105, 38);
            this.btnWorksheetTaskRemove.TabIndex = 2;
            this.btnWorksheetTaskRemove.Text = "Ukloni";
            this.btnWorksheetTaskRemove.UseVisualStyleBackColor = true;
            // 
            // worksheetTaskUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnWorksheetTaskRemove);
            this.Controls.Add(this.btnWorksheetTaskEdit);
            this.Controls.Add(this.txtWorksheetTaskName);
            this.Name = "worksheetTaskUserControl";
            this.Size = new System.Drawing.Size(441, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWorksheetTaskEdit;
        private System.Windows.Forms.Button btnWorksheetTaskRemove;
        private System.Windows.Forms.TextBox txtWorksheetTaskName;
    }
}