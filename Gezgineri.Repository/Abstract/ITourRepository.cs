using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Repository.Abstract
{
    public interface ITourRepository : IGenericRepository<Tour>
    {
        public Task<List<Tour>> GetToursByAgencyIdWithIncludeAsync(Guid agencyid);
        public Task<Tour> GetByIdWithIncludeAsync(Guid id);
        public Task<List<Tour>> GetAllWithIncludeAsync();
        public Task<List<Tour>> GetToursStartingFromTodayAsync();


    }
}
