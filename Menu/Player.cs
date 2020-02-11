using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Player
    {
        private Guid Id;
        public string Name { get; set; }

        public Player(string name)
        {
            this.Id = new Guid();
            this.Name = name;
        }
        public void Validate()
        {
            if(String.IsNullOrEmpty(Name))
            {
                throw new Exception("Enter player name");
            }
        }
    }
}
