using System;
using System.Collections.Generic;
using System.Text;
using ViewLayer.Constants;

namespace ViewLayer
{
    public class NumberValidation
    {
        private ConsoleOutput output = new ConsoleOutput();
        private ConsoleInput input = new ConsoleInput();
        public int CheckNumber(int min, int max, string enterValidNumber, string notValidNumber)
        {          
            int validNumber = 0;
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    int number = 0;
                    string someText = input.InputString();
                    bool isNumberSuccess = int.TryParse(someText, out number);
                    if (isNumberSuccess && number >= min && number <= max)
                    {
                        validNumber = number;
                        isValid = true;
                    }
                    if (!isNumberSuccess || number < min || number > max)
                    {
                        output.ShowSomeOutput(enterValidNumber, min, max);
                    }
                }
                catch
                {
                    output.ShowSomeOutput(notValidNumber);
                }
            }
            return validNumber;
        }
    }
}
