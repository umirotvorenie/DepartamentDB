using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class Form1 : Form
    {
        public static DatabaseHelper db;
        public Form1()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadData();
        }

        public class DatabaseHelper
        {
            public string connectionString;

            public string ConnectionString 
            {
                get { return connectionString; }
            }
            public DatabaseHelper()
            {
                connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;
            }

            public DataTable GetTable(string query)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public void LoadData()
        {
            dataGridView1.DataSource = db.GetTable("SELECT * FROM Departments");

            dataGridView2.DataSource = db.GetTable("SELECT * FROM PostStaffs");

            dataGridView3.DataSource = db.GetTable("SELECT * FROM Staff");

            dataGridView4.DataSource = db.GetTable("SELECT * FROM ContractTypes");

            dataGridView5.DataSource = db.GetTable("SELECT * FROM Contracts");

            dataGridView6.DataSource = db.GetTable("SELECT * FROM Vacancies");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(db); 
            this.Hide();
            form2.Show();
            
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            var connectionString = db.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
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
                        return cmd.ExecuteNonQuery(); // Возвращает количество затронутых строк
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
                    return -1; // Возвращает -1 при ошибке
                }
            }
        }

        public bool FireStaff(int staffId)
        {
            string query = @"
        DELETE FROM Contracts WHERE StaffID = @StaffID;
        DELETE FROM Staff WHERE StaffID = @StaffID;
    ";

            var parameters = new Dictionary<string, object>
    {
        { "@StaffID", staffId }
    };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0; // Если удаление успешно, возвращает true
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                // Получаем ID выбранного сотрудника
                int staffId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["StaffID"].Value);

                // Подтверждаем действие
                var confirmResult = MessageBox.Show(
                    $"Вы уверены, что хотите уволить сотрудника с ID {staffId}?",
                    "Подтверждение увольнения",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Увольняем сотрудника
                    bool success = FireStaff(staffId);

                    if (success)
                    {
                        MessageBox.Show("Сотрудник успешно уволен!");
                        LoadData(); // Обновляем данные в текущей форме
                    }
                    else
                    {
                        MessageBox.Show("Не удалось уволить сотрудника.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для увольнения.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(db);
            this.Hide();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(db);
            this.Hide();
            form4.Show();
        }

    }
}

