using System;
using System.Windows.Forms;
namespace KursGlazunov
{
    public partial class UserControl1 : UserControl
    {
        public void Card(string fullNameStudents, string nameDiscipline, string fullNameTeacher, string status, string mark, string description)
        {
            label1.Text = fullNameStudents;
            label3.Text = nameDiscipline;
            label5.Text = fullNameTeacher;
            label7.Text = status;
            label9.Text = mark;
            label11.Text = description;
        }
        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
