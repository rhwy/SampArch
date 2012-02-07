using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SampArch.Domain.Blog
{
    public class Post : Identifiable
    {
        [Required(ErrorMessage = "Author name is required")]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required(ErrorMessage = "Author name is required")]
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        
        public Post()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
            PublishDate = DateTime.Now;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }

        public bool RemoveTag(Tag tag)
        {
            if (Tags.FirstOrDefault(t => t == tag) != null)
            {
                Tags.Remove(tag);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool RemoveTag(string name)
        {
            Tag tag = Tags.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());
            if (tag != null)
            {
                return RemoveTag(tag);
            }
            else
            {
                return false;
            }
        }
    }
}
