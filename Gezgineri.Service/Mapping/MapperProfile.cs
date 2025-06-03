using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Service.Dto.AgencyDtos;
using Gezgineri.Service.Dto.CategoryDtos;
using Gezgineri.Service.Dto.FavoritePlaceDtos;
using Gezgineri.Service.Dto.MemberDtos;
using Gezgineri.Service.Dto.MyTravelDtos;
using Gezgineri.Service.Dto.OwnerDtos;
using Gezgineri.Service.Dto.PlaceDtos;
using Gezgineri.Service.Dto.TourDtos;
using Gezgineri.Service.Dto.TourRouteDtos;
using Gezgineri.Service.Dto.TravelerDtos;
using Gezgineri.Service.Dto.MyTravelPlanDtos;
using Gezgineri.Service.Dto.Admin;


namespace Gezgineri.Service.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();

            CreateMap<Admin, AdminRegisterRequestDto>();

            CreateMap<Traveler, TravelerRegisterRequestDto>();
            CreateMap<Traveler, UpdateTravelerDto>();

            CreateMap<Agency, AgencyRegisterRequestDto>();
            CreateMap<Agency, UpdateAgencyDto>();

            CreateMap<Owner, UpdateOwnerDto>().ReverseMap();
            CreateMap<Owner, OwnerRegisterRequestDto>();

            CreateMap<Admin, AdminDto>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.Member.ID))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Member.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Member.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Member.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Member.Role));

            CreateMap<AdminRegisterRequestDto, Member>()
                .ForMember(dest => dest.ID, opt => opt.Ignore()) 
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<AdminRegisterRequestDto, Admin>()
                .ForMember(dest => dest.MemberId, opt => opt.Ignore());

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

            CreateMap<Category, CategoryDto>().ReverseMap();
            
            CreateMap<Place, PlaceDto>().ReverseMap();

            CreateMap<Place, PlacesWithIncludeDto>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.ID))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.ID))
                .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.Owner.BusinessName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Tour, TourDto>().ReverseMap();

            CreateMap<Tour, ToursWithIncludeDto>()
                .ForMember(dest => dest.AgencyId, opt => opt.MapFrom(src => src.Agency.ID))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Agency.CompanyName))
                .ForMember(dest => dest.WebSiteUrl, opt => opt.MapFrom(src => src.Agency.WebSiteUrl));

            CreateMap<TourRoute, TourRouteDto>().ReverseMap();
            
            CreateMap<MyTravel, MyTravelDto>().ReverseMap();

            CreateMap<MyTravelPlan, MyTravelPlanDto>().ReverseMap();

            CreateMap<MyTravelPlan, MyTravelPlanWithIncludeDto>()
                .ForMember(dest => dest.PlaceId, opt => opt.MapFrom(src => src.Place.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Place.Category.Name));

            CreateMap<FavoritePlace, FavoritePlaceDto>()
               .ForMember(dest => dest.PlaceId, opt => opt.MapFrom(src => src.Place != null ? src.Place.ID : Guid.Empty))
               .ForMember(dest => dest.TravelerId, opt => opt.MapFrom(src => src.Traveler != null ? src.Traveler.ID : Guid.Empty))
               .ReverseMap();
        }
    }
}
