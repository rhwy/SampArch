using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;
using System.Data.Entity.ModelConfiguration;
using Efmap.Helpers;

namespace SampArch.Infrastructure.EF.Common
{
    public class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
            : base()
        {
            this.WithRequiredGeneratedIdentity(p => p.Id);
            Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(32);


            ToTable("Comments");

        }
    }
}
