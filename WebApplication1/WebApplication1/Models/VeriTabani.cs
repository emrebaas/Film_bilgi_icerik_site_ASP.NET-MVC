namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VeriTabani : DbContext
    {
        public VeriTabani()
            : base("name=VeriTabani")
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Gelecek> Geleceks { get; set; }
        public virtual DbSet<Haber> Habers { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kullanıcı> Kullanıcı { get; set; }
        public virtual DbSet<Vizyon> Vizyons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(e => e.film_adi)
                .IsFixedLength();

            modelBuilder.Entity<Film>()
                .Property(e => e.film_yil)
                .IsFixedLength();

            modelBuilder.Entity<Gelecek>()
                .Property(e => e.gelecek_tarih)
                .IsFixedLength();

            modelBuilder.Entity<Kategori>()
                .Property(e => e.kategori_adi)
                .IsFixedLength();

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Films)
                .WithRequired(e => e.Kategori)
                .HasForeignKey(e => e.film_kategori_id);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Vizyons)
                .WithRequired(e => e.Kategori)
                .HasForeignKey(e => e.vizyon_film_kategori);

            modelBuilder.Entity<Vizyon>()
                .Property(e => e.vizyon_tarih)
                .IsFixedLength();
        }
    }
}
