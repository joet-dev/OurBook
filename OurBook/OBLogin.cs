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
                    String query = "SELECT * FROM UserTable WHERE username=@userParam";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@userParam", SqlDbType.VarChar) { Value = usernameTextBox.Text });

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            OBPassHash hasher = new OBPassHash();
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
        /// Onclick method for showing and hiding the password. 
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
    }
}
