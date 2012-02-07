using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Common;

namespace SampArchi.Infrastructure.Azure.TableEntities.Common
{
    public class RoleTableEntity : TableServiceEntity
    {
        public string Name { get; set; }

        public RoleTableEntity(Role role)
        {
            RowKey = role.Id.ToString();
            PartitionKey = "Roles";
            Name = role.Name;
        }

        public static explicit operator Role(RoleTableEntity tableEntity)
        {
            Role role = new Role();
            role.Id = int.Parse(tableEntity.RowKey);
            role.Name = tableEntity.Name;
            return role;
        }
    }
}
