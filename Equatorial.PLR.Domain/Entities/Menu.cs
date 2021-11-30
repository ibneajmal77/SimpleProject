using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public short Sequence { get; set; }
        public short Level { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string IconPage { get; set; }
        public string IconMenu { get; set; }
        public string Permission { get; set; }
    }
}
