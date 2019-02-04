using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic;
using BusinessLogic.Services;
using ViewLayer.Constants;



namespace ViewLayer
{
    public class Game
    {
        ConsoleOutput Output = new ConsoleOutput();
        ConsoleInput Input = new ConsoleInput();
        readonly Settings GameSettings = new Settings();


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
            
            GameDeskModel PreparedGameModel =  OneGame.PrepareGame(GameInfo);
            var GetGamerViewList = OneGame.GetGamerViewList(PreparedGameModel);

            Output.ShowSomeOutput(TextCuts.CardsOnTable);
            Output.ShowFinishResult(GetGamerViewList);//промежуточный результат после двух карт всех игроков
            
            Output.ShowResult

            //OneGame.DoGame(PreparedGame);
         
        
        }
    }
}
