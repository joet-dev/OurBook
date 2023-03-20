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
            //TODO: Load user data from file. 

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True");
            cn.Open();

            cmd = new SqlCommand("select * from UserTable where id=@id", cn);
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = userId });
            dr = cmd.ExecuteReader();
            dr.Read();
            userAttributes = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);
            dr.Close(); 

            //TODO: Create a database that can store jobs/payments. 
        }

        private void OBHome_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome, " + userAttributes["username"].ToString() + "!";

            DisplayBills();
        }
        private void DisplayBills()
        {
            var items = UnpaidBillsListBox.Items;
            List<DateTime> billIdList = new List<DateTime>();

            cmd = new SqlCommand("select * from UsersBills where UserId=@UserId", cn);
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar) { Value = userId });

            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0] != null || dr[1] != null)
                    {
                        billIdList.Add((DateTime)dr[1]);
                    }
                }
            }

            foreach (DateTime i in billIdList)
            {
                Console.WriteLine($"{i}"); 
            }

            //TODO: Add bills to global (class) datatype. Maybe create a custom datatype. Then display bills on 
        }
    }
}
