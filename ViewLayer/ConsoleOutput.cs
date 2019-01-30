using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Interfaces;
using ViewLayer.Constants;
using BusinessLogic.Models;
using BusinessLogic.Enums;


namespace ViewLayer
{
    public class ConsoleOutput : IOutput
    {
        public void ShowFinishResult(List<Gamer> gamerlist)
        {
            foreach (Gamer player in gamerlist)
            {
                Console.WriteLine(TextCuts.ShowFinishResultByConsole,
                   player.Name, player.Points, player.Status, player.WinCash);
            }
        }

        public void ShowResult(string number, string suit, int points)
        {
            Console.WriteLine(TextCuts.ShowResultByConsole, number, suit, points);
        }

        public void ShowSomeOutput(string text)
        {
            Console.WriteLine(TextCuts.ShowSomeText, text);
        }

        public void ShowSomeOutput(string text, int number)
        {
            Console.WriteLine(text, number);
        }

        public void ShowSomeOutput(string text, int number1, int number2)
        {
            Console.WriteLine(text, number1, number2);
        }

        public void ShowSomeOutput(GamerStatus text)
        {
            Console.WriteLine(text);
        }

    }
}
