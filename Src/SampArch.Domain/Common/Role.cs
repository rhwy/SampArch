using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    public class Role : Identifiable
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }

        public Role(string name) : this()
        {
            Name = name;
        }
    }
}
