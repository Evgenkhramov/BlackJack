using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Enums;

namespace BusinessLogic.Models
{
    public abstract class GamerAbstr
    {
        string Name { get; set; }
        int Rate { get; set; }
        int Points { get; set; }
        GamerStatus Status { get; set; }
        GamerRole Role { get; set; }
    }
    public class Gamer : GamerAbstr
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public int Points { get; set; }
        public GamerStatus Status { get; set; }
        public int WinCash { get; set; }
        public GamerRole Role { get; set; }

        public Gamer()
        {
            Name = Settings.BotName;
            Rate = 0;
            Points = 0;
            Status = GamerStatus.None;
            WinCash = 0;
            Role = GamerRole.None;
        }
    }
}
