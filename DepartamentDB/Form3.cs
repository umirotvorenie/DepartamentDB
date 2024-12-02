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
    public partial class Form3 : Form
    {
        public Form3(DatabaseHelper databaseHelper)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string departmentName = textBoxDepartmentName.Text.Trim();
            string departmentDescription = textBoxDepartmentDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(departmentName))
            {
                MessageBox.Show("Введите название отдела.");
                return;
            }

            string query = @"
        INSERT INTO Departments (DepartmentName, DepartmentDescription)
        VALUES (@DepartmentName, @DepartmentDescription);
    ";

            var parameters = new Dictionary<string, object>
    {
        { "@DepartmentName", departmentName },
        { "@DepartmentDescription", departmentDescription }
    };

            int rowsAffected = ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Отдел успешно добавлен.");
                textBoxDepartmentName.Clear();
                textBoxDepartmentDescription.Clear();
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении отдела.");
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
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
                    return -1;
                }
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
