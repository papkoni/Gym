using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class VisitConfiguration : IEntityTypeConfiguration<VisitEntity>
    {
        public void Configure(EntityTypeBuilder<VisitEntity> builder)
        {

            builder.HasKey(e => e.Id).HasName("visit_pkey");

            builder.ToTable("visit");

            builder.HasIndex(e => e.StartDate, "idx_visit_start_date");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            builder.Property(e => e.IdClient).HasColumnName("id_client");
            builder.Property(e => e.IdScheduleGroup).HasColumnName("id_schedule_group");
            builder.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_id_client_fkey");

            builder.HasOne(d => d.IdScheduleGroupNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdScheduleGroup)
                .HasConstraintName("visit_id_schedule_group_fkey");
        }
    }
}

