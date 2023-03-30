// <copyright file=User>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class representing the User entity</summary>
                    
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurBook
{
    /// <summary>
    /// User class used to store and get user information. 
    /// </summary>
    public class User
    {
        /// <summary>
        /// Creates a user object from given parameters. 
        /// </summary>
        /// <param name="id"> The ID of the user. </param>
        /// <param name="username"> The username of the user. </param>
        /// <param name="role"> The role of the user. </param>
        public User(int id, string username, string role)
        {
            this.id = id;
            this.username = username;
            this.role = role;
        }
         
        // Getters and setters. 
        public int id { get; }
        public string username { get; }
        public string role { get; }

        /// <summary>
        /// Retrieves user information from database using the ID as the filter and creates a user object. 
        /// </summary>
        /// <param name="id"> The ID of the user required. </param>
        public User(int id)
        {
            String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";

            using (SqlConnection cn = new SqlConnection(dbConnectionStr))
            {
                String query = "SELECT * FROM [dbo].[User] WHERE Id=@userParam";
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

        public override string ToString() => $"{username}";
    }
}
