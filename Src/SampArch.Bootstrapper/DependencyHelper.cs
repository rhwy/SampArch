using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace SampArch.Bootstrapper
{
    public class DependencyHelper
    {
        private static bool _dependenciesRegistered;

        private Container _container;

        private void RegisterDependencies()
        {
            string assemblyPrefix = GetThisAssembliesPrefix();
            string path = AppDomain.CurrentDomain.BaseDirectory + "bin";

            _container = new Container(x => x.Scan(y =>
            {
                y.AssembliesFromPath(path, a => a.GetName().Name.StartsWith(assemblyPrefix));

                y.WithDefaultConventions();
                y.LookForRegistries();

                y.AddAllTypesOf<IFactoryStartupConfigurator>();
            }));

            InitializeFactoriesWithContainer();
            
        }

        internal void ConfigureOnStartup()
        {
            RegisterDependencies();
        }

        internal void InitializeFactoriesWithContainer()
        {
            var factories = _container.GetAllInstances<IFactoryStartupConfigurator>();
            foreach (IFactoryStartupConfigurator factory in factories)
            {
                factory.Configure(_container);
            }
        }

        protected static readonly object Sync = new object();
        public static void EnsureDependenciesRegistered()
        {
            if (!_dependenciesRegistered)
            {
                lock (Sync)
                {
                    if (!_dependenciesRegistered)
                    {
                        ObjectFactory.ResetDefaults();
                        new DependencyHelper().RegisterDependencies();
                        _dependenciesRegistered = true;

                    }
                }
            }
        }

        private string GetThisAssembliesPrefix()
        {
            string name = GetType().Assembly.GetName().Name;
            name = name.Substring(0, name.IndexOf("."));
            return name;
        }

    }
}
