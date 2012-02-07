using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Ideas;

namespace SampArchi.Infrastructure.Azure.Ideas
{
    public class IdeaRepository : IIdeaRepository
    {
        private SampleArchTableContext _context;

        public IdeaRepository(ITableContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
        }

        public IEnumerable<Idea> FindByTag(SampArch.Domain.Common.Tag tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idea> FindByVotesUp()
        {
            throw new NotImplementedException();
        }

        public Idea GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idea> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idea> Get(Func<Idea, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Idea item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Idea item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Idea item)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Idea> SortBy(Func<Idea, object> sort)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idea> SortByDesc(Func<Idea, object> sort)
        {
            throw new NotImplementedException();
        }
    }
}
