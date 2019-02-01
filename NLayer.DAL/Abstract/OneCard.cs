using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Abstract
{
   public abstract class OneCardAbstr
    {
        string CardSuit { get; set; }
        string CardNumber { get; set; }

        public override string ToString()
        {
            return $"{CardSuit}:{CardNumber}";
        }
    }
}
