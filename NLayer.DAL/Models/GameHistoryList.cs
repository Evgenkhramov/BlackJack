using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Models
{
    public class GameHistoryList
    {
        public static List<CardHistory> History = new List<CardHistory>();
        public static void AddGameHistory(List<CardHistory> historyList, Gamer gamer, OneCard oneCard)
        {
            CardHistory newRecord = new CardHistory(gamer.Name, gamer.Points, oneCard);

            historyList.Add(newRecord);
        }
    }
}
