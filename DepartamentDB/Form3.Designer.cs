﻿namespace DepartamentDB
{
    partial class Form3
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
            this.textBoxDepartmentName = new System.Windows.Forms.TextBox();
            this.textBoxDepartmentDescription = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDepartmentName
            // 
            this.textBoxDepartmentName.Location = new System.Drawing.Point(250, 86);
            this.textBoxDepartmentName.Name = "textBoxDepartmentName";
            this.textBoxDepartmentName.Size = new System.Drawing.Size(287, 20);
            this.textBoxDepartmentName.TabIndex = 0;
            // 
            // textBoxDepartmentDescription
            // 
            this.textBoxDepartmentDescription.Location = new System.Drawing.Point(250, 125);
            this.textBoxDepartmentDescription.Name = "textBoxDepartmentDescription";
            this.textBoxDepartmentDescription.Size = new System.Drawing.Size(287, 20);
            this.textBoxDepartmentDescription.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить новый отдел";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(627, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 10;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDepartmentDescription);
            this.Controls.Add(this.textBoxDepartmentName);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDepartmentName;
        private System.Windows.Forms.TextBox textBoxDepartmentDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}