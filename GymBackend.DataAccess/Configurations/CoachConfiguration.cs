using System;
using GymBackend.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class CoachConfiguration : IEntityTypeConfiguration<CoachEntity>
    {
        public void Configure(EntityTypeBuilder<CoachEntity> builder)
        {



            builder.HasKey(e => e.Id).HasName("coach_pkey");

            builder.ToTable("coach");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.HiringDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("hiring_date");
            builder.Property(e => e.IdUser).HasColumnName("id_user");
            builder.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            builder.Property(e => e.Qualification)
                .HasMaxLength(50)
                .HasColumnName("qualification");
            builder.Property(e => e.TerminationDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("termination_date");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("coach_id_user_fkey");

        }
    }
}

