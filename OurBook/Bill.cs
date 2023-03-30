// <copyright file=Bill>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class representing the Bill entity</summary>
                    
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
    /// Stores bill information as easily accessible objects. 
    /// </summary>
    public readonly struct Bill
    {
        /// <summary>
        /// Constructor for Bill. 
        /// </summary>
        /// <param name="dateCreated"> Creation date of the bill. </param>
        /// <param name="name"> Name of the bill. </param>
        /// <param name="splitCost"> The cost split for each payee. </param>
        public Bill(DateTime dateCreated, string name, decimal splitCost)
        {
            DateCreated = dateCreated;
            Name = name;
            SplitCost = splitCost; 
        }

        public DateTime DateCreated { get; }
        public string Name { get; }
        public decimal SplitCost { get; }

        /// <summary>
        /// Checks whether the bill has been paid by all relevant parties. 
        /// </summary>
        public void CheckBillStatus()
        {
            String dbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\source\repos\OurBook\OurBook\ourbookDatabase.mdf;Integrated Security=True";
            using (SqlConnection cn = new SqlConnection(dbConnectionStr))
            {
                // If there are zero UsersBills under "datecreated" that have datepaid as null, the bill is complete. Therefore update bill datecompleted in Bill table. 
                String query = "IF EXISTS (SELECT * FROM [dbo].[UserBill] WHERE DateCreated=@DateCreated AND DatePaid IS NULL) " +
                "BEGIN PRINT 'fail' END" +
                " ELSE " +
                "BEGIN UPDATE [dbo].[Bill] SET DateCompleted=GETDATE() WHERE DateCreated=@DateCreated END";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("DateCreated", SqlDbType.DateTime2) { Value = this.DateCreated });

                    cn.Open();
                    var rowsUpdated = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
        public override string ToString() => $"${Math.Round(SplitCost, 2)} - {Name} ({DateCreated})";
    }
}
