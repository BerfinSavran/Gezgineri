using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class MyTravelPlanRepository : GenericRepository<MyTravelPlan>, IMyTravelPlanRepository
    {
        private readonly AppDbContext _context;
        public MyTravelPlanRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyTravelPlan?>> GetMyTravelPlansByTravelIdAsync(Guid myTravelId)
        {
            return await _context.MyTravelPlans
                .Where(p => p.MyTravelId == myTravelId)
                .Include(p => p.Place)
                .ThenInclude(place => place.Category)
                .ToListAsync();
        }
    }
}
