using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Repository.Concrete
{
    public class TourRouteRepository : GenericRepository<TourRoute>, ITourRouteRepository
    {
        private readonly AppDbContext _context;
        public TourRouteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
