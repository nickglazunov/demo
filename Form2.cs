using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace KursGlazunov
{
    public partial class Form2 : Form
    {
        public string connStr = "Server=localhost;Database=Stydent;Integrated Security=True;TrustServerCertificate=True";
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string query = "SELECT TOP 500 * FROM Students, Disciplines, CompletedTasks, Sessions, Tasks, Teachers";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                    reader["fullNameStudent"].ToString(),
                    reader["nameDiscipline"].ToString(),
                    reader["fullNameTeacher"].ToString(),
                    reader["status"].ToString(),
                    reader["mark"].ToString(),
                    reader["Opisanie"].ToString()
                    );
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            string query = "SELECT TOP 100 * FROM Students, Disciplines, CompletedTasks, Sessions, Tasks, Teachers";
            flowLayoutPanel1.Controls.Clear();
            if (!string.IsNullOrEmpty(search))
            {
                query += " WHERE nameDiscipline LIKE '%" + search + "%'";
            }
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand sqlc = new SqlCommand(query, conn);
            SqlDataReader reader = sqlc.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                    reader["fullNameStudent"].ToString(),
                    reader["nameDiscipline"].ToString(),
                    reader["fullNameTeacher"].ToString(),
                    reader["status"].ToString(),
                    reader["mark"].ToString(),
                    reader["Opisanie"].ToString()
                    );
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT TOP 100 * FROM Students, Disciplines, CompletedTasks, Sessions, Tasks, Teachers";
            if (comboBox1.SelectedIndex == 0)
            {
                query += " ORDER BY mark ASC";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                query += " ORDER BY mark DESC";
            }
            flowLayoutPanel1 .Controls.Clear();
            SqlConnection conn123 = new SqlConnection(connStr);
            conn123.Open();
            SqlCommand sql1 = new SqlCommand(query, conn123);
            SqlDataReader reader = sql1.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                    reader["fullNameStudent"].ToString(),
                    reader["nameDiscipline"].ToString(),
                    reader["fullNameTeacher"].ToString(),
                    reader["status"].ToString(),
                    reader["mark"].ToString(),
                    reader["Opisanie"].ToString()
                    );
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT TOP 100 * FROM Students, Disciplines, CompletedTasks, Sessions, Tasks, Teachers";
            if (comboBox2.SelectedIndex == 0)
            {
                query += " WHERE nameSession = 'Летняя сессия 2025'";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                query += " WHERE nameSession = 'Зимняя сессия 2025'";
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                query += " WHERE nameSession = 'Зимняя сессия 2024'";
            }
            flowLayoutPanel1.Controls.Clear();
            SqlConnection conn123 = new SqlConnection(connStr);
            conn123.Open();
            SqlCommand sql1 = new SqlCommand(query, conn123);
            SqlDataReader reader = sql1.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                    reader["fullNameStudent"].ToString(),
                    reader["nameDiscipline"].ToString(),
                    reader["fullNameTeacher"].ToString(),
                    reader["status"].ToString(),
                    reader["mark"].ToString(),
                    reader["Opisanie"].ToString()
                    );
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
    }
}
