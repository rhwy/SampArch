using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArchi.Infrastructure.Azure
{
    public interface ITableContextFactory
    {
        SampleArchTableContext GetContext();
    }
}
