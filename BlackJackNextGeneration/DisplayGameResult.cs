using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackNextGeneration
{
    public class DisplayGameResults
    {
        private IPrint _print;

        private IOutput _output;

        public DisplayGameResults(IOutput output, IPrint print)
        {
            _output = output;
            _print = print;
        }

        public void FinishResult(List<Gamer> afterGameArray, List<CardHistory> gameHistory)
        {
            _output.ShowFinishResult(afterGameArray);
            _output.ShowSomeOutput(TextCuts.GameHistory);
            _print.PrintHistory(gameHistory);
        }
    }
}
