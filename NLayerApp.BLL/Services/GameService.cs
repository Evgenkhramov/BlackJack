using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using DataAccesLayer.Models;
using DataAccesLayer;
using DataAccesLayer.Enums;
using ViewModels.Enums;
using ViewModels;
using BusinessLogic.Mappers;
using BusinessLogic.Dictionary;
using DataAccesLayer.Service;

namespace BusinessLogic.Services
{
    public class GameService
    {
        public GamerView PrepareGame(GameInfoModel gameInfo)
        {
            StaticGamerList.StaticGamersList = GenerateBotList(StaticGamerList.StaticGamersList, gameInfo.HowManyBots, Settings.BotName);
            StaticGamerList.StaticGamersList = AddPlayer(StaticGamerList.StaticGamersList, gameInfo.UserName, gameInfo.UserRate, GamerRole.Gamer, GamerStatus.Plays);
            StaticGamerList.StaticGamersList = AddPlayer(StaticGamerList.StaticGamersList, Settings.DealerName, Settings.DealerRate, GamerRole.Dealer, GamerStatus.Plays);
            StaticCardList.StaticCardsList = CardDeckService.DoOneDeck();
            RoundService round = new RoundService();

            StaticGamerList.StaticGamersList = round.DoFirstRound(StaticGamerList.StaticGamersList, StaticCardList.StaticCardsList, Settings.HowManyCardsInFirstRound);

            List<GamerView> outputGamerViewList = GetGamerViewList(StaticGamerList.StaticGamersList);

            GamerView Gamer = GamerFromViewList(outputGamerViewList);
            
            return Gamer;
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
            var mapper = new Mappered();
                   
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

        public void WriteHistoryInFile()
        {
            var historyFile = new DirectoryAndFileOfHistoryService();
            var fullDirectoryName = historyFile.CreateDirectory(Settings.HistoryDirectoryPath, Settings.HistoryDirectorySubPath);
            var fullFileName = historyFile.CreateFile(Settings.HistoryFileName, fullDirectoryName);
            var HistoryService = new HistoryHelper();
            HistoryService.WriteHistoryListToFile(fullFileName, StaticCardHistoryList.History);
        }
    }
}

