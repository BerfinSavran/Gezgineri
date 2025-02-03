using Gezgineri.Service.Dto.PlaceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface IPlaceService
    {
        public Task<bool> AddOrUpdatePlaceAsync(PlaceDto placeDto);
        public Task<bool> DeletePlaceAsync(Guid id);
        public Task<IEnumerable<PlaceDto?>> GetAllPlacesAsync();
        public Task<PlaceDto?> GetPlaceByIdAsync(Guid id);
    }
}

