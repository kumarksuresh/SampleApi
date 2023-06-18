using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleApi.Data;

public partial class InsuredInfoContext : DbContext
{   

    public InsuredInfoContext(DbContextOptions<InsuredInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Insured> Insureds { get; set; }

    public virtual DbSet<PolicyInfo> PolicyInfos { get; set; }

    public virtual DbSet<PolicyType> PolicyTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Insured>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insured__3214EC07C6BF608E");

            entity.ToTable("Insured");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<PolicyInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyIn__3214EC070C99A1AC");

            entity.ToTable("PolicyInfo");

            entity.Property(e => e.PolicyEndDate).HasColumnType("date");
            entity.Property(e => e.PolicyNumber).HasMaxLength(20);
            entity.Property(e => e.PolicyStartDate).HasColumnType("date");
            entity.Property(e => e.PremiumAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PolicyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyTy__3214EC07950CBC85");

            entity.ToTable("PolicyType");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TypeName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
