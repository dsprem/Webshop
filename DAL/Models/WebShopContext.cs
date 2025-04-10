using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class WebShopContext : DbContext
{
    public WebShopContext()
    {
    }

    public WebShopContext(DbContextOptions<WebShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategorije> Kategorije { get; set; }

    public virtual DbSet<KategorijeProizvodi> KategorijeProizvodi { get; set; }

    public virtual DbSet<Korisnici> Korisnici { get; set; }

    public virtual DbSet<MjereProizvoda> MjereProizvoda { get; set; }

    public virtual DbSet<Narudzbe> Narudzbe { get; set; }

    public virtual DbSet<NarudzbeDetalji> NarudzbeDetalji { get; set; }

    public virtual DbSet<Proizvodi> Proizvodi { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WINDOWS-OC48PJE;Database=WebShop;User Id=sa;Password=sqlsifra;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategorije>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Naziv).HasMaxLength(50);
            entity.Property(e => e.Opis).HasMaxLength(500);
        });

        modelBuilder.Entity<KategorijeProizvodi>(entity =>
        {
            entity.HasOne(d => d.Kategorija).WithMany(p => p.KategorijeProizvodi)
                .HasForeignKey(d => d.KategorijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KategorijeProizvodi_Kategorije");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.KategorijeProizvodi)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KategorijeProizvodi_Proizvodi");
        });

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Korisnik");

            entity.Property(e => e.AdresaDostave).HasMaxLength(250);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Kontakt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prezime).HasMaxLength(50);
        });

        modelBuilder.Entity<MjereProizvoda>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Naziv).HasMaxLength(10);
        });

        modelBuilder.Entity<Narudzbe>(entity =>
        {
            entity.Property(e => e.DatumKreiranja)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DatumVrijemeDostave).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Narudzbe)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Narudzbe_Korisnici");
        });

        modelBuilder.Entity<NarudzbeDetalji>(entity =>
        {
            entity.Property(e => e.JedCijena).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Kolicina).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Narudzba).WithMany(p => p.NarudzbeDetalji)
                .HasForeignKey(d => d.NarudzbaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NarudzbeDetalji_Narudzbe");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.NarudzbeDetalji)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NarudzbeDetalji_Proizvodi");
        });

        modelBuilder.Entity<Proizvodi>(entity =>
        {
            entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Dostupan).HasDefaultValue(true);
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VrijemeKreiranja)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MjeraProizvoda).WithMany(p => p.Proizvodi)
                .HasForeignKey(d => d.MjeraProizvodaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proizvodi_MjereProizvoda");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
