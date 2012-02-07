using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Common;

namespace SampArchi.Infrastructure.Azure.TableEntities.Common
{
    public class CommentTableEntity : TableServiceEntity
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime PublishDate { get; set; }

        public CommentTableEntity(Comment comment)
        {
            RowKey = comment.Id.ToString();
            PartitionKey = "Comments";
            Content = comment.Content;
            UserName = comment.UserName;
            PublishDate = comment.PublishDate;
        }

        public static explicit operator Comment(CommentTableEntity tableEntity)
        {
            Comment comment = new Comment();
            comment.Id = int.Parse(tableEntity.RowKey);
            comment.Content = tableEntity.Content;
            comment.UserName = tableEntity.UserName;
            comment.PublishDate = tableEntity.PublishDate;
            return comment;
        }
    }
}
