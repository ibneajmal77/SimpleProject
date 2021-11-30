using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Model.Response
{
    public partial class ProfileAccessResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Module { get; set; }
    }
}
