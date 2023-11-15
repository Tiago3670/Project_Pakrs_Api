using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ParkApi.model;

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
                .HasOne(p => p.FeaturesID);

            modelBuilder.Entity<Parks>()
            .HasOne(p => p.LocationID);

          
            modelBuilder.Entity<Favourites>().HasNoKey();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<LocationDetail> locationDetails { get; set; }
        public DbSet<FeaturesList> featuresLists { get; set; }
        public DbSet<Parks> parks { get; set; }
        public DbSet<Favourites> favourites { get; set; }

    }
}
