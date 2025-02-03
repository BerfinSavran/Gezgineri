using Gezgineri.Service.Dto.TourDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface ITourService
    {
        public Task<bool> AddOrUpdateTourAsync(TourDto tourDto);
        public Task<bool> DeleteTourAsync(Guid id);
        public Task<IEnumerable<TourDto?>> GetAllToursAsync();
        public Task<TourDto?> GetTourByIdAsync(Guid id);
    }
}
