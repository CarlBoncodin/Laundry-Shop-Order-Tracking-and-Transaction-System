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
using System.Net.Mail;

namespace CPLS_Software
{
    public partial class OngoingOrders : Form
    {
        // Order info
        string customerName;
        string customerAddress;
        string customerEmail;
        string customerUnpaid;
        string deliveryMode;

        // Database
        string[] scopes = { SheetsService.Scope.Spreadsheets };
        string applicationName = "CPLS Software";
        string spreadsheetID = "1O0PortQCkBNsKzosv7OBNYY0RpKfHOhd4fU8NHCwV_s";
        SheetsService service;
        int id = 1;
        public OngoingOrders()
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

            // Initialization
            initializeOrders();
        }
        #region initializations
        private void initializeOrders()
        {
            id = 1;
            // Storing the entries
            var updateRequest = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Ongoing Orders"}!A2:F");
            var updateResponse = updateRequest.Execute();
            var updateValues = updateResponse.Values;
            if (updateValues != null && updateValues.Count > 0)
            {
                foreach (var row in updateValues)
                {
                    if (row[0] != null)
                    {
                        ListViewItem item = new ListViewItem(" " + id);
                        item.SubItems.Add(row[1].ToString());
                        listView1.Items.Add(item);
                        id++;
                    }
                    else
                    {
                        break;
                    }

                }
            }

        }
        #endregion
        #region external functions
        private void getInfo()
        {
            int databaseIndex = listView1.FocusedItem.Index + 2;
            var retrieveRequest = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Ongoing Orders"}!B{databaseIndex}:F{databaseIndex}");
            var retrieveResponse = retrieveRequest.Execute();
            var retrieveValues = retrieveResponse.Values;

            if (retrieveValues != null && retrieveValues.Count > 0)
            {
                foreach (var row in retrieveValues)
                    if (row[0] != null)
                    {
                        customerName = row[0].ToString();
                        customerAddress = row[1].ToString();
                        customerEmail = row[2].ToString();
                        customerUnpaid = row[3].ToString();
                        deliveryMode = row[4].ToString();
                    }
                    else
                    {
                        break;
                    }
            }
        }
        private void pop()
        {
            // Initialization
            int customRangeInt = listView1.FocusedItem.Index + 2; // store the index of the selected item for use later 

            id = 1; // reset id to 1

            // Storing the entries
            List<List<Object>> orders = new List<List<Object>>();
            var updateRequest = service.Spreadsheets.Values.Get(spreadsheetID, $"{"Ongoing Orders"}!A{customRangeInt + 1}:F");
            var updateResponse = updateRequest.Execute();
            var updateValues = updateResponse.Values;


            id = customRangeInt - 1;
            if (updateValues != null && updateValues.Count > 0)
            {
                foreach (var row in updateValues)
                    if (row[0] != null)
                    {
                        orders.Add(new List<Object> { id.ToString(), row[1], row[2], row[3], row[4], row[5] });
                        id++;
                    }
                    else
                    {
                        break;
                    }
            }

            // Removing the entries
            var deleteValues = new Google.Apis.Sheets.v4.Data.ClearValuesRequest();
            var deleteRequest = service.Spreadsheets.Values.Clear(deleteValues, spreadsheetID, $"{"Ongoing Orders"}!A{customRangeInt}:F100"); // remove specific cell based on selected index
            var deleteResponse = deleteRequest.Execute();

            for (int i = 0; i < orders.Count; i++)
            {
                var appendRange = new Google.Apis.Sheets.v4.Data.ValueRange();
                var list = orders[i];
                appendRange.Values = new List<IList<Object>> { list };
                var appendRequest = service.Spreadsheets.Values.Append(appendRange, spreadsheetID, $"{"Ongoing Orders"}!A2:F100"); // append from orders
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendResponse = appendRequest.Execute();
            }
        }

        #endregion
        #region button clicks
        private void deleteClicked(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("There are currently no ongoing orders!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this order?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool retry = false;
                    do
                    {
                        getInfo();
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient host = new SmtpClient("smtp.gmail.com");
                            host.Port = 587;
                            host.Credentials = new System.Net.NetworkCredential("crystalpalace3744@gmail.com", "ygjhbjylrjxvdjwx");
                            host.EnableSsl = true;
                            mail.From = new MailAddress("crystalpalace3744@gmail.com");
                            mail.To.Add(customerEmail);
                            mail.Subject = "Your order has been cancelled!";
                            mail.Body = "Good day, " + customerName + "!\n\nYour laundry order has now been cancelled. We hope you will choose Crystal Palace Laundry Shop again next time!\n\nIf you think this was a mistake, please contact us: (046) 572-3744.\n\nThank you and God bless!";
                            host.Send(mail);
                            retry = false;
                            pop();
                            listView1.Items.Clear();
                            initializeOrders();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There has been an error while sending the email! Please check your internet connection or the inputted password.\n\nMore details:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult retryConfirm = MessageBox.Show("Do you want to try sending the email again?", "WARNING",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (retryConfirm == DialogResult.Yes)
                            {
                                retry = true;
                            }
                            else
                            {
                                retry = false;
                            }

                        }
                    } while (retry);
                }
            }


        }
        private void finishClicked(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("There are currently no ongoing orders!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this order?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool retry = false;
                    do
                    {
                        getInfo();
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient host = new SmtpClient("smtp.gmail.com");
                            host.Port = 587;
                            host.Credentials = new System.Net.NetworkCredential("crystalpalace3744@gmail.com", "ygjhbjylrjxvdjwx");
                            host.EnableSsl = true;
                            mail.From = new MailAddress("crystalpalace3744@gmail.com");
                            mail.To.Add(customerEmail);
                            mail.Subject = "Your order has been processed!";
                            if (deliveryMode == "PICK UP")
                            {
                                if (int.Parse(customerUnpaid) == 0)
                                {
                                    mail.Body = "Good day, " + customerName + "!\n\nYour laundry order has now been completed, and it will be delivered at this address: " + customerAddress + " in a short while. Thank you for choosing Crystal Palace Laundry Shop!\n\nThank you and God bless!";
                                }
                                else
                                {
                                    mail.Body = "Good day, " + customerName + "!\n\nYour laundry order has now been completed! It will be delivered at this address: " + customerAddress + " in a short while and please prepare P" + customerUnpaid + " for the payment. Thank you for choosing Crystal Palace Laundry Shop!\n\nThank you and God bless!";
                                }
                                
                            }
                            else if (deliveryMode == "DROP OFF")
                            {
                                if (int.Parse(customerUnpaid) == 0)
                                {
                                    mail.Body = "Good day, " + customerName + "!\n\nYour laundry order has now been completed, and is ready for pick-up. Thank you for choosing Crystal Palace Laundry Shop!\n\nThank you and God bless!";
                                }
                                else
                                {
                                    mail.Body = "Good day, " + customerName + "!\n\nYour laundry order has now been completed, and is ready for pick-up. Please pay P" + customerUnpaid + " at the cashier for the payment. Thank you for choosing Crystal Palace Laundry Shop!\n\nThank you and God bless!";
                                }
                            }
                            host.Send(mail);
                            retry = false;
                            pop();
                            listView1.Items.Clear();
                            initializeOrders();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There has been an error while sending the email! Please check your internet connection or the inputted password.\n\nMore details:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult retryConfirm = MessageBox.Show("Do you want to try sending the email again?", "WARNING",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (retryConfirm == DialogResult.Yes)
                            {
                                retry = true;
                            }
                            else
                            {
                                retry = false;
                            }

                        }
                    } while (retry);
                }
            }
        }

        #endregion
    }
}
