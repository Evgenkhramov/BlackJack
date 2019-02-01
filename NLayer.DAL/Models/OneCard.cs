using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Abstract;

namespace DataAccesLayer.Models
{
    public class OneCard:OneCardAbstr
    {
        public string CardSuit { get; set; }
        public string CardNumber { get; set; }

        public override string ToString()
        {
            return $"{CardSuit}:{CardNumber}";
        }
    }
}
