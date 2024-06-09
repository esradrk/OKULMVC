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
    }
}
