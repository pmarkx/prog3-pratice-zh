using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhprobalkozas.ZH.DataLoader;
using zhprobalkozas.ZH.Entities;

namespace zhprobalkozas.ZH.Data
{
    public class AircraftContext:DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AircraftDB.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(x=>x
                .HasOne(y=>y.Planes)
                .WithMany(z=>z.Orders)
                .HasForeignKey(y=>y.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                );
            Loader loader = new Loader("data.xml");
            modelBuilder.Entity<Plane>().HasData(loader.LoadPlanes());
            modelBuilder.Entity<Order>().HasData(loader.LoadOrders());

        }
        public AircraftContext()
        {
            Database.EnsureCreated();
        }
    }
}
