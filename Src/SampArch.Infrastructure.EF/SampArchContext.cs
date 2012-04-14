using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SampArch.Domain.Ideas;
using SampArch.Domain.Blog;
using Efmap.Helpers;
using SampArch.Domain.Common;
using System.Data.Entity.Infrastructure;

namespace SampArch.Infrastructure.EF
{
    public class SampArchContext : DbContext
    {
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public SampArchContext()
            : base(InfrastructureConfiguration.DB_NAME)
        {}

        public SampArchContext(string dbName)
            : base(dbName)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            this.AutoLoadForThisContext(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

    }
}
