using System;
using System.Windows.Forms;

namespace Excel.App
{
    public partial class AuthorizationForm : Form
    {
        private readonly ClientActionForm _clientActionForm;
        public AuthorizationForm()
        {
            _clientActionForm = new ClientActionForm();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;
            _clientActionForm.Show();
            Hide();
            // if (login == "Иванов" && password == "123")
            // {
            //     _clientActionForm.Show();
            //     Hide();
            // }
        }
    }
}