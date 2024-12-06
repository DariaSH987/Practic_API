using System;
using System.Collections.Generic;
using Confectioner.Model;
using Microsoft.EntityFrameworkCore;

namespace Confectioner;

public partial class Prd2Context : DbContext
{
    public Prd2Context()
    {
    }

    public Prd2Context(DbContextOptions<Prd2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Assortment> Assortments { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=44-7\\SQLEXPRESS;Database=prd2;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assortment>(entity =>
        {
            entity.HasKey(e => e.IdAssortment);

            entity.ToTable("Assortment");

            entity.Property(e => e.IdAssortment).HasColumnName("id_assortment");
            entity.Property(e => e.Decor).HasMaxLength(50);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("Product_name");
            entity.Property(e => e.Stuffing).HasMaxLength(50);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Assortments)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assortment_Suppliers");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrders);

            entity.Property(e => e.IdOrders).HasColumnName("id_orders");
            entity.Property(e => e.DataOrder).HasColumnName("Data_order");
            entity.Property(e => e.DateOfIssue).HasColumnName("Date_of_issue");

            entity.HasOne(d => d.Assortment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AssortmentId)
                .HasConstraintName("FK_Orders_Assortment");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Orders_Clients");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSuppliers).HasName("PK_Supplier");

            entity.Property(e => e.IdSuppliers).HasColumnName("id_suppliers");
            entity.Property(e => e.Goods).HasMaxLength(50);
            entity.Property(e => e.SuppliersName)
                .HasMaxLength(50)
                .HasColumnName("Suppliers_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
