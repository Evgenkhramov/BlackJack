using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic;
using ViewLayer.Constants;

namespace ViewLayer
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

            var someGameGetDate = new DataFromGamer(consoleOut, consoleInp);

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
            var prepareAllGame = new PrepareAllGame();
            prepareAllGame.PreparedGame(gameInfo.UserName, gameInfo.UserRate, gameInfo.HowManyBots);          

            var deskOut = new GameDeskOut();
            deskOut.OutputGameDesk(preparedGamerList, consoleOut);

            var gameDeskModel = new GameDeskModel
            {
                gamerListAfterPrepare = preparedGamerList,
                cardDeck = cardDeck
            };

            return gameDeskModel;
        }

        private GameProcess DoGame(GameDeskModel gameDeskModel)
        {
            var consoleOut = new ConsoleOutput();
            var consoleInp = new ConsoleInput();

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
