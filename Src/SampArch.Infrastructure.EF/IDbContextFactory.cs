using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace SampArch.Infrastructure.EF
{
    public interface IDbContextFactory
    {
        SampArchContext GetContext();
    }
}
