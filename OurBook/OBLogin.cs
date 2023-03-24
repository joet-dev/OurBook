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
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cn;

        public OBLogin()
        {
            InitializeComponent();
        }

        private void OBLogin_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            cn.Open();

            InitializePasswordControl();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text != string.Empty || usernameTextBox.Text != string.Empty)
            {
                
                // Parameterized so to protect against SQL injection.
                cmd = new SqlCommand("select * from UserTable where username=@userParam", cn);
                cmd.Parameters.Add(new SqlParameter("@userParam", SqlDbType.VarChar) { Value = usernameTextBox.Text });
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    var userAttributes = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);

                    String salt = userAttributes["salt"].ToString();

                    OBPassHash hasher = new OBPassHash();
                    string hashedPassword = hasher.Compute(passwordTextBox.Text, salt);

                    if (hashedPassword == userAttributes["password"].ToString())
                    {
                        if (userAttributes["role"].ToString() == "admin")
                        {
                            dr.Close();
                            this.Hide();
                            OBAdmin admin = new OBAdmin();
                            admin.ShowDialog();
                        }
                        else
                        {
                            dr.Close();
                            this.Hide();
                            //TODO: Pass through the userattribute dictionary.
                            OBHome home = new OBHome((int) userAttributes["Id"]);
                            home.ShowDialog();
                        }
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("Username or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Username or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePasswordControl()
        {
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.MaxLength = 14;
            passwordTextBox.AcceptsReturn = true;
        }

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
    }
}
