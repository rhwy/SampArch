using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain;
using Raven.Client.Embedded;

namespace SampArch.Infrastructure.Raven
{
    public class RavenUnitOfWork : IUnitOfWork
    {
        

        public void Begin()
        {
            var documentStore = new EmbeddableDocumentStore { DataDirectory = "~/App_Data/" };
            
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
