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
                string playername = GenerateNamePlayerteam1();

                string positionrandom = position[random.Next(position.Length)];

                int skilllevel=random.Next(1, 100);

                players.Add(new Players(i, playername, positionrandom, skilllevel));

               

            }






        }

        //to generate the name teams
        public string GenerateNamePlayerteam1()
        {
            string[] namepalyer = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

            string name = namepalyer[random.Next(namepalyer.Length)];

            return name;
        }

        //with each half consisting of several turns where one team attacks
        public int AttackPlayer()
        {
            List<Players> forwardsAndMidfielders = new List<Players>();

            // search for the player is forward and midfielder
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Position == "Forward" || players[i].Position == "Midfielder")
                {
                    forwardsAndMidfielders.Add(players[i]);
                }
            }
            int numOfPlayers = random.Next(1, forwardsAndMidfielders.Count);

            int skilllevel = 0;
            for (int i = 0; i < numOfPlayers; i++)
            {
                skilllevel += forwardsAndMidfielders[i].skilllevel;
            }


            return skilllevel;
        }


        //each half consisting of several turns where one team  defends.
        public int defencePlayer()
        {

            int skilllevel = 0;
            List<Players> DefenderAndGoalkeepear = new List<Players>();

            // search for the player is forward and midfielder
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Position == "Defender" || players[i].Position == "Goalkeeper")
                {
                    DefenderAndGoalkeepear.Add(players[i]);
                }
            }
            int numOfPlayers = random.Next(1, DefenderAndGoalkeepear.Count );

            for (int i = 0; i < numOfPlayers; i++)
            {
                skilllevel += DefenderAndGoalkeepear[i].skilllevel;
            }



            return skilllevel;
        }


        public void DisplayPayer()
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.number_player}  {player.NamePlayer} - {player.Position} (Skill: {player.skilllevel})");
            }
        }
        //to get the persentage of skilllevel for all forward by average 
        public int ScoringForward()
        {
            //total skill level
            int totalskilllevel = 0;
            int forwardcount = 0;
            //player object to search for forward 
            for (int i = 0; i < players.Count; i++)
            {
                //get forward 
                if (players[i].Position == "Forward")
                {
                    //count the 
                    totalskilllevel += players[i].skilllevel;
                    forwardcount++;
                }
               
            }
            //if not have random forward 
            if (forwardcount == 0)
            {
                return 0;
            }


            int averageforward = totalskilllevel / forwardcount;
            return averageforward;

        }

    }
     
}
