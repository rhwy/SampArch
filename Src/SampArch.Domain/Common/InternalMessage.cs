using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    public class InternalMessage : Identifiable
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
