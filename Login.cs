using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;

namespace CPLS_Software
{
    public partial class Login : Form
    {
        string[] scopes = { SheetsService.Scope.Spreadsheets };
        string applicationName = "CPLS Software";
        string spreadsheetID = "1O0PortQCkBNsKzosv7OBNYY0RpKfHOhd4fU8NHCwV_s";
        SheetsService service;

        public Login()
        {
            InitializeComponent();

            // Database
            GoogleCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
            }
            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName,
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Access registered credentials in the database
            var range = $"{"Credentials"}!A2:C5";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);
            var response = request.Execute();
            var credentials = response.Values;

            // Store credentials in arrays
            List<string> userLevels = new List<string>();
            List<string> userNames = new List<string>();
            List<string> passWords = new List<string>();
            foreach (var credential in credentials)
            {
                userLevels.Add(credential[0].ToString());
                userNames.Add(credential[1].ToString());
                passWords.Add(credential[2].ToString());
            }

            // Checks if the inputted username and password matches any of the registered credentials
            bool success = false;
            for (int i = 0; i < userNames.Count; i++)
            {
                if (textBox1.Text.Equals(userNames[i]) && textBox2.Text.Equals(passWords[i]))
                {
                    MainMenu mm = new MainMenu(textBox1.Text, userLevels[i]);
                    this.Hide();
                    mm.Show();
                    success = true;
                    break;
                }
            }
            if (!success)
            {
                MessageBox.Show("Please enter the correct username and password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "USERNAME";
                textBox2.Text = "Password";
            }
            
        }

        private void userPass_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "USERNAME")
            {
                textBox1.SelectAll();
            }
            if (textBox2.Text == "Password")
            {
                textBox2.SelectAll();
            }
        }
    }
}
