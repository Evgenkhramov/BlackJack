using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Models;


namespace BusinessLogic
{
    public class PrepareGameDesk
    {

        public List<Gamer> DistributionCards(List<Gamer> gamerList, List<OneCard> cardDeckList)
        {

            var oneRound = new DistributionOfPlayingCards();
            for (int i = 0; i < Settings.HowManyCardsInFirstRound; i++)
            {
                foreach (Gamer player in gamerList)
                {
                    oneRound.DoRound(player, cardDeckList);
                }
            }

            return gamerList;
        }

    }
}
