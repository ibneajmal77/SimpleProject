using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Hierarchy
    {
        public Hierarchy()
        {
            CollaboratorIdGroupCompetitorNavigations = new HashSet<Collaborator>();
            CollaboratorIdUnityManagerialNavigations = new HashSet<Collaborator>();
            GroupsEvaluations = new HashSet<GroupsEvaluation>();
            InverseIdHierarchyPaiNavigation = new HashSet<Hierarchy>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Premise { get; set; }
        public string Situation { get; set; }
        public int? IdTypeRanking { get; set; }
        public string CodeTypeHierarchy { get; set; }
        public int? IdHierarchyPai { get; set; }
        public int? IdResponsible { get; set; }
        public int IdCycle { get; set; }

        public virtual TypeHierarchy CodeTypeHierarchyNavigation { get; set; }
        public virtual Cycle IdCycleNavigation { get; set; }
        public virtual Hierarchy IdHierarchyPaiNavigation { get; set; }
        public virtual Collaborator IdResponsibleNavigation { get; set; }
        public virtual TypeRanking IdTypeRankingNavigation { get; set; }
        public virtual ICollection<Collaborator> CollaboratorIdGroupCompetitorNavigations { get; set; }
        public virtual ICollection<Collaborator> CollaboratorIdUnityManagerialNavigations { get; set; }
        public virtual ICollection<GroupsEvaluation> GroupsEvaluations { get; set; }
        public virtual ICollection<Hierarchy> InverseIdHierarchyPaiNavigation { get; set; }
    }
}
