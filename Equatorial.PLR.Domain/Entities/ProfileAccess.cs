using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class ProfileAccess
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Module { get; set; }

        public virtual GroupEvaluation GroupEvaluation { get; set; }
    }
}
