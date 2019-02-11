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
            string UserName = Input.InputString();


            Output.ShowSomeOutput(TextCuts.HowManyBots, Settings.MaxBots);
            int HowManyBots = Input.InputInt(Settings.MinBots, Settings.MaxBots);

            Output.ShowSomeOutput(TextCuts.EnterValidRate, Settings.MinRateForGamer, Settings.MaxRateForGamer);

            int Rate = Input.InputInt(Settings.MinRateForGamer, Settings.MaxRateForGamer);

            Output.ShowSomeOutput(TextCuts.ShowStartRaund);

            GameHelper OneGame = new GameHelper();
            var GameInfo = new GameInfoModel
            {
                UserName = UserName,
                UserRate = Rate,
                HowManyBots = HowManyBots
            };
            
            GamerView  Gamer =  OneGame.PrepareGame(GameInfo);
            Output.ShowAllGamerCards(Gamer);
            Output.ShowSomeOutput(TextCuts.NowYouHave + Gamer.Points);


           
            bool Answer = true;
            string GamerAnswer;
            while(Answer)
            {
                Output.ShowSomeOutput(TextCuts.DoYouWantCard);
                GamerAnswer = Input.InputString();
                if (GamerAnswer == Settings.YesAnswer && Gamer.Status!= GamerViewStatus.Enough)
                {
                    Gamer = OneGame.GiveCardToTheRealPlayer();
                    Output.ShowAllGamerCards(Gamer);
                    Output.ShowSomeOutput(TextCuts.NowYouHave + Gamer.Points);

                }
                if (GamerAnswer != Settings.YesAnswer || Gamer.Status == GamerViewStatus.Many)
                {
                    Answer = false;
                    OneGame.GamerSayEnaugh();
                }

            }
          
            List<GamerView> FinalResult = OneGame.DoRoundForAllGamerWithResult();
            Output.ShowFinishResult(FinalResult);
            OneGame.WriteHistoryInFile();
        }
    }
}
