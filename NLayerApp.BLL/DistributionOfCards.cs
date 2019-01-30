using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic.Dictionary;
using DataAccesLayer.Models;

namespace BusinessLogic
{
    public class DistributionOfPlayingCards
    {
      
        public void DoRound(Gamer gamer, List<OneCard> newSomeDeck)
        {
            //output.ShowSomeOutput(gamer.Name);

            OneCard SomeCard = PrepareCardDeck.GetSomeCard(newSomeDeck);
            int cardPoints = DictionaryOfCardPoints.CardPointDict[SomeCard.CardNumber];
            gamer.Points += cardPoints;

            //GameHistoryList.AddGameHistory(GameHistoryList.History, gamer, SomeCard);

            //output. ;
        }
    }
}
