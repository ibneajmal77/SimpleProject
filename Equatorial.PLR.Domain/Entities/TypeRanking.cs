using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class TypeRanking
    {
        public TypeRanking()
        {
            EvaluationIdRankingDivisionBonusNavigations = new HashSet<Evaluation>();
            EvaluationIdRankingFinalNavigations = new HashSet<Evaluation>();
            EvaluationIdRankingFirstRoundNavigations = new HashSet<Evaluation>();
            EvaluationIdRankingMondayRoundNavigations = new HashSet<Evaluation>();
            Hierarchies = new HashSet<Hierarchy>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Sequence { get; set; }

        public virtual ICollection<Evaluation> EvaluationIdRankingDivisionBonusNavigations { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdRankingFinalNavigations { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdRankingFirstRoundNavigations { get; set; }
        public virtual ICollection<Evaluation> EvaluationIdRankingMondayRoundNavigations { get; set; }
        public virtual ICollection<Hierarchy> Hierarchies { get; set; }
    }
}
