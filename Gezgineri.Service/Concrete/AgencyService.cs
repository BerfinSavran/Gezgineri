using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Entity.Models;
using Gezgineri.Entity.Types;
using Gezgineri.Repository.Abstract;
using Gezgineri.Repository.Concrete;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.AgencyDtos;
using Gezgineri.Service.Dto.TravelerDtos;

namespace Gezgineri.Service.Concrete
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public AgencyService(IAgencyRepository agencyRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _agencyRepository = agencyRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAgencyAsync(AgencyRegisterRequestDto registerDto)
        {
            var member = _mapper.Map<Member>(registerDto);

            member.Password = Encrypter.EncryptString(registerDto.Password);
            member.Role = EnumRole.Agency;
            await _memberRepository.AddAsync(member);

            var agency = _mapper.Map<Agency>(registerDto);
            agency.MemberId = member.ID;

            var agencyAdded = await _agencyRepository.AddAsync(agency);
            return agencyAdded;
        }

        public async Task<bool> DeleteAgencyAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return await _memberRepository.DeleteAsync(id);
        }

        public async Task<AgencyDto?> GetAgencyByIdAsync(Guid id)
        {
            var agency = await _agencyRepository.GetAgencyByIdWithIncludeAsync(id);

            if (agency == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<AgencyDto>(agency);
        }

        public async Task<AgencyDto?> GetAgencyByMemberIdAsync(Guid memberid)
        {
            var agency = await _agencyRepository.GetAgencyByMemberIdWithIncludeAsync(memberid);

            if (agency == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<AgencyDto>(agency);
        }

        public async Task<IEnumerable<AgencyDto?>> GetAllAgencysAsync()
        {
            var agencies = await _agencyRepository.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<AgencyDto>>(agencies);
        }

        public async Task<bool> UpdateAgencyAsync(UpdateAgencyDto updateAgencyDto)
        {
            var agency = await _agencyRepository.GetAgencyByIdWithIncludeAsync(updateAgencyDto.ID);

            if(agency == null)
                throw new KeyNotFoundException("Agency not found with the given ID.");

            _mapper.Map(updateAgencyDto, agency);

            return await _agencyRepository.UpdateAgencyWithIncludeAsync(agency);
        }
    }
}
