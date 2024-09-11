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
    public partial class MainMenu : Form
    {
        string userLevel;
        string attendantName;
        public MainMenu(string userName, string userLvl)
        {
            InitializeComponent();
            userLevel = userLvl;
            if (userLevel == "User")
            {
                btnSettings.Hide();
            }
            attendantName = userName;
            lblAttendant.Text = attendantName;
            panel4.Height = btnJobOrder.Height;
            panel4.Top = btnJobOrder.Top;
            panel4.Left = btnJobOrder.Left;
            btnJobOrder.BackColor = Color.FromArgb(212, 241, 244);
            btnCustomers.BackColor = Color.FromArgb(24, 154, 180);
            btnOngoing.BackColor = Color.FromArgb(24, 154, 180);
            btnSettings.BackColor = Color.FromArgb(24, 154, 180);
            this.panel3.Controls.Clear();
            JobOrder jo = new JobOrder();
            jo.Dock = DockStyle.Top;
            jo.TopLevel = false;
            jo.TopMost = true;
            jo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel3.Controls.Add(jo);
            jo.Show();
        }

        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            // Select animation
            panel4.Height = btnJobOrder.Height;
            panel4.Top = btnJobOrder.Top;
            panel4.Left = btnJobOrder.Left;
            btnJobOrder.BackColor = Color.FromArgb(212, 241, 244);
            btnCustomers.BackColor = Color.FromArgb(24, 154, 180);
            btnOngoing.BackColor = Color.FromArgb(24, 154, 180);
            btnSettings.BackColor = Color.FromArgb(24, 154, 180);

            // Displays Job Order window
            this.panel3.Controls.Clear();
            JobOrder jo = new JobOrder();
            jo.Dock = DockStyle.Top;
            jo.TopLevel = false;
            jo.TopMost = true;
            jo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel3.Controls.Add(jo);
            jo.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            // Select animation
            panel4.Height = btnCustomers.Height;
            panel4.Top = btnCustomers.Top;
            panel4.Left = btnCustomers.Left;
            btnJobOrder.BackColor = Color.FromArgb(24, 154, 180);
            btnCustomers.BackColor = Color.FromArgb(212, 241, 244);
            btnOngoing.BackColor = Color.FromArgb(24, 154, 180);
            btnSettings.BackColor = Color.FromArgb(24, 154, 180);

            // Displays Job Order window
            this.panel3.Controls.Clear();
            Customers c = new Customers();
            c.Dock = DockStyle.Top;
            c.TopLevel = false;
            c.TopMost = true;
            c.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel3.Controls.Add(c);
            c.Show();
        }

        private void btnOngoing_Click(object sender, EventArgs e)
        {
            // Select animation
            panel4.Height = btnOngoing.Height;
            panel4.Top = btnOngoing.Top;
            panel4.Left = btnOngoing.Left;
            btnJobOrder.BackColor = Color.FromArgb(24, 154, 180);
            btnCustomers.BackColor = Color.FromArgb(24, 154, 180);
            btnOngoing.BackColor = Color.FromArgb(212, 241, 244);
            btnSettings.BackColor = Color.FromArgb(24, 154, 180);

            // Displays Ongoing Orders window
            this.panel3.Controls.Clear();
            OngoingOrders oo = new OngoingOrders();
            oo.Dock = DockStyle.Top;
            oo.TopLevel = false;
            oo.TopMost = true;
            oo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel3.Controls.Add(oo);
            oo.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Select animation
            panel4.Height = btnSettings.Height;
            panel4.Top = btnSettings.Top;
            panel4.Left = btnSettings.Left;
            btnJobOrder.BackColor = Color.FromArgb(24, 154, 180);
            btnCustomers.BackColor = Color.FromArgb(24, 154, 180);
            btnOngoing.BackColor = Color.FromArgb(24, 154, 180);
            btnSettings.BackColor = Color.FromArgb(212, 241, 244);

            // Displays Settings window
            this.panel3.Controls.Clear();
            Settings s = new Settings();
            s.Dock = DockStyle.Top;
            s.TopLevel = false;
            s.TopMost = true;
            s.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel3.Controls.Add(s);
            s.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Are you sure you want to exit the program and end your shift?", "WARNING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exit == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAuditClick(object sender, EventArgs e)
        {
            // Select Animation
            panel4.Height = btnViewAudit.Height;
            panel4.Top = btnViewAudit.Top;
            panel4.Left = btnViewAudit.Left;
            btnJobOrder.BackColor = Color.FromArgb(24, 154, 180);
            btnCustomers.BackColor = Color.FromArgb(24, 154, 180);
            btnOngoing.BackColor = Color.FromArgb(212, 241, 244);
            btnSettings.BackColor = Color.FromArgb(24, 154, 180);

            // displays View Audit Window 
            this.panel3.Controls.Clear();
            dailyAudit a = new dailyAudit();
            a.Dock = DockStyle.Top;
            a.TopLevel = false;
            a.TopMost = true;
            a.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel3.Controls.Add(a);
            a.Show();
        }
    }
}
