using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SampArch.Infrastructure.EF
{
    public class RepositoryBase
    {
    }

    public class RepositoryBase<T> : IRepositoryBase<T> where T : Identifiable
    {
        protected SampArchContext db;



        public RepositoryBase(SampArchContext context)
        {

        }

        public RepositoryBase()
        {

        }

        public T GetById(int id)
        {
            return db.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
