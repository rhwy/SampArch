using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Starts a new UoW.
        /// </summary>
        void Begin();

        /// <summary>
        /// Commits all changes in the UoW.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks all changes in the UoW.
        /// </summary>
        void RollBack();
    }
}
