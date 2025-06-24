namespace InventorySystem.Employees
{
    partial class frmAddEmployee
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPerson = new System.Windows.Forms.TabPage();
            this.ctrlAddEditPersonInfo1 = new InventorySystem.Utilities.ctrlAddEditPersonInfo();
            this.tpEmployee = new System.Windows.Forms.TabPage();
            this.ctrlAddEditEmployeeInfo1 = new InventorySystem.Employees.ctrlAddEditEmployeeInfo();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpPerson.SuspendLayout();
            this.tpEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPerson);
            this.tabControl1.Controls.Add(this.tpEmployee);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 121);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1143, 453);
            this.tabControl1.TabIndex = 0;
            // 
            // tpPerson
            // 
            this.tpPerson.Controls.Add(this.ctrlAddEditPersonInfo1);
            this.tpPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPerson.Location = new System.Drawing.Point(4, 34);
            this.tpPerson.Name = "tpPerson";
            this.tpPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tpPerson.Size = new System.Drawing.Size(1135, 415);
            this.tpPerson.TabIndex = 0;
            this.tpPerson.Text = "Person Info";
            this.tpPerson.UseVisualStyleBackColor = true;
            // 
            // ctrlAddEditPersonInfo1
            // 
            this.ctrlAddEditPersonInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAddEditPersonInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlAddEditPersonInfo1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlAddEditPersonInfo1.Name = "ctrlAddEditPersonInfo1";
            this.ctrlAddEditPersonInfo1.Size = new System.Drawing.Size(1129, 409);
            this.ctrlAddEditPersonInfo1.TabIndex = 0;
            // 
            // tpEmployee
            // 
            this.tpEmployee.Controls.Add(this.ctrlAddEditEmployeeInfo1);
            this.tpEmployee.Location = new System.Drawing.Point(4, 34);
            this.tpEmployee.Name = "tpEmployee";
            this.tpEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployee.Size = new System.Drawing.Size(1135, 415);
            this.tpEmployee.TabIndex = 1;
            this.tpEmployee.Text = "Employee Info";
            this.tpEmployee.UseVisualStyleBackColor = true;
            // 
            // ctrlAddEditEmployeeInfo1
            // 
            this.ctrlAddEditEmployeeInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditEmployeeInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAddEditEmployeeInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlAddEditEmployeeInfo1.Name = "ctrlAddEditEmployeeInfo1";
            this.ctrlAddEditEmployeeInfo1.Size = new System.Drawing.Size(1129, 409);
            this.ctrlAddEditEmployeeInfo1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(144, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(860, 62);
            this.lblTitle.TabIndex = 74;
            this.lblTitle.Text = "Add New Employee";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1012, 582);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 49);
            this.btnSave.TabIndex = 998;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(863, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 49);
            this.btnClose.TabIndex = 999;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 656);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddEmployee";
            this.Text = "frmAddEmployee";
            this.Load += new System.EventHandler(this.frmAddEmployee_Load);
            this.Shown += new System.EventHandler(this.frmAddEmployee_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tpPerson.ResumeLayout(false);
            this.tpEmployee.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPerson;
        private System.Windows.Forms.TabPage tpEmployee;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private Utilities.ctrlAddEditPersonInfo ctrlAddPersonInfo1;
        private Utilities.ctrlAddEditPersonInfo ctrlAddEditPersonInfo1;
        private ctrlAddEditEmployeeInfo ctrlAddEditEmployeeInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}