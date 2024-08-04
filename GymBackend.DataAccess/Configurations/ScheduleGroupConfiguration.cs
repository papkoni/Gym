using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class ScheduleGroupConfiguration : IEntityTypeConfiguration<ScheduleGroupEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleGroupEntity> builder)
        {

            builder.HasKey(e => e.Id).HasName("schedule_group_pkey");

            builder.ToTable("schedule_group");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            builder.Property(e => e.IdCoach).HasColumnName("id_coach");
            builder.Property(e => e.MaxPeople).HasColumnName("max_people");
            builder.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            builder.Property(e => e.TypeOfTraining)
                .HasMaxLength(50)
                .HasColumnName("type_of_training");

            builder.HasOne(d => d.IdCoachNavigation).WithMany(p => p.ScheduleGroups)
                .HasForeignKey(d => d.IdCoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_group_id_coach_fkey");
        }
    }
}

