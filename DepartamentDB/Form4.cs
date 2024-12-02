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
    public partial class Form4 : Form
    {
        public Form4(DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int staffId;
            if (!int.TryParse(textBoxStaffID.Text, out staffId))
            {
                MessageBox.Show("Некорректный ID сотрудника.");
                return;
            }

            UpdateStaff(staffId);
        }

        private void LoadComboBoxes()
        {
            // Загрузка данных для comboBoxPost
            DataTable postData = db.GetTable("SELECT PostID, PostName FROM PostStaffs");
            comboBoxPosts.DataSource = postData;
            comboBoxPosts.DisplayMember = "PostName";
            comboBoxPosts.ValueMember = "PostID";

            // Загрузка данных для comboBoxDepartment
            DataTable departmentData = db.GetTable("SELECT DepartmentID, DepartmentName FROM Departments");
            comboBoxDepartment.DataSource = departmentData;
            comboBoxDepartment.DisplayMember = "DepartmentName";
            comboBoxDepartment.ValueMember = "DepartmentID";
        }

        private void UpdateStaff(int staffId)
        {
            string query = @"
        UPDATE Staff
        SET 
            FullName = @FullName,
            PostID = @PostID,
            Passport = @Passport,
            INN = @INN,
            CertificateNumber = @CertificateNumber,
            Phone = @Phone,
            Education = @Education,
            DepartmentID = @DepartmentID
        WHERE StaffID = @StaffID";

            var parameters = new Dictionary<string, object>
    {
        { "@FullName", textBoxFullName.Text.Trim() },
        { "@PostID", comboBoxPosts.SelectedValue },
        { "@Passport", textBoxPassport.Text.Trim() },
        { "@INN", textBoxINN.Text.Trim() },
        { "@CertificateNumber", textBoxCertificateNumber.Text.Trim() },
        { "@Phone", textBoxPhone.Text.Trim() },
        { "@Education", textBoxEducation.Text.Trim() },
        { "@DepartmentID", comboBoxDepartment.SelectedValue },
        { "@StaffID", staffId }
    };

            int rowsAffected = ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Данные сотрудника успешно обновлены.");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных сотрудника.");
            }
        }
        private void LoadStaffData(int staffId)
        {
            string query = "SELECT * FROM Staff WHERE StaffID = @StaffID";
            var parameters = new Dictionary<string, object> { { "@StaffID", staffId } };

            DataTable staffData = GetTable(query, parameters);

            if (staffData.Rows.Count > 0)
            {
                DataRow row = staffData.Rows[0];
                textBoxFullName.Text = row["FullName"].ToString();
                comboBoxPosts.SelectedValue = row["PostID"];
                textBoxPassport.Text = row["Passport"].ToString();
                textBoxINN.Text = row["INN"].ToString();
                textBoxCertificateNumber.Text = row["CertificateNumber"].ToString();
                textBoxPhone.Text = row["Phone"].ToString();
                textBoxEducation.Text = row["Education"].ToString();
                comboBoxDepartment.SelectedValue = row["DepartmentID"];
            }
            else
            {
                MessageBox.Show("Сотрудник не найден.");
            }
        }
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Добавляем параметры, если они есть
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        // Выполняем команду и возвращаем количество затронутых строк
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                    return -1;
                }
            }
        }
        public DataTable GetTable(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Добавляем параметры, если они есть
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        // Выполняем запрос и заполняем DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            return table;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                    return null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStaffData(Int32.Parse(textBoxStaffID.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }

}
