using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using DataAccesLayer;
using DataAccesLayer.Models;
using DataAccesLayer.Enums;
using ViewModels.Enums;
using ViewModels;
using BusinessLogic.Mappers;
using BusinessLogic.Dictionary;




namespace BusinessLogic.Services
{
    public class GameHelper
    {

        public GamerView PrepareGame(GameInfoModel gameInfo)
        {

            StaticGamerList.StaticGamersList = GenerateBotList(StaticGamerList.StaticGamersList, gameInfo.HowManyBots, Settings.BotName);
            StaticGamerList.StaticGamersList = AddPlayer(StaticGamerList.StaticGamersList, gameInfo.UserName, gameInfo.UserRate, GamerRole.Gamer, GamerStatus.Plays);
            StaticGamerList.StaticGamersList = AddPlayer(StaticGamerList.StaticGamersList, Settings.DealerName, Settings.DealerRate, GamerRole.Dealer, GamerStatus.Plays);
            StaticCardList.StaticCardsList = PrepareCardDeck.DoOneDeck();

            StaticGamerList.StaticGamersList = DoFirstRound(StaticGamerList.StaticGamersList, StaticCardList.StaticCardsList, Settings.HowManyCardsInFirstRound);

            List<GamerView> outputGamerViewList = GetGamerViewList(StaticGamerList.StaticGamersList);

            GamerView Gamer = GamerFromViewList(outputGamerViewList);

            return Gamer;
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
            Mapper mapper = new Mapper();
            DoRoundForGamer(gamer, StaticCardList.StaticCardsList);
            GamerView gamerView = mapper.Mapping(gamer);
            return gamerView;
        }
        public void GamerSayEnaugh()
        {
            foreach (Gamer player in StaticGamerList.StaticGamersList)
            {
                if (player.Role == GamerRole.Gamer)
                {
                    player.Status = GamerStatus.Enough;
                }
            }

        }

        public List<Gamer> GenerateBotList(List<Gamer> allGamers, int howManyBots, string botName)
        {
            for (int i = 0; i < howManyBots; i++)
            {

                allGamers.Add(new Gamer() { Name = botName + i, Rate = Settings.BotRate, Status = GamerStatus.Plays, Role = GamerRole.Bot });
            }

            return allGamers;
        }

        public List<Gamer> AddPlayer(List<Gamer> allGamers, string name, int rate, GamerRole role, GamerStatus status)
        {
            allGamers.Add(new Gamer() { Name = name, Rate = rate, Status = status, Role = role });
            return allGamers;
        }

        public List<GamerView> GetGamerViewList(List<Gamer> gamerList)
        {
            Mapper mapper = new Mapper();
            List<GamerView> outputGamerList = new List<GamerView>();
            foreach (Gamer player in gamerList)
            {
                outputGamerList.Add(mapper.Mapping(player));
            }
            return outputGamerList;
        }

        public GamerView GamerFromViewList(List<GamerView> gamerViewList)
        {
            var gamer = new GamerView();
            foreach (GamerView player in gamerViewList)
            {
                if (player.Role == GamerViewRole.Gamer)
                {
                    gamer = player;
                }
            }
            return gamer;
        }

        public void GiveACard(Gamer gamer, List<OneCard> cardDeck)
        {
            OneCard SomeCard = PrepareCardDeck.GetSomeCard(cardDeck);
            gamer.PlayersCard.Add(SomeCard);
            int cardPoints = DictionaryOfCardPoints.CardPointDict[SomeCard.CardNumber];
            gamer.Points += cardPoints;
        }

        public List<Gamer> DoFirstRound(List<Gamer> gamerList, List<OneCard> cardDeck, int howCards)
        {
            for (int i = 0; i < howCards; i++)
            {
                foreach (Gamer gamer in gamerList)
                {
                    GiveACard(gamer, StaticCardList.StaticCardsList);
                }
            }
            return gamerList;
        }
        public List<GamerView> DoRoundForAllGamerWithResult()
        {
            var gameResult = new GameResult();
            foreach (Gamer player in StaticGamerList.StaticGamersList)
            {
                DoRoundForGamer(player, StaticCardList.StaticCardsList);
            }
            StaticGamerList.StaticGamersList = gameResult.GetFinishResult(StaticGamerList.StaticGamersList);

            List<GamerView> gamerView = GetGamerViewList(StaticGamerList.StaticGamersList);
            return gamerView;
        }

        public void DoRoundForGamer(Gamer someGamer, List<OneCard> newSomeDeck)
        {

            if (someGamer.Role == GamerRole.Dealer && someGamer.Points < Settings.MinimumCasinoPointsLevel)
            {
                GiveACard(someGamer, newSomeDeck);
                DoGamerStatus(someGamer);
            }
            if (someGamer.Role == GamerRole.Dealer && someGamer.Points >= Settings.MinimumCasinoPointsLevel)
            {
                someGamer.Status = GamerStatus.Enough;
            }

            if (someGamer.Role == GamerRole.Gamer && someGamer.Status != GamerStatus.Enough)
            {

                GiveACard(someGamer, newSomeDeck);
                DoGamerStatus(someGamer);

            }
            if (someGamer.Role == GamerRole.Bot && someGamer.Status != GamerStatus.Enough)
            {
                if (someGamer.Points <= 15)
                {
                    GiveACard(someGamer, newSomeDeck);
                    DoGamerStatus(someGamer);
                }
                if (GetRandom(2) == 1 && someGamer.Points > 15)
                {
                    GiveACard(someGamer, newSomeDeck);
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

