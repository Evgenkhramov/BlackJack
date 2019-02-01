using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Models;
using DataAccesLayer.Enums;
using ViewModels;



namespace BusinessLogic
{
    public class PrepareAllGame
    {
        public void PreparedGame(string userName, int userRate, int howManyBots)
        {
            List<Gamer> gamersList = new List<Gamer>();
            PrepareGamersList botGamers = new PrepareGamersList();

            List<Gamer> allGamers = botGamers.GenerateBotList(gamersList, howManyBots, Settings.BotName);
            allGamers = botGamers.AddPlayer(allGamers, userName, userRate, GamerRole.Gamer, GamerStatus.Plays);
            allGamers = botGamers.AddPlayer(allGamers, Settings.DealerName, Settings.DealerRate, GamerRole.Dealer, GamerStatus.Plays);

            var cardDeck = PrepareCardDeck.DoOneDeck();
            var prepareGame = new PrepareGameDesk();
            List<Gamer> preparedGamerList = prepareGame.DistributionCards(allGamers, cardDeck);
            List<GamerView> outputGamerList = new List<GamerView>();
            
        }


    }
}