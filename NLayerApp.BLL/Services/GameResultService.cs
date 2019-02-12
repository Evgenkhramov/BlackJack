using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using DataAccesLayer.Models;
using DataAccesLayer.Enums;

namespace BusinessLogic
{
    public class GameResultService
    {
        public List<Gamer> GetFinishResult(List<Gamer> SomeGamersList)
        {
            Gamer dealer = new Gamer();
            foreach (Gamer player in SomeGamersList)
            {
                if (player.Role == GamerRole.Dealer)
                {
                    dealer = player;
                }
            }
            foreach (Gamer player in SomeGamersList)
            {
                if (player.Role != GamerRole.Dealer)
                {
                    if ((player.Status == GamerStatus.Blackjack && dealer.Status != GamerStatus.Blackjack) ||
                            (player.Status == GamerStatus.Enough && player.Points >= dealer.Points && dealer.Status == GamerStatus.Enough) ||
                            (player.Status == GamerStatus.Enough && player.Points < dealer.Points && dealer.Status == GamerStatus.Many))
                    {
                        player.Status = GamerStatus.Win;
                        player.WinCash = Settings.HowManyWinRate * player.Rate;
                    }
                    if (player.Status == GamerStatus.Blackjack && dealer.Status == GamerStatus.Blackjack)
                    {
                        player.Status = GamerStatus.Win;
                        player.WinCash = player.Rate;
                    }
                    if ((player.Status == GamerStatus.Enough && dealer.Status == GamerStatus.Blackjack) ||
                        (player.Status == GamerStatus.Enough && player.Points < dealer.Points && dealer.Status == GamerStatus.Enough) ||
                        (player.Status == GamerStatus.Many))
                    {
                        player.Status = GamerStatus.Lose;
                        player.WinCash = 0;
                        dealer.WinCash += player.Rate;
                    }
                }
            }
           
            return SomeGamersList;
        }
    }
}
