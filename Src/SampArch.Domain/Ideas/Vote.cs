using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Ideas
{
    
    public class Vote : Identifiable
    {
        public int Up { get; set; }
        public int Down { get; set; }
    }
}
