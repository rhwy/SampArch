using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain
{
    public interface IRepositoryBase<T> where T : Identifiable
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Func<T, bool> filter);

        void Add(T item);
        void Delete(T item);
        void Delete(int id);
        void Update(T item);
    }
}
