namespace CPLS_Software
{
    partial class Settings
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
            this.panelExisting = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.lblCredentials = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblItem = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.comboItems = new System.Windows.Forms.ComboBox();
            this.lblChangePrice = new System.Windows.Forms.Label();
            this.panelExisting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExisting
            // 
            this.panelExisting.Controls.Add(this.txtPassword);
            this.panelExisting.Controls.Add(this.txtUsername);
            this.panelExisting.Controls.Add(this.btnSave);
            this.panelExisting.Controls.Add(this.lblPassword);
            this.panelExisting.Controls.Add(this.lblUsername);
            this.panelExisting.Controls.Add(this.comboUser);
            this.panelExisting.Controls.Add(this.lblCredentials);
            this.panelExisting.Location = new System.Drawing.Point(12, 12);
            this.panelExisting.Name = "panelExisting";
            this.panelExisting.Size = new System.Drawing.Size(874, 269);
            this.panelExisting.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(129, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(728, 29);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.Location = new System.Drawing.Point(134, 120);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(723, 29);
            this.txtUsername.TabIndex = 17;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.btnSave.Location = new System.Drawing.Point(357, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 34);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.lblPassword.Location = new System.Drawing.Point(21, 167);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(102, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.lblUsername.Location = new System.Drawing.Point(21, 120);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 25);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboUser
            // 
            this.comboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Location = new System.Drawing.Point(18, 72);
            this.comboUser.Name = "comboUser";
            this.comboUser.Size = new System.Drawing.Size(839, 29);
            this.comboUser.TabIndex = 1;
            this.comboUser.SelectedIndexChanged += new System.EventHandler(this.comboUser_SelectedIndexChanged);
            // 
            // lblCredentials
            // 
            this.lblCredentials.AutoSize = true;
            this.lblCredentials.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredentials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.lblCredentials.Location = new System.Drawing.Point(11, 11);
            this.lblCredentials.Name = "lblCredentials";
            this.lblCredentials.Size = new System.Drawing.Size(280, 47);
            this.lblCredentials.TabIndex = 0;
            this.lblCredentials.Text = "Edit Credentials";
            this.lblCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblItem);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.comboItems);
            this.panel1.Controls.Add(this.lblChangePrice);
            this.panel1.Location = new System.Drawing.Point(12, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 221);
            this.panel1.TabIndex = 3;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.lblItem.Location = new System.Drawing.Point(21, 72);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(57, 25);
            this.lblItem.TabIndex = 19;
            this.lblItem.Text = "Item:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(88, 120);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(102, 29);
            this.txtPrice.TabIndex = 18;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.FlatAppearance.BorderSize = 0;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.btnChange.Location = new System.Drawing.Point(357, 168);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(160, 34);
            this.btnChange.TabIndex = 16;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.lblPrice.Location = new System.Drawing.Point(21, 120);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(61, 25);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboItems
            // 
            this.comboItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.comboItems.FormattingEnabled = true;
            this.comboItems.Location = new System.Drawing.Point(84, 72);
            this.comboItems.Name = "comboItems";
            this.comboItems.Size = new System.Drawing.Size(773, 29);
            this.comboItems.TabIndex = 1;
            this.comboItems.SelectedIndexChanged += new System.EventHandler(this.comboItems_SelectedIndexChanged);
            // 
            // lblChangePrice
            // 
            this.lblChangePrice.AutoSize = true;
            this.lblChangePrice.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.lblChangePrice.Location = new System.Drawing.Point(11, 11);
            this.lblChangePrice.Name = "lblChangePrice";
            this.lblChangePrice.Size = new System.Drawing.Size(236, 47);
            this.lblChangePrice.TabIndex = 0;
            this.lblChangePrice.Text = "Change Price";
            this.lblChangePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(898, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelExisting);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panelExisting.ResumeLayout(false);
            this.panelExisting.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelExisting;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox comboUser;
        private System.Windows.Forms.Label lblCredentials;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox comboItems;
        private System.Windows.Forms.Label lblChangePrice;
        private System.Windows.Forms.Label lblItem;
    }
}