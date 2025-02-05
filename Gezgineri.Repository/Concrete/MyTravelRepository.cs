using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Repository.Concrete
{
    public class MyTravelRepository : GenericRepository<MyTravel>, IMyTravelRepository
    {
        public MyTravelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
