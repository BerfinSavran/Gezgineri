using Gezgineri.Entity.Models;

namespace Gezgineri.Repository.Abstract
{
    public interface IMyTravelRepository : IGenericRepository<MyTravel>
    {
        public Task<IEnumerable<MyTravel>> GetMyTravelsByTravelerIdAsync(Guid travelerid);
    }
}
