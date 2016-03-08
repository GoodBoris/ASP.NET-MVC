using System.Security.Claims;
using Autofac;
using AutoMapper;
using PhotoAlbum.WEB.MembershipService;
using PhotoAlbum.WEB.Models;
using PhotoAlbum.WEB.PhotoService;

namespace PhotoAlbum.WEB
{
    public partial class Startup
    {
        public static void RegisterMappings(IContainer container)
        {
            Mapper.CreateMap<RegisterViewModel, CreateRequest>()
                .AfterMap((model, request) =>
                {
                    request.Role = "user";
                    request.AuthenticationType = AuthenticationTypeEnum.ApplicationCookie;
                });

            Mapper.CreateMap<ClaimView, Claim>()
                .ConstructUsing(dest => new Claim(dest.Type, dest.Value, dest.ValueType))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.ValueType, opt => opt.MapFrom(src => src.ValueType))
                .ForMember(dest => dest.Issuer, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalIssuer, opt => opt.Ignore())
                .ForMember(dest => dest.Properties, opt => opt.Ignore())
                .ForMember(dest => dest.Subject, opt => opt.Ignore());

            Mapper.CreateMap<PhotoDescriptionDto, PhotoViewModel>()
                .ForMember(dest => dest.TimeOfCreation, opt => opt.MapFrom(src => src.TimeOfCreation.ToLocalTime()))
                .ReverseMap();
            Mapper.CreateMap<ChangePasswordViewModel, ChangeUserPasswordRequest>();
            Mapper.CreateMap<ChangeUserInfoViewModel, ChangeUserInfoRequest>();
            Mapper.CreateMap<UserProfileResponse, IndexViewModel>();
        }
    }
}