using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Constants;
using BusinessLogic.Models;
using ViewModels;

namespace ViewLayer
{
    public class GameDeskOut
    {
        public void OutputGameDesk(List<GamerView> gamerList, ConsoleOutput consoleOut)
        {
            consoleOut.ShowSomeOutput(TextCuts.NewCards);

            foreach (GamerView gamer in gamerList)
            {
               consoleOut.ShowSomeOutput(gamer.Name);
                foreach (CardView card in gamer.PlayersCardView)
                {
                    consoleOut.ShowResult(card.CardNumber, card.CardSuit, gamer.Points);
                }               
            }

            consoleOut.ShowSomeOutput(TextCuts.CardsOnTable);
        }
    }
}
