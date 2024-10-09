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
        public enum Position
        {
            Forward, Midfielder, Defender, Goalkeeper
        }
        public Position position { get; private set; }

        public string NamePlayer { get; private set; }


        public Players( int numplayer ,Position pos , string nameplayer )
        {
            number_player = numplayer;
            position = pos;
            NamePlayer = nameplayer;

        }

    }
}
