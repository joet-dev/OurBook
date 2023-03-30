
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
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CreateBillButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.LogoutButton = new System.Windows.Forms.ToolStripButton();
            this.UserLabel = new System.Windows.Forms.ToolStripLabel();
            this.BillGridView = new System.Windows.Forms.DataGridView();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCompletedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ourbookDatabaseDataSet = new ourbookDatabaseDataSet();
            this.billTableAdapter = new ourbookDatabaseDataSetTableAdapters.BillTableAdapter();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ourbookDatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateBillButton,
            this.RefreshButton,
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
            this.CreateBillButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateBillButton.Image")));
            this.CreateBillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateBillButton.Name = "CreateBillButton";
            this.CreateBillButton.Size = new System.Drawing.Size(70, 22);
            this.CreateBillButton.Text = "New Bill";
            this.CreateBillButton.ToolTipText = "Create a new bill";
            this.CreateBillButton.Click += new System.EventHandler(this.CreateBillButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(66, 22);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
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
            // BillGridView
            // 
            this.BillGridView.AllowUserToAddRows = false;
            this.BillGridView.AllowUserToDeleteRows = false;
            this.BillGridView.AutoGenerateColumns = false;
            this.BillGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BillGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateCreatedDataGridViewTextBoxColumn,
            this.dateCompletedDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.invoiceIdDataGridViewTextBoxColumn});
            this.BillGridView.DataSource = this.billBindingSource;
            this.BillGridView.Location = new System.Drawing.Point(0, 28);
            this.BillGridView.Name = "BillGridView";
            this.BillGridView.ReadOnly = true;
            this.BillGridView.Size = new System.Drawing.Size(547, 370);
            this.BillGridView.TabIndex = 4;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCompletedDataGridViewTextBoxColumn
            // 
            this.dateCompletedDataGridViewTextBoxColumn.DataPropertyName = "DateCompleted";
            this.dateCompletedDataGridViewTextBoxColumn.HeaderText = "DateCompleted";
            this.dateCompletedDataGridViewTextBoxColumn.Name = "dateCompletedDataGridViewTextBoxColumn";
            this.dateCompletedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoiceIdDataGridViewTextBoxColumn
            // 
            this.invoiceIdDataGridViewTextBoxColumn.DataPropertyName = "InvoiceId";
            this.invoiceIdDataGridViewTextBoxColumn.HeaderText = "InvoiceId";
            this.invoiceIdDataGridViewTextBoxColumn.Name = "invoiceIdDataGridViewTextBoxColumn";
            this.invoiceIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // billBindingSource
            // 
            this.billBindingSource.DataMember = "Bill";
            this.billBindingSource.DataSource = this.ourbookDatabaseDataSet;
            // 
            // ourbookDatabaseDataSet
            // 
            this.ourbookDatabaseDataSet.DataSetName = "ourbookDatabaseDataSet";
            this.ourbookDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billTableAdapter
            // 
            this.billTableAdapter.ClearBeforeFill = true;
            // 
            // OBAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(547, 401);
            this.Controls.Add(this.BillGridView);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OBAdmin";
            this.Text = "OBAdmin";
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ourbookDatabaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton CreateBillButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator;
        private System.Windows.Forms.ToolStripButton LogoutButton;
        private System.Windows.Forms.ToolStripLabel UserLabel;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.DataGridView BillGridView;
        private ourbookDatabaseDataSet ourbookDatabaseDataSet;
        private System.Windows.Forms.BindingSource billBindingSource;
        private ourbookDatabaseDataSetTableAdapters.BillTableAdapter billTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCompletedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIdDataGridViewTextBoxColumn;
    }
}