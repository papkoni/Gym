using System;
using System.Collections.Generic;
using GymBackend.DataAccess.Configurations;
using GymBackend.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.DataAccess;

public partial class CourseworkContext : DbContext
{
    public CourseworkContext()
    {
    }

    public CourseworkContext(DbContextOptions<CourseworkContext> options)
        : base(options)
    {
    }


    public virtual DbSet<ClientEntity> Clients { get; set; }

    public virtual DbSet<CoachEntity> Coaches { get; set; }

    public virtual DbSet<ProgressEntity> Progresses { get; set; }

    public virtual DbSet<PurchaseHistoryEntity> PurchaseHistories { get; set; }

    public virtual DbSet<RegistrationEntity> Registrations { get; set; }

    public virtual DbSet<ScheduleGroupEntity> ScheduleGroups { get; set; }

    public virtual DbSet<SubscriptionEntity> Subscriptions { get; set; }

    public virtual DbSet<UserEntity> Users { get; set; }

    public virtual DbSet<VisitEntity> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("file_fdw")
            .HasPostgresExtension("pgcrypto");

        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new CoachConfiguration());
        modelBuilder.ApplyConfiguration(new ProgressConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleGroupConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new VisitConfiguration());


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



}
