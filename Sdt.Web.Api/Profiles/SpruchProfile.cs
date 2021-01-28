using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sdt.Domain.Entities;
using Sdt.Web.Api.Dto;

namespace Sdt.Web.Api.Profiles
{
    public class SpruchProfile : Profile
    {
        public SpruchProfile()
        {
            CreateMap<Spruch, SpruchDTO>()
                .ForMember(dest => dest.AutorName, opt => opt.MapFrom(src => src.Autor.Name));

            CreateMap<Spruch, SpruchDesTagesDTO>()
                .ForMember(dest => dest.AutorBild, opt => opt.MapFrom(src => src.Autor.Photo))
                .ForMember(dest => dest.AutorBildType, opt => opt.MapFrom(src => src.Autor.PhotoMimeType));

            //.ForMember(c => c.AutorId, opt => opt.Ignore());
        }
    }
}
