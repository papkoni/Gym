using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class ProgressConfiguration : IEntityTypeConfiguration<ProgressEntity>
    {
        public void Configure(EntityTypeBuilder<ProgressEntity> builder)
        {



            builder.HasKey(e => e.Id).HasName("progress_pkey");

            builder.ToTable("progress");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            builder.Property(e => e.HipArm).HasColumnName("hip_arm");
            builder.Property(e => e.HipChest).HasColumnName("hip_chest");
            builder.Property(e => e.HipGirth).HasColumnName("hip_girth");
            builder.Property(e => e.IdClient).HasColumnName("id_client");
            builder.Property(e => e.Weight).HasColumnName("weight");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("progress_id_client_fkey");

        }
    }
}


