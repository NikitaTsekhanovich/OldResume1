using System;
using System.Windows.Forms;
using Excel.Infrastructure;

namespace Excel.App
{
    public partial class ChoosingDocumentForm : Form
    {
        private readonly AgencyPortfolio _agencyPortfolio;
        private readonly DocumentSettings _documentSettings;
        
        public ChoosingDocumentForm(string name, string surname, string yearBirth,
            string passId, string registration)
        {
            _agencyPortfolio = new AgencyPortfolio(name, surname, yearBirth, passId, registration);
            _documentSettings = new DocumentSettings();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var fr2 = new AuthorizationForm();
            fr2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _agencyPortfolio.CreateAgencyPortfolio(_documentSettings.ContractTypes[1]);
            var fr2 = new AuthorizationForm();
            fr2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _agencyPortfolio.CreateAgencyPortfolio(_documentSettings.ContractTypes[0]);
            var fr2 = new AuthorizationForm();
            fr2.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _agencyPortfolio.CreateAgencyPortfolio(_documentSettings.ContractTypes[2]);
            var fr2 = new AuthorizationForm();
            fr2.Show();
            Hide();
        }
    }
}