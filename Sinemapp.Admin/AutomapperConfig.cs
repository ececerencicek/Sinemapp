using AutoMapper;
using AutoMapper.Configuration;
using Sinemapp.Admin.Models;
using Sinemapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinemapp.Admin
{
    public class AutoMapperConfig
    {
       public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<Film, FilmViewModel>().ReverseMap().ForMember(dest => dest.Casts, opt => opt.Ignore());

            cfg.CreateMap<TvSerie, TvSerieViewModel>().ReverseMap().ForMember(dest => dest.Casts, opt => opt.Ignore());

            cfg.CreateMap<News, NewsViewModel>().ReverseMap();

            cfg.CreateMap<Cast, CastViewModel>().ForMember(
            dest => dest.FilmName,
            opt => opt.MapFrom(src => src.Film.Name)).ForMember(
            dest => dest.TvSerieName,
            opt => opt.MapFrom(src => src.TvSerie.Name)).ReverseMap();

            Mapper.Initialize(cfg);
        }
    }
}