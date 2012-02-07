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
        //public IDocumentSession GetContext()
        //{
        //    var requestStore = HttpRequestSingleton<EmbeddableDocumentStore>.Instance;

        //    if (!requestStore.IsSet)
        //    {
        //        requestStore.Value = new EmbeddableDocumentStore { DataDirectory = Path.Combine(Environment.CurrentDirectory,"Data") };
        //        requestStore.Value.Conventions.IdentityPartsSeparator = "-";
        //        if (!_initialized)
        //        {
        //            requestStore.Value.Initialize();
        //        }
        //    }
        //    if (requestStore.Value == null)
        //    {
        //        return null;
        //    }
        //    return requestStore.Value.OpenSession();
        //}
    }
}
