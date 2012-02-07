using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Common;

namespace SampArchi.Infrastructure.Azure.TableEntities.Common
{
    public class TagTableEntity : TableServiceEntity
    {
        public string Name { get; set; }

        public TagTableEntity(Tag tag)
        {
            RowKey = tag.Id.ToString();
            PartitionKey = "Tags";
            Name = tag.Name;
        }

        public static explicit operator Tag (TagTableEntity tableEntity)
        {
            Tag tag = new Tag();
            tag.Id = int.Parse(tableEntity.RowKey);
            tag.Name = tableEntity.Name;
            return tag;
        }
    }
}
