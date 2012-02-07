using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;

namespace SampArch.Infrastructure.EF.Common
{
    public class UserRepository : IUserRepository
    {
        private SampArchContext _context;

        public UserRepository(IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
        }


        public IEnumerable<User> FindByRole(Role role)
        {
            return _context.Users.Where(x => x.Roles.Any(r => r.Name == role.Name));
        }

        public IEnumerable<User> FindByRoleName(string role)
        {
            return _context.Users.Where(x => x.Roles.Any(r => r.Name == role));
        }

        public User GetByName(string name)
        {
            return _context.Users.Where(x => x.Name == name).SingleOrDefault() ;
        }

        public User GetByLogin(string login)
        {
            return _context.Users.Where(x => x.Login == login).SingleOrDefault();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include("Roles");
        }

        public IEnumerable<User> Get(Func<User, bool> filter)
        {
            return _context.Users.Where(filter);
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public void Update(User item)
        {
            _context.Entry(item).State = System.Data.EntityState.Modified;
        }
    }
}
