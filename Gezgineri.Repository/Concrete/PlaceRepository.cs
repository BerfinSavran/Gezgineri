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
    public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
    {
        private readonly AppDbContext _context;
        public PlaceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
