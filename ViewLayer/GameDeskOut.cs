using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Constants;
using BusinessLogic.Models;

namespace ViewLayer
{
    public class GameDeskOut
    {
        public void OutputGameDesk(List<Gamer> gamerList, ConsoleOutput consoleOut)
        {
            consoleOut.ShowSomeOutput(TextCuts.NewCards);
            foreach (Gamer gamer in gamerList)
            {
               consoleOut.ShowSomeOutput(gamer.Name);
                consoleOut.ShowResult(SomeCard.CardNumber, SomeCard.CardSuit, gamer.Points);
            }
            consoleOut.ShowSomeOutput(TextCuts.CardsOnTable);
        }
    }
}
