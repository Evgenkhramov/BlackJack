using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackNextGeneration.Interfeces
{
    public interface IOutput
    {
        void ShowFinishResult(List<Gamer> gamerList);
        void ShowResult(string number, string suit, int points);
        void ShowSomeOutput(string text);
        void ShowSomeOutput(string text, int number);
        void ShowSomeOutput(string text, int number1, int number2);
        void ShowSomeOutput(Enums.GamerStatus text);
    }
}
