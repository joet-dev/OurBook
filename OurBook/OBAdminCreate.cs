// <copyright file=OBAdminCreate>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class for Windows Form AdminCreate page</summary>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OurBook
{
    public partial class OBAdminCreate : Form
    {
        private List<User> accList = new List<User>();
        private DateTime creationTime = DateTime.Now;
        private String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";
        private User currentUser;
        private Bill currentBill; 

        /// <summary>
        /// Bill Creation form for OurBook. 
        /// </summary>
        public OBAdminCreate(User user)
        {
            InitializeComponent();

            this.currentUser = user; 

            InitializeFormDisplay();
            DisplayUsersChkListBox();
        }

        private void AmountValue_Enter(object sender, EventArgs e)
        {
           AmountValue.Select(0, AmountValue.Value.ToString().Length);
        }

        /// <summary>
        /// Creates a new bill in the Bill table. 
        /// </summary>
        /// 
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                currentBill = new Bill(creationTime, TitleTextBox.Text, ((decimal) AmountValue.Value / UsersListBox.Items.Count)); 
                using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                {
                    String query = "INSERT INTO [dbo].[Bill] values(@DateCreated, @DateCompleted, @Name, @Cost, @InvoiceId)";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("Name", TitleTextBox.Text);
                        cmd.Parameters.AddWithValue("InvoiceId", InvoiceTextBox.Text);
                        cmd.Parameters.AddWithValue("Cost", AmountValue.Value);
                        cmd.Parameters.AddWithValue("DateCreated", creationTime);
                        cmd.Parameters.AddWithValue("DateCompleted", DBNull.Value);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        BillUsers();

                        MessageBox.Show("The bill has been added to the database.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        currentBill.CheckBillStatus(); 
                    }
                }
            }
            this.Close();
        }

        /// <summary>
        /// Validates inputs for bill creation.
        /// </summary>
        /// <returns> Boolean reflecting input validity. </returns>
        private bool IsInputValid()
        {
            if (TitleTextBox.Text != string.Empty)
            {
                if (UsersListBox.CheckedItems.Count != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Please select users for this bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a title for this bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
        }

        /// <summary>
        /// Gets the users from UserTable and displays them in a checkedListBox. 
        /// </summary>
        private void DisplayUsersChkListBox()
        {
            using (SqlConnection cn = new SqlConnection(dbConnectionStr))
            {
                //Get all users and display them in the UsersListBox. 
                String query = "SELECT Id, Username, Role FROM [dbo].[User]";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr["Id"] != null)
                            {
                                //Append all users to list.
                                UsersListBox.Items.Add(new User((int)dr["Id"], (string)dr["username"], (string)dr["role"]));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows available.");
                    }
                    dr.Close();
                    cn.Close();
                }
            }
        }
 
        /// <summary>
        /// Adds the bill to UsersBills (table is used as intermediary for many-to-many relationship. 
        /// </summary>
        private void BillUsers()
        {
            if (UsersListBox.CheckedItems.Count != 0)
            {
                bool updateBill = false; 
                for (int i = 0; i < UsersListBox.CheckedItems.Count; i++)
                {
                    User temp = (User)UsersListBox.CheckedItems[i];

                    using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                    {
                        String query = "INSERT INTO [dbo].[UserBill] values(@UserId, @DateCreated, @DatePaid)";
                        using (SqlCommand cmd = new SqlCommand(query,cn))
                        {
                            cmd.Parameters.AddWithValue("DateCreated", creationTime);
                            cmd.Parameters.AddWithValue("UserId", temp.id);

                            if (temp.role == "admin" && temp.id == currentUser.id)
                            {
                                cmd.Parameters.AddWithValue("DatePaid", creationTime);

                                if (UsersListBox.CheckedItems.Count == 1)
                                {
                                    updateBill = true;
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("DatePaid", DBNull.Value);
                            }

                            cn.Open(); 
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                }
                // If the only user that has the bill is the current admin, mark the bill as completed. 
                if (updateBill)
                {
                    using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                    {
                        String query = "UPDATE [dbo].[Bill] SET DateCompleted=@DateCreated WHERE DateCreated=@DateCreated"; 
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.AddWithValue("DateCreated", creationTime);

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Form display settings.
        /// </summary>
        private void InitializeFormDisplay()
        {
            this.CenterToScreen();
            UsersListBox.Sorted = true;
            UsersListBox.CheckOnClick = true;

            DateTextBox.Text = creationTime.ToString();
            DateTextBox.ReadOnly = true;
            
            AmountValue.Maximum = 5000;
            AmountValue.Minimum = 0;
            AmountValue.DecimalPlaces = 2;
        }
    }
}
