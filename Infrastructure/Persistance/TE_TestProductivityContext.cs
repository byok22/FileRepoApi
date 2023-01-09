using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Infrastructure.Persistance;

public partial class TE_TestProductivityContext : DbContext
{
    public TE_TestProductivityContext()
    {
    }

    public TE_TestProductivityContext(DbContextOptions<TE_TestProductivityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CtCustomer> CtCustomers { get; set; }

    public virtual DbSet<CtSubCustomer> CtSubCustomers { get; set; }

    public virtual DbSet<ScUser> ScUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AWUEA1GDLSQL41;Database=TE_TestProductivity;Trusted_Connection=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtCustomer>(entity =>
        {
            entity.HasKey(e => e.PkCustomer);

            entity.ToTable("CT_Customers");

            entity.Property(e => e.PkCustomer).HasColumnName("PK_Customer");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FkbuildingId).HasColumnName("FKBuildingID");
            entity.Property(e => e.FkdivisionId).HasColumnName("FKDivisionID");
            entity.Property(e => e.FkmesCustomerId).HasColumnName("FKMesCustomerID");
            entity.Property(e => e.FkserverMesid).HasColumnName("FKServerMESID");
            entity.Property(e => e.Server)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ServerReporting)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CtSubCustomer>(entity =>
        {
            entity.HasKey(e => e.PksubCustomerId);

            entity.ToTable("CT_SubCustomers");

            entity.Property(e => e.PksubCustomerId).HasColumnName("PKSubCustomerID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkcustomerId).HasColumnName("FKCustomerID");
            entity.Property(e => e.SubCustomerName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ScUser>(entity =>
        {
            entity.HasKey(e => e.PkuserId);

            entity.ToTable("SC_Users");

            entity.Property(e => e.PkuserId).HasColumnName("PKUserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FkmesUserId).HasColumnName("FKMesUserID");
            entity.Property(e => e.FkroleId).HasColumnName("FKRoleID");
            entity.Property(e => e.LastName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Ntuser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NTUser");
            entity.Property(e => e.SecondLastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
