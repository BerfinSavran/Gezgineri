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
        public DbSet<TravelPlanPlace> TravelPlanPlaces { get; set; }
        public DbSet<MyTravel> MyTravels { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourRoute> TourRoutes { get; set; }
        public DbSet<TravelPlan> TravelPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TravelPlan - MyTravel ilişkisi
            modelBuilder.Entity<TravelPlan>()
                .HasOne(tp => tp.MyTravel)
                .WithMany()
                .HasForeignKey(tp => tp.MyTravelId)
                .OnDelete(DeleteBehavior.Restrict);

            // TravelPlanPlace - TravelPlan ilişkisi
            modelBuilder.Entity<TravelPlanPlace>()
                .HasOne(tpp => tpp.TravelPlan)
                .WithMany()
                .HasForeignKey(tpp => tpp.TravelPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // TravelPlanPlace - Place ilişkisi
            modelBuilder.Entity<TravelPlanPlace>()
                .HasOne(tpp => tpp.Place)
                .WithMany()
                .HasForeignKey(tpp => tpp.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Member>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }
    }
}
