using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public string connString = "Server=HONELUVSWAGGA\\SQLEXPRESS;Database=Demo1;Integrated Security=True;TrustServerCertificate=true";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(connString);
            sqlconn.Open();
            string query = "SELECT product_name, description, price FROM Products";
            SqlCommand sqlCommand = new SqlCommand(query, sqlconn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                    reader["product_name"].ToString(),
                    reader["description"].ToString(),
                    Convert.ToDecimal(reader["price"]));
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
    }
}
