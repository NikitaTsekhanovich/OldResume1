using System;
using System.Windows.Forms;
using Excel;

namespace Excel.App
{
    public partial class ClientAddForm : Form
    {
        public ClientAddForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var fr2 = new AuthorizationForm();
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // var name = textBox1.Text;
            // var surname = textBox2.Text;
            // var yearBirth = textBox3.Text;
            // var passId = textBox4.Text;
            // var registration = textBox5.Text;
            var name = "Олег";
            var surname = "Олегович";
            var yearBirth = "17.02.2000";
            var passId = "222";
            var registration = "г. Екб ул. ыы";
            var fr2 = new CarsInformationForm(name, surname, yearBirth, passId, registration);
            fr2.Show();
            Hide();
        }
    }
}