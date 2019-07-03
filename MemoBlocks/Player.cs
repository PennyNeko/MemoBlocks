using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBlocks
{
    class Player
    {
        public Player(string name, int tries, TimeSpan duration)
        {
            Name = name;
            Tries = tries;
            Duration = duration;
        }

        public string Name { set; get; }
        public int Tries { set; get; }
        public TimeSpan Duration { set; get; }

    }
}
