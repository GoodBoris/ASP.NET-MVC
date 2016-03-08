using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;
using Service.Messages.FileTransfer;
using Service.Messages.Photo;
using Service.Utilities.Membership;
using Service.Views.FileTransfer;
using Service.Views.Membership;

namespace Service
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            //Membership service maps
            Mapper.CreateMap<ClaimsIdentity, ClaimIdentityView>()
                .ForMember(dest => dest.ClaimViewList, opt => opt.MapFrom(src => src.Claims))
                .ForMember(dest => dest.AuthenticationType,
                    opt => opt.MapFrom(src => (AuthenticationTypeEnum)
                        EnumStringValue.Parse(typeof(AuthenticationTypeEnum), src.AuthenticationType)))
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.GetUserId()));
            Mapper.CreateMap<Claim, ClaimView>();

            //PhotoAlbum service maps
            Mapper.CreateMap<Photo, PhotoDescriptionDto>()
                .ForMember(dest => dest.PhotoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ClientProfileId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.ClientProfile.UserName))
                .ForMember(dest => dest.AverageRating,
                    opt => opt.ResolveUsing(src => src.Votes.Any() == false ? 0 : src.Votes.Average(vote => vote.NodeVote)));
            Mapper.CreateMap<PhotoDescriptionDto, Photo>()
                .ForMember(dest => dest.ClientProfileId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TimeOfCreation, opt => opt.Ignore())
                .AfterMap((dto, photo) =>
                {
                    if (photo.TimeOfCreation == null)
                        photo.TimeOfCreation = DateTime.UtcNow;
                    if (photo.Image == null)
                        photo.Image = new Image();
                });

            //FileTransfer service maps
            Mapper.CreateMap<Image, ImageDownloadResponse>()
                .ConstructUsing(src => new ImageDownloadResponse(new ImageMetaData(src.Id, src.ImageMimeType), new MemoryStream(src.ImageData)))
                .ForSourceMember(x => x.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.Photo, opt => opt.Ignore());

            Mapper.CreateMap<ImageUploadRequest, Photo>()
                .AfterMap((request, photo) => photo.Image.ImageMimeType = request.Metadata.ImageMimeType)
                .AfterMap((request, photo) =>
                {
                    using (var ms = new MemoryStream())
                    {
                        request.FileByteStream.CopyTo(ms);
                        photo.Image.ImageData = ms.ToArray();
                    }
                });
        }
    }
}