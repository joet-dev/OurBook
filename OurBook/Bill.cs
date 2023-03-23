using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurBook
{
    public readonly struct Bill
    {
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
