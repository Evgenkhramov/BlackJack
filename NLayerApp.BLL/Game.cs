using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;

namespace BusinessLogic
{
    public class Game
    {
        readonly Settings game;

        public Game()
        {
            game = new Settings();
            GameInfoModel date = GetGameInfo();
            GameDeskModel prepare = PrepareGame(date);
            GameProcess gameProcess = DoGame(prepare);
            CheckResult(gameProcess);
        }

        //return model
        private GameInfoModel GetGameInfo()
        {
            var consoleOut = new ConsoleOutput();
            var consoleInp = new ConsoleInput();

            var someGameGetDate = new DateFromGamer(consoleOut, consoleInp);
            someGameGetDate.ShowStart();
            string userName = someGameGetDate.GetUserName();
            int howManyBots = someGameGetDate.GetNumberOfBots();

            var gameInfo = new GameInfoModel
            {
                HowManyBots = howManyBots,
                UserName = userName,
                UserRate = someGameGetDate.GetGamerRate()
            };

            return gameInfo;
        }

        private GameDeskModel PrepareGame(GameInfoModel gameInfo)
        {
            var consoleOut = new ConsoleOutput();

            List<Gamer> gamersList = new List<Gamer>();
            PrepareGamersList botGamers = new PrepareGamersList();
            List<Gamer> allGamers = botGamers.GenerateBotList(gamersList, gameInfo.HowManyBots);
            allGamers = botGamers.AddPlayer(allGamers, gameInfo.UserName, gameInfo.UserRate, GamerRole.Gamer, GamerStatus.Plays);
            allGamers = botGamers.AddPlayer(allGamers, TextCuts.DealerName, Settings.DealerRate, GamerRole.Dealer, GamerStatus.Plays);

            var cardDeck = PrepareCardDeck.DoOneDeck();
            PrepareGameDesk prepareGame = new PrepareGameDesk(consoleOut);
            List<Gamer> gamerList = prepareGame.DistributionCards(allGamers, cardDeck);

            var gameDeskModel = new GameDeskModel();
            gameDeskModel.gamerListAfterPrepare = gamerList;
            gameDeskModel.cardDeck = cardDeck;

            return gameDeskModel;
        }

        private GameProcess DoGame(GameDeskModel gameDeskModel)
        {

            RoundOfGame makeGame = new RoundOfGame();

            foreach (Gamer player in gameDeskModel.gamerListAfterPrepare)
            {
                while (player.Status == GamerStatus.Plays)
                {
                    makeGame.DoRoundForGamer(player, gameDeskModel.cardDeck);
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
            var printOut = new PrintOutput();
            var consoleInp = new ConsoleInput();
            var createDirectory = new DirectoryAndFileOfHistory();
            var displayGameResult = new DisplayGameResults(consoleOut, printOut);

            gameResult.GetFinishResult(result.afterGameArray);

            string fullName = createDirectory.CreateDirectory(Settings.HistoryDirectoryPath, Settings.HistoryDirectorySubPath);
            string fullFileName = createDirectory.CreateFile(Settings.HistoryFileName, fullName);
            HelperTextFileHistory textFile = new HelperTextFileHistory();
            textFile.WriteHistoryStringToFile(fullFileName, GameHistoryList.History);

            displayGameResult.FinishResult(result.afterGameArray, GameHistoryList.History);

            //input.InputString();
        }
    }
}
