using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string connString = "Server=HONELUVSWAGGA\\SQLEXPRESS;Database=Demo1;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы вошли как гость", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form2 newForm = new Form2();
            newForm.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните поля", "Поля не могут быть пустыми", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection sqlconn = new SqlConnection(connString);
            sqlconn.Open();
            string query = "SELECT * FROM [User] WHERE login=@login AND password=@password";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@login", login);
            sqlcomm.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = sqlcomm.ExecuteReader();
            if (reader.Read()) 
            {
                MessageBox.Show("Успешная авторизация", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 newForm = new Form2();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Введен неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
