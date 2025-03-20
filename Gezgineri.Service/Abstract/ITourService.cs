using Gezgineri.Service.Dto.PlaceDtos;
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
        public Task<IEnumerable<ToursWithIncludeDto?>> GetAllWithIncludeAsync();
        public Task<ToursWithIncludeDto?> GetTourByIdWithIncludeAsync(Guid id);
        public Task<List<ToursWithIncludeDto?>> GetToursByAgencyIdWithIncludeAsync(Guid agencyid);
        public Task<List<ToursWithIncludeDto?>> GetToursStartingFromTodayAsync();

    }
}
