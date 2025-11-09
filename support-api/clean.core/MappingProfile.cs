using AutoMapper;
using clean.core.DTOs;
using clean.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Albums, AlbumsDTO>().ReverseMap();
            CreateMap<Singer, SingerDTO>().ReverseMap();
            CreateMap<Songs, SongsDTO>().ReverseMap();
        }
    }
}
