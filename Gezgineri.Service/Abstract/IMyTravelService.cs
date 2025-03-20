using Gezgineri.Service.Dto.MyTravelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface IMyTravelService
    {
        public Task<bool> AddOrUpdateMyTravelAsync(MyTravelDto myTravelDto);
        public Task<bool> DeleteMyTravelAsync(Guid id);
        public Task<IEnumerable<MyTravelDto?>> GetAllMyTravelsAsync();
        public Task<MyTravelDto?> GetMyTravelByIdAsync(Guid id);
        public Task<IEnumerable<MyTravelDto?>> GetMyTravelsByTravelerIdAsync(Guid travelerid);
    }
}
