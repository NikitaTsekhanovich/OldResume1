using System;
using System.Windows.Forms;

namespace Excel.App
{
    public partial class CarsInformationForm : Form
    {
        private readonly ChoosingDocumentForm _choosingDocumentForm;
        public CarsInformationForm(string name, string surname, string yearBirth,
            string passId, string registration)
        {
            _choosingDocumentForm = new ChoosingDocumentForm(name, surname, yearBirth, passId, registration);
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _choosingDocumentForm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fr2 = new AddOrChangeAutoForm();
            fr2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fr2 = new AddOrChangeAutoForm();
            fr2.Show();
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var fr2 = new AuthorizationForm();
            fr2.Show();
            Hide();
        }
    }
}