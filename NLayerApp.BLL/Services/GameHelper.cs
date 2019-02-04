using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using DataAccesLayer;
using DataAccesLayer.Models;
using DataAccesLayer.Enums;
using ViewModels.Enums;
using ViewModels;

namespace BusinessLogic.Services
{
    public class GameHelper
    {
        readonly Settings GameSettings;
         //return model
        
        public GameDeskModel PrepareGame(GameInfoModel gameInfo)
        {
            List<Gamer> gamersList = new List<Gamer>();
            PrepareGamersList botGamers = new PrepareGamersList();

            List<Gamer> allGamers = botGamers.GenerateBotList(gamersList, gameInfo.HowManyBots, Settings.BotName);
            allGamers = botGamers.AddPlayer(allGamers, gameInfo.UserName, gameInfo.UserRate, GamerRole.Gamer, GamerStatus.Plays);
            allGamers = botGamers.AddPlayer(allGamers, Settings.DealerName, Settings.DealerRate, GamerRole.Dealer, GamerStatus.Plays);

            var cardDeck = PrepareCardDeck.DoOneDeck();
            var prepareGame = new PrepareGameDesk();
            List<Gamer> preparedGamerList = prepareGame.DistributionCards(allGamers, cardDeck);
            List<GamerView> outputGamerList = new List<GamerView>();
            var gameDeskModel = new GameDeskModel
            {
                gamerListAfterPrepare = preparedGamerList,
                cardDeck = cardDeck
            };
            return gameDeskModel;
        }

        public  GameProcess DoGame(GameDeskModel gameDeskModel)
        {
           var makeGame = new RoundOfGame();

            foreach (Gamer player in gameDeskModel.gamerListAfterPrepare)
            {
                while (player.Status == GamerStatus.Plays)
                {
                    string answer = BusinessLogic.Settings.NoAnswer;
                    if (player.Role == GamerRole.Gamer)
                    {
                        consoleOut.ShowSomeOutput(TextCuts.NowYouHave + player.Points);
                        consoleOut.ShowSomeOutput(TextCuts.DoYouWantCard);
                        answer = consoleInp.InputString();
                    }
                    makeGame.DoRoundForGamer(player, gameDeskModel.cardDeck, answer);
                }
            }
            var gameProcessResult = new GameProcess
            {
                afterGameArray = gameDeskModel.gamerListAfterPrepare
            };

            return gameProcessResult;
        }

        private void CheckResult(GameProcess result)
        {
            var gameResult = new GameResult();
            var consoleOut = new ConsoleOutput();

            var consoleInp = new ConsoleInput();
            //var createDirectory = new DirectoryAndFileOfHistory();
            var displayGameResult = new DisplayGameResults(consoleOut);

            gameResult.GetFinishResult(result.afterGameArray);

            //string fullName = createDirectory.CreateDirectory(Settings.HistoryDirectoryPath, Settings.HistoryDirectorySubPath);
            //string fullFileName = createDirectory.CreateFile(Settings.HistoryFileName, fullName);
            //HelperTextFileHistory textFile = new HelperTextFileHistory();
            //textFile.WriteHistoryStringToFile(fullFileName, GameHistoryList.History);

            displayGameResult.FinishResult(result.afterGameArray);

            //input.InputString();
        }
    }
}
