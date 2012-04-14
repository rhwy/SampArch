using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Embedded;
using Raven.Client;

namespace SampArch.Infrastructure.Raven
{
    public interface IDocumentContextFactory
    {
        IDocumentStore GetStore();
        IDocumentSession GetSession();
    }
}
