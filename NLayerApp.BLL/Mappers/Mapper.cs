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
            MapperConfiguration GetMapper = MapperConfig.GetMapperConfiguration();
            var mapper = new Mapper(GetMapper);

            GamerView mappingGamer = mapper.Map<GamerView>(Gamer);

            return mappingGamer;
        }
     
        
        public GamerView Mapping(Gamer gamer)
        {
         
            var mappingGamer = new GamerView()
            {
                Name = gamer.Name,
                Rate = gamer.Rate,
                Points = gamer.Points,
                WinCash = gamer.WinCash,
                Status = (GamerViewStatus)((int)gamer.Status),

                PlayersCardView = gamer.PlayersCard.Select(card => new CardView { CardNumber = card.CardNumber, CardSuit = card.CardSuit }).ToList(),
                Role = (GamerViewRole)((int)gamer.Role)
            };
            return mappingGamer;
        }
    }
}
