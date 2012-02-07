using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Ideas;
using System.Data;

namespace SampArch.Infrastructure.EF.Ideas
{
    public class IdeaRepository : IIdeaRepository
    {

        private SampArchContext _context;

        public IdeaRepository(IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
        }

        public IEnumerable<Idea> FindByTag(Domain.Common.Tag tag)
        {
            return _context.Ideas.Where(s => s.Tags.Contains(tag));
        }

        public IEnumerable<Idea> FindByVotesUp()
        {
            return _context.Ideas.Where(s => s.Votes.Up > 0).OrderByDescending(s => s.Votes.Up);
        }

        public IEnumerable<Idea> SortBy(Func<Idea, object> sort)
        {
            return _context.Ideas.OrderBy(sort);
        }
        public IEnumerable<Idea> SortByDesc(Func<Idea, object> sort)
        {
            return _context.Ideas.OrderByDescending(sort);
        }

        public Idea GetById(int id)
        {
            return _context.Ideas.Include("Comments").Include("Tags").SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Idea> GetAll()
        {
            return _context.Ideas;
        }

        public IEnumerable<Idea> Get(Func<Idea, bool> filter)
        {
            return _context.Ideas.Where(filter);
        }

        public void Add(Idea item)
        {
            _context.Ideas.Add(item);
        }

        public void Delete(Idea item)
        {
            _context.Ideas.Remove(item);
        }

        public void Delete(int id)
        {
            Idea idea = GetById(id);
            if (idea != null)
            {
                Delete(idea);
            }
        }

        public void Update(Idea item)
        {
            _context.Entry(item).State = EntityState.Modified;

        }
    }
}
