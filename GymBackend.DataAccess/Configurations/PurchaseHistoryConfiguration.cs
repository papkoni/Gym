using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class PurchaseHistoryConfiguration : IEntityTypeConfiguration<PurchaseHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseHistoryEntity> builder)
        {



            builder.HasKey(e => e.Id).HasName("purchase_history_pkey");

            builder.ToTable("purchase_history");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            builder.Property(e => e.IdClient).HasColumnName("id_client");
            builder.Property(e => e.IdSubscription).HasColumnName("id_subscription");
            builder.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.PurchaseHistories)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_history_id_client_fkey");

            builder.HasOne(d => d.IdSubscriptionNavigation).WithMany(p => p.PurchaseHistories)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_history_id_subscription_fkey");

        }
    }
}

