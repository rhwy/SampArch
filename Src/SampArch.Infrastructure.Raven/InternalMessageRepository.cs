using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;
using Raven.Client.Embedded;
using Raven.Client;

namespace SampArch.Infrastructure.Raven
{
    public class InternalMessageRepository : IInternalMessageRepository
    {
        private IDocumentStore _store;

        public InternalMessageRepository(IDocumentContextFactory context)
        {
            _store = context.GetStore();
        }

        public InternalMessage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InternalMessage> GetAll()
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<InternalMessage>();
            }
        }

        public IEnumerable<InternalMessage> Get(Func<InternalMessage, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(InternalMessage item)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
        }

        public void Delete(InternalMessage item)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(InternalMessage item)
        {
            throw new NotImplementedException();
        }
    }
}
