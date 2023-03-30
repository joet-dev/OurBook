
namespace OurBook
{
    partial class OBAdminCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OBAdminCreate));
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.AmountValue = new System.Windows.Forms.NumericUpDown();
            this.UsersListBox = new System.Windows.Forms.CheckedListBox();
            this.InvoiceTextBox = new System.Windows.Forms.TextBox();
            this.InvoiceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmountValue)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(80, 11);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(166, 20);
            this.TitleTextBox.TabIndex = 0;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.AmountLabel.Location = new System.Drawing.Point(13, 67);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(61, 13);
            this.AmountLabel.TabIndex = 2;
            this.AmountLabel.Text = "Amount ($):";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TitleLabel.Location = new System.Drawing.Point(44, 14);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Title:";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(171, 277);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.DateLabel.Location = new System.Drawing.Point(41, 94);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(33, 13);
            this.DateLabel.TabIndex = 5;
            this.DateLabel.Text = "Date:";
            // 
            // DateTextBox
            // 
            this.DateTextBox.Location = new System.Drawing.Point(80, 91);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(166, 20);
            this.DateTextBox.TabIndex = 3;
            // 
            // AmountValue
            // 
            this.AmountValue.Location = new System.Drawing.Point(80, 65);
            this.AmountValue.Name = "AmountValue";
            this.AmountValue.Size = new System.Drawing.Size(166, 20);
            this.AmountValue.TabIndex = 2;
            // 
            // UsersListBox
            // 
            this.UsersListBox.FormattingEnabled = true;
            this.UsersListBox.Location = new System.Drawing.Point(80, 117);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(166, 154);
            this.UsersListBox.TabIndex = 4;
            // 
            // InvoiceTextBox
            // 
            this.InvoiceTextBox.Location = new System.Drawing.Point(80, 39);
            this.InvoiceTextBox.Name = "InvoiceTextBox";
            this.InvoiceTextBox.Size = new System.Drawing.Size(166, 20);
            this.InvoiceTextBox.TabIndex = 1;
            // 
            // InvoiceLabel
            // 
            this.InvoiceLabel.AutoSize = true;
            this.InvoiceLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.InvoiceLabel.Location = new System.Drawing.Point(29, 42);
            this.InvoiceLabel.Name = "InvoiceLabel";
            this.InvoiceLabel.Size = new System.Drawing.Size(45, 13);
            this.InvoiceLabel.TabIndex = 9;
            this.InvoiceLabel.Text = "Invoice:";
            // 
            // OBAdminCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(258, 331);
            this.Controls.Add(this.InvoiceTextBox);
            this.Controls.Add(this.InvoiceLabel);
            this.Controls.Add(this.UsersListBox);
            this.Controls.Add(this.AmountValue);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OBAdminCreate";
            this.Text = "OurBook Admin";
            ((System.ComponentModel.ISupportInitialize)(this.AmountValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.NumericUpDown AmountValue;
        private System.Windows.Forms.CheckedListBox UsersListBox;
        private System.Windows.Forms.TextBox InvoiceTextBox;
        private System.Windows.Forms.Label InvoiceLabel;
    }
}