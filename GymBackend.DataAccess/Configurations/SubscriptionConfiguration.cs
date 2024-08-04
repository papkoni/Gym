using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class SubscriptionConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
    {
        public void Configure(EntityTypeBuilder<SubscriptionEntity> builder)
        {

            builder.HasKey(e => e.Id).HasName("subscription_pkey");

            builder.ToTable("subscription");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Price).HasColumnName("price");
            builder.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        }
    }
}

