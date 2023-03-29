
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
            this.UnpaidBillsLabel = new System.Windows.Forms.Label();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.PayBillButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.LogoutButton = new System.Windows.Forms.ToolStripButton();
            this.WelcomeLabel = new System.Windows.Forms.ToolStripLabel();
            this.UnpaidBillsListBox = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnpaidBillsLabel
            // 
            this.UnpaidBillsLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.UnpaidBillsLabel.Location = new System.Drawing.Point(0, 38);
            this.UnpaidBillsLabel.Name = "UnpaidBillsLabel";
            this.UnpaidBillsLabel.Size = new System.Drawing.Size(359, 13);
            this.UnpaidBillsLabel.TabIndex = 2;
            this.UnpaidBillsLabel.Text = "placeholder";
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PayBillButton,
            this.RefreshButton,
            this.ToolStripSeparator,
            this.LogoutButton,
            this.WelcomeLabel});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(361, 25);
            this.ToolStrip.TabIndex = 5;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // PayBillButton
            // 
            this.PayBillButton.Image = ((System.Drawing.Image)(resources.GetObject("PayBillButton.Image")));
            this.PayBillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PayBillButton.Name = "PayBillButton";
            this.PayBillButton.Size = new System.Drawing.Size(65, 22);
            this.PayBillButton.Text = "Pay Bill";
            this.PayBillButton.ToolTipText = "Pay Bill";
            this.PayBillButton.Click += new System.EventHandler(this.PayBillButton_Click);
            // 
            // ToolStripSeparator
            // 
            this.ToolStripSeparator.Name = "ToolStripSeparator";
            this.ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // LogoutButton
            // 
            this.LogoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LogoutButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LogoutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogoutButton.Image")));
            this.LogoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(49, 22);
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.WelcomeLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.WelcomeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(98, 22);
            this.WelcomeLabel.Text = "User: Placeholder";
            // 
            // UnpaidBillsListBox
            // 
            this.UnpaidBillsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UnpaidBillsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnpaidBillsListBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.UnpaidBillsListBox.FormattingEnabled = true;
            this.UnpaidBillsListBox.Location = new System.Drawing.Point(3, 65);
            this.UnpaidBillsListBox.Name = "UnpaidBillsListBox";
            this.UnpaidBillsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.UnpaidBillsListBox.Size = new System.Drawing.Size(356, 249);
            this.UnpaidBillsListBox.TabIndex = 6;
            this.UnpaidBillsListBox.SelectedIndexChanged += new System.EventHandler(this.UnpaidBillsListBox_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(66, 22);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.ToolTipText = "Refresh Bills";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // OBHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(361, 316);
            this.Controls.Add(this.UnpaidBillsListBox);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.UnpaidBillsLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OBHome";
            this.Text = "OBHome";
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UnpaidBillsLabel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton PayBillButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator;
        private System.Windows.Forms.ToolStripButton LogoutButton;
        private System.Windows.Forms.ToolStripLabel WelcomeLabel;
        private System.Windows.Forms.ListBox UnpaidBillsListBox;
        private System.Windows.Forms.ToolStripButton RefreshButton;
    }
}