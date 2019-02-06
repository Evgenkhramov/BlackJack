using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enums;
using DataAccesLayer.Models;

namespace DataAccesLayer.Abstract
{
    public abstract class GamerAbstr
    {
        string Name { get; set; }
        int Rate { get; set; }
        int Points { get; set; }
        GamerStatus Status { get; set; }
        GamerRole Role { get; set; }
        List<OneCard> PlayersCard;
    }
}
