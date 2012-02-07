using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using Efmap;
using SampArch.Infrastructure.EF;
using Efmap.Bootstrap;
using System.Web.Security;

namespace SampArch.Bootstrapper
{
    public class DataStartupConfigurator : IFactoryStartupConfigurator
    {
        public void Configure(Container container)
        {
            //EntityMapHelper.SetDbInitializer<SampArchContext>(new SampArchDbInitializer());
            EntityMapHelper.SetEntityInitializer<SampArchContext>(new SampArchEntityInitializer());
            //EntityMapHelper.Initialize<SampArchContext>().With<DropCreateOnModelChanges<SampArchContext>>();
            EntityMapHelper.Initialize<SampArchContext>().With<DropCreateAlways<SampArchContext>>();

            EnsureDbIsUptoDate();

        }

        private void EnsureDbIsUptoDate()
        {
            using (SampArchContext db = new SampArchContext())
            {
                if(!db.Database.CompatibleWithModel(false))
                {
                    db.Database.Initialize(false);
                }
                SetUpMembership();
            }
        }

        private void SetUpMembership()
        {
            SampArch.Domain.DomainInitializer di = new Domain.DomainInitializer();

            foreach (var item in di.DefineRoles())
            {
                if (!Roles.RoleExists(item.Name))
                {
                    Roles.CreateRole(item.Name);
                }
            }

            foreach (var domainUsers in di.DefineDefaultUsers())
            {
                MembershipUser user = Membership.GetUser(domainUsers.Login);
                if (user == null)
                {
                    user = Membership.CreateUser(domainUsers.Login, InfrastructureConfiguration.DEFAULT_PASSWORD, domainUsers.Email);
                    foreach (var role in domainUsers.Roles)
                    {
                        Roles.AddUserToRole(user.UserName, role.Name);
                    }
                }
            }

            
        }
    }
}
