using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class RegistrationConfiguration : IEntityTypeConfiguration<RegistrationEntity>
    {
        public void Configure(EntityTypeBuilder<RegistrationEntity> builder)
        {

            builder.HasKey(e => e.Id).HasName("registration_pkey");

            builder.ToTable("registration");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Deleted)
                .HasDefaultValueSql("false")
                .HasColumnName("deleted");
            builder.Property(e => e.FromDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("from_date");
            builder.Property(e => e.IdClient).HasColumnName("id_client");
            builder.Property(e => e.IdScheduleGroup).HasColumnName("id_schedule_group");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_id_client_fkey");

            builder.HasOne(d => d.IdScheduleGroupNavigation).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.IdScheduleGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_id_schedule_group_fkey");
        }
    }
}

