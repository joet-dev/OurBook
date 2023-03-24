
namespace OurBook
{
    partial class OBAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OBAdmin));
            this.billingTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ourbookDatabaseDataSet = new OurBook.ourbookDatabaseDataSet();
            this.billingTableTableAdapter = new OurBook.ourbookDatabaseDataSetTableAdapters.BillingTableTableAdapter();
            this.billingTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.BillingGridView = new System.Windows.Forms.DataGridView();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CreateBillButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.LogoutButton = new System.Windows.Forms.ToolStripButton();
            this.UserLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ourbookDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingGridView)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // billingTableBindingSource
            // 
            this.billingTableBindingSource.DataMember = "BillingTable";
            this.billingTableBindingSource.DataSource = this.ourbookDatabaseDataSet;
            // 
            // ourbookDatabaseDataSet
            // 
            this.ourbookDatabaseDataSet.DataSetName = "ourbookDatabaseDataSet";
            this.ourbookDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billingTableTableAdapter
            // 
            this.billingTableTableAdapter.ClearBeforeFill = true;
            // 
            // billingTableBindingSource1
            // 
            this.billingTableBindingSource1.DataMember = "BillingTable";
            this.billingTableBindingSource1.DataSource = this.ourbookDatabaseDataSet;
            // 
            // BillingGridView
            // 
            this.BillingGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BillingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillingGridView.Location = new System.Drawing.Point(1, 28);
            this.BillingGridView.Name = "BillingGridView";
            this.BillingGridView.Size = new System.Drawing.Size(544, 371);
            this.BillingGridView.TabIndex = 2;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateBillButton,
            this.ToolStripSeparator,
            this.LogoutButton,
            this.UserLabel});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(547, 25);
            this.ToolStrip.TabIndex = 3;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // CreateBillButton
            // 
            this.CreateBillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateBillButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateBillButton.Image")));
            this.CreateBillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateBillButton.Name = "CreateBillButton";
            this.CreateBillButton.Size = new System.Drawing.Size(23, 22);
            this.CreateBillButton.Text = "CreateBill";
            this.CreateBillButton.ToolTipText = "Create a new bill";
            this.CreateBillButton.Click += new System.EventHandler(this.CreateBillButton_Click);
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
            // UserLabel
            // 
            this.UserLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.UserLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserLabel.BackColor = System.Drawing.SystemColors.Control;
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(98, 22);
            this.UserLabel.Text = "User: Placeholder";
            // 
            // OBAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(547, 401);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.BillingGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OBAdmin";
            this.Text = "OurBook Admin";
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ourbookDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingGridView)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ourbookDatabaseDataSet ourbookDatabaseDataSet;
        private System.Windows.Forms.BindingSource billingTableBindingSource;
        private ourbookDatabaseDataSetTableAdapters.BillingTableTableAdapter billingTableTableAdapter;
        private System.Windows.Forms.BindingSource billingTableBindingSource1;
        private System.Windows.Forms.DataGridView BillingGridView;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton CreateBillButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator;
        private System.Windows.Forms.ToolStripButton LogoutButton;
        private System.Windows.Forms.ToolStripLabel UserLabel;
    }
}