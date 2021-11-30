using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Audit
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Login { get; set; }
        public string Registration { get; set; }
        public string Module { get; set; }
        public string Screen { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
    }
}
