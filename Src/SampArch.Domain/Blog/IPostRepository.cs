using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;

namespace SampArch.Domain.Blog
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        IEnumerable<Post> FindByTag(Tag tag);
        IEnumerable<Post> FindByAuthor(string authorName);
    }
}
