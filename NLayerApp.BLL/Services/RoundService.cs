using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Models;
using DataAccesLayer.Service;
using BusinessLogic.Dictionary;
using ViewModels;
using DataAccesLayer.Enums;
using BusinessLogic.Mappers;

namespace BusinessLogic.Services
{
    public class RoundService
    {
        public void GiveCard(Gamer gamer, List<OneCard> cardDeck)
        {
            OneCard someCard = CardDeckService.GetSomeCard(cardDeck);
            gamer.PlayersCard.Add(someCard);
            var HistoryService = new HistoryHelper();
            HistoryService.AddGameHistory(StaticCardHistoryList.History, gamer, someCard);
            int cardPoints = DictionaryOfCardPoints.CardPointDict[someCard.CardNumber];
            gamer.Points += cardPoints;
        }

        public GamerView GiveCardToTheRealPlayer()
        {
            Gamer gamer = new Gamer();
            foreach (Gamer player in StaticGamerList.StaticGamersList)
            {
                if (player.Role == GamerRole.Gamer)
                {
                    gamer = player;
                }
            }
            var mapper = new Mapper();
            DoRoundForGamer(gamer, StaticCardList.StaticCardsList);
            GamerView gamerView = mapper.Mapping(gamer);
            return gamerView;
        }

        public List<Gamer> DoFirstRound(List<Gamer> gamerList, List<OneCard> cardDeck, int howCards)
        {
            for (int i = 0; i < howCards; i++)
            {
                foreach (Gamer gamer in gamerList)
                {
                    GiveCard(gamer, StaticCardList.StaticCardsList);
                }
            }
            return gamerList;
        }
        public List<GamerView> DoRoundForAllGamerWithResult()
        {
            var gameService = new GameService();
            var gameResult = new GameResultService();
            foreach (Gamer player in StaticGamerList.StaticGamersList)
            {
                DoRoundForGamer(player, StaticCardList.StaticCardsList);
            }
            StaticGamerList.StaticGamersList = gameResult.GetFinishResult(StaticGamerList.StaticGamersList);

            List<GamerView> gamerView = gameService.GetGamerViewList(StaticGamerList.StaticGamersList);
            return gamerView;
        }

        public void DoRoundForGamer(Gamer someGamer, List<OneCard> newSomeDeck)
        {

            if (someGamer.Role == GamerRole.Dealer && someGamer.Points < Settings.MinimumCasinoPointsLevel)
            {
                GiveCard(someGamer, newSomeDeck);
                DoGamerStatus(someGamer);
            }
            if (someGamer.Role == GamerRole.Dealer && someGamer.Points >= Settings.MinimumCasinoPointsLevel)
            {
                someGamer.Status = GamerStatus.Enough;
            }

            if (someGamer.Role == GamerRole.Gamer && someGamer.Status != GamerStatus.Enough)
            {

                GiveCard(someGamer, newSomeDeck);
                DoGamerStatus(someGamer);

            }
            if (someGamer.Role == GamerRole.Bot && someGamer.Status != GamerStatus.Enough)
            {
                if (someGamer.Points <= Settings.MinBotPoints)
                {
                    GiveCard(someGamer, newSomeDeck);
                    DoGamerStatus(someGamer);
                }
                if (GetRandom(2) == 1 && someGamer.Points > Settings.MinBotPoints)
                {
                    GiveCard(someGamer, newSomeDeck);
                    DoGamerStatus(someGamer);
                }
                if (GetRandom(2) == 0 && someGamer.Points > Settings.MinBotPoints)
                {
                    someGamer.Status = GamerStatus.Enough;
                }
            }
        }

        public void DoGamerStatus(Gamer someGamer)
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

        public int GetRandom(int maxNumber)
        {
            Random random = new Random();
            int randomNumber = random.Next(maxNumber);

            return randomNumber;
        }
    }
}
