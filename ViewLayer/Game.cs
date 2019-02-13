using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic;
using BusinessLogic.Services;
using ViewLayer.Constants;
using ViewModels;
using ViewModels.Enums;



namespace ViewLayer
{
    public class Game
    {
        ConsoleOutput Output = new ConsoleOutput();
        ConsoleInput Input = new ConsoleInput();
        readonly Settings GameSettings = new Settings();
        public Game()
        {
            DoGame();
        }

        public void DoGame()
        {
            Output.ShowSomeOutput(TextCuts.StartGame);
            Output.ShowSomeOutput(TextCuts.EnterName);

            GameService gameService = new GameService();
            RoundService roundService  = new RoundService();

            string userName = Input.InputString();

            Output.ShowSomeOutput(TextCuts.HowManyBots, Settings.MaxBots);
            int howManyBots = Input.InputInt(Settings.MinBots, Settings.MaxBots);

            Output.ShowSomeOutput(TextCuts.EnterValidRate, Settings.MinRateForGamer, Settings.MaxRateForGamer);
            int rate = Input.InputInt(Settings.MinRateForGamer, Settings.MaxRateForGamer);

            Output.ShowSomeOutput(TextCuts.ShowStartRaund);
           
            var GameInfo = new GameInfoModel
            {
                UserName = userName,
                UserRate = rate,
                HowManyBots = howManyBots
            };
            
            GamerView  gamer =  gameService.PrepareGame(GameInfo);
            Output.ShowAllGamerCards(gamer);
            Output.ShowSomeOutput(TextCuts.NowYouHave + gamer.Points);
           
            bool isAnswer = true;
            string gamerAnswer;
            while(isAnswer)
            {
                Output.ShowSomeOutput(TextCuts.DoYouWantCard);
                gamerAnswer = Input.InputString();
                if (gamerAnswer == Settings.YesAnswer && gamer.Status!= GamerViewStatus.Enough)
                {
                    gamer = roundService.GiveCardToTheRealPlayer();
                    Output.ShowAllGamerCards(gamer);
                    Output.ShowSomeOutput(TextCuts.NowYouHave + gamer.Points);

                }
                if (gamerAnswer != Settings.YesAnswer || gamer.Status == GamerViewStatus.Many)
                {
                    isAnswer = false;
                    gameService.GamerSayEnaugh();
                }

            }
          
            List<GamerView> finalResult = roundService.DoRoundForAllGamerWithResult();
            Output.ShowFinishResult(finalResult);
            gameService.WriteHistoryInFile();

            Console.ReadKey();
        }
    }
}
