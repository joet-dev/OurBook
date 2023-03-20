using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurBook
{
    public readonly struct User
    {
        public User(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public int Id { get; }
        public string Username { get; }

        public override string ToString() => $"{Username}";
    }
}
