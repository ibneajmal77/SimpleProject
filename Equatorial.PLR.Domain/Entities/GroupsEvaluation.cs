using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class GroupsEvaluation
    {
        public int IdGroupEvaluation { get; set; }
        public int IdHierarchy { get; set; }

        public virtual GroupEvaluation IdGroupEvaluationNavigation { get; set; }
        public virtual Hierarchy IdHierarchyNavigation { get; set; }
    }
}
