
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EditBill = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.SearchDatabase = new System.Windows.Forms.Button();
            this.AddBill = new System.Windows.Forms.Button();
            this.DeleteBill = new System.Windows.Forms.Button();
            this.BillingGridView = new System.Windows.Forms.DataGridView();
            this.billingTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ourbookDatabaseDataSet = new OurBook.ourbookDatabaseDataSet();
            this.billingTableTableAdapter = new OurBook.ourbookDatabaseDataSetTableAdapters.BillingTableTableAdapter();
            this.billingTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ourbookDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.47826F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BillingGridView, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 377F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 445);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.70271F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.2973F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel2.Controls.Add(this.EditBill, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddBill, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DeleteBill, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(545, 62);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // EditBill
            // 
            this.EditBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditBill.BackgroundImage")));
            this.EditBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EditBill.Location = new System.Drawing.Point(296, 3);
            this.EditBill.Name = "EditBill";
            this.EditBill.Size = new System.Drawing.Size(56, 56);
            this.EditBill.TabIndex = 3;
            this.EditBill.UseVisualStyleBackColor = true;
            this.EditBill.Click += new System.EventHandler(this.EditBill_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.FilterTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SearchDatabase, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(358, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(176, 56);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(3, 3);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(170, 20);
            this.FilterTextBox.TabIndex = 0;
            // 
            // SearchDatabase
            // 
            this.SearchDatabase.Location = new System.Drawing.Point(3, 31);
            this.SearchDatabase.Name = "SearchDatabase";
            this.SearchDatabase.Size = new System.Drawing.Size(170, 22);
            this.SearchDatabase.TabIndex = 1;
            this.SearchDatabase.Text = "Search";
            this.SearchDatabase.UseVisualStyleBackColor = true;
            this.SearchDatabase.Click += new System.EventHandler(this.SearchDatabase_Click);
            // 
            // AddBill
            // 
            this.AddBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBill.BackgroundImage")));
            this.AddBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddBill.Location = new System.Drawing.Point(3, 3);
            this.AddBill.Name = "AddBill";
            this.AddBill.Size = new System.Drawing.Size(57, 56);
            this.AddBill.TabIndex = 1;
            this.AddBill.UseVisualStyleBackColor = true;
            this.AddBill.Click += new System.EventHandler(this.AddBill_Click);
            // 
            // DeleteBill
            // 
            this.DeleteBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBill.BackgroundImage")));
            this.DeleteBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteBill.Location = new System.Drawing.Point(231, 3);
            this.DeleteBill.Name = "DeleteBill";
            this.DeleteBill.Size = new System.Drawing.Size(57, 56);
            this.DeleteBill.TabIndex = 2;
            this.DeleteBill.UseVisualStyleBackColor = true;
            this.DeleteBill.Click += new System.EventHandler(this.DeleteBill_Click);
            // 
            // BillingGridView
            // 
            this.BillingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillingGridView.Location = new System.Drawing.Point(3, 71);
            this.BillingGridView.Name = "BillingGridView";
            this.BillingGridView.Size = new System.Drawing.Size(544, 371);
            this.BillingGridView.TabIndex = 1;
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
            // OBAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(557, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OBAdmin";
            this.Text = "OurBook Admin";
            this.Load += new System.EventHandler(this.OBAdmin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ourbookDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingTableBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView BillingGridView;
        private ourbookDatabaseDataSet ourbookDatabaseDataSet;
        private System.Windows.Forms.BindingSource billingTableBindingSource;
        private ourbookDatabaseDataSetTableAdapters.BillingTableTableAdapter billingTableTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button EditBill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Button SearchDatabase;
        private System.Windows.Forms.Button AddBill;
        private System.Windows.Forms.Button DeleteBill;
        private System.Windows.Forms.BindingSource billingTableBindingSource1;
    }
}