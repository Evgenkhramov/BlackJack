using System;
using System.Collections.Generic;
using System.Text;
using ViewLayer.Constants;

namespace ViewLayer
{
    public class NumberValidation
    {
        

        private ConsoleOutput output = new ConsoleOutput();
        public int CheckNumber(int min, int max)
        {
            int number = 0;
            int validNumber = 0;
            bool valid = true;
            while (valid)
            {
                try
                {
                    string someText = Console.ReadLine();
                    bool success = Int32.TryParse(someText, out number);
                    if (success && number >= min && number <= max)
                    {
                        validNumber = number;
                        valid = false;
                    }
                    if (!success || number < min || number > max)
                    {
                        output.ShowSomeOutput(TextCuts.EnterValidNumber, min, max);
                    }
                }
                catch
                {
                    Console.WriteLine(TextCuts.NotValidNumber);
                }
            }
            return validNumber;
        }
    }
}
