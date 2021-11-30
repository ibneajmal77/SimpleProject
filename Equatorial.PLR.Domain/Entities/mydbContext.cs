using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Equatorial.PLR.Domain.Entities
{
    public partial class mydbContext : DbContext
    {
        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<ClassificationOffice> ClassificationOffices { get; set; }
        public virtual DbSet<Collaborator> Collaborators { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Cycle> Cycles { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<EvaluationQuiz> EvaluationQuizzes { get; set; }
        public virtual DbSet<GroupEvaluation> GroupEvaluations { get; set; }
        public virtual DbSet<GroupsEvaluation> GroupsEvaluations { get; set; }
        public virtual DbSet<Hierarchy> Hierarchies { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<ProfileAccess> ProfileAccesses { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<TypeHierarchy> TypeHierarchies { get; set; }
        public virtual DbSet<TypeRanking> TypeRankings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("audit");

                entity.HasIndex(e => e.Login, "key_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(15)
                    .HasColumnName("action");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("description");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Module)
                    .HasMaxLength(15)
                    .HasColumnName("module");

                entity.Property(e => e.Registration)
                    .HasMaxLength(45)
                    .HasColumnName("registration");

                entity.Property(e => e.Screen)
                    .HasMaxLength(500)
                    .HasColumnName("screen");
            });

            modelBuilder.Entity<ClassificationOffice>(entity =>
            {
                entity.ToTable("classification_office");

                entity.HasIndex(e => e.Code, "code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Title, "title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("code");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Collaborator>(entity =>
            {
                entity.ToTable("collaborator");

                entity.HasIndex(e => e.CodeClassificationOffice, "fk_collaborator_classification_office1_idx");

                entity.HasIndex(e => e.IdCycle, "fk_collaborator_cycle1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.IdGroupCompetitor, "fk_collaborator_hierarchy1_idx");

                entity.HasIndex(e => e.IdUnityManagerial, "fk_collaborator_hierarchy2_idx");

                entity.HasIndex(e => e.Registration, "registration_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Absences).HasColumnName("absences");

                entity.Property(e => e.CodeClassificationOffice)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("code_classification_office");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IdCycle).HasColumnName("id_cycle");

                entity.Property(e => e.IdGroupCompetitor).HasColumnName("id_group_competitor");

                entity.Property(e => e.IdUnityManagerial).HasColumnName("id_unity_managerial");

                entity.Property(e => e.MonthsWorked)
                    .HasColumnName("months_worked")
                    .HasDefaultValueSql("'12'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("registration");

                entity.Property(e => e.Situation)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("situation")
                    .HasDefaultValueSql("'participant'");

                entity.Property(e => e.ValueDangerousness).HasColumnName("value_dangerousness");

                entity.Property(e => e.ValueWage).HasColumnName("value_wage");

                entity.HasOne(d => d.CodeClassificationOfficeNavigation)
                    .WithMany(p => p.Collaborators)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.CodeClassificationOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_collaborator_classification_office1");

                entity.HasOne(d => d.IdCycleNavigation)
                    .WithOne(p => p.Collaborator)
                    .HasForeignKey<Collaborator>(d => d.IdCycle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_collaborator_cycle1");

                entity.HasOne(d => d.IdGroupCompetitorNavigation)
                    .WithMany(p => p.CollaboratorIdGroupCompetitorNavigations)
                    .HasForeignKey(d => d.IdGroupCompetitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_collaborator_hierarchy1");

                entity.HasOne(d => d.IdUnityManagerialNavigation)
                    .WithMany(p => p.CollaboratorIdUnityManagerialNavigations)
                    .HasForeignKey(d => d.IdUnityManagerial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_collaborator_hierarchy2");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.Value)
                    .HasPrecision(19, 2)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.ToTable("cycle");

                entity.HasIndex(e => e.IdCompany, "fk_cycle_company1_idx");

                entity.HasIndex(e => e.IdCyclePrevious, "fk_cycle_cycle1_idx");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CorpoEmailRanking).HasColumnName("corpo_email_ ranking");

                entity.Property(e => e.CorpoPdfPayment).HasColumnName("corpo_pdf_payment");

                entity.Property(e => e.CorpoPdfRanking).HasColumnName("corpo_pdf_ ranking");

                entity.Property(e => e.DafaEndClosure)
                    .HasColumnType("datetime")
                    .HasColumnName("dafa_end_closure");

                entity.Property(e => e.DateEnd1Round)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end_1_round");

                entity.Property(e => e.DateEnd2Round)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end_2_round");

                entity.Property(e => e.DateEndDivisionBonus)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end_division_bonus");

                entity.Property(e => e.DatePayment)
                    .HasColumnType("datetime")
                    .HasColumnName("date_payment");

                entity.Property(e => e.DateStart1Round)
                    .HasColumnType("datetime")
                    .HasColumnName("date_start_1_round");

                entity.Property(e => e.DateStart2Round)
                    .HasColumnType("datetime")
                    .HasColumnName("date_start_2_round");

                entity.Property(e => e.DateStartClosure)
                    .HasColumnType("datetime")
                    .HasColumnName("date_start_closure");

                entity.Property(e => e.DateStartDivisionBonus)
                    .HasColumnType("datetime")
                    .HasColumnName("date_start_division_bonus");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.IdCompany).HasColumnName("id_company");

                entity.Property(e => e.IdCyclePrevious).HasColumnName("id_cycle_previous");

                entity.Property(e => e.IndexNoteIndividualRated).HasColumnName("index_note_individual_rated");

                entity.Property(e => e.IndexNoteObjectiveResponsible).HasColumnName("index_note_objective_responsible");

                entity.Property(e => e.IndexRankingNoteObjective).HasColumnName("index_ranking_note_objective");

                entity.Property(e => e.IndexRankingNoteSubjective).HasColumnName("index_ranking_note_subjective");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.NoteMinimumConsider).HasColumnName("note_minimum_consider");

                entity.Property(e => e.Situation)
                    .HasMaxLength(15)
                    .HasColumnName("situation");

                entity.Property(e => e.TitleEmailPayment)
                    .HasMaxLength(45)
                    .HasColumnName("title_email_payment");

                entity.Property(e => e.TitleEmailRanking)
                    .HasMaxLength(45)
                    .HasColumnName("title_email_ranking");

                entity.Property(e => e.ValueMaxBonusAdditional).HasColumnName("value_max_bonus_additional");

                entity.Property(e => e.ValueMaxParticipation).HasColumnName("value_max_participation");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Cycles)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cycle_company1");

                entity.HasOne(d => d.IdCyclePreviousNavigation)
                    .WithMany(p => p.InverseIdCyclePreviousNavigation)
                    .HasForeignKey(d => d.IdCyclePrevious)
                    .HasConstraintName("fk_cycle_cycle1");
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdCollaborator })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("evaluation");

                entity.HasIndex(e => e.IdCollaborator, "fk_evaluation_collaborator1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.IdCycle, "fk_evaluation_cycle1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.IdRankingFirstRound, "fk_evaluation_type_ranking1_idx");

                entity.HasIndex(e => e.IdRankingMondayRound, "fk_evaluation_type_ranking2_idx");

                entity.HasIndex(e => e.IdRankingFinal, "fk_evaluation_type_ranking3_idx");

                entity.HasIndex(e => e.IdRankingDivisionBonus, "fk_evaluation_type_ranking4_idx");

                entity.HasIndex(e => e.IdEvaluatorFirstRound, "fk_evaluation_user1_idx");

                entity.HasIndex(e => e.IdEvaluatorDivisionBonus, "fk_evaluation_user2_idx");

                entity.HasIndex(e => e.IdEvaluatorMondayRound, "fk_evaluation_user3_idx");

                entity.HasIndex(e => e.IdEvaluatorFinal, "fk_evaluation_user4_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCollaborator).HasColumnName("id_collaborator");

                entity.Property(e => e.BaseValueReference).HasColumnName("base_value_reference");

                entity.Property(e => e.DateConclusionDivisionBonus)
                    .HasColumnType("datetime")
                    .HasColumnName("date_conclusion_division_bonus");

                entity.Property(e => e.DateConclusionFirstRoad)
                    .HasColumnType("datetime")
                    .HasColumnName("date_conclusion_first_road");

                entity.Property(e => e.DateConclusionMondayRound)
                    .HasColumnType("datetime")
                    .HasColumnName("date_conclusion_monday_round");

                entity.Property(e => e.DateEvaluationFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("date_evaluation_final");

                entity.Property(e => e.DiscountBonus).HasColumnName("discount_bonus");

                entity.Property(e => e.Evaluationcol)
                    .HasMaxLength(45)
                    .HasColumnName("evaluationcol");

                entity.Property(e => e.IdCycle).HasColumnName("id_cycle");

                entity.Property(e => e.IdEvaluatorDivisionBonus).HasColumnName("id_evaluator_division_bonus");

                entity.Property(e => e.IdEvaluatorFinal).HasColumnName("id_evaluator_final");

                entity.Property(e => e.IdEvaluatorFirstRound).HasColumnName("id_evaluator_first_round");

                entity.Property(e => e.IdEvaluatorMondayRound).HasColumnName("id_evaluator_monday_round");

                entity.Property(e => e.IdRankingDivisionBonus).HasColumnName("id_ranking_division_bonus");

                entity.Property(e => e.IdRankingFinal).HasColumnName("id_ranking_final");

                entity.Property(e => e.IdRankingFirstRound).HasColumnName("id_ranking_first_round");

                entity.Property(e => e.IdRankingMondayRound).HasColumnName("id_ranking_monday_round");

                entity.Property(e => e.Justification)
                    .HasMaxLength(1000)
                    .HasColumnName("justification");

                entity.Property(e => e.MultipleWage).HasColumnName("multiple_wage");

                entity.Property(e => e.NoteFinal).HasColumnName("note_final");

                entity.Property(e => e.NoteIndividual).HasColumnName("note_individual");

                entity.Property(e => e.NoteObjective).HasColumnName("note_objective");

                entity.Property(e => e.NoteRanking).HasColumnName("note_ranking");

                entity.Property(e => e.NoteSubjective1DivisionBonus).HasColumnName("note_subjective_1_division_bonus");

                entity.Property(e => e.NoteSubjective1Final).HasColumnName("note_subjective_1_final");

                entity.Property(e => e.NoteSubjective1MondayRound).HasColumnName("note_subjective_1_monday_round");

                entity.Property(e => e.NoteSubjective2DivisionBonus).HasColumnName("note_subjective_2_division_bonus");

                entity.Property(e => e.NoteSubjective2Final).HasColumnName("note_subjective_2_final");

                entity.Property(e => e.NoteSubjective2MondayRound).HasColumnName("note_subjective_2_monday_round");

                entity.Property(e => e.PositionRankingDivisionBonus).HasColumnName("position_ranking_division_bonus");

                entity.Property(e => e.PositionRankingFinal).HasColumnName("position_ranking_final");

                entity.Property(e => e.PositionRankingFirstRound).HasColumnName("position_ranking_first_round");

                entity.Property(e => e.PositionRankingMondayRound).HasColumnName("position_ranking_monday_round");

                entity.Property(e => e.SituationDivisionBonus)
                    .HasMaxLength(15)
                    .HasColumnName("situation_division_bonus")
                    .HasDefaultValueSql("'no-started'");

                entity.Property(e => e.SituationFinal)
                    .HasMaxLength(15)
                    .HasColumnName("situation_final")
                    .HasDefaultValueSql("'simulation'");

                entity.Property(e => e.SituationFirstRound)
                    .HasMaxLength(15)
                    .HasColumnName("situation_first_round")
                    .HasDefaultValueSql("'no-started'");

                entity.Property(e => e.SituationMondayRound)
                    .HasMaxLength(15)
                    .HasColumnName("situation_monday_round")
                    .HasDefaultValueSql("'no-started'");

                entity.Property(e => e.ValueBonusClaculated).HasColumnName("value_bonus_claculated");

                entity.Property(e => e.ValueBonusFinal).HasColumnName("value_bonus_final");

                entity.HasOne(d => d.IdCollaboratorNavigation)
                    .WithOne(p => p.Evaluation)
                    .HasForeignKey<Evaluation>(d => d.IdCollaborator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluation_collaborator1");

                entity.HasOne(d => d.IdCycleNavigation)
                    .WithOne(p => p.Evaluation)
                    .HasForeignKey<Evaluation>(d => d.IdCycle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluation_cycle1");

                entity.HasOne(d => d.IdEvaluatorDivisionBonusNavigation)
                    .WithMany(p => p.EvaluationIdEvaluatorDivisionBonusNavigations)
                    .HasForeignKey(d => d.IdEvaluatorDivisionBonus)
                    .HasConstraintName("fk_evaluation_user2");

                entity.HasOne(d => d.IdEvaluatorFinalNavigation)
                    .WithMany(p => p.EvaluationIdEvaluatorFinalNavigations)
                    .HasForeignKey(d => d.IdEvaluatorFinal)
                    .HasConstraintName("fk_evaluation_user4");

                entity.HasOne(d => d.IdEvaluatorFirstRoundNavigation)
                    .WithMany(p => p.EvaluationIdEvaluatorFirstRoundNavigations)
                    .HasForeignKey(d => d.IdEvaluatorFirstRound)
                    .HasConstraintName("fk_evaluation_user1");

                entity.HasOne(d => d.IdEvaluatorMondayRoundNavigation)
                    .WithMany(p => p.EvaluationIdEvaluatorMondayRoundNavigations)
                    .HasForeignKey(d => d.IdEvaluatorMondayRound)
                    .HasConstraintName("fk_evaluation_user3");

                entity.HasOne(d => d.IdRankingDivisionBonusNavigation)
                    .WithMany(p => p.EvaluationIdRankingDivisionBonusNavigations)
                    .HasForeignKey(d => d.IdRankingDivisionBonus)
                    .HasConstraintName("fk_evaluation_type_ranking4");

                entity.HasOne(d => d.IdRankingFinalNavigation)
                    .WithMany(p => p.EvaluationIdRankingFinalNavigations)
                    .HasForeignKey(d => d.IdRankingFinal)
                    .HasConstraintName("fk_evaluation_type_ranking3");

                entity.HasOne(d => d.IdRankingFirstRoundNavigation)
                    .WithMany(p => p.EvaluationIdRankingFirstRoundNavigations)
                    .HasForeignKey(d => d.IdRankingFirstRound)
                    .HasConstraintName("fk_evaluation_type_ranking1");

                entity.HasOne(d => d.IdRankingMondayRoundNavigation)
                    .WithMany(p => p.EvaluationIdRankingMondayRoundNavigations)
                    .HasForeignKey(d => d.IdRankingMondayRound)
                    .HasConstraintName("fk_evaluation_type_ranking2");
            });

            modelBuilder.Entity<EvaluationQuiz>(entity =>
            {
                entity.HasKey(e => new { e.EvaluationId, e.EvaluationIdCollaborator, e.QuizId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("evaluation_quiz");

                entity.HasIndex(e => new { e.EvaluationId, e.EvaluationIdCollaborator }, "fk_evaluation_has_quiz_evaluation1_idx");

                entity.HasIndex(e => e.QuizId, "fk_evaluation_has_quiz_quiz1_idx");

                entity.Property(e => e.EvaluationId).HasColumnName("evaluation_id");

                entity.Property(e => e.EvaluationIdCollaborator).HasColumnName("evaluation_id_collaborator");

                entity.Property(e => e.QuizId).HasColumnName("quiz_id");

                entity.Property(e => e.ValueResposta).HasColumnName("value_resposta");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.EvaluationQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluation_has_quiz_quiz1");

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.EvaluationQuizzes)
                    .HasForeignKey(d => new { d.EvaluationId, d.EvaluationIdCollaborator })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluation_has_quiz_evaluation1");
            });

            modelBuilder.Entity<GroupEvaluation>(entity =>
            {
                entity.ToTable("group_evaluation");

                entity.HasIndex(e => e.IdCycle, "fk_group_evaluation_cycle1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.IdProfileAccess, "fk_group_evaluation_profile_access1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser, "fk_group_evaluation_user1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.Module, "module_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdCycle).HasColumnName("id_cycle");

                entity.Property(e => e.IdProfileAccess).HasColumnName("id_profile_access");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("module");

                entity.HasOne(d => d.IdCycleNavigation)
                    .WithOne(p => p.GroupEvaluation)
                    .HasForeignKey<GroupEvaluation>(d => d.IdCycle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_evaluation_cycle1");

                entity.HasOne(d => d.IdProfileAccessNavigation)
                    .WithOne(p => p.GroupEvaluation)
                    .HasForeignKey<GroupEvaluation>(d => d.IdProfileAccess)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_evaluation_profile_access1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.GroupEvaluation)
                    .HasForeignKey<GroupEvaluation>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_evaluation_user1");
            });

            modelBuilder.Entity<GroupsEvaluation>(entity =>
            {
                entity.HasKey(e => new { e.IdGroupEvaluation, e.IdHierarchy })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("groups_evaluation");

                entity.HasIndex(e => e.IdGroupEvaluation, "fk_group_evaluation_has_hierarchy_group_evaluation1_idx");

                entity.HasIndex(e => e.IdHierarchy, "fk_group_evaluation_has_hierarchy_hierarchy1_idx");

                entity.Property(e => e.IdGroupEvaluation).HasColumnName("id_group_evaluation");

                entity.Property(e => e.IdHierarchy).HasColumnName("id_hierarchy");

                entity.HasOne(d => d.IdGroupEvaluationNavigation)
                    .WithMany(p => p.GroupsEvaluations)
                    .HasForeignKey(d => d.IdGroupEvaluation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_evaluation_has_hierarchy_group_evaluation1");

                entity.HasOne(d => d.IdHierarchyNavigation)
                    .WithMany(p => p.GroupsEvaluations)
                    .HasForeignKey(d => d.IdHierarchy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_evaluation_has_hierarchy_hierarchy1");
            });

            modelBuilder.Entity<Hierarchy>(entity =>
            {
                entity.ToTable("hierarchy");

                entity.HasIndex(e => e.Code, "code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdResponsible, "fk_hierarchy_collaborator1_idx");

                entity.HasIndex(e => e.IdCycle, "fk_hierarchy_cycle1_idx")
                    .IsUnique();

                entity.HasIndex(e => e.IdHierarchyPai, "fk_hierarchy_hierarchy1_idx");

                entity.HasIndex(e => e.IdTypeRanking, "fk_hierarchy_type-ranking_idx");

                entity.HasIndex(e => e.CodeTypeHierarchy, "fk_hierarchy_type_hierarchy1_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("code");

                entity.Property(e => e.CodeTypeHierarchy)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("code_type_hierarchy");

                entity.Property(e => e.IdCycle).HasColumnName("id_cycle");

                entity.Property(e => e.IdHierarchyPai).HasColumnName("id_hierarchy_pai");

                entity.Property(e => e.IdResponsible).HasColumnName("id_responsible");

                entity.Property(e => e.IdTypeRanking).HasColumnName("id_type_ranking");

                entity.Property(e => e.Premise)
                    .HasMaxLength(15)
                    .HasColumnName("premise");

                entity.Property(e => e.Situation)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("situation")
                    .HasDefaultValueSql("'Ativa'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.CodeTypeHierarchyNavigation)
                    .WithMany(p => p.Hierarchies)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.CodeTypeHierarchy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hierarchy_type_hierarchy1");

                entity.HasOne(d => d.IdCycleNavigation)
                    .WithOne(p => p.Hierarchy)
                    .HasForeignKey<Hierarchy>(d => d.IdCycle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hierarchy_cycle1");

                entity.HasOne(d => d.IdHierarchyPaiNavigation)
                    .WithMany(p => p.InverseIdHierarchyPaiNavigation)
                    .HasForeignKey(d => d.IdHierarchyPai)
                    .HasConstraintName("fk_hierarchy_hierarchy1");

                entity.HasOne(d => d.IdResponsibleNavigation)
                    .WithMany(p => p.Hierarchies)
                    .HasForeignKey(d => d.IdResponsible)
                    .HasConstraintName("fk_hierarchy_collaborator1");

                entity.HasOne(d => d.IdTypeRankingNavigation)
                    .WithMany(p => p.Hierarchies)
                    .HasForeignKey(d => d.IdTypeRanking)
                    .HasConstraintName("fk_hierarchy_type-ranking");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.HasIndex(e => e.Level, "key_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("area");

                entity.Property(e => e.IconMenu)
                    .HasMaxLength(500)
                    .HasColumnName("icon_menu");

                entity.Property(e => e.IconPage)
                    .HasMaxLength(500)
                    .HasColumnName("icon_page");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("permission");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("parameters");

                entity.HasIndex(e => e.Key, "key_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("key");

                entity.Property(e => e.TypeField)
                    .HasMaxLength(15)
                    .HasColumnName("type_field");

                entity.Property(e => e.Value)
                    .HasMaxLength(4000)
                    .HasColumnName("value");

                entity.Property(e => e.ValueSensitive)
                    .HasColumnName("value_sensitive")
                    .HasDefaultValueSql("'0'")
                    .HasComment("{true|false}");
            });

            modelBuilder.Entity<ProfileAccess>(entity =>
            {
                entity.ToTable("profile_access");

                entity.HasIndex(e => e.Code, "abbreviation_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Title, "title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("code");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("module");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("quiz");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("question");

                entity.Property(e => e.Sequence).HasColumnName("sequence");
            });

            modelBuilder.Entity<TypeHierarchy>(entity =>
            {
                entity.ToTable("type_hierarchy");

                entity.HasIndex(e => e.Code, "code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Title, "title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("code");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<TypeRanking>(entity =>
            {
                entity.ToTable("type_ranking");

                entity.HasIndex(e => e.Title, "code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AreaExecutive)
                    .HasMaxLength(100)
                    .HasColumnName("area_executive");

                entity.Property(e => e.Directory)
                    .HasMaxLength(100)
                    .HasColumnName("directory");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.LastAccess)
                    .HasColumnType("datetime")
                    .HasColumnName("last_access");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Office)
                    .HasMaxLength(100)
                    .HasColumnName("office");

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("registration");

                entity.Property(e => e.Situation)
                    .HasMaxLength(20)
                    .HasColumnName("situation");

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
