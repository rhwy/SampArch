using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain;
using SampArch.Utilities;
using StructureMap;

namespace SampArch.Infrastructure.EF
{
    public class UnitOfWorkFactory : AbstractFactoryBase<IUnitOfWork>
    {
         
        public static Func<IUnitOfWork> GetDefault = DefaultUnconfiguredState;
    }
}
