using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBackend.DataAccess.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.HasKey(e => e.Id).HasName("user_pkey");

            builder.ToTable("user");

            builder.HasIndex(e => e.Login, "unique_login").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            builder.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        }
    }
}

