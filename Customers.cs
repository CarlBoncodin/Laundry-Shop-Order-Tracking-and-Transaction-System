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
    public partial class Customers : Form
    {
        string[] scopes = { SheetsService.Scope.Spreadsheets };
        string applicationName = "CPLS Software";
        string spreadsheetID = "1O0PortQCkBNsKzosv7OBNYY0RpKfHOhd4fU8NHCwV_s";
        SheetsService service;
        public Customers()
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

            // Initializations
            initializeCustomers();
        }
        #region initializations
        private void initializeCustomers() // Adds all registered customers on the database to comboExisting
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Customers"}!A2:A");
            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        comboExisting.Items.Add(row[0]);
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are no customers found in the database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling
            }
        }
        #endregion

        #region existingCustomers
        private void comboExisting_SelectedIndexChanged(object sender, EventArgs e)
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Customers"}!A2:D");
            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        if (comboExisting.Text.Equals(row[0].ToString()))
                        {
                            lblActualName.Text = row[0].ToString();
                            lblActualAddress.Text = row[1].ToString();
                            lblActualNumber.Text = row[2].ToString();
                            lblActualEmail.Text = row[3].ToString();
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are no customers found in the database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to remove this customer?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                // To be continued
            }
        }
        #endregion

        #region addCustomer
        private void button2_Click(object sender, EventArgs e)
        {
            txtNewName.Clear();
            txtNewAddress.Clear();
            txtNewNumber.Clear();
            txtNewEmail.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewName.Text != "" && txtNewAddress.Text != "" && txtNewNumber.Text != "" && txtNewEmail.Text != "")
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to add this customer?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    // Append the new customer in the database
                    // Check mo mga ginawa namin and learn how to append something in the database
                    var range = $"{"Customers"}!A2:D";
                    var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();

                    var oblist = new List<object>() { txtNewName.Text, txtNewAddress.Text, txtNewNumber.Text, txtNewEmail.Text };
                    valueRange.Values = new List<IList<object>> { oblist };

                    var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetID, range);
                    appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var appendReponse = appendRequest.Execute();

                    txtNewName.Text = "";
                    txtNewAddress.Text = "";
                    txtNewNumber.Text = "";
                    txtNewEmail.Text = "";
                    initializeCustomers();
                }
            }
            else
            {
                MessageBox.Show("Fill up all necessary fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling
            }
        }
        #endregion
    }
}
