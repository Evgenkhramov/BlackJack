using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Models;
using ViewModels;
using ViewModels.Enums;
using AutoMapper;


namespace BusinessLogic.Mappers
{
    public class Mappered
    {
        public GamerView MappingByAutoMapper(Gamer player)
        {
            MapperConfiguration getMapper = MapperConfig.GetMapperConfiguration();
            var mapper = new Mapper(getMapper);
            
            GamerView mappingGamer = Mapper.Map<GamerView>(player);
          
            return mappingGamer;
        }    
    }
}
