using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Abstract;
using DataAccesLayer.Enums;

namespace DataAccesLayer.Models
{
  
    public class Gamer : GamerAbstr
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public int Points { get; set; }
        public GamerStatus Status { get; set; }
        public int WinCash { get; set; }
        public GamerRole Role { get; set; }
        public List<OneCard> PlayersCard;

        public Gamer()
        {
            Name = null;
            Rate = 0;
            Points = 0;
            Status = GamerStatus.None;
            WinCash = 0;
            Role = GamerRole.None;
            List<OneCard> PlayersCard = new List<OneCard>();
        }
    }
}
