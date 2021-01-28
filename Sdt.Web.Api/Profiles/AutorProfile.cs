using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sdt.Domain.Entities;
using Sdt.Web.Api.Dto;
using Sdt.Web.Common.Utilities;

namespace Sdt.Web.Api.Profiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<AutorCreateDto, Autor>()
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        opt.PreCondition(c => c.Photo != null);
                        opt.MapFrom(src => Util.GetFile(src.Photo).Result.fileContent);
                    })
                .ForMember(
                    dest => dest.PhotoMimeType,
                    opt =>
                    {
                        opt.PreCondition(c => c.Photo != null);
                        opt.MapFrom(src => src.Photo.ContentType);
                    });



            CreateMap<Autor, AutorDTO>().ReverseMap();
        }
    }
}
