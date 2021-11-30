using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Model.Request.Create
{
    public class ParameterCreateRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string TypeField { get; set; }
        public sbyte? ValueSensitive { get; set; }
    }
}
