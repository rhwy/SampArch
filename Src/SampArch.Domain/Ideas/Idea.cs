using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SampArch.Domain.Common;

namespace SampArch.Domain.Ideas
{
    public class Idea : Identifiable
    {
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(140)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
        
        [Required(ErrorMessage = "Author name is required")]
        [StringLength(32)]
        public string Author { get; set; }
        
        public virtual Vote Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Idea()
        {
            Votes = new Vote();
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
            CreationDate = DateTime.Now;
        }

        //note: you are supposed to only add comments, not remove them
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }


        public void VoteUp()
        {
            Votes.Up++;
        }

        public void VoteDown()
        {
            Votes.Down++;
        }

        public void AddTag(Tag tag)
        {
            if (!Tags.Contains(tag))
            {
                Tags.Add(tag);
            }
        }

        public void AddTag(string tag)
        {
            Tag newTag = new Tag(tag);
            AddTag(newTag);
        }

        public void RemoveTag(Tag tag)
        {
            if (Tags.Contains(tag))
            {
                Tags.Remove(tag);
            }
        }

        public void RemoveTag(string tagName)
        {
            Tag tag = Tags.FirstOrDefault(t => t.Name == tagName);
            if (tag != null)
            {
                RemoveTag(tag);
            }
        }
    }
}
