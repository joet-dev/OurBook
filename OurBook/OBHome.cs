using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OurBook
{
    public partial class OBHome : Form
    {

        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cn;
        System.Collections.Generic.Dictionary<string, object> userAttributes;
        int userId; 

        public OBHome(int UserID)
        {
            userId = UserID; 

            InitializeComponent();

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            cn.Open();

            cmd = new SqlCommand("select * from UserTable where id=@id", cn);
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = userId });
            dr = cmd.ExecuteReader();
            dr.Read();
            userAttributes = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);
            dr.Close();

            cn.Close();
        }

        private void OBHome_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome, " + userAttributes["username"].ToString() + "!";

            DisplayBills();
        }
        private void DisplayBills()
        {
            var items = UnpaidBillsListBox.Items;

            var sqlCmdString = "SELECT B.[Cost], " +
                "B.[Name], " +
                "B.[DateCreated], " +
                "(CAST(B.Cost AS DECIMAL)/B.[NumPayee]) AS SplitCost " +
                "FROM BillingTable B where B.DateCreated in (select UB.DateCreated from UsersBills UB where UserId=@UserId)";

            cmd = new SqlCommand(sqlCmdString, cn);
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar) { Value = userId });

            cn.Open(); 
            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["DateCreated"] != null)
                    {
                        //Possibly append to custom object list then display in list. 
                        items.Add($"${Math.Round((decimal) dr["SplitCost"], 2)} - { dr["Name"]} ({dr["DateCreated"]})");
                    }
                }
            }

            //TODO: Add paid (bool) & datePaid (DateTime2) column to UsersBills. 
            //TODO: Make it so that on update it checks whether everybody has completed payment. 
            //TODO: If everybody has completed payment -> UPDATE DateCompleted in BillingTable.
            //TODO: Admin can see completed bills, verify payment, append information to excel spreadsheet (for ledger purposes), then REMOVE associated rows from UsersBills. 

            cn.Close(); 
        }
    }
}
