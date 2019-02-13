using System;
using System.Collections.Generic;
using System.IO;
using DataAccesLayer.Models;
using DataAccesLayer.Interfeces;

namespace DataAccesLayer.Service
{
    public class HistoryHelperService : IWrite
    {
        public  void AddGameHistory(List<CardHistory> historyList, Gamer gamer, OneCard oneCard)
        {
            var newRecord = new CardHistory(gamer.Name, gamer.Points, oneCard);
            historyList.Add(newRecord);
        }

        public  void  WriteHistoryListToFile(string fullFileName, List<CardHistory> historyList)
        {
            try
            { 
                using (var fileStream = new FileStream(fullFileName, FileMode.CreateNew))
                {
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        foreach (CardHistory element in historyList)
                        {
                            streamWriter.WriteLine($"{element.GamerName} get card {element.CardOfRound.CardNumber} {element.CardOfRound.CardSuit}  and get {element.GamerPoints}");
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
