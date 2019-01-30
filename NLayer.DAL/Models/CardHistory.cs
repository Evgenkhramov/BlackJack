using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccesLayer.Models
{
    public class CardHistory
    {
        public string GamerName { get; set; }
        public int GamerPoints { get; set; }
        public OneCard CardOfRound { get; set; }

        public CardHistory(string name, int points, OneCard someCard)
        {
            GamerName = name;
            GamerPoints = points;
            CardOfRound = someCard;
        }
    }
}
