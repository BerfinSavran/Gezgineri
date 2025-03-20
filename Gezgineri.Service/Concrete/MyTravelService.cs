using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MyTravelDtos;

namespace Gezgineri.Service.Concrete
{
    public class MyTravelService : IMyTravelService
    {
        private readonly IMyTravelRepository _myTravelRepository;
        private readonly IMapper _mapper;

        public MyTravelService(IMyTravelRepository myTravelRepository, IMapper mapper)
        {
            _mapper = mapper;
            _myTravelRepository = myTravelRepository;
        }

        public async Task<bool> AddOrUpdateMyTravelAsync(MyTravelDto myTravelDto)
        {
            var myTravel = _mapper.Map<MyTravel>(myTravelDto);
            if (myTravelDto.ID == null)
            {
                return await _myTravelRepository.AddAsync(myTravel);
            }
            return await _myTravelRepository.UpdateAsync(myTravel);
        }

        public async Task<bool> DeleteMyTravelAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No myTravel exists with the provided identifier.");
            }
            return await _myTravelRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MyTravelDto?>> GetAllMyTravelsAsync()
        {
            var myTravels = await _myTravelRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MyTravelDto>>(myTravels);
        }

        public async Task<MyTravelDto?> GetMyTravelByIdAsync(Guid id)
        {
            var myTravel = await _myTravelRepository.GetByIdAsync(id);
            if (myTravel == null)
            {
                throw new Exception("No myTravel exists with the provided identifier.");
            }
            return _mapper.Map<MyTravelDto>(myTravel);
        }

        public async Task<IEnumerable<MyTravelDto?>> GetMyTravelsByTravelerIdAsync(Guid travelerid)
        {
            var myTravels = await _myTravelRepository.GetMyTravelsByTravelerIdAsync(travelerid);
            return _mapper.Map<IEnumerable<MyTravelDto>>(myTravels);

        }
    }
}

