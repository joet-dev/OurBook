using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurBook
{
    public class User
    {
        public int id { get; }
        public string username { get; }
        public string role { get; }

        public User(int id)
        {
            String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";

            using (SqlConnection cn = new SqlConnection(dbConnectionStr))
            {
                String query = "SELECT * FROM UserTable WHERE Id=@userParam";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@userParam", SqlDbType.VarChar) { Value = id });

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.id = id; 
                        this.username = dr["username"].ToString();
                        this.role = dr["role"].ToString();
                    }
                }
            }
        }

        public User(int id, string username, string role)
        {
            this.id = id;
            this.username = username;
            this.role = role;
        }

        public override string ToString() => $"{username}";
    }
}
