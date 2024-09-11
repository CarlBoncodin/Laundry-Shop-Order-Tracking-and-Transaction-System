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
    public partial class Settings : Form
    {
        string[] scopes = { SheetsService.Scope.Spreadsheets };
        string applicationName = "CPLS Software";
        string spreadsheetID = "1O0PortQCkBNsKzosv7OBNYY0RpKfHOhd4fU8NHCwV_s";
        SheetsService service;
        public Settings()
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
            initializeCredentials();
            initializeItems();
        }

        #region initializations
        private void initializeCredentials()
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            var request = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Credentials"}!B2:B5");
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        comboUser.Items.Add(row[0].ToString()); // Put all users in the comboUser
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are no credentials found in the database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling 
            }
        }
        private void initializeItems()
        {
            txtPrice.Enabled = false;
            var request = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Prices"}!B2:B28");
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        comboItems.Items.Add(row[0].ToString()); // Put all items/services in the comboItems
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("There are no items/services found in the database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling 
            }
        }
        #endregion

        #region credentials
        string[] info = new string[3];
        private void getInfo(string username)
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Credentials"}!A2:C5");
            var response = request.Execute();
            var values = response.Values;
            int n = 2;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        if (row[1].ToString() == username)
                        {
                            info[0] = n.ToString();
                            info[1] = row[0].ToString();
                            info[2] = row[2].ToString();
                        }
                        n++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are no credentials found in the database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling
            }
        }
        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUser.Text != "")
            {
                getInfo(comboUser.Text);
                if (info[1] == "Admin") // TO BE CHANGED!!
                {
                    txtUsername.Enabled = false;
                }
                else
                {
                    txtUsername.Enabled = true;
                }
                txtPassword.Enabled = true;
                txtUsername.Text = comboUser.Text;
                txtPassword.Text = info[2];
            }
            else
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar)) // Prevent punctuations
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == ' ') // Prevent spaces
                {
                    e.Handled = true;
                }
                else if ((!Char.IsDigit(e.KeyChar) && txtUsername.Text.Length < 17) || Char.IsControl(e.KeyChar))
                {
                    // Allow letters only up to 16 char and allows control button
                    e.Handled = false;
                }
                else
                {
                    // Prevent any other inputs
                    e.Handled = true;
                }
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') // Prevent spaces
            {
                e.Handled = true;
            }
            else if (txtPassword.Text.Length < 17 || Char.IsControl(e.KeyChar))
            {
                // Allows only up to 16 char and allows control button
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to make these changes?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
                    var list = new List<Object>() { txtUsername.Text, txtPassword.Text };
                    valueRange.Values = new List<IList<Object>> { list };
                    int n = int.Parse(info[0]);
                    var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetID, $"{"Credentials"}!B{n}:C{n}");
                    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                    var updateResponse = updateRequest.Execute();
                    comboUser.Items.Clear();
                    comboUser.Text = "";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    initializeCredentials();
                }
            }
            else
            {
                MessageBox.Show("Fill up all necessary fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region prices 
        string[] item = new string[3];
        private void getItemInfo(string value)
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Prices"}!A2:C28");
            var response = request.Execute();
            var values = response.Values;
            int n = 2;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        if (row[1].ToString() == value)
                        {
                            item[0] = n.ToString();
                            item[1] = row[0].ToString();
                            item[2] = row[2].ToString();
                        }
                        n++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are no items/services found in the database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exception handling
            }
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text != "")
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to make these changes?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
                    var list = new List<Object>() { txtPrice.Text };
                    valueRange.Values = new List<IList<Object>> { list };
                    int n = int.Parse(item[0]);
                    var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetID, $"{"Prices"}!C{n}");
                    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                    var updateResponse = updateRequest.Execute();
                    comboItems.Items.Clear();
                    comboItems.Text = "";
                    txtPrice.Text = "";
                    initializeItems();
                }
            }
            else
            {
                MessageBox.Show("Fill up all necessary fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboItems.Text != "")
            {
                txtPrice.Enabled = true;
                getItemInfo(comboItems.Text);
                txtPrice.Text = item[2];
            }
            else
            {
                txtPrice.Enabled = false;
            }
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtPrice.Text.Length < 4) || Char.IsControl(e.KeyChar) || txtPrice.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

    }
}
