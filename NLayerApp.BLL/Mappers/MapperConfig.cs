using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccesLayer.Models;
using ViewModels;

namespace BusinessLogic.Mappers
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => 
                
                cfg.CreateMap<Gamer, GamerView>()
            );

            return config;

        }
    }
}
