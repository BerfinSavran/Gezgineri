using Gezgineri.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MyTravel> MyTravels { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourRoute> TourRoutes { get; set; }
        public DbSet<MyTravelPlan> MyTravelPlans { get; set; }
        public DbSet<FavoritePlace> FavoritePlaces { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TravelPlan - MyTravel ilişkisi
            modelBuilder.Entity<MyTravelPlan>()
                .HasOne(tp => tp.MyTravel)
                .WithMany()
                .HasForeignKey(tp => tp.MyTravelId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Member>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<FavoritePlace>()
                .HasOne(fp => fp.Place)
                .WithMany() // Eğer Place içinde FavoritePlaces koleksiyonu yoksa
                .HasForeignKey(fp => fp.PlaceId)
                .OnDelete(DeleteBehavior.NoAction); // Burada silme davranışını engelliyoruz

            modelBuilder.Entity<FavoritePlace>()
                .HasOne(fp => fp.Traveler)
                .WithMany() // Eğer Traveler içinde FavoritePlaces koleksiyonu yoksa
                .HasForeignKey(fp => fp.TravelerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
