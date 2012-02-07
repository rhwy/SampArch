using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> FindByRole(Role role);
        IEnumerable<User> FindByRoleName(string role);

        User GetByName(string name);
        User GetByLogin(string login);
    }
}
