using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class RoundOfGame
    {
        private ConsoleOutput output = new ConsoleOutput();
        private static ConsoleInput input = new ConsoleInput();


        public void DoRoundForGamer(Gamer someGamer, List<OneCard> newSomeDeck)
        {
            var oneRound = new DistributionOfPlayingCards();
            if (someGamer.Role == GamerRole.Dealer && someGamer.Points < Settings.MinimumCasinoPointsLevel)
            {
                oneRound.DoRound(someGamer, newSomeDeck);
                DoGamerStatus(someGamer);
            }
            if (someGamer.Role == GamerRole.Dealer && someGamer.Points >= Settings.MinimumCasinoPointsLevel)
            {
                someGamer.Status = GamerStatus.Enough;
            }

            if (someGamer.Role == GamerRole.Gamer && someGamer.Status != GamerStatus.Enough)
            {
                output.ShowSomeOutput(TextCuts.NowYouHave + someGamer.Points);
                output.ShowSomeOutput(TextCuts.DoYouWantCard);

                string answer = input.InputString();
                if (answer == TextCuts.Yes)
                {
                    oneRound.DoRound(someGamer, newSomeDeck);
                    DoGamerStatus(someGamer);
                }
                if (answer != TextCuts.Yes)
                {
                    someGamer.Status = GamerStatus.Enough;
                    output.ShowSomeOutput(someGamer.Status);
                }
            }
            if (someGamer.Role == GamerRole.Bot && someGamer.Status != GamerStatus.Enough)
            {
                if (someGamer.Points <= 15)
                {
                    oneRound.DoRound(someGamer, newSomeDeck);
                    DoGamerStatus(someGamer);
                }
                if (GetRandom(2) == 1 && someGamer.Points > 15)
                {
                    oneRound.DoRound(someGamer, newSomeDeck);
                    DoGamerStatus(someGamer);
                }
                if (GetRandom(2) == 0 && someGamer.Points > 15)
                {
                    someGamer.Status = GamerStatus.Enough;
                }
            }
        }

        public static void DoGamerStatus(Gamer someGamer)
        {
            if (someGamer.Points < Settings.BlackJeckPoints)
            {
                someGamer.Status = GamerStatus.Plays;
            }
            if (someGamer.Points == Settings.BlackJeckPoints)
            {
                someGamer.Status = GamerStatus.Blackjack;
            }
            if (someGamer.Points > Settings.BlackJeckPoints)
            {
                someGamer.Status = GamerStatus.Many;
            }
        }

        public static int GetRandom(int maxNumber)
        {
            Random random = new Random();
            int randomNumber = random.Next(maxNumber);

            return randomNumber;
        }
    }
}
