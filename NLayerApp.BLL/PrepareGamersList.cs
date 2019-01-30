using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic.Enums;


namespace BusinessLogic
{
    public class PrepareGamersList
    {
        //private string _botName { get; set; }
        //public PrepareGamersList(string botName)
        //{
        //    _botName = botName;
        //}

        public List<Gamer> GenerateBotList(List<Gamer> allGamers, int howManyBots, string _botName)
        {
            for (int i = 0; i < howManyBots; i++)
            {
                allGamers.Add(new Gamer() { Name = _botName + i, Rate = Settings.BotRate, Status = GamerStatus.Plays, Role = GamerRole.Bot });
            }

            return allGamers;
        }

        public List<Gamer> AddPlayer(List<Gamer> allGamers, string name, int rate, GamerRole role, GamerStatus status)
        {
            allGamers.Add(new Gamer() { Name = name, Rate = rate, Status = status, Role = role });
            return allGamers;
        }

    }
}
