using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;

namespace SampArch.Domain.Ideas
{
    public interface IIdeaRepository : IRepositoryBase<Idea>
    {
        IEnumerable<Idea> FindByTag(Tag tag);
        IEnumerable<Idea> FindByVotesUp();

        IEnumerable<Idea> SortBy(Func<Idea, object> sort);
        IEnumerable<Idea> SortByDesc(Func<Idea, object> sort);
    }
}
