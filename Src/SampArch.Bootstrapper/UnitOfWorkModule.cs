using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SampArch.Domain;
using SampArch.Infrastructure.EF;

namespace SampArch.Bootstrapper
{
    public class UnitOfWorkModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
            
        }

        public void Dispose() { }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            DependencyHelper.EnsureDependenciesRegistered();

            IUnitOfWork instance = UnitOfWorkFactory.GetDefault();
            instance.Begin();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            IUnitOfWork instance = UnitOfWorkFactory.GetDefault();
            try
            {
                instance.Commit();
            }
            catch
            {
                instance.RollBack();
            }
            finally
            {
                instance.Dispose();
            }
        }
    }
}
