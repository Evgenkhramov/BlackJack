using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Models;

namespace DataAccesLayer.Interfeces
{
    public interface IWrite
    {
        void AddGameHistory(List<CardHistory> historyList, Gamer gamer, OneCard oneCard);
        void WriteHistoryListToFile(string fullFileName, List<CardHistory> historyList);

    }
}
