using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Company
    {
        public Company()
        {
            Cycles = new HashSet<Cycle>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? Value { get; set; }

        public virtual ICollection<Cycle> Cycles { get; set; }
    }
}
