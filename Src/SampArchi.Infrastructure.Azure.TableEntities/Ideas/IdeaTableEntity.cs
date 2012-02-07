using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Ideas;
using SampArch.Domain.Common;

namespace SampArchi.Infrastructure.Azure.TableEntities.Ideas
{
    public class IdeaTableEntity : TableServiceEntity
    {
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Author { get; set; }
        public int VoteId { get; set; }
        public string TagIds { get; set; }

        public IdeaTableEntity(Idea suggest)
        {
            RowKey = suggest.Id.ToString();
            PartitionKey = "Suggests";
            CreationDate = suggest.CreationDate;
            Title = suggest.Title;
            Detail = suggest.Detail;
            Author = suggest.Author;
            VoteId = suggest.Votes.Id;
            TagIds = suggest.Tags.Any() ? string.Join(",", suggest.Tags.Select(t => t.Id)) : string.Empty;
        }

        public static explicit operator Idea(IdeaTableEntity tableEntity)
        {
            Idea suggest = new Idea();
            suggest.Id = int.Parse(tableEntity.RowKey);
            suggest.CreationDate = tableEntity.CreationDate;
            suggest.Title = tableEntity.Title;
            suggest.Detail = tableEntity.Detail;
            suggest.Author = tableEntity.Author;
            suggest.Votes = new Vote() { Id = tableEntity.VoteId };
            return suggest;
        }
    }
}
