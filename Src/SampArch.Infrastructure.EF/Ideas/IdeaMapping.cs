using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Ideas;
using System.Data.Entity.ModelConfiguration;
using Efmap.Helpers;
using SampArch.Domain.Common;

namespace SampArch.Infrastructure.EF.Ideas
{
    
    public class IdeaMapping : EntityTypeConfiguration<Idea>
    {
        public IdeaMapping()
            : base()
        {
            this.WithRequiredGeneratedIdentity(p => p.Id);
            Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);
            Property(p => p.Votes.Up)
                .HasColumnType("int")
                .HasColumnName("VoteUp");
            Property(p => p.Votes.Down)
                .HasColumnType("int")
                .HasColumnName("VoteDown");
            HasMany<Comment>(p => p.Comments)
                .WithMany();
            
            ToTable("Ideas");

        }
    }

    
}
