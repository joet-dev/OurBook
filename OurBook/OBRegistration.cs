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
    public partial class OBRegistration : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public OBRegistration()
        {
            InitializeComponent();
        }

        private void OBRegistration_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            cn.Open();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (confirmPasswordTextBox.Text != string.Empty || passwordTextBox.Text != string.Empty || usernameTextBox.Text != string.Empty)
            {
                if (confirmPasswordTextBox.Text == passwordTextBox.Text)
                {
                    cmd = new SqlCommand("select * from UserTable where username=@userParam", cn);
                    cmd.Parameters.Add(new SqlParameter("@userParam", SqlDbType.VarChar) { Value = usernameTextBox.Text });
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username already exists please try another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();

                        OBPassHash hasher = new OBPassHash();
                        string hashedPassword = hasher.Compute(passwordTextBox.Text);
                        string salt = hasher.Salt;

                        cmd = new SqlCommand("insert into UserTable values(@username, @password, @salt)", cn);
                        cmd.Parameters.AddWithValue("username", usernameTextBox.Text);
                        cmd.Parameters.AddWithValue("password", hashedPassword);
                        cmd.Parameters.AddWithValue("salt", salt);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        OBLogin login = new OBLogin();
                        login.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter values in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
