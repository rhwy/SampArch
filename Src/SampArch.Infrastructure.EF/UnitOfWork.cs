using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections;
using System.Data;
using System.Data.Objects;

namespace SampArch.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbContextFactory _contextFactory;
        
        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Begin()
        {
            _contextFactory.GetContext();

        }

        public void Commit()
        {
            SampArchContext context = _contextFactory.GetContext();
            context.ChangeTracker.DetectChanges();
            var changes = context.ChangeTracker.Entries().Where(x => (x.State == EntityState.Modified ) | (x.State == EntityState.Added) | (x.State == EntityState.Deleted));
            var ThereIsChangesAwaiting = (changes.Count() > 0);
            var errors = context.GetValidationErrors();

            
            if (errors != null && errors.Count() > 0)
            {
                throw new EntityCommandExecutionException(string.Format("There is {0} errors in context, we can not save the changes", errors.Count()));
            }
            else
            {
                if (ThereIsChangesAwaiting)
                {
                    context.SaveChanges();
                }
                
            }
        }

        public void RollBack()
        {
            SampArchContext context = _contextFactory.GetContext();
            ((IObjectContextAdapter)context).ObjectContext.Refresh(RefreshMode.StoreWins, context.ChangeTracker.Entries());
        }

        public void Dispose()
        {
            if (_contextFactory.GetContext() != null)
            {
                _contextFactory.GetContext().Dispose();
            }
        }

    }
}
