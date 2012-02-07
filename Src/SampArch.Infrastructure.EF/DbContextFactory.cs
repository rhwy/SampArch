using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SampArch.Utilities;

namespace SampArch.Infrastructure.EF
{
    public class DbContextFactory : IDbContextFactory
    {
        public SampArchContext GetContext()
        {
            var requestStore = HttpRequestSingleton<SampArchContext>.Instance;

            if (!requestStore.IsSet)
            {
                requestStore.Value = new SampArchContext();
            }
            return requestStore.Value;
        }
    }

}
