using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Blog;
using System.Data.Entity.ModelConfiguration;
using Efmap.Helpers;
using SampArch.Domain.Common;


namespace SampArch.Infrastructure.EF.Blog
{
    public class PostMapping : EntityTypeConfiguration<Post>
    {
        public PostMapping()
            : base()
        {
            this.WithRequiredGeneratedIdentity(p => p.Id);
            Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            HasMany<Comment>(p => p.Comments)
                .WithMany();
            HasMany<Tag>(p => p.Tags)
                .WithMany();
            ToTable("Posts");

        }
    }
}
