using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Entity.Models;
using Gezgineri.Entity.Types;
using Gezgineri.Repository.Abstract;
using Gezgineri.Repository.Concrete;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.OwnerDtos;


namespace Gezgineri.Service.Concrete
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public OwnerService(IOwnerRepository ownerRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddOwnerAsync(OwnerRegisterRequestDto registerDto)
        {
            var member = _mapper.Map<Member>(registerDto);

            member.Password = Encrypter.EncryptString(registerDto.Password);
            member.Role = EnumRole.Owner;
            await _memberRepository.AddAsync(member);

            var owner = _mapper.Map<Owner>(registerDto);
            owner.MemberId = member.ID;

            var ownerAdded = await _ownerRepository.AddAsync(owner);
            return ownerAdded;
        }

        public async Task<bool> DeleteOwnerAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OwnerDto?>> GetAllOwnersAsync()
        {
            var owners = await _ownerRepository.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<OwnerDto>>(owners);
        }

        public async Task<OwnerDto?> GetOwnerByIdAsync(Guid id)
        {
            var owner = await _ownerRepository.GetOwnerByIdWithIncludeAsync(id);

            if (owner == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<OwnerDto>(owner);
        }

        public async Task<OwnerDto?> GetOwnerByMemberIdAsync(Guid memberid)
        {
            var owner = await _ownerRepository.GetOwnerByMemberIdWithIncludeAsync(memberid);

            if (owner == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<OwnerDto>(owner);
        }

        public async Task<bool> UpdateOwnerAsync(UpdateOwnerDto updateOwnerDto)
        {
            var owner = await _ownerRepository.GetOwnerByIdWithIncludeAsync(updateOwnerDto.ID);

            if(owner == null)
                throw new KeyNotFoundException("Owner not found with the given ID.");

            _mapper.Map(updateOwnerDto, owner);

            return await _ownerRepository.UpdateOwnerWithIncludeAsync(owner);
        }
    }
}
