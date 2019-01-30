using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer
{
    public class HelperFileHistory
    {
        public void WriteHistoryStringToFile(string fullFileName, List<CardHistory> historyList)
        {

            try
            {
                StreamWriter strimWrite = new StreamWriter(fullFileName);
                foreach (CardHistory element in historyList)
                {
                    strimWrite.WriteLine($"{element.GamerName} get card {element.CardOfRound.CardNumber} {element.CardOfRound.CardSuit}  and get {element.GamerPoints}");

                }
                strimWrite.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
