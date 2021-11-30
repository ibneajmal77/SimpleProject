using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Model.Response
{
    public partial class ClassificationOfficeResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Sequence { get; set; }
    }
}
