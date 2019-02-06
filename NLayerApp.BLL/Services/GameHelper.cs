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
            List<Gamer> gamersList = new List<Gamer>();
            List<Gamer> allGamers = GenerateBotList(gamersList, gameInfo.HowManyBots, Settings.BotName);
            allGamers = AddPlayer(allGamers, gameInfo.UserName, gameInfo.UserRate, GamerRole.Gamer, GamerStatus.Plays);
            allGamers = AddPlayer(allGamers, Settings.DealerName, Settings.DealerRate, GamerRole.Dealer, GamerStatus.Plays);

            var cardDeck = PrepareCardDeck.DoOneDeck();

            List<Gamer> PreparedGamerList = DoFirstRound(allGamers, cardDeck, Settings.HowManyCardsInFirstRound);
            List<GamerView> outputGamerViewList = GetGamerViewList(PreparedGamerList);

            GamerView Gamer = GamerFromViewList(outputGamerViewList);

            return Gamer;
        }
        public GamerView GiveCardToThePlayer()
        {
            
            return GamerView
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

        public List<Gamer> DoFirstRound(List<Gamer> gamerList, List<OneCard> cardDeck, int howCards)
        {
            for (int i = 0; i < howCards; i++)
            {
                foreach (Gamer gamer in gamerList)
                {
                    OneCard SomeCard = PrepareCardDeck.GetSomeCard(cardDeck);
                    gamer.PlayersCard.Add(SomeCard);
                    int cardPoints = DictionaryOfCardPoints.CardPointDict[SomeCard.CardNumber];
                    gamer.Points += cardPoints;
                }
            }
            return gamerList;
        }

        public void DoRoundForGamer(Gamer gamer, List<OneCard> someDeck)
        {
            OneCard SomeCard = PrepareCardDeck.GetSomeCard(someDeck);
            gamer.PlayersCard.Add(SomeCard);
            int cardPoints = DictionaryOfCardPoints.CardPointDict[SomeCard.CardNumber];
            gamer.Points += cardPoints;

            //GameHistoryListHelper.AddGameHistory(GameHistoryListHelper.History, gamer, SomeCard);

        }
        public void DoRound(Gamer gamer, List<OneCard> newSomeDeck)
        {
            OneCard SomeCard = PrepareCardDeck.GetSomeCard(newSomeDeck);
            int cardPoints = DictionaryOfCardPoints.CardPointDict[SomeCard.CardNumber];
            gamer.Points += cardPoints;
            gamer.PlayersCard.Add(SomeCard);

            //GameHistoryList.AddGameHistory(GameHistoryList.History, gamer, SomeCard);

        }

       
        //public GameProcess DoGame(GameDeskModel gameDeskModel)
        //{


        //    foreach (Gamer player in gameDeskModel.gamerListAfterPrepare)
        //    {
        //        while (player.Status == GamerStatus.Plays)
        //        {
        //            string answer = BusinessLogic.Settings.NoAnswer;
        //            if (player.Role == GamerRole.Gamer)
        //            {
        //                consoleOut.ShowSomeOutput(TextCuts.NowYouHave + player.Points);
        //                consoleOut.ShowSomeOutput(TextCuts.DoYouWantCard);
        //                answer = consoleInp.InputString();
        //            }
        //            makeGame.DoRoundForGamer(player, gameDeskModel.cardDeck, answer);
        //        }
        //    }
        //    var gameProcessResult = new GameProcess
        //    {
        //        afterGameArray = gameDeskModel.gamerListAfterPrepare
        //    };

        //    return gameProcessResult;
        //}

        //private void CheckResult(GameProcess result)
        //{
        //    var gameResult = new GameResult();
        //    var consoleOut = new ConsoleOutput();

        //    var consoleInp = new ConsoleInput();
        //    //var createDirectory = new DirectoryAndFileOfHistory();
        //    var displayGameResult = new DisplayGameResults(consoleOut);

        //    gameResult.GetFinishResult(result.afterGameArray);

        //    //string fullName = createDirectory.CreateDirectory(Settings.HistoryDirectoryPath, Settings.HistoryDirectorySubPath);
        //    //string fullFileName = createDirectory.CreateFile(Settings.HistoryFileName, fullName);
        //    //HelperTextFileHistory textFile = new HelperTextFileHistory();
        //    //textFile.WriteHistoryStringToFile(fullFileName, GameHistoryList.History);

        //    displayGameResult.FinishResult(result.afterGameArray);

        //    //input.InputString();
        //}
    }
}
