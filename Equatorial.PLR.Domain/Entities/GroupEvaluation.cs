using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class GroupEvaluation
    {
        public GroupEvaluation()
        {
            GroupsEvaluations = new HashSet<GroupsEvaluation>();
        }

        public int Id { get; set; }
        public string Module { get; set; }
        public int IdUser { get; set; }
        public int IdProfileAccess { get; set; }
        public int IdCycle { get; set; }

        public virtual Cycle IdCycleNavigation { get; set; }
        public virtual ProfileAccess IdProfileAccessNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<GroupsEvaluation> GroupsEvaluations { get; set; }
    }
}
