namespace DepartamentDB
{
    partial class Form4
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
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxPassport = new System.Windows.Forms.TextBox();
            this.textBoxINN = new System.Windows.Forms.TextBox();
            this.textBoxCertificateNumber = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxEducation = new System.Windows.Forms.TextBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxPosts = new System.Windows.Forms.ComboBox();
            this.textBoxStaffID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(233, 62);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(328, 20);
            this.textBoxFullName.TabIndex = 0;
            // 
            // textBoxPassport
            // 
            this.textBoxPassport.Location = new System.Drawing.Point(233, 88);
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(328, 20);
            this.textBoxPassport.TabIndex = 2;
            // 
            // textBoxINN
            // 
            this.textBoxINN.Location = new System.Drawing.Point(233, 114);
            this.textBoxINN.Name = "textBoxINN";
            this.textBoxINN.Size = new System.Drawing.Size(328, 20);
            this.textBoxINN.TabIndex = 3;
            // 
            // textBoxCertificateNumber
            // 
            this.textBoxCertificateNumber.Location = new System.Drawing.Point(233, 140);
            this.textBoxCertificateNumber.Name = "textBoxCertificateNumber";
            this.textBoxCertificateNumber.Size = new System.Drawing.Size(328, 20);
            this.textBoxCertificateNumber.TabIndex = 4;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(233, 166);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(328, 20);
            this.textBoxPhone.TabIndex = 5;
            // 
            // textBoxEducation
            // 
            this.textBoxEducation.Location = new System.Drawing.Point(233, 192);
            this.textBoxEducation.Name = "textBoxEducation";
            this.textBoxEducation.Size = new System.Drawing.Size(328, 20);
            this.textBoxEducation.TabIndex = 6;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(68, 264);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(186, 21);
            this.comboBoxDepartment.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "Обновить данные сотрудника";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxPosts
            // 
            this.comboBoxPosts.FormattingEnabled = true;
            this.comboBoxPosts.Location = new System.Drawing.Point(553, 264);
            this.comboBoxPosts.Name = "comboBoxPosts";
            this.comboBoxPosts.Size = new System.Drawing.Size(217, 21);
            this.comboBoxPosts.TabIndex = 9;
            // 
            // textBoxStaffID
            // 
            this.textBoxStaffID.Location = new System.Drawing.Point(32, 45);
            this.textBoxStaffID.Name = "textBoxStaffID";
            this.textBoxStaffID.Size = new System.Drawing.Size(128, 20);
            this.textBoxStaffID.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 41);
            this.button2.TabIndex = 11;
            this.button2.Text = "Загрузить данные";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(638, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 44);
            this.button3.TabIndex = 12;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxStaffID);
            this.Controls.Add(this.comboBoxPosts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.textBoxEducation);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxCertificateNumber);
            this.Controls.Add(this.textBoxINN);
            this.Controls.Add(this.textBoxPassport);
            this.Controls.Add(this.textBoxFullName);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxPassport;
        private System.Windows.Forms.TextBox textBoxINN;
        private System.Windows.Forms.TextBox textBoxCertificateNumber;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxEducation;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxPosts;
        private System.Windows.Forms.TextBox textBoxStaffID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}