using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataAccesLayer.Models;

namespace DataAccesLayer
{
    public class HelperFileHistory
    {
        public void WriteHistoryStringToFile(string fullFileName, List<CardHistory> historyList)
        {
            //try
            //{
            //    const string V = @"C:\blackjack\text.txt";

            //    StreamWriter streamWriter = new StreamWriter(V);
            //    foreach (CardHistory element in historyList)
            //    {
            //        streamWriter.WriteLine($"{element.GamerName} get card {element.CardOfRound.CardNumber} {element.CardOfRound.CardSuit}  and get {element.GamerPoints}");

            //    }
            //    streamWriter.Close();

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //}
        }
    }
}
