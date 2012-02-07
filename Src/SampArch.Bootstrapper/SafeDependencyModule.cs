using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using StructureMap;

namespace SampArch.Bootstrapper
{
    public class SafeDependencyModule : IHttpModule
    {
        private static bool _dependenciesRegistered;
        protected static readonly object Lock = new object();

        public void Init(HttpApplication context)
        {
            context.BeginRequest += base_context_BeginRequest;
        }

        private static void base_context_BeginRequest(object sender, EventArgs e)
        {
            EnsureDependenciesRegistered();
        }

        public static void EnsureDependenciesRegistered()
        {
            if (!_dependenciesRegistered)
            {
                lock (Lock)
                {
                    if (!_dependenciesRegistered)
                    {
                        ObjectFactory.ResetDefaults();
                        new DependencyHelper().ConfigureOnStartup();
                        _dependenciesRegistered = true;
                    }
                }
            }
        }

        public void Dispose() { }
    }
}
