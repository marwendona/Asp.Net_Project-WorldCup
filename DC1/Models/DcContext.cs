using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DC1.Models;

public partial class DcContext : DbContext
{
    public DcContext()
    {
    }

    public DcContext(DbContextOptions<DcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arbitre> Arbitres { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Stade> Stades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5MD2IBS\\MSSQLSERVER1;Database=DC;Integrated Security=True ; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arbitre>(entity =>
        {
            entity.HasKey(e => e.IdArbitre);

            entity.ToTable("Arbitre");

            entity.Property(e => e.NationaliteArbitre).HasMaxLength(50);
            entity.Property(e => e.NomArbitre).HasMaxLength(50);
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.IdEquipe);

            entity.ToTable("Equipe");

            entity.Property(e => e.Groupe).HasMaxLength(50);
            entity.Property(e => e.NomEquipe).HasMaxLength(50);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.IdMatch);

            entity.ToTable("Match");

            entity.HasOne(d => d.IdArbitreNavigation).WithMany(p => p.Matches)
                .HasForeignKey(d => d.IdArbitre)
                .HasConstraintName("FK_Match_Arbitre");

            entity.HasOne(d => d.IdEquipeANavigation).WithMany(p => p.MatchIdEquipeANavigations)
                .HasForeignKey(d => d.IdEquipeA)
                .HasConstraintName("FK_Match_EquipeA");

            entity.HasOne(d => d.IdEquipeBNavigation).WithMany(p => p.MatchIdEquipeBNavigations)
                .HasForeignKey(d => d.IdEquipeB)
                .HasConstraintName("FK_Match_EquipeB");

            entity.HasOne(d => d.IdStadeNavigation).WithMany(p => p.Matches)
                .HasForeignKey(d => d.IdStade)
                .HasConstraintName("FK_Match_Stade");
        });

        modelBuilder.Entity<Stade>(entity =>
        {
            entity.HasKey(e => e.IdStade);

            entity.ToTable("Stade");

            entity.Property(e => e.NomStade).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
