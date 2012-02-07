using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Blog;
using SampArch.Domain.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace SampArch.Infrastructure.EF.Blog
{
    public class PostRepository : IPostRepository
    {
         private SampArchContext _context;
         private DbQuery<Post> posts
         {
             get
             {
                 return _context.Posts.Include("Tags");
             }
         }
         public PostRepository(IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
        }

        public IEnumerable<Post> FindByTag(Tag tag)
        {
            return posts.Where(t => t.Tags.Contains(tag));
        }

        public IEnumerable<Post> FindByAuthor(string authorName)
        {
            return posts.Where(x => x.Author == authorName);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Post> GetAll()
        {
            return posts;
        }

        public IEnumerable<Post> Get(Func<Post, bool> filter)
        {
            return posts.Where(filter);
        }

        public void Add(Post item)
        {
            _context.Posts.Add(item);
        }

        public void Delete(Post item)
        {
            _context.Posts.Remove(item);
        }

        public void Delete(int id)
        {
            Post post = GetById(id);
            if (post != null)
            {
                Delete(post);
            }
        }

        public void Update(Post item)
        {
            _context.Entry(item).State = EntityState.Modified;

        }
    }
}
