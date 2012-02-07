using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Common;

namespace SampArchi.Infrastructure.Azure.TableEntities.Common
{
    public class UserTableEntity : TableServiceEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }

        public UserTableEntity(User user)
        {
            RowKey = user.Id.ToString();
            PartitionKey = "Users";
            Name = user.Name;
            Login = user.Login;
        }

        public static explicit operator User(UserTableEntity tableEntity)
        {
            User user = new User();
            user.Id = int.Parse(tableEntity.RowKey);
            user.Login = tableEntity.Login;
            user.Name = tableEntity.Name;
            return user;
        }
    }
}
