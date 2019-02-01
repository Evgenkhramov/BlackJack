using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Models;
using BusinessLogic.Dictionary;


namespace BusinessLogic
{
    public class DistributionOfPlayingCards
    {
        public void DoRound(Gamer gamer, List<OneCard> newSomeDeck)
        {
            OneCard SomeCard = PrepareCardDeck.GetSomeCard(newSomeDeck);
            gamer.PlayersCard.Add(SomeCard);
            int cardPoints = DictionaryOfCardPoints.CardPointDict[SomeCard.CardNumber];
            gamer.Points += cardPoints;

            //GameHistoryListHelper.AddGameHistory(GameHistoryListHelper.History, gamer, SomeCard);

        }
    }
}
