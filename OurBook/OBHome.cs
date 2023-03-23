﻿using System;
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

        System.Collections.Generic.Dictionary<string, object> userAttr;

        private List<Bill> billList = new List<Bill>();

        public OBHome(int UserID)
        {
            InitializeComponent();

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            cn.Open();

            cmd = new SqlCommand("select * from UserTable where id=@id", cn);
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = UserID });
            dr = cmd.ExecuteReader();
            dr.Read();
            userAttr = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);
            dr.Close();
            cn.Close();
        }

        private void OBHome_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome, " + userAttr["username"].ToString() + "!";

            DisplayBills();
        }
        private void DisplayBills()
        {
            UnpaidBillsListBox.Items.Clear();
            billList.Clear(); 

            var sqlCmdString = "SELECT B.[Cost], " +
                "B.[Name], " +
                "B.[DateCreated], " +
                "(CAST(B.Cost AS DECIMAL)/B.[NumPayee]) AS SplitCost " +
                "FROM BillingTable B WHERE B.DateCreated IN (SELECT UB.DateCreated FROM UsersBills UB WHERE UserId=@UserId AND DatePaid IS NULL)";

            cmd = new SqlCommand(sqlCmdString, cn);
            cmd.Parameters.Add(new SqlParameter("UserId", SqlDbType.VarChar) { Value = userAttr["Id"] });

            cn.Open(); 
            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["DateCreated"] != null)
                    {
                        billList.Add(new Bill((DateTime)dr["DateCreated"], (string)dr["name"], (decimal)dr["SplitCost"]));
                    }
                }
            }
            else
            {
                UnpaidBillsLabel.Text = "You have no unpaid bills. Congratulations!";
                Console.WriteLine("No rows available."); 
            }
            dr.Close(); 
            cn.Close();

            for (int i = 0; i < billList.Count; i++)
            {
                UnpaidBillsListBox.Items.Add(billList[i]);
            }

            UnpaidBillsListBox.CheckOnClick = true; 

            //TODO: Add nullable datePaid (DateTime2) column to UsersBills. 
            //TODO: Make it so that on update it checks whether everybody has completed payment. 
            //TODO: If everybody has completed payment -> UPDATE DateCompleted in BillingTable.
            //TODO: Admin can see completed bills, verify payment, append information to excel spreadsheet (for ledger purposes), then REMOVE associated rows from UsersBills. 
        }

        private void UpdateBillsButton_Click(object sender, EventArgs e)
        {
            if (UnpaidBillsListBox.CheckedItems.Count != 0)
            {
                for (int i = 0; i < UnpaidBillsListBox.CheckedItems.Count; i++)
                {
                    Bill temp = (Bill)UnpaidBillsListBox.CheckedItems[i];

                    cmd = new SqlCommand("UPDATE UsersBills SET DatePaid=GETDATE() WHERE UserId=@UserId AND DateCreated=@DateCreated", cn);
                    cmd.Parameters.Add(new SqlParameter("UserId", SqlDbType.VarChar) { Value = userAttr["Id"] });
                    cmd.Parameters.Add(new SqlParameter("DateCreated", SqlDbType.DateTime2) { Value = temp.DateCreated });

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    CheckBillPaid(temp.DateCreated); 
                }
            }
            else
            {
                MessageBox.Show("There are no bills selected to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DisplayBills(); 
        }

        private void CheckBillPaid(DateTime dateCreated)
        {
            
        }
    }
}
