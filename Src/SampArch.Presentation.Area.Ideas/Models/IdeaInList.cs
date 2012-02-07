using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Ideas;

namespace SampArch.Presentation.Area.Ideas.Models
{
    public class IdeaInList
    {
        public int Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }

        public int CommentsCount { get; private set; }
        public int VotesUp { get; private set; }
        public int VotesDown { get; private set; }
        public IEnumerable<string> Tags { get; private set; }

        public IdeaInList(Idea idea) : this(
            idea.Id,idea.CreationDate,idea.Title,idea.Author,idea.Comments.Count,idea.Votes.Up,idea.Votes.Down, idea.Tags.Select(x=>x.Name))
        {   
        }

        public IdeaInList(int id, DateTime date, string title, string author, int comments, int votesup, int votesdown, IEnumerable<string> tags)
        {
            Id = id;
            CreationDate = date;
            Title = title;
            Author = author;
            CommentsCount = comments;
            VotesUp = votesup;
            VotesDown = votesdown;
            Tags = tags;
        }
    }
}
