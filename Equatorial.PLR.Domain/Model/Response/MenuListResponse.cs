using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Model.Response
{
    public partial class MenuListResponse
    {
        public List<MenuResponse> pge { get; set; }
        public List<MenuResponse> ppme { get; set; }
        public List<MenuResponse> admin { get; set; }
        public List<MenuResponse> banners { get; set; }
    }
}
