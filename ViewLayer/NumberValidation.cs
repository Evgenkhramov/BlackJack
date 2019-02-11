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
            int number = 0;
            int validNumber = 0;
            bool valid = true;
            while (valid)
            {
                try
                {
                    string someText = input.InputString();
                    bool success = Int32.TryParse(someText, out number);
                    if (success && number >= min && number <= max)
                    {
                        validNumber = number;
                        valid = false;
                    }
                    if (!success || number < min || number > max)
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
