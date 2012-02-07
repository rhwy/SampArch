using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SampArch.Presentation.Core.Models
{
    public class ContactMessage
    {
        [DataType(DataType.Text)]
        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        
        [DataType(DataType.DateTime)]
        [Display(Name = "Message date")]
        public DateTime CreationDate { get; set; }

        public ContactMessage()
        {
            CreationDate = DateTime.Now;
        }
    }
}