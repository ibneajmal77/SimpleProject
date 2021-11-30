using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class ClassificationOffice
    {
        public ClassificationOffice()
        {
            Collaborators = new HashSet<Collaborator>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Sequence { get; set; }

        public virtual ICollection<Collaborator> Collaborators { get; set; }
    }
}
