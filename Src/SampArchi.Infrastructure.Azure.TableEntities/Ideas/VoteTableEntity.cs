using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using SampArch.Domain.Ideas;

namespace SampArchi.Infrastructure.Azure.TableEntities.Ideas
{
    public class VoteTableEntity : TableServiceEntity
    {
        public int Up { get; set; }
        public int Down { get; set; }

        public VoteTableEntity(Vote vote)
        {
            RowKey = vote.Id.ToString();
            PartitionKey = "Votes";
            Up = vote.Up;
            Down = vote.Down;
        }

        public static explicit operator Vote(VoteTableEntity tableEntity)
        {
            Vote vote = new Vote();
            vote.Id = int.Parse(tableEntity.RowKey);
            vote.Up = tableEntity.Up;
            vote.Down = tableEntity.Down;
            return vote;
        }
    }
}
