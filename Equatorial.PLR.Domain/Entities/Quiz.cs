using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Quiz
    {
        public Quiz()
        {
            EvaluationQuizzes = new HashSet<EvaluationQuiz>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public int Sequence { get; set; }

        public virtual ICollection<EvaluationQuiz> EvaluationQuizzes { get; set; }
    }
}
