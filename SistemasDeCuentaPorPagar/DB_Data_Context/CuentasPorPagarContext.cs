using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemasDeCuentaPorPagar.DB_Data_Context;

public partial class CuentasPorPagarContext : DbContext
{
    public CuentasPorPagarContext()
    {
    }

    public CuentasPorPagarContext(DbContextOptions<CuentasPorPagarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=MSORIANO-LT\\SQLEXPRESS02; Database=Cuentas_por_pagar; TrustServerCertificate=True; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC0756E51E2F");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.InvoiceNumber, "UQ__Invoice__EA97382581935F7C").IsUnique();

            entity.Property(e => e.ExpirationDate).HasColumnName("Expiration_date");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Invoice_number");
            entity.Property(e => e.IssueDate).HasColumnName("Issue_date");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_amount");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC07DE6B9CFD");

            entity.ToTable("Payment");

            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_id");
            entity.Property(e => e.PaidAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Paid_amount");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_method");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC072A7AE469");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.RncCedula, "UQ__Supplier__51A719023F2BF453").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RncCedula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rnc_cedula");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
