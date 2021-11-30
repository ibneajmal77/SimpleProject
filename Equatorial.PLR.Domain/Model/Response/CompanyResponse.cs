using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Model.Response
{
    public partial class CompanyResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? Value { get; set; }
    }
}
