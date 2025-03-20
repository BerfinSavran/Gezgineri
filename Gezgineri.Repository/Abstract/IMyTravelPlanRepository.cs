using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Repository.Abstract
{
    public interface IMyTravelPlanRepository : IGenericRepository<MyTravelPlan>
    {
        public Task<IEnumerable<MyTravelPlan?>> GetMyTravelPlansByTravelIdAsync(Guid myTravelId);
    }
}
