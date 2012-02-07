using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    public class Comment : Identifiable
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime PublishDate { get; set; }

        public Comment()
        {
            //PublishDate = DateTime.Now;
        }
    }
}
