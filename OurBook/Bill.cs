// <copyright file=Bill>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Class representing the Bill entity</summary>
                    
using System;
using System.Collections.Generic;
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

        public override string ToString() => $"${Math.Round(SplitCost, 2)} - {Name} ({DateCreated})";
    }
}
