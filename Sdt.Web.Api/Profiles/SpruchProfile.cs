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
        }
    }
}
