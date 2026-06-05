using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace KursGlazunov
{
    public partial class Form1 : Form
    {
        public string connStr = "Server=localhost;Database=Stydent;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы вошли как гость!", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form2 newform = new Form2();
            newform.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните оба поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string query = "SELECT * FROM [Students] WHERE Email=@login AND idStudent=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Успешная авторизация", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 newform = new Form2();
                newform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
