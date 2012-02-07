using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Utilities;

namespace SampArchi.Infrastructure.Azure
{
    public class TableContextFactory : ITableContextFactory
    {
        private const string SESSION_TABLE_CONTEXT_KEY = "TableContextSessionKey";

        public SampleArchTableContext GetContext()
        {
            var requestStore = HttpRequestSingleton<SampleArchTableContext>.Instance;
            if (!requestStore.IsSet)
            {
                //TODO : baseAddress/credentials
                requestStore.Value = new SampleArchTableContext("", null);
            }

            return requestStore.Value;
        }
    }
}
