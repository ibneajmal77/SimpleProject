using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            EvaluationQuizzes = new HashSet<EvaluationQuiz>();
        }

        public int Id { get; set; }
        public float? NoteIndividual { get; set; }
        public float? NoteObjective { get; set; }
        public int? IdRankingFirstRound { get; set; }
        public int? PositionRankingFirstRound { get; set; }
        public string Justification { get; set; }
        public int? IdEvaluatorFirstRound { get; set; }
        public DateTime? DateConclusionFirstRoad { get; set; }
        public string SituationFirstRound { get; set; }
        public float? NoteSubjective1MondayRound { get; set; }
        public float? NoteSubjective2MondayRound { get; set; }
        public int? IdRankingMondayRound { get; set; }
        public int? PositionRankingMondayRound { get; set; }
        public int? IdEvaluatorMondayRound { get; set; }
        public DateTime? DateConclusionMondayRound { get; set; }
        public string SituationMondayRound { get; set; }
        public float? NoteSubjective1DivisionBonus { get; set; }
        public float? NoteSubjective2DivisionBonus { get; set; }
        public int? IdRankingDivisionBonus { get; set; }
        public int? PositionRankingDivisionBonus { get; set; }
        public int? IdEvaluatorDivisionBonus { get; set; }
        public DateTime? DateConclusionDivisionBonus { get; set; }
        public string SituationDivisionBonus { get; set; }
        public float? NoteSubjective1Final { get; set; }
        public float? NoteSubjective2Final { get; set; }
        public float? NoteRanking { get; set; }
        public int? IdRankingFinal { get; set; }
        public float? PositionRankingFinal { get; set; }
        public int? IdEvaluatorFinal { get; set; }
        public DateTime? DateEvaluationFinal { get; set; }
        public string SituationFinal { get; set; }
        public float? BaseValueReference { get; set; }
        public float? MultipleWage { get; set; }
        public float? ValueBonusClaculated { get; set; }
        public float? DiscountBonus { get; set; }
        public float? ValueBonusFinal { get; set; }
        public float? NoteFinal { get; set; }
        public string Evaluationcol { get; set; }
        public int IdCollaborator { get; set; }
        public int IdCycle { get; set; }

        public virtual Collaborator IdCollaboratorNavigation { get; set; }
        public virtual Cycle IdCycleNavigation { get; set; }
        public virtual User IdEvaluatorDivisionBonusNavigation { get; set; }
        public virtual User IdEvaluatorFinalNavigation { get; set; }
        public virtual User IdEvaluatorFirstRoundNavigation { get; set; }
        public virtual User IdEvaluatorMondayRoundNavigation { get; set; }
        public virtual TypeRanking IdRankingDivisionBonusNavigation { get; set; }
        public virtual TypeRanking IdRankingFinalNavigation { get; set; }
        public virtual TypeRanking IdRankingFirstRoundNavigation { get; set; }
        public virtual TypeRanking IdRankingMondayRoundNavigation { get; set; }
        public virtual ICollection<EvaluationQuiz> EvaluationQuizzes { get; set; }
    }
}
