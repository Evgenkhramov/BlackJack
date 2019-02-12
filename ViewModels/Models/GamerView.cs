using System;
using System.Collections.Generic;
using ViewModels.Enums;

namespace ViewModels
{
    public class GamerView
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public int Points { get; set; }
        public int WinCash { get; set; }
        public GamerViewRole Role { get; set; }
        public List<CardView> PlayersCardView;
        public GamerViewStatus Status { get; set; }

        public GamerView()
        {
            PlayersCardView = new List<CardView>();
            Role = GamerViewRole.None;
            Status = GamerViewStatus.None;

        }
    }
}
