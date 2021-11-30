using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            EvaluationIdEvaluatorDivisionBonusNavigations = new HashSet<Evaluation>();
            EvaluationIdEvaluatorFinalNavigations = new HashSet<Evaluation>();
            EvaluationIdEvaluatorFirstRoundNavigations = new HashSet<Evaluation>();
            EvaluationIdEvaluatorMondayRoundNavigations = new HashSet<Evaluation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Registration { get; set; }
        public string Type { get; set; }
        public string Directory { get; set; }
        public string AreaExecutive { get; set; }
        public string Office { get; set; }
        public string Situation { get; set; }
        public DateTime? LastAccess { get; set; }

        public virtual GroupEvaluation GroupEvaluation { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdEvaluatorDivisionBonusNavigations { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdEvaluatorFinalNavigations { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdEvaluatorFirstRoundNavigations { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdEvaluatorMondayRoundNavigations { get; set; }
    }
}
