namespace DepartamentDB
{
    partial class Form2
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
            this.comboBoxPostName = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(183, 84);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(401, 20);
            this.textBoxFullName.TabIndex = 0;
            // 
            // textBoxPassport
            // 
            this.textBoxPassport.Location = new System.Drawing.Point(183, 110);
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(401, 20);
            this.textBoxPassport.TabIndex = 1;
            // 
            // textBoxINN
            // 
            this.textBoxINN.Location = new System.Drawing.Point(183, 136);
            this.textBoxINN.Name = "textBoxINN";
            this.textBoxINN.Size = new System.Drawing.Size(401, 20);
            this.textBoxINN.TabIndex = 2;
            // 
            // textBoxCertificateNumber
            // 
            this.textBoxCertificateNumber.Location = new System.Drawing.Point(183, 162);
            this.textBoxCertificateNumber.Name = "textBoxCertificateNumber";
            this.textBoxCertificateNumber.Size = new System.Drawing.Size(401, 20);
            this.textBoxCertificateNumber.TabIndex = 3;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(183, 188);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(401, 20);
            this.textBoxPhone.TabIndex = 4;
            // 
            // textBoxEducation
            // 
            this.textBoxEducation.Location = new System.Drawing.Point(183, 214);
            this.textBoxEducation.Name = "textBoxEducation";
            this.textBoxEducation.Size = new System.Drawing.Size(401, 20);
            this.textBoxEducation.TabIndex = 5;
            // 
            // comboBoxPostName
            // 
            this.comboBoxPostName.FormattingEnabled = true;
            this.comboBoxPostName.Location = new System.Drawing.Point(83, 276);
            this.comboBoxPostName.Name = "comboBoxPostName";
            this.comboBoxPostName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPostName.TabIndex = 6;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(582, 276);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDepartment.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(625, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.comboBoxPostName);
            this.Controls.Add(this.textBoxEducation);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxCertificateNumber);
            this.Controls.Add(this.textBoxINN);
            this.Controls.Add(this.textBoxPassport);
            this.Controls.Add(this.textBoxFullName);
            this.Name = "Form2";
            this.Text = "Form2";
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
        private System.Windows.Forms.ComboBox comboBoxPostName;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}