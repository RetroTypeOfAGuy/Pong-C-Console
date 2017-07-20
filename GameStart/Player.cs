using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public class Player
    {
        public string Name {get;set;}
        public int Score { get; set; }
        public Position ScorePosition { get; set; }
        public Position NamePosition { get; set; }
        public Player(string name, Position nameposition, Position scoreposition)
        {
            this.Name = name;
            this.Score = 0;
            this.ScorePosition = scoreposition;
            this.NamePosition = nameposition;
        }

    }
}
