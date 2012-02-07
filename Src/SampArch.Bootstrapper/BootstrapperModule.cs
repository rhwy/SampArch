using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using StructureMap;
using SampArch.Infrastructure.EF;
using Efmap;
using Efmap.Bootstrap;
using System.Web.Mvc;
using SampArch.Domain;
using SampArch.Domain.Ideas;
using SampArch.Infrastructure.EF.Ideas;

namespace SampArch.Bootstrapper
{
    public class BootstrapperModule : IHttpModule
    {
        private static bool _registered = false;
        private static readonly object _lock = new object();
        private DependencyHelper _dependencyHelper;

        public void Init(HttpApplication context)
        {

            lock (_lock)
            {
                if (!_registered)
                {
                    Register();
                }
            }
        }

        public void Dispose()
        {
            
        }

        public void Register()
        {
            DependencyHelper.EnsureDependenciesRegistered();
            _registered = true;
        }

       
    }
}
