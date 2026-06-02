using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void Card(string product_name, string description, decimal price)
        {
            label1.Text = product_name;
            label2.Text = description;
            label3.Text = $"{price.ToString()} руб.";
        }
    }
}
