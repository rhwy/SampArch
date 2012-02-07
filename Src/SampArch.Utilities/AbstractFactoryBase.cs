using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Utilities
{
    public class AbstractFactoryBase<T>
    {
        protected static T DefaultUnconfiguredState()
        {
            throw new Exception(string.Format("No factory for type {0}",typeof(T).Name));
        }
    }
}
