using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain;
using Raven.Client.Embedded;
using Raven.Client;

namespace SampArch.Infrastructure.Raven
{
    public class RavenUnitOfWork : IUnitOfWork
    {
        private IDocumentStore _documentStore;
        private IDocumentSession _session;

        public RavenUnitOfWork(IDocumentContextFactory _factory)
        {
            _documentStore = _factory.GetStore();
        }

        public void Begin()
        {
            _session = _documentStore.OpenSession();
        }

        public void Commit()
        {
            _session.SaveChanges();
        }

        public void RollBack()
        {
            //do nothing more to do, don't commit and wait for the end of the session
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
            }
        }
    }
}
