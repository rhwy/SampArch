using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Blog;

namespace SampArchi.Infrastructure.Azure.TableEntities.Blog
{
    public class PostTableEntity : TableServiceEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

        public PostTableEntity(Post post)
        {
            RowKey = post.Id.ToString();
            PartitionKey = "Posts";
            Title = post.Title;
            Content = post.Content;
            Author = post.Author;
            PublishDate = post.PublishDate;
        }

        public static explicit operator Post (PostTableEntity postTableEntity)
        {
            Post post = new Post();
            post.Id = int.Parse(postTableEntity.RowKey);
            post.Title = postTableEntity.Title;
            post.Content = postTableEntity.Content;
            post.PublishDate = postTableEntity.PublishDate;
            return post;
        }
    }
}
