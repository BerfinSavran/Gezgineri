using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Service.Dto.AgencyDtos;
using Gezgineri.Service.Dto.MemberDtos;
using Gezgineri.Service.Dto.OwnerDtos;
using Gezgineri.Service.Dto.TravelerDtos;


namespace Gezgineri.Service.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            
            CreateMap<Traveler, TravelerRegisterRequestDto>();
            CreateMap<Traveler, UpdateTravelerDto>();

            CreateMap<Agency, AgencyRegisterRequestDto>();
            CreateMap<Agency, UpdateAgencyDto>();

            CreateMap<Owner, UpdateOwnerDto>().ReverseMap();
            CreateMap<Owner, OwnerRegisterRequestDto>();

            CreateMap<Traveler, TravelerDto>()
            .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.Member.ID))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Member.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Member.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Member.Password))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Member.Role));


            CreateMap<TravelerRegisterRequestDto, Member>()
                .ForMember(dest => dest.ID, opt => opt.Ignore()) // ID'yi maplemiyoruz çünkü DB tarafından atanacak
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)); // Şifreyi özel olarak mapleyebilirsiniz

            CreateMap<TravelerRegisterRequestDto, Traveler>()
                .ForMember(dest => dest.MemberId, opt => opt.Ignore());

            CreateMap<UpdateTravelerDto, Traveler>()
                .ForPath(dest => dest.Member.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForPath(dest => dest.Member.Email, opt => opt.MapFrom(src => src.Email));


            CreateMap<Agency, AgencyDto>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.Member.ID))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Member.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Member.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Member.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Member.Role));

            CreateMap<AgencyRegisterRequestDto, Member>()
                .ForMember(dest => dest.ID, opt => opt.Ignore()) // ID'yi maplemiyoruz çünkü DB tarafından atanacak
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)); // Şifreyi özel olarak mapleyebilirsiniz

            CreateMap<AgencyRegisterRequestDto, Agency>()
                .ForMember(dest => dest.MemberId, opt => opt.Ignore());

            CreateMap<UpdateAgencyDto, Agency>()
                 .ForPath(dest => dest.Member.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForPath(dest => dest.Member.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<Owner, OwnerDto>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.Member.ID))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Member.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Member.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Member.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Member.Role));

            CreateMap<OwnerRegisterRequestDto, Member>()
                .ForMember(dest => dest.ID, opt => opt.Ignore()) // ID'yi maplemiyoruz çünkü DB tarafından atanacak
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)); // Şifreyi özel olarak mapleyebilirsiniz

            CreateMap<OwnerRegisterRequestDto, Owner>()
                .ForMember(dest => dest.MemberId, opt => opt.Ignore());

            CreateMap<UpdateOwnerDto, Owner>()
                 .ForPath(dest => dest.Member.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForPath(dest => dest.Member.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
