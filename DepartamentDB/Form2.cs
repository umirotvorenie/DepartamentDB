using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DepartamentDB.Form1;

namespace DepartamentDB
{
    public partial class Form2 : Form
    {
        public Form2(DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            // Заполнение списка должностей
            var postStaffs = db.GetTable("SELECT PostID, PostName FROM PostStaffs");
            comboBoxPostName.DataSource = postStaffs;
            comboBoxPostName.DisplayMember = "PostName";
            comboBoxPostName.ValueMember = "PostID";

            // Заполнение списка отделов
            var departments = db.GetTable("SELECT DepartmentID, DepartmentName FROM Departments");
            comboBoxDepartment.DataSource = departments;
            comboBoxDepartment.DisplayMember = "DepartmentName";
            comboBoxDepartment.ValueMember = "DepartmentID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Сбор данных из полей
                string fullName = textBoxFullName.Text;
                string passport = textBoxPassport.Text;
                string inn = textBoxINN.Text;
                string certificateNumber = textBoxCertificateNumber.Text;
                string phone = textBoxPhone.Text;
                string education = textBoxEducation.Text;
                int postId = (int)comboBoxPostName.SelectedValue;
                int departmentId = (int)comboBoxDepartment.SelectedValue;

                // SQL-запрос для добавления
                string query = @"INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
                         VALUES (@FullName, @PostID, @Passport, @INN, @CertificateNumber, @Phone, @Education, @DepartmentID)";

                using (SqlConnection conn = new SqlConnection(db.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Параметры для защиты от SQL-инъекций
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@PostID", postId);
                        cmd.Parameters.AddWithValue("@Passport", passport);
                        cmd.Parameters.AddWithValue("@INN", inn);
                        cmd.Parameters.AddWithValue("@CertificateNumber", certificateNumber);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Education", education);
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Сотрудник успешно добавлен.");

                    }
                }

                // Очистка полей после успешного добавления
                textBoxFullName.Clear();
                textBoxPassport.Clear();
                textBoxINN.Clear();
                textBoxCertificateNumber.Clear();
                textBoxPhone.Clear();
                textBoxEducation.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
