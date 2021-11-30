using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Parameter
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string TypeField { get; set; }
        public sbyte? ValueSensitive { get; set; }
    }
}
