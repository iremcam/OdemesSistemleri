using EL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;Database=OdemeSistemleri;Uid=sa;Pwd=1234;Encrypt=true;TrustServerCertificate=true;");
            }
        }
        public DbSet<Faturalar> Faturalar { get; set; }
        public DbSet<Hesaplar> HesapBilgileri { get; set; }
        public DbSet<IslemGecmisi> IslemGecmisi { get; set; }
        public DbSet<Kullanicilar> Kullanici { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faturalar>()
                .HasOne(f => f.Hesaplar)
                .WithMany(u => u.Faturalar)
                .HasForeignKey(f => f.HesapId);
            modelBuilder.Entity<IslemGecmisi>()
                .HasOne(h => h.Hesaplar).WithMany(a => a.IslemGecmis).HasForeignKey(h => h.HesapNumarasi);
            modelBuilder.Entity<IslemGecmisi>()
            .HasOne(h => h.Hesaplar).WithMany(a => a.IslemGecmis).HasForeignKey(h => h.HesapNumarasi2);
            modelBuilder.Entity<Hesaplar>()
                .HasOne(a => a.Kullanicilar).WithMany(a => a.Hesaplar).HasForeignKey(b => b.KullaniciId);


        }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectContext>
        {
            public ProjectContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;Database=OdemeSistemleri;User Id=sa;Password=1234;");

                return new ProjectContext(optionsBuilder.Options);
            }
        }
    }
}
