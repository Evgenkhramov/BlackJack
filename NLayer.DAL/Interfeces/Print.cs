using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Models;

namespace DataAccesLayer.Interfeces
{
    public interface IPrint
    {
        void PrintHistory(List<CardHistory> history);
    }
}
