using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Entity.Models;
using Gezgineri.Entity.Types;
using Gezgineri.Repository.Abstract;
using Gezgineri.Repository.Concrete;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MemberDtos;
using Gezgineri.Service.Dto.TravelerDtos;


namespace Gezgineri.Service.Concrete
{
    public class TravelerService : ITravelerService
    {
        private readonly ITravelerRepository _travelerRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public TravelerService(ITravelerRepository travelerRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _travelerRepository = travelerRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddTravelerAsync(TravelerRegisterRequestDto registerDto)
        {
            var member = _mapper.Map<Member>(registerDto);
           
            member.Password = Encrypter.EncryptString(registerDto.Password);
            member.Role = EnumRole.Traveler;
            await _memberRepository.AddAsync(member);
            

            var traveler = _mapper.Map<Traveler>(registerDto);
            traveler.MemberId = member.ID; // Member ID ile ilişkiyi kur

            var travelerAdded = await _travelerRepository.AddAsync(traveler);
            return travelerAdded;
        }

        public async Task<bool> DeleteTravelerAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No member exists with the provided identifier.");
            }
           
            return await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TravelerDto?>> GetAllTravelersAsync()
        {
            var travelers = await _travelerRepository.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<TravelerDto>>(travelers);
        }

        public async Task<TravelerDto?> GetTravelerByIdAsync(Guid id)
        {
            var traveler = await _travelerRepository.GetTravelerByIdWithIncludeAsync(id);

            if (traveler == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<TravelerDto>(traveler);
        }

        public async Task<TravelerDto?> GetTravelerByMemberIdAsync(Guid memberid)
        {
            var traveler = await _travelerRepository.GetTravelerByMemberIdWithIncludeAsync(memberid);

            if (traveler == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<TravelerDto>(traveler);
        }

        public async Task<bool> UpdateTravelerAsync(UpdateTravelerDto updateTravelerDto)
        {
            // Mevcut Traveler'ı veritabanından çek
            var traveler = await _travelerRepository.GetTravelerByIdWithIncludeAsync(updateTravelerDto.ID);

            if (traveler == null)
                throw new KeyNotFoundException("Traveler not found with the given ID.");

            // DTO'dan Traveler nesnesine mapleme
            _mapper.Map(updateTravelerDto, traveler);

            // Repository'ye gönder
            return await _travelerRepository.UpdateTravelerWithIncludeAsync(traveler);
        }

    }
}
