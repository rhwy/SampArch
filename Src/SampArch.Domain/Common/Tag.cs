using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain.Common
{
    public class Tag : Identifiable
    {
        public string Name { get; set; }

        public Tag()
        {

        }

        public Tag(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            var value = (Tag)obj;
            if (value == null)
            {
                return false;
            }
            return Name.Equals(value.Name);
        }

        public static implicit operator Tag (string tagName)
        {
            Tag newTag = new Tag(tagName);
            return newTag;
        }
        public static implicit operator string(Tag tag)
        {
            return tag.Name;
        }
    }
}
