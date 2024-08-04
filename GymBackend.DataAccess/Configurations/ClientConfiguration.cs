using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GymBackend.DataAccess.Entites;


namespace GymBackend.DataAccess.Configurations
{
	public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
		public void Configure(EntityTypeBuilder<ClientEntity> builder)
		{
			


            builder.HasKey(e => e.Id).HasName("client_pkey");

            builder.ToTable("client");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Birthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthday");
            builder.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            builder.Property(e => e.IdUser).HasColumnName("id_user");
            builder.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            builder.Property(e => e.Phone)
                .HasMaxLength(13)
                .HasColumnName("phone");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_id_user_fkey");

        }
	}
}

