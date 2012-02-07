using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Domain
{
    /// <summary>
    /// This the common class used to share the identification type (by an int id)
    /// this is used also as a facility for the repositories
    /// </summary>
    public abstract class Identifiable
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var matchedObj = obj as Identifiable;
            if (matchedObj == null)
            {
                return false;
            }
            if (matchedObj.Id != Id)
            {
                return false;
            }
            return base.Equals(obj);
        }
    }
}
