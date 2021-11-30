using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Cycle
    {
        public Cycle()
        {
            InverseIdCyclePreviousNavigation = new HashSet<Cycle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart1Round { get; set; }
        public DateTime DateEnd1Round { get; set; }
        public DateTime DateStart2Round { get; set; }
        public DateTime DateEnd2Round { get; set; }
        public DateTime DateStartDivisionBonus { get; set; }
        public DateTime DateEndDivisionBonus { get; set; }
        public DateTime DateStartClosure { get; set; }
        public DateTime DafaEndClosure { get; set; }
        public DateTime DatePayment { get; set; }
        public float NoteMinimumConsider { get; set; }
        public float ValueMaxBonusAdditional { get; set; }
        public float ValueMaxParticipation { get; set; }
        public float IndexNoteObjectiveResponsible { get; set; }
        public float IndexNoteIndividualRated { get; set; }
        public float IndexRankingNoteObjective { get; set; }
        public float IndexRankingNoteSubjective { get; set; }
        public string TitleEmailRanking { get; set; }
        public string CorpoEmailRanking { get; set; }
        public string CorpoPdfRanking { get; set; }
        public string TitleEmailPayment { get; set; }
        public string CorpoPdfPayment { get; set; }
        public string Situation { get; set; }
        public int IdCompany { get; set; }
        public int? IdCyclePrevious { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        public virtual Cycle IdCyclePreviousNavigation { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        public virtual GroupEvaluation GroupEvaluation { get; set; }
        public virtual Hierarchy Hierarchy { get; set; }
        public virtual ICollection<Cycle> InverseIdCyclePreviousNavigation { get; set; }
    }
}
