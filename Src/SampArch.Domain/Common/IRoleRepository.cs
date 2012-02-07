using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        IEnumerable<Role> FindByUser(User user);
    }
}
