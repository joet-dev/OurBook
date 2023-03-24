
namespace OurBook
{
    partial class OBHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OBHome));
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.UnpaidBillsListBox = new System.Windows.Forms.CheckedListBox();
            this.UnpaidBillsLabel = new System.Windows.Forms.Label();
            this.UpdateBillsButton = new System.Windows.Forms.Button();
            this.Logoutbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.WelcomeLabel.Location = new System.Drawing.Point(12, 9);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(210, 24);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "WelcomePlaceholder";
            // 
            // UnpaidBillsListBox
            // 
            this.UnpaidBillsListBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.UnpaidBillsListBox.FormattingEnabled = true;
            this.UnpaidBillsListBox.Location = new System.Drawing.Point(15, 65);
            this.UnpaidBillsListBox.Name = "UnpaidBillsListBox";
            this.UnpaidBillsListBox.Size = new System.Drawing.Size(332, 154);
            this.UnpaidBillsListBox.TabIndex = 1;
            // 
            // UnpaidBillsLabel
            // 
            this.UnpaidBillsLabel.AutoSize = true;
            this.UnpaidBillsLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.UnpaidBillsLabel.Location = new System.Drawing.Point(12, 42);
            this.UnpaidBillsLabel.Name = "UnpaidBillsLabel";
            this.UnpaidBillsLabel.Size = new System.Drawing.Size(67, 13);
            this.UnpaidBillsLabel.TabIndex = 2;
            this.UnpaidBillsLabel.Text = "Unpaid bills: ";
            // 
            // UpdateBillsButton
            // 
            this.UpdateBillsButton.Location = new System.Drawing.Point(289, 228);
            this.UpdateBillsButton.Name = "UpdateBillsButton";
            this.UpdateBillsButton.Size = new System.Drawing.Size(58, 23);
            this.UpdateBillsButton.TabIndex = 3;
            this.UpdateBillsButton.Text = "Update";
            this.UpdateBillsButton.UseVisualStyleBackColor = true;
            this.UpdateBillsButton.Click += new System.EventHandler(this.UpdateBillsButton_Click);
            // 
            // Logoutbutton
            // 
            this.Logoutbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logoutbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Logoutbutton.Location = new System.Drawing.Point(289, 12);
            this.Logoutbutton.Name = "Logoutbutton";
            this.Logoutbutton.Size = new System.Drawing.Size(58, 23);
            this.Logoutbutton.TabIndex = 4;
            this.Logoutbutton.Text = "Logout";
            this.Logoutbutton.UseVisualStyleBackColor = true;
            this.Logoutbutton.Click += new System.EventHandler(this.Logoutbutton_Click);
            // 
            // OBHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(359, 264);
            this.Controls.Add(this.Logoutbutton);
            this.Controls.Add(this.UpdateBillsButton);
            this.Controls.Add(this.UnpaidBillsLabel);
            this.Controls.Add(this.UnpaidBillsListBox);
            this.Controls.Add(this.WelcomeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OBHome";
            this.Text = "OBHome";
            this.Load += new System.EventHandler(this.OBHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.CheckedListBox UnpaidBillsListBox;
        private System.Windows.Forms.Label UnpaidBillsLabel;
        private System.Windows.Forms.Button UpdateBillsButton;
        private System.Windows.Forms.Button Logoutbutton;
    }
}