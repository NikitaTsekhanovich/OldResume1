using System;
using System.Windows.Forms;

namespace Excel.App
{
    public partial class ClientActionForm : Form
    {
        public ClientActionForm()
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
            var fr2 = new ClientSearchForm();
            fr2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fr2 = new ClientAddForm();
            fr2.Show();
            Hide();
        }
    }
}