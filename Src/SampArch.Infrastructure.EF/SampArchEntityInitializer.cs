using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Efmap.Bootstrap;
using SampArch.Domain;

namespace SampArch.Infrastructure.EF
{
    
    public class SampArchEntityInitializer : EntityInitializer<SampArchContext>
    {
        public SampArchEntityInitializer()
        {
            this.AddCommand(
                "define default roles",
                (context) =>
                {
                    DomainInitializer init = new DomainInitializer();

                    init.DefineRoles().ForEach(r=> context.Roles.Add(r));
                });

            this.AddCommand(
                "add default users",
                (context) =>
                {
                    DomainInitializer init = new DomainInitializer();

                    init.DefineDefaultUsers().ForEach(u => context.Users.Add(u));

                });

            this.AddCommand(
                "add startup suggestion",
                (context) =>
                {
                    DomainInitializer init = new DomainInitializer();

                    init.DefineStartingIdea().ForEach(i => context.Ideas.Add(i));
                });

            this.AddCommand(
                "add introduction post",
                (context) =>
                {
                    DomainInitializer init = new DomainInitializer();

                    init.DefineIntroductionPost().ForEach(p => context.Posts.Add(p));
                });

        }
    }

}
