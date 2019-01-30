using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class OneCard
    {
        public string CardSuit { get; set; }
        public string CardNumber { get; set; }

        public override string ToString()
        {
            return $"{CardSuit}:{CardNumber}";
        }
    }
}
