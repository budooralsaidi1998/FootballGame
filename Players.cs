using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public class Players
    {
        public int number_player {  get; private set; }
      
        public string Position  { get; private set; }

        public string NamePlayer { get; private set; }


        public Players( int numplayer ,string pos , string nameplayer )
        {
            number_player = numplayer;
            Position = pos;
            NamePlayer = nameplayer;

        }

    }
}
