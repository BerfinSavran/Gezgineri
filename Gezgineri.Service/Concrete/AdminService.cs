using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Entity.Models;
using Gezgineri.Entity.Types;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.Admin;


namespace Gezgineri.Service.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public AdminService(IAdminRepository adminRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAdminAsync(AdminRegisterRequestDto registerDto)
        {
            var member = _mapper.Map<Member>(registerDto);

            member.Password = Encrypter.EncryptString(registerDto.Password);
            member.Role = EnumRole.Admin;
            await _memberRepository.AddAsync(member);

            var admin = _mapper.Map<Admin>(registerDto);
            admin.MemberId = member.ID;

            var adminAdded = await _adminRepository.AddAsync(admin);
            return adminAdded;
        }

        public async Task<bool> DeleteAdminAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AdminDto?>> GetAllAdminsAsync()
        {
            var admins = await _adminRepository.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<AdminDto>>(admins);
        }

        public async Task<AdminDto?> GetAdminByIdAsync(Guid id)
        {
            var admin = await _adminRepository.GetAdminByIdWithIncludeAsync(id);

            if (admin == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<AdminDto>(admin);
        }

        public async Task<AdminDto?> GetAdminByMemberIdAsync(Guid memberid)
        {
            var admin = await _adminRepository.GetAdminByMemberIdWithIncludeAsync(memberid);

            if (admin == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<AdminDto>(admin);
        }
    }
}
