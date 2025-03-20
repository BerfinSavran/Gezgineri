using Gezgineri.Entity.Models;

namespace Gezgineri.Repository.Abstract
{
    public interface ITourRouteRepository : IGenericRepository<TourRoute>
    {
        public Task<IEnumerable<TourRoute>> GetTourRoutesByTourIdAsync(Guid tourId);

    }
}
