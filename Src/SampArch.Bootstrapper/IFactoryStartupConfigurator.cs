using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace SampArch.Bootstrapper
{
    public interface IFactoryStartupConfigurator
    {
        void Configure(Container container);
    }

}
