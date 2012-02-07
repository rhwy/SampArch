using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Infrastructure.EF;
using System.Web.Mvc;
using SampArch.Domain;
using StructureMap;

namespace SampArch.Bootstrapper
{
    public class DefaultsStartupConfigurator : IFactoryStartupConfigurator
    {
        public void Configure(Container container)
        {
            UnitOfWorkFactory.GetDefault = () => container.GetInstance<IUnitOfWork>();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(container));
        }
    }
}
