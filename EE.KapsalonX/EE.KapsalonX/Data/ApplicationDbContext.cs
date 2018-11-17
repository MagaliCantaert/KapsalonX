using System;
using System.Collections.Generic;
using System.Text;
using EE.KapsalonX.Domain.Afspraken;
using EE.KapsalonX.Domain.Kalender;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EE.KapsalonX.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Behandeling> Behandelingen { get; set; }
        public DbSet<Afspraak> Afspraken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klant>()
                .HasKey(e => e.KlantId);
            modelBuilder.Entity<Klant>()
                .Property(e => e.Voornaam)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Klant>()
                .Property(e => e.Achternaam)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Klant>()
                .Property(e => e.Emailadres)
                .IsRequired();
            modelBuilder.Entity<Klant>()
                .Property(e => e.Telefoonnummer)
                .IsRequired();
            modelBuilder.Entity<Klant>()
                .HasMany(e => e.Afspraken)
                .WithOne(p => p.KlantGegevens)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Behandeling>()
                .HasKey(e => e.BehandelingId);
            modelBuilder.Entity<Behandeling>()
                .Property(e => e.Geslacht);
            modelBuilder.Entity<Behandeling>()
                .Property(e => e.GekozenBehandeling);

            modelBuilder.Entity<Afspraak>()
                .HasKey(e => e.AfspraakId);
            modelBuilder.Entity<Afspraak>()
                .Property(e => e.Datum)
                .IsRequired();
            
            modelBuilder.Entity<Afspraak>()
                .Property(e => e.Tijdstip)
                .IsRequired();
            modelBuilder.Entity<Afspraak>()
                .Property(e => e.Opmerking)
                .HasMaxLength(300);
            modelBuilder.Entity<Afspraak>()
                .HasOne(e => e.KlantGegevens)
                .WithMany(p => p.Afspraken)
                .HasForeignKey(p => p.AfspraakId);
            modelBuilder.Entity<Afspraak>()
                .HasOne(e => e.BehandelingGegevens);

            base.OnModelCreating(modelBuilder);
        }

    }


}
