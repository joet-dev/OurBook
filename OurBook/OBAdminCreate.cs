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
    public partial class OBAdminCreate : Form
    {
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cn;

        DateTime creationTime = DateTime.Now;
        private List<User> accList = new List<User>();

        public OBAdminCreate()
        {
            InitializeComponent();
        }

        private void OBAdminCreate_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            

            InitializeFormControl();
        }
        
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.Text != string.Empty)
            {
                if (UsersListBox.CheckedItems.Count != 0)
                {
                    cmd = new SqlCommand("insert into BillingTable values(@DateCreated, @DateCompleted, @Name, @Cost, @NumPayee, @InvoiceId)", cn);

                    cmd.Parameters.AddWithValue("Name", TitleTextBox.Text);
                    cmd.Parameters.AddWithValue("InvoiceId", InvoiceTextBox.Text);
                    cmd.Parameters.AddWithValue("Cost", AmountValue.Value);
                    cmd.Parameters.AddWithValue("NumPayee", UsersListBox.CheckedItems.Count);
                    cmd.Parameters.AddWithValue("DateCreated", creationTime);
                    cmd.Parameters.AddWithValue("DateCompleted", DBNull.Value);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                    BillUsers();

                    cn.Close();

                    MessageBox.Show("The bill has been added to the database.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select users for this bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a title for this bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeFormControl()
        {

            UsersListBox.Sorted = true;

            //Get all users and display them in the UsersListBox. 
            cmd = new SqlCommand("select Id, username, role from UserTable", cn);

            cn.Open(); 
            dr = cmd.ExecuteReader();

            //Append all users to list.
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["Id"] != null)
                    {
                        accList.Add(new User((int)dr["Id"], (string)dr["username"], (string)dr["role"]));
                    }
                }
            }
            else
            {
                Console.WriteLine("No rows available from UserTable.");
            }
            dr.Close();
            cn.Close(); 

            //Add users from list to checkedListBox. 
            for (int i = 0; i < accList.Count; i++)
            {
                UsersListBox.Items.Add(accList[i]);
            }

            UsersListBox.CheckOnClick = true;

            DateTextBox.Text = creationTime.ToString();
            DateTextBox.ReadOnly = true;

            AmountValue.Maximum = 5000;
            AmountValue.Minimum = 0;
            AmountValue.DecimalPlaces = 2; 
        }
 
        private void BillUsers()
        {
            if (UsersListBox.CheckedItems.Count != 0)
            {
                for (int i = 0; i < UsersListBox.CheckedItems.Count; i++)
                {
                    User temp = (User)UsersListBox.CheckedItems[i];
                    
                    cmd = new SqlCommand("insert into UsersBills values(@UserId, @BillId, @DatePaid)", cn);
                    cmd.Parameters.AddWithValue("BillId", creationTime);
                    cmd.Parameters.AddWithValue("UserId", temp.id);
                    cmd.Parameters.AddWithValue("DatePaid", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
