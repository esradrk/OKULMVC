using Microsoft.EntityFrameworkCore;
using OKULMVC.Models;

namespace OKULMVC
{
    public class OkulDbcontext: DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<DersOgrenci> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=OkulDbSube2Bil;Integrated Security=true; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("Ogrenciler");
            modelBuilder.Entity<Ders>().ToTable("Dersler");
            modelBuilder.Entity<DersOgrenci>().ToTable("StudentCourses");

            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Ders>().Property(o => o.Dersad).HasColumnType("varchar").HasMaxLength(15).IsRequired();

        }
    }
}
