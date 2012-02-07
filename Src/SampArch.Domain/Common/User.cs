using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    public class User : Identifiable
    {
        public string Name { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }

        public User(string name) : this()
        {
            Name = name;
        }


    }
}
