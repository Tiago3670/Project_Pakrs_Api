using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ParkApi.model;
using System.Reflection.Metadata;

namespace ParkApi.Data
{
    public class AppDbContext :DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
           

            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parks>()
              .HasOne(e => e.Location)
              .WithOne()
              .HasForeignKey<LocationDetail>(e => e.LocationId)
              .IsRequired();
           
            modelBuilder.Entity<Parks>()
             .HasOne(e => e.Features)
             .WithOne()
             .HasForeignKey<FeaturesList>(e => e.FeaturesId)
             .IsRequired();
            
            modelBuilder.Entity<Favourites>().HasNoKey();

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<LocationDetail> LocationDetail { get; set; }
        public DbSet<FeaturesList> FeaturesList { get; set; }
        public DbSet<Parks> Parks { get; set; }
        public DbSet<Favourites> Favourites { get; set; }

    }
}
