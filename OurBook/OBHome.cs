// <copyright file=OBHome>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class for Windows Form Home page</summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace OurBook
{
    public partial class OBHome : Form
    {
        private String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";

        private User currentUser; 
        private List<Bill> billList = new List<Bill>();

        /// <summary>
        /// Home form for OurBook. 
        /// </summary>
        /// <param name="UserID"> User ID that is passed in from the OBLogin form. </param>
        public OBHome(int UserID)
        {
            InitializeComponent();

            currentUser = new User(UserID);

            InitializeFormDisplay();
            DisplayBillsListBox();
        }

        /// <summary>
        /// BUTTON: Updates a users bills with a datepaid value. 
        /// </summary>
        private void PayBillButton_Click(object sender, EventArgs e)
        {
            if (UnpaidBillsListBox.SelectedItems.Count != 0)
            {
                for (int i = 0; i < UnpaidBillsListBox.SelectedItems.Count; i++)
                {
                    Bill temp = (Bill)UnpaidBillsListBox.SelectedItems[i];

                    using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                    {
                        String query = "UPDATE UsersBills SET DatePaid=GETDATE() WHERE UserId=@UserId AND DateCreated=@DateCreated";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.Add(new SqlParameter("UserId", SqlDbType.VarChar) { Value = currentUser.id });
                            cmd.Parameters.Add(new SqlParameter("DateCreated", SqlDbType.DateTime2) { Value = temp.DateCreated });

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();

                            CheckBillComplete(temp.DateCreated);
                        }
                    }
                    MessageBox.Show("Your bills have been updated!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There are no bills selected to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DisplayBillsListBox(); 
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
        /// BUTTON: Refreshes the bills listbox.
        /// </summary>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DisplayBillsListBox(); 
        }

        /// <summary>
        /// TRIGGER: Enabled or disables the paybill button When a user selects or deselects a bill. 
        /// </summary>
        private void UnpaidBillsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnpaidBillsListBox.SelectedItems.Count > 0)
            {
                PayBillButton.Enabled = true;
            }
            else
            {
                PayBillButton.Enabled = false;
            }
        }

        /// <summary>
        /// Checks whether the bill in the parameters is completed and if so updates the bill's datecompleted value in the BillingTable.
        /// </summary>
        /// <param name="dateCreated"> The dateCreated value of the bill to check. </param>
        private void CheckBillComplete(DateTime dateCreated)
        {
            using (SqlConnection cn = new SqlConnection(dbConnectionStr))
            {
                // If there are zero UsersBills under "datecreated" that have datepaid as null, the bill is complete. Therefore update BillingTable bill datecompleted. 
                String query = "IF EXISTS (SELECT * FROM UsersBills WHERE DateCreated=@DateCreated AND DatePaid IS NULL) " +
                "BEGIN PRINT 'fail.' END" +
                " ELSE " +
                "BEGIN UPDATE BillingTable SET DateCompleted=GETDATE() WHERE DateCreated=@DateCreated END";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("DateCreated", SqlDbType.DateTime2) { Value = dateCreated });

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        /// <summary>
        /// Gets the current users assigned bills from the UsersBills table and displays them in a list box. 
        /// </summary>
        private void DisplayBillsListBox()
        {
            UnpaidBillsListBox.Items.Clear();
            billList.Clear();

            using (SqlConnection cn = new SqlConnection(dbConnectionStr))
            {
                // Selects the columns cost, name, datecreated, and splitcost (derived value) of bills from the billing table that arent completed by the user. 
                var query = "SELECT B.[Cost], " +
                "B.[Name], " +
                "B.[DateCreated], " +
                "(CAST(B.Cost AS DECIMAL)/(B.DateCreated) AS SplitCost " +
                "FROM BillingTable B WHERE B.DateCreated IN (SELECT UB.DateCreated FROM UsersBills UB WHERE UserId=@UserId AND DatePaid IS NULL)";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("UserId", SqlDbType.VarChar) { Value = currentUser.id });

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
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
                }
            }

            // This could be split off as a seprate function so that there is a function GetBills() and a function DisplayBills(). 
            for (int i = 0; i < billList.Count; i++)
            {
                UnpaidBillsListBox.Items.Add(billList[i]);
            }
        }

        /// <summary>
        /// Form display settings.
        /// </summary>
        private void InitializeFormDisplay()
        {
            this.CenterToScreen();
            WelcomeLabel.Text = "Welcome, " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(currentUser.ToString()) + "!";
            
            UnpaidBillsLabel.AutoSize = false;
            UnpaidBillsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            UnpaidBillsLabel.Text = "Unpaid Bills:"; 

            PayBillButton.Enabled = false; 
        }
    }
}
