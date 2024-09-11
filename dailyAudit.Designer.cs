namespace CPLS_Software
{
    partial class dailyAudit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.auditListView = new System.Windows.Forms.ListView();
            this.Items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.consumeToday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dailyProfit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalConsumed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalProfit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.incomeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // auditListView
            // 
            this.auditListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.auditListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Items,
            this.consumeToday,
            this.dailyProfit,
            this.totalConsumed,
            this.totalProfit});
            this.auditListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.auditListView.FullRowSelect = true;
            this.auditListView.GridLines = true;
            this.auditListView.HideSelection = false;
            this.auditListView.Location = new System.Drawing.Point(34, 70);
            this.auditListView.Name = "auditListView";
            this.auditListView.Size = new System.Drawing.Size(836, 522);
            this.auditListView.TabIndex = 0;
            this.auditListView.UseCompatibleStateImageBehavior = false;
            this.auditListView.View = System.Windows.Forms.View.Details;
            // 
            // Items
            // 
            this.Items.Text = "Items";
            this.Items.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // consumeToday
            // 
            this.consumeToday.Text = "Amount Consumed Today";
            this.consumeToday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.consumeToday.Width = 260;
            // 
            // dailyProfit
            // 
            this.dailyProfit.Text = "Profit (Today)";
            this.dailyProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dailyProfit.Width = 130;
            // 
            // totalConsumed
            // 
            this.totalConsumed.Text = "Amount Consumed (Total)";
            this.totalConsumed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalConsumed.Width = 260;
            // 
            // totalProfit
            // 
            this.totalProfit.Text = "Profit (Total)";
            this.totalProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalProfit.Width = 122;
            // 
            // incomeLabel
            // 
            this.incomeLabel.AutoSize = true;
            this.incomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.incomeLabel.Location = new System.Drawing.Point(12, 9);
            this.incomeLabel.Name = "incomeLabel";
            this.incomeLabel.Size = new System.Drawing.Size(221, 28);
            this.incomeLabel.TabIndex = 2;
            this.incomeLabel.Text = "Today\'s Total Income: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Overall Total Profit: ";
            // 
            // dailyAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(898, 604);
            this.Controls.Add(this.auditListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incomeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dailyAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView auditListView;
        private System.Windows.Forms.Label incomeLabel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ColumnHeader Items;
        private System.Windows.Forms.ColumnHeader consumeToday;
        private System.Windows.Forms.ColumnHeader dailyProfit;
        private System.Windows.Forms.ColumnHeader totalConsumed;
        private System.Windows.Forms.ColumnHeader totalProfit;
    }
}