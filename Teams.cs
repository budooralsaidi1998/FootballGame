using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public class Teams
    {

        public string NameTeams { get; private set; }
        public List<Players> players { get; private set; } = new List<Players>();

        Random random = new Random();
        public Teams(string nameteam)
        {

            NameTeams = nameteam;
        }


        //automatically generate 11 players for each team
        //a random skill level between 1 and 100
        //players will be assigned to positions such as Forward, Midfielder, Defender, or Goalkeeper.


        public void AutomaticallyGeneratPlayer()
        {

            string[] position = { "Forward", "Midfielder", "Defender", "Goalkeeper" };
           
            for (int i = 1; i < 11; i++)
            {
                string playername = GenerateNamePlayer();

                string positionrandom = position[random.Next(position.Length)];

                int skilllevel=random.Next(1, 100);

                players.Add(new Players(i, playername, positionrandom, skilllevel));

            }






        }

        public string GenerateNamePlayer()
        {
            string[] namepalyer = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

            string name = namepalyer[random.Next(namepalyer.Length)];

            return name;
        }


        public int AttackPlayer()
        {

            int skilllevel = 0;
            foreach (var player in players)
            {
                if(player.Position== "Forward" || player.Position== "Midfielder")
                {
                    skilllevel += player.skilllevel;
                }
            }

            return skilllevel;
        }
        public int defencePlayer()
        {

            int skilllevel = 0;
            foreach (var player in players)
            {
                if (player.Position == "Defender" || player.Position == "Goalkeeper")
                {
                    skilllevel += player.skilllevel;
                }
            }

            return skilllevel;
        }


    }

}
