using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class TypeHierarchy
    {
        public TypeHierarchy()
        {
            Hierarchies = new HashSet<Hierarchy>();
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int Sequence { get; set; }

        public virtual ICollection<Hierarchy> Hierarchies { get; set; }
    }
}
