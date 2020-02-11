using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Winner:Player
    {
        public int Moves { get; set; }
        public int O_Moves { get; set; }
        public string Opponent { get; set; }
        public Winner(string name, int moves,int o_moves,string opponent) : base(name)
        {
            
            this.Moves = moves;
            this.O_Moves = o_moves;
            this.Name = name;
            this.Opponent = opponent;
        }
        public override string ToString()
        {
            return $"{Name} won with {Opponent}, in a {Moves}vs{O_Moves} match";
        }
    }
}
