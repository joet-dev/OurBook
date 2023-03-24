using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurBook
{
    public partial class OBAdmin : Form
    {
        User user; 

        /// <summary>
        /// Admin dashboard for OurBook. 
        /// Intializes user object. 
        /// </summary>
        /// <param name="userId"> User id number. Sets the user information for the form. </param>
        public OBAdmin(int userId)
        {
            InitializeComponent();

            user = new User(userId); 

            InitializeFormDisplay();
            PopulateDataGridView();
        }

        /// <summary>
        /// Populates data grid.
        /// </summary>
        private void PopulateDataGridView()
        {
            try 
            {
                billingTableBindingSource.DataSource = GetTableData("SELECT * FROM BillingTable");
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

        /// <summary>
        /// Retrieves table data from database.
        /// </summary>
        /// <param name="sqlCommand"> The sql command to retrieve table data. </param>
        /// <returns> DataTable containing all data read from the sql command input. </returns>
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

        /// <summary>
        /// BUTTON: Creates a new bill. 
        /// </summary>
        private void CreateBillButton_Click(object sender, EventArgs e)
        {
            OBAdminCreate create = new OBAdminCreate();
            create.ShowDialog();

            PopulateDataGridView();
        }

        /// <summary>
        /// BUTTON: Logs out the user. 
        /// </summary>
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var th = new Thread(() => Application.Run(new OBLogin()));
            th.Start(); 

            this.Close();
        }

        /// <summary>
        /// Form display settings. 
        /// </summary>
        private void InitializeFormDisplay()
        {
            this.CenterToScreen();
            UserLabel.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.username); 
        }

        //TODO: Have a create bill page to add bills. 
        //TODO: Create bill page will have a title headline, a uneditable datetime field, an amount, and a list of users to include in the bill. The bill will be split evenly among users included. 

        //TODO: Have a view to show all previous views in tablature format along with who has paid and hasn't. Allow rows to be selected and cleared to completion.
    }
}
