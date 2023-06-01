using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace naosei.Model;

public partial class TestentityContext : DbContext
{
    public TestentityContext()
    {
    }

    public TestentityContext(DbContextOptions<TestentityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ofertum> Oferta { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013D\\SQLEXPRESS;Initial Catalog=testentity;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ofertum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Oferta__3214EC272AAED1E1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.ProdutoNavigation).WithMany(p => p.Oferta)
                .HasForeignKey(d => d.Produto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Oferta__Produto__286302EC");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Oferta)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Oferta__Usuario__29572725");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC272DBEA157");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.Foto).HasColumnType("image");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC273D0655C3");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Foto).HasColumnType("image");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
