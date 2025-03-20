using Gezgineri.Data;
using Gezgineri.Data.Migrations;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class MyTravelRepository : GenericRepository<MyTravel>, IMyTravelRepository
    {
        private readonly AppDbContext _context;
        public MyTravelRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyTravel>> GetMyTravelsByTravelerIdAsync(Guid travelerid)
        {
            return await _context.MyTravels
                .Where(mt => mt.TravelerId == travelerid)
                .ToListAsync();
        }

    }
}
