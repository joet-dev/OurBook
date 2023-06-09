// <copyright file=OBLogin>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class for Windows Form Login page</summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurBook
{
    public partial class OBLogin : Form
    {
        private String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";

        /// <summary>
        /// Login form for OurBook
        /// </summary>
        public OBLogin()
        {
            InitializeComponent();
            InitializeFormDisplay();
        }

        /// <summary>
        /// Authenticates user. 
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                {
                    String query = "SELECT * FROM [dbo].[User] WHERE Username=@Username";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar) { Value = usernameTextBox.Text });

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            PassHash hasher = new PassHash();
                            string hashedPassword = hasher.Compute(passwordTextBox.Text, dr["salt"].ToString());

                            if (hashedPassword == dr["password"].ToString())
                            {
                                if (dr["role"].ToString() == "admin")
                                {
                                    this.Hide();
                                    OBAdmin admin = new OBAdmin((int)dr["Id"]);
                                    dr.Close();
                                    cn.Close();
                                    admin.ShowDialog();
                                }
                                else
                                {
                                    this.Hide();
                                    OBHome home = new OBHome((int)dr["Id"]);
                                    dr.Close();
                                    cn.Close();
                                    home.ShowDialog();
                                }
                            }
                            else
                            {
                                dr.Close();
                                cn.Close();
                                MessageBox.Show("Username or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            dr.Close();
                            cn.Close();
                            MessageBox.Show("Username or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
        }

        /// <summary>
        /// Checks input credential validity.
        /// </summary>
        /// <returns> Whether the input is valid. </returns>
        private bool IsInputValid()
        {
            if (passwordTextBox.Text != string.Empty || usernameTextBox.Text != string.Empty)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please enter values in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; 
            }
        }

        /// <summary>
        /// CHECKBOX: shows or hides the password. 
        /// </summary>
        private void ShowHidePass_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowHidePass.Checked)
            {
                passwordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Form display settings.  
        /// </summary>
        private void InitializeFormDisplay()
        {
            this.CenterToScreen(); 
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.MaxLength = 14;
            passwordTextBox.AcceptsReturn = true;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var th = new Thread(() => Application.Run(new OBRegistration()));
            th.Start();

            this.Close();
        }
    }
}
