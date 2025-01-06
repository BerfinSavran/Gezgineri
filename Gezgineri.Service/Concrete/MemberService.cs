
using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MemberDtos;

namespace Gezgineri.Service.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
        }
        public async Task<bool> AddOrUpdateMemberAsync(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            if (memberDto.ID == null)
            {
                member.Password = Encrypter.EncryptString(memberDto.Password);
                return await _memberRepository.AddAsync(member);
            }
            return await _memberRepository.UpdateAsync(member);
        }

        public async Task<bool> DeleteMemberAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No member exists with the provided identifier.");
            }
            return await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            var members = await _memberRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }


        public async Task<MemberDto?> GetMemberByEmailAsync(string email)
        {
            var member = await _memberRepository.GetMemberByEmailAsync(email);
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("No employee exists with the provided email.");
            }
            return _mapper.Map<MemberDto?>(member);
        }

        public async Task<MemberDto?> GetMemberByIdAsync(Guid id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }
            return _mapper.Map<MemberDto>(member);
        }
    }
}
