using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace SampArch.Presentation.Area.Ideas.Models
{
    public class AddCommentIdea
    {
        [Required]
        public int IdeaId { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public AddCommentIdea()
        {
            
        }
    }
}
