using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class EvaluationQuiz
    {
        public int EvaluationId { get; set; }
        public int EvaluationIdCollaborator { get; set; }
        public int QuizId { get; set; }
        public int ValueResposta { get; set; }

        public virtual Evaluation Evaluation { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
