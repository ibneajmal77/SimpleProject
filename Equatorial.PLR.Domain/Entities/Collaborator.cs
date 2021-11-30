using System;
using System.Collections.Generic;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class Collaborator
    {
        public Collaborator()
        {
            Hierarchies = new HashSet<Hierarchy>();
        }

        public int Id { get; set; }
        public string Registration { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float ValueWage { get; set; }
        public float ValueDangerousness { get; set; }
        public short MonthsWorked { get; set; }
        public int Absences { get; set; }
        public string Situation { get; set; }
        public string CodeClassificationOffice { get; set; }
        public int IdGroupCompetitor { get; set; }
        public int IdUnityManagerial { get; set; }
        public int IdCycle { get; set; }

        public virtual ClassificationOffice CodeClassificationOfficeNavigation { get; set; }
        public virtual Cycle IdCycleNavigation { get; set; }
        public virtual Hierarchy IdGroupCompetitorNavigation { get; set; }
        public virtual Hierarchy IdUnityManagerialNavigation { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        public virtual ICollection<Hierarchy> Hierarchies { get; set; }
    }
}
