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
    public partial class JobOrder : Form
    {
        string[] scopes = { SheetsService.Scope.Spreadsheets };
        string applicationName = "CPLS Software";
        string spreadsheetID = "1O0PortQCkBNsKzosv7OBNYY0RpKfHOhd4fU8NHCwV_s";
        string sheet = "Prices";
        SheetsService service;

        public JobOrder()
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
            initializeService();
            initializeWash();
            initializeDry();
            initializeDetergent();
            initializeFabCon();
            initializePlastic();
            this.comboMix.SelectedIndex = 0;
            txtWhite.Enabled = false;
            txtColored.Enabled = false;

        }

        private void initializePlastic()
        {
            var range = $"{"Prices"}!C28";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        lblPrice6.Text = row[0].ToString();
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

        private void initializeCustomers()
        {
            var range = $"{"Customers"}!A2:A1000";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0] != null)
                    {
                        comboCustomer.Items.Add(row[0].ToString()); // write values from databsae TO service comboBox
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("No data was found!"); // exception handling 
            }
        }

        private void initializeService() // read database from database TO service comboBox
        {
            var range = $"{sheet}!B25:B27";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboService.Items.Add(row[0].ToString()); // write values from databsae TO service comboBox
                }
                this.comboService.SelectedIndex = 0;
            }
            else
            {
                Console.WriteLine("No data was found!"); // exception handling 
            }
        }

        private void initializeWash() // read database for wash combobox items
        {

            var range = $"{sheet}!B2:B6";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboWash.Items.Add(row[0].ToString()); // write values from databsae TO wash mode comboBox
                }
                this.comboWash.SelectedIndex = 0;
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }

        }


        private void initializeDry()
        {
            var range = $"{sheet}!B7:B9";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboDry.Items.Add(row[0].ToString()); // write values from database TO dry mode comboBox
                    this.comboDry.SelectedIndex = 0;
                }
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }

        }

        private void initializeDetergent()
        {
            var range = $"{sheet}!B10:B15";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboDetergent.Items.Add(row[0].ToString()); // write values from database TO Detergent comboBox
                }
                this.comboDetergent.SelectedIndex = 0;
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling
            }
        }

        private void initializeFabCon()
        {
            var range = $"{sheet}!B16:B24";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboConditioner.Items.Add(row[0].ToString()); // write values from database TO FabCon combobox
                }
                this.comboConditioner.SelectedIndex = 0;
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }
        }

        private void comboMix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMix.Text == "NO")
            {
                txtWhite.Clear();
                txtColored.Clear();
                lblActualLoads.Text = "0";
                txtTags.Text = "0";
                txtQty1.Text = "0";
                txtQty2.Text = "0";
                txtQty3.Text = "0";
                txtQty4.Text = "0";
                txtQty5.Text = "0";
                txtQty6.Text = "0";
                lblTotalPrice.Text = "0";
                txtTotal.Enabled = false;
                txtWhite.Enabled = true;
                txtColored.Enabled = true;
                txtTotal.BackColor = Color.Gray;
                txtWhite.BackColor = System.Drawing.ColorTranslator.FromHtml("212, 241, 244");
                txtColored.BackColor = System.Drawing.ColorTranslator.FromHtml("212, 241, 244");
                txtTotal.Clear();
            }
            else
            {
                txtWhite.Text = "-";
                txtColored.Text = "-";
                lblActualLoads.Text = "0";
                txtTags.Text = "0";
                txtQty1.Text = "0";
                txtQty2.Text = "0";
                txtQty3.Text = "0";
                txtQty4.Text = "0";
                txtQty5.Text = "0";
                txtQty6.Text = "0";
                lblTotalPrice.Text = "0";
                txtTotal.Enabled = true;
                txtWhite.Enabled = false;
                txtColored.Enabled = false;
                txtTotal.BackColor = System.Drawing.ColorTranslator.FromHtml("212, 241, 244");
                txtWhite.BackColor = Color.Gray;
                txtColored.BackColor = Color.Gray;
                txtAmount.Text = "0";
                lblUnpaid.Text = "0";
            }
        }

        private void txtTotal_textChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length > 0)
            {
                if (txtTotal.Text != "0.")
                {
                    float weight = float.Parse(txtTotal.Text);
                    float result = weight / 8;
                    int tagCount = (int)Math.Ceiling(result);
                    lblActualLoads.Text = tagCount.ToString();
                    txtQty1.Text = tagCount.ToString();
                    txtQty2.Text = tagCount.ToString();
                    txtQty3.Text = tagCount.ToString();
                    txtQty4.Text = tagCount.ToString();
                    txtQty5.Text = tagCount.ToString();
                    txtQty6.Text = tagCount.ToString();
                    comboPayment.SelectedIndex = 0;
                    txtAmount.Text = "0";
                    calculateAll();
                }
            }
            else if (txtTotal.Text.Length == 0)
            {
                txtTags.Text = "0";
                lblActualLoads.Text = "0";
                txtQty1.Text = "0";
                txtQty2.Text = "0";
                txtQty3.Text = "0";
                txtQty4.Text = "0";
                txtQty5.Text = "0";
                txtQty6.Text = "0";
            }
        }

        private void comboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> servicePrices = new List<string>();
            var range = $"{sheet}!C25:C27";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    servicePrices.Add(row[0].ToString());

                }

                switch (comboService.SelectedIndex)
                {

                    case 0:
                        lblPrice1.Text = servicePrices[0];
                        break;
                    case 1:
                        lblPrice1.Text = servicePrices[1];
                        break;

                    case 2:
                        lblPrice1.Text = servicePrices[2];
                        break;
                }
                comboPayment.SelectedIndex = 0;
                txtAmount.Text = "0";
                calculateAll();
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }
        }

        private void comboWash_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> washPrices = new List<string>();
            var range = $"{sheet}!C2:C6";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;


            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    washPrices.Add(row[0].ToString());

                }

                switch (comboWash.SelectedIndex)
                {
                    case 0:
                        lblPrice2.Text = washPrices[0];
                        break;

                    case 1:
                        lblPrice2.Text = washPrices[1];
                        break;

                    case 2:
                        lblPrice2.Text = washPrices[2];
                        break;

                    case 3:
                        lblPrice2.Text = washPrices[3];
                        break;
                    case 4:
                        lblPrice2.Text = washPrices[4];
                        break;

                }
                comboPayment.SelectedIndex = 0;
                txtAmount.Text = "0";
                calculateAll();
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }
        }

        private void comboDry_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> dryPrices = new List<string>();
            var range = $"{sheet}!C7:C9";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;


            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    dryPrices.Add(row[0].ToString());

                }

                switch (comboDry.SelectedIndex)
                {
                    case 0:
                        lblPrice3.Text = dryPrices[0];
                        break;
                    case 1:
                        lblPrice3.Text = dryPrices[1];
                        break;

                    case 2:
                        lblPrice3.Text = dryPrices[2];
                        break;
                }
                comboPayment.SelectedIndex = 0;
                txtAmount.Text = "0";
                calculateAll();
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }
        }

        private void comboDetergent_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> detergentPrices = new List<string>();
            var range = $"{sheet}!C10:C15";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;


            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    detergentPrices.Add(row[0].ToString());

                }

                switch (comboDetergent.SelectedIndex)
                {
                    case 0:
                        lblPrice4.Text = detergentPrices[0];
                        break;
                    case 1:
                        lblPrice4.Text = detergentPrices[1];
                        break;

                    case 2:
                        lblPrice4.Text = detergentPrices[2];
                        break;

                    case 3:
                        lblPrice4.Text = detergentPrices[3];
                        break;

                    case 4:
                        lblPrice4.Text = detergentPrices[4];
                        break;

                    case 5:
                        lblPrice4.Text = detergentPrices[5];
                        break;
                }
                comboPayment.SelectedIndex = 0;
                txtAmount.Text = "0";
                calculateAll();
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }
        }
        private void comboConditioner_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> conditionerPrices = new List<string>();
            var range = $"{sheet}!C16:C24";
            var request = service.Spreadsheets.Values.Get(spreadsheetID, range);

            var response = request.Execute();
            var values = response.Values;


            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    conditionerPrices.Add(row[0].ToString());

                }

                switch (comboConditioner.SelectedIndex)
                {
                    case 0:
                        lblPrice5.Text = conditionerPrices[0];
                        break;
                    case 1:
                        lblPrice5.Text = conditionerPrices[1];
                        break;

                    case 2:
                        lblPrice5.Text = conditionerPrices[2];
                        break;

                    case 3:
                        lblPrice5.Text = conditionerPrices[3];
                        break;

                    case 4:
                        lblPrice5.Text = conditionerPrices[4];
                        break;

                    case 5:
                        lblPrice5.Text = conditionerPrices[5];
                        break;

                    case 6:
                        lblPrice5.Text = conditionerPrices[6];
                        break;

                    case 7:
                        lblPrice5.Text = conditionerPrices[7];
                        break;

                    case 8:
                        lblPrice5.Text = conditionerPrices[8];
                        break;
                }
                comboPayment.SelectedIndex = 0;
                txtAmount.Text = "0";
                calculateAll();
            }
            else
            {
                Console.WriteLine("No Data was Found"); // exception handling 
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            comboPayment.SelectedIndex = 0;
            txtAmount.Text = "0";
            calculateAll();
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar.ToString() == "." && !txtTotal.Text.Contains(e.KeyChar.ToString()) && txtTotal.Text.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtTotal.Text.Length < 4) || Char.IsControl(e.KeyChar) || txtTotal.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtWhiteColored_TextChanged(object sender, EventArgs e)
        {
            if (txtWhite.Text.Length > 0 && txtWhite.Text != "-" && txtColored.Text.Length > 0 && txtColored.Text != "-")
            {
                if (txtWhite.Text != "0." && txtColored.Text != "0.")
                {
                    float weightWhite = float.Parse(txtWhite.Text);
                    float weightColored = float.Parse(txtColored.Text);
                    float totalWeight = weightWhite + weightColored;
                    float result = totalWeight / 8;
                    int tagCount = (int)Math.Ceiling(result);
                    txtTags.Text = tagCount.ToString();
                    lblActualLoads.Text = tagCount.ToString();
                    txtQty1.Text = tagCount.ToString();
                    txtQty2.Text = tagCount.ToString();
                    txtQty3.Text = tagCount.ToString();
                    txtQty4.Text = tagCount.ToString();
                    txtQty5.Text = tagCount.ToString();
                    txtQty6.Text = tagCount.ToString();
                    comboPayment.SelectedIndex = 0;
                    txtAmount.Text = "0";
                    calculateAll();
                }
            }
            else if (txtWhite.Text.Length == 0 || txtColored.Text.Length == 0)
            {
                txtTags.Text = "0";
                lblActualLoads.Text = "0";
                txtQty1.Text = "0";
                txtQty2.Text = "0";
                txtQty3.Text = "0";
                txtQty4.Text = "0";
                txtQty5.Text = "0";
                txtQty6.Text = "0";
            }
        }

        private void txtWhite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar.ToString() == "." && !txtWhite.Text.Contains(e.KeyChar.ToString()) && txtWhite.Text.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtWhite.Text.Length < 4) || Char.IsControl(e.KeyChar) || txtWhite.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtColored_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar.ToString() == "." && !txtColored.Text.Contains(e.KeyChar.ToString()) && txtColored.Text.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtColored.Text.Length < 4) || Char.IsControl(e.KeyChar) || txtColored.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void calculateAll()
        {
            int result1, result2, result3, result4, result5, result6;

            if (txtQty1.Text.Length != 0)
            {
                int p1 = int.Parse(lblPrice1.Text);
                int q1 = int.Parse(txtQty1.Text);
                result1 = p1 * q1;
                lblTotal1.Text = result1.ToString();
            }
            else
            {
                result1 = 0;
                lblTotal1.Text = result1.ToString();
            }
            if (txtQty2.Text.Length != 0)
            {
                int p2 = int.Parse(lblPrice2.Text);
                int q2 = int.Parse(txtQty2.Text);
                result2 = p2 * q2;
                lblTotal2.Text = result2.ToString();
            }
            else
            {
                result2 = 0;
                lblTotal2.Text = result2.ToString();
            }
            if (txtQty3.Text.Length != 0)
            {
                int p3 = int.Parse(lblPrice3.Text);
                int q3 = int.Parse(txtQty3.Text);
                result3 = p3 * q3;
                lblTotal3.Text = result3.ToString();
            }
            else
            {
                result3 = 0;
                lblTotal3.Text = result3.ToString();
            }
            if (txtQty4.Text.Length != 0)
            {
                int p4 = int.Parse(lblPrice4.Text);
                int q4 = int.Parse(txtQty4.Text);
                result4 = p4 * q4;
                lblTotal4.Text = result4.ToString();
            }
            else
            {
                result4 = 0;
                lblTotal4.Text = result4.ToString();
            }
            if (txtQty5.Text.Length != 0)
            {
                int p5 = int.Parse(lblPrice5.Text);
                int q5 = int.Parse(txtQty5.Text);
                result5 = p5 * q5;
                lblTotal5.Text = result5.ToString();
            }
            else
            {
                result5 = 0;
                lblTotal5.Text = result5.ToString();
            }
            if (txtQty6.Text.Length != 0)
            {
                int p6 = int.Parse(lblPrice6.Text);
                int q6 = int.Parse(txtQty6.Text);
                result6 = p6 * q6;
                lblTotal6.Text = result6.ToString();
            }
            else
            {
                result6 = 0;
                lblTotal6.Text = result6.ToString();
            }

            int total = result1 + result2 + result3 + result4 + result5 + result6;
            lblTotalPrice.Text = total.ToString();

            int amount = int.Parse(txtAmount.Text);
            int unpaid = total - amount;
            lblUnpaid.Text = unpaid.ToString();
        }

        private void txtQty1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtQty1.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtQty1.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtQty2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtQty2.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtQty2.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtQty3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtQty3.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtQty3.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtQty4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtQty4.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtQty4.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtQty5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtQty5.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtQty5.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtQty6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtQty6.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtQty6.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtTags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtTags.Text.Length < 4) || Char.IsControl(e.KeyChar) || txtTags.SelectionLength <= 3)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtTags_TextChanged(object sender, EventArgs e)
        {
            if (txtTags.Text.Length != 0)
            {
                int tags = int.Parse(txtTags.Text);
                int maxTags = int.Parse(lblActualLoads.Text);
                if (tags > maxTags)
                {
                    MessageBox.Show("You have exceeded the maximum number of load tags to print!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTags.Text = lblActualLoads.Text;
                }
            }
        }

        private void comboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPayment.Text == "NO DEPOSIT")
            {
                txtAmount.Enabled = false;
                txtAmount.BackColor = Color.Gray;
                txtAmount.Text = "0";
                lblUnpaid.Text = lblTotalPrice.Text;
            }
            else if (comboPayment.Text == "PARTIAL PAYMENT")
            {
                txtAmount.Text = "0";
                txtAmount.Enabled = true;
                txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("212, 241, 244");
                calculateAll();
            }
            else if (comboPayment.Text == "FULLY PAID")
            {
                txtAmount.Enabled = false;
                txtAmount.BackColor = Color.Gray;
                txtAmount.Text = lblTotalPrice.Text;
                lblUnpaid.Text = "0";
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if ((Char.IsDigit(e.KeyChar) && txtAmount.Text.Length < 3) || Char.IsControl(e.KeyChar) || txtAmount.SelectionLength >= 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text.Length != 0)
            {
                int total = int.Parse(lblTotalPrice.Text);
                int amount = int.Parse(txtAmount.Text);
                int unpaid = total - amount;
                lblUnpaid.Text = unpaid.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // TO BE MODIFIED ONCE PRINTING PART IS DONE
        }
    }
}
