using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Interfaces;
using BusinessLogic;
using ViewLayer.Constants;

namespace ViewLayer
{
    public class ConsoleInput : IInput
    {
        public string InputString()
        {
            return Console.ReadLine();
        }

        public int InputInt(int min, int max)
        {
            var intCheck = new NumberValidation();
            int validNumber = intCheck.CheckNumber(min, max, TextCuts.EnterValidNumber, TextCuts.NotValidNumber);
            return validNumber;
        }
    }
}
