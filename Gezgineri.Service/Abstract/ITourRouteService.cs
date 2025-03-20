using Gezgineri.Service.Dto.TourDtos;
using Gezgineri.Service.Dto.TourRouteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface ITourRouteService
    {
        public Task<bool> AddOrUpdateTourRouteAsync(TourRouteDto tourRouteDto);
        public Task<bool> DeleteTourRouteAsync(Guid id);
        public Task<IEnumerable<TourRouteDto?>> GetAllTourRoutesAsync();
        public Task<TourRouteDto?> GetTourRouteByIdAsync(Guid id);
        public Task<IEnumerable<TourRouteDto?>> GetTourRoutesByTourIdAsync(Guid tourId);

    }
}
