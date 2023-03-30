// <copyright file=OBRegistration>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class for Windows Form Registration page</summary>

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
    public partial class OBRegistration : Form
    {
        private String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";
        private Role role; 

        public enum Role
        {
            admin, 
            user
        }

        /// <summary>
        /// Registration form for OurBook. 
        /// </summary>
        /// <param name="role"> Role type. Sets the type of role the user will be registered to. </param>
        public OBRegistration(Role role=Role.user)
        {
            InitializeComponent();
            
            // enum role is used to ensure there are no errors in args. 
            this.role = role;

            InitializeFormDisplay();
        }

        /// <summary>
        /// BUTTON: Creates a new user in the UserTable. 
        /// - The password is hashed with salt.
        /// </summary>
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                PassHash hasher = new PassHash();
                string hashedPassword = hasher.Compute(passwordTextBox.Text);
                string salt = hasher.Salt;

                using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                {
                    String query = "INSERT INTO [dbo].[User] VALUES(@Username, @Password, @Salt, @Role)";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("Username", usernameTextBox.Text);
                        cmd.Parameters.AddWithValue("Password", hashedPassword);
                        cmd.Parameters.AddWithValue("Salt", salt);
                        cmd.Parameters.AddWithValue("Role", Enum.GetName(this.role.GetType(), this.role));

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        MessageBox.Show("Your account has been created. Please login.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Hide();
                    OBLogin login = new OBLogin();
                    login.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Returns user to the login window.
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            var th = new Thread(() => Application.Run(new OBLogin()));
            th.Start();

            this.Close();
        }

        /// <summary>
        /// Validates user input to ensure values are appropriate for database insert. 
        /// </summary>
        /// <returns> Boolean reflecting input validity </returns>
        private bool IsInputValid()
        {
            if (confirmPasswordTextBox.Text != string.Empty || passwordTextBox.Text != string.Empty || usernameTextBox.Text != string.Empty)
            {
                if (confirmPasswordTextBox.Text == passwordTextBox.Text)
                {
                    using (SqlConnection cn = new SqlConnection(dbConnectionStr))
                    {
                        String query = "SELECT username FROM [dbo].[User] WHERE username=@Username";
                        using (SqlCommand selectCmd = new SqlCommand(query, cn))
                        {
                            selectCmd.Parameters.Add(new SqlParameter("Username", SqlDbType.VarChar) { Value = usernameTextBox.Text });

                            cn.Open();
                            String username = (string) selectCmd.ExecuteScalar();
                            cn.Close(); 

                            if (string.IsNullOrEmpty(username))
                            {
                                return true; 
                            }
                            else
                            {
                                MessageBox.Show("Username already exists please try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return false;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false; 
                }
            }
            else
            {
                MessageBox.Show("Please enter values in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
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
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            confirmPasswordTextBox.MaxLength = 14;
            confirmPasswordTextBox.AcceptsReturn = true;

            RoleLabel.AutoSize = false;
            RoleLabel.Text = "Role: " + Enum.GetName(this.role.GetType(), this.role).ToUpper();
            RoleLabel.TextAlign = ContentAlignment.BottomRight;   
        }
    }
}
