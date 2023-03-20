using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurBook
{
    public partial class OBAdmin : Form
    {
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cn;
        public OBAdmin()
        {
            InitializeComponent();
        }

        private void OBAdmin_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            cn.Open();

            PopulateDataGridView(); 

            //// TODO: This line of code loads data into the 'ourbookDatabaseDataSet.BillingTable' table. You can move, or remove it, as needed.
            //this.billingTableTableAdapter.Fill(this.ourbookDatabaseDataSet.BillingTable);
        }
        private void PopulateDataGridView()
        {
            try 
            {
                billingTableBindingSource.DataSource = GetTableData("select * from BillingTable");
                BillingGridView.DataSource = billingTableBindingSource;

                BillingGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            }
            catch (SqlException)
            {
                MessageBox.Show("Invalid database or table.", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private static DataTable GetTableData(string sqlCommand)
        {
            SqlConnection tableConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand(sqlCommand, tableConnection);

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adpt.Fill(table);

            return table; 
        }

        private void AddBill_Click(object sender, EventArgs e)
        {
            OBAdminCreate create = new OBAdminCreate();
            create.ShowDialog();

            PopulateDataGridView();
        }

        private void DeleteBill_Click(object sender, EventArgs e)
        {

        }

        private void EditBill_Click(object sender, EventArgs e)
        {

        }

        private void SearchDatabase_Click(object sender, EventArgs e)
        {

        }

        //TODO: Have a create bill page to add bills. 
        //TODO: Create bill page will have a title headline, a uneditable datetime field, an amount, and a list of users to include in the bill. The bill will be split evenly among users included. 

        //TODO: Have a view to show all previous views in tablature format along with who has paid and hasn't. Allow rows to be selected and cleared to completion.
    }
}
