using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Embedded;
using SampArch.Utilities;
using Raven.Client;
using System.IO;

namespace SampArch.Infrastructure.Raven
{
    public class DocumentContextFactory : IDocumentContextFactory
    {
        public static bool _initialized;
        private static IDocumentStore _store;

        public IDocumentStore GetStore()
        {
            if (_store == null)
            {
                _store = new EmbeddableDocumentStore { DataDirectory = Path.Combine(Environment.CurrentDirectory, "Data") };
                _store.Conventions.IdentityPartsSeparator = "-";
                if (!_initialized)
                {
                    _store.Initialize();
                }
            }
            return _store;
        }



        public IDocumentSession GetSession()
        {
            return GetStore().OpenSession();
        }
    }
}
