using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Model.Response
{
    public partial class QuizResponse
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int Sequence { get; set; }
    }
}
