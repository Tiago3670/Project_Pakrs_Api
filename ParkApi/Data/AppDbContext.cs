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
        .HasOne(p => p.FeaturesID)  // Assuming FeaturesList is the navigation property in Parks
        .WithMany()
        .HasForeignKey(p => p.FeaturesID)
        .OnDelete(DeleteBehavior.Restrict);  // Choose the appropriate delete behavior

            modelBuilder.Entity<Parks>()
                .HasOne(p => p.LocationID)  // Assuming LocationDetail is the navigation property in Parks
                .WithMany()
                .HasForeignKey(p => p.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favourites>().HasNoKey();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<LocationDetail> LocationDetail { get; set; }
        public DbSet<FeaturesList> FeaturesList { get; set; }
        public DbSet<Parks> Parks { get; set; }
        public DbSet<Favourites> Favourites { get; set; }

    }
}
