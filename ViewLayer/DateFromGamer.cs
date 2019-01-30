using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Interfaces;
using ViewLayer.Constants;


namespace ViewLayer
{
   public class DateFromGamer
    {
        private IOutput _output;
        private IInput _input;
        public DateFromGamer(IOutput output, IInput input)
        {
            _output = output;
            _input = input;

        }
        public string GetUserName()
        {
            string userName = _input.InputString();
            return userName;
        }
        public void ShowStart()
        {
            _output.ShowSomeOutput(TextCuts.StartGame);
            _output.ShowSomeOutput(TextCuts.EnterName);
        }

        public int GetNumberOfBots()
        {
            _output.ShowSomeOutput(TextCuts.HowManyBots, Settings.MaxBots);

            int howManyBots = _input.InputInt(Settings.MinBots, Settings.MaxBots);

            return howManyBots;
        }

        public int GetGamerRate()
        {
            _output.ShowSomeOutput(TextCuts.EnterValidRate, Settings.MinRateForGamer, Settings.MaxRateForGamer);

            int rate = _input.InputInt(Settings.MinRateForGamer, Settings.MaxRateForGamer);

            _output.ShowSomeOutput(TextCuts.ShowStartRaund);

            return rate;
        }
    }
}
