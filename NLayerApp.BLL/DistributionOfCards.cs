using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DistributionOfPlayingCards
    {
        private ConsoleOutput output = new ConsoleOutput();
        public void DoRound(Gamer gamer, List<OneCard> newSomeDeck)
        {
            output.ShowSomeOutput(gamer.Name);

            OneCard SomeCard = PrepareCardDeck.GetSomeCard(newSomeDeck);
            int cardPoints = CardPointDiction.CardPointDict[SomeCard.CardNumber];
            gamer.Points += cardPoints;

            GameHistoryList.AddGameHistory(GameHistoryList.History, gamer, SomeCard);

            output.ShowResult(SomeCard.CardNumber, SomeCard.CardSuit, gamer.Points);
        }
    }
}
