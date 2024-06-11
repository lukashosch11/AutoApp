using System;
using System.Collections.Generic;
using AutoWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoWebApp.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<Autokategorie> Autokategories { get; set; }

    public virtual DbSet<Kunde> Kundes { get; set; }

    public virtual DbSet<Verkauf> Verkaufs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-fancy-feather-a2u5wux0.eu-central-1.aws.neon.tech;username=autodb_owner;Password=A9fzsldhV7PY;Database=autodb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.Autoid).HasName("auto_pkey");

            entity.ToTable("auto");

            entity.Property(e => e.Autoid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("autoid");
            entity.Property(e => e.Baujahr).HasColumnName("baujahr");
            entity.Property(e => e.Kategorienid).HasColumnName("kategorienid");
            entity.Property(e => e.Marke)
                .HasMaxLength(32)
                .HasColumnName("marke");
            entity.Property(e => e.Modell)
                .HasMaxLength(32)
                .HasColumnName("modell");
            entity.Property(e => e.Preis).HasColumnName("preis");
        });

        modelBuilder.Entity<Autokategorie>(entity =>
        {
            entity.HasKey(e => e.Kategorienid).HasName("autokategorie_pkey");

            entity.ToTable("autokategorie");

            entity.Property(e => e.Kategorienid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("kategorienid");
            entity.Property(e => e.Bezeichnung)
                .HasMaxLength(64)
                .HasColumnName("bezeichnung");
        });

        modelBuilder.Entity<Kunde>(entity =>
        {
            entity.HasKey(e => e.Kundenid).HasName("kunde_pkey");

            entity.ToTable("kunde");

            entity.Property(e => e.Kundenid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("kundenid");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
            entity.Property(e => e.Nachname)
                .HasMaxLength(64)
                .HasColumnName("nachname");
            entity.Property(e => e.Postleitzahl).HasColumnName("postleitzahl");
            entity.Property(e => e.Straße)
                .HasMaxLength(64)
                .HasColumnName("straße");
            entity.Property(e => e.Vorname)
                .HasMaxLength(64)
                .HasColumnName("vorname");
            entity.Property(e => e.Wohnort)
                .HasMaxLength(64)
                .HasColumnName("wohnort");
        });

        modelBuilder.Entity<Verkauf>(entity =>
        {
            entity.HasKey(e => e.Verkaufsid).HasName("verkauf_pkey");

            entity.ToTable("verkauf");

            entity.Property(e => e.Verkaufsid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("verkaufsid");
            entity.Property(e => e.Autoid).HasColumnName("autoid");
            entity.Property(e => e.Kundenid).HasColumnName("kundenid");
            entity.Property(e => e.Verkaufsdatum).HasColumnName("verkaufsdatum");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
