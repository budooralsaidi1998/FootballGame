using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public class FGame: IGameActions
    {
        public Teams team1;//object 1
        public Teams team2;//object 2
        Random random = new Random();
        static Dictionary<string, int> score  = new Dictionary<string, int>();

        public void StartGame()
        {
            string teamname1;
            string teamname2;

            // prompt the user to input the names of two teams
            Console.WriteLine("Welcome to the Soccer Game Simulator!");

            Console.WriteLine();

            Console.Write(" Enter name of team 1 : ");
            teamname1 = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Enter name of team 1 : ");
            teamname2 = Console.ReadLine();

            //object1
            team1 = new Teams(teamname1);
            //object2
            team2 = new Teams(teamname2);

            //initial score each teams 
            score[team1.NameTeams] = 0;
            score[team2.NameTeams] = 0;


            Console.WriteLine("Generating players for both teams...  ");


            //automatically generate 11 players for each team
            team1.AutomaticallyGeneratPlayer();
            team2.AutomaticallyGeneratPlayer();

            //display info team1 object
            Console.WriteLine($"Team :{teamname1}");
            team1.DisplayPayer();


            Console.WriteLine();


            //display info team2 object
            Console.WriteLine($"Team :{teamname2}");
            team2.DisplayPayer();

            //coin toss will determine which team gets to start
            CointossTeams();

            // add first half
            PlayHalf("first");

            Console.WriteLine();

            //add second half
            PlayHalf("second");

            //display result of match 
            DisplayResults();
        }

        public void CointossTeams()
        {


            //a coin toss will determine which team gets to start

            Console.WriteLine("\nCoin toss...");
            //0-1
            //if random is 0 will start team 1
            // else will start team2
            int teamstart = random.Next(2);

            if (teamstart == 0)
            {
                Console.WriteLine($"Coin toss... Team {team1.NameTeams} will start the game.");

            }
            else
            {
                Console.WriteLine($"Coin toss... Team {team2.NameTeams} will start the game.");
            }

        }

        // Console.WriteLine($"\n--- {NumHalf} Half ---");

        // //to check if first team is attack by random number turn 
        // // and flag to know if team1 attack 
        // // else defens
        // bool IsTeam1Attack = true;

        //// int turnnum = random.Next(1, 7);

        // for (int i = 1; i <= 5; i++)
        // {
        //     if (IsTeam1Attack)
        //     {
        //         
        //         SimulateTurnTeams(team1, team2);
        //     }
        //     else

        //         

        //         SimulateTurnTeams(team2, team1);
        //     }
        //     //change flag to alternative to false
        //     IsTeam1Attack = !IsTeam1Attack;
        // }
        public void PlayHalf(string NumHalf)
        {

            Console.WriteLine($"\n--- {NumHalf} Half ---");

            // Alternate which team attacks first in each half
            bool isTeam1Attacking = random.Next(0, 2) == 0; //0-1 if 1 is true ,0 is false
                                                            //i search in documintation 


            // Number of turns for the half, you can adjust this for more variability
            int turns = random.Next(1, 5);

            //to check if first team is attack by random number turn 
            // // and flag to know if team1 attack 
            // // else defens

            for (int i = 0; i < turns; i++)
            {
                if (isTeam1Attacking)
                //use this method to know each team will assign gole and defends success 
                //team 1 attack 
                //team 2 defens
                {
                    SimulateTurnTeams(team1, team2);
                }
                else
                {
                    //team 2 attack 
                    //team 1 attack 
                    SimulateTurnTeams(team2, team1);
                }

                // Alternate the attacking team for the next turn
                isTeam1Attacking = !isTeam1Attacking;
            }
        }



        public void SimulateTurnTeams(Teams Attackteam, Teams Defendsteam)
        {
            Console.WriteLine($"Turn: {Attackteam.NameTeams} is attacking...");

            //one team will attack
            //total the number skilllevel is attack
            // forward and midfielder

            int skillAttck = Attackteam.AttackPlayer();

            //team will defend
            // total number skilllevel is defends
            //defends and goalkeeper
            int skilldefends = Defendsteam.defencePlayer();

            if (skillAttck > skilldefends + 5)//higher by 5 point 
            {
                Console.WriteLine("Goal!");
                score[Attackteam.NameTeams]++;

            }

            else
            {
                Console.WriteLine("Defended successfully!");
            }
            //current score 
            Console.WriteLine($"Current Score: {team1.NameTeams}: {score[team1.NameTeams]} | {team2.NameTeams}: {score[team2.NameTeams]}");
        }


        public void DisplayResults()
        {
            Console.WriteLine("Final Score: ");

            Console.WriteLine($"{team1.NameTeams} : {score[team1.NameTeams]} | {team2.NameTeams} : {score[team2.NameTeams]}");

            if (score[team1.NameTeams] > score[team2.NameTeams])
            {
                Console.WriteLine($"Team {team1.NameTeams} wins!");
            }
            else if (score[team1.NameTeams] < score[team2.NameTeams])
            {
                Console.WriteLine($"Team {team2.NameTeams} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
                Console.WriteLine();
                Console.WriteLine("------- Plenalty Shout ------");
                Console.WriteLine(" enter to start the Plenalty Shout  ");
                Console.ReadLine();

                PlenaltyShout();
            }
        }

        // bouns idea if teams is draw 
        public void PlenaltyShout()
        {
            //add score team 1 and team 2

            int scoreteam1 = 0;
            int scoreteam2 = 0;
            //to compare with chance AverageForword by % 
            //if ScoringForward is 50% skilllevel 
            //will compare with roundomnumber 
            int RoundomNum = random.Next(1, 100);
            //add turn value  
            int trun = 5;

            for (int i = 0; i <= trun; i++)
            {

                Console.WriteLine($"\n--- Round {i} ---");

                // attacker team 1 shout in turn 5
                if (RoundomNum<= team1.ScoringForward())

                {
                    Console.WriteLine($"{team1.NameTeams} scored!");
                    scoreteam1++;
                }
                else
                {
                    Console.WriteLine($"{team1.NameTeams} missed!");
                }


                // attacker team 2 shout in turn 5

                if (RoundomNum <= team2.ScoringForward())

                {
                    Console.WriteLine($"{team2.NameTeams} scored!");
                    scoreteam2++;
                }
                else
                {
                    Console.WriteLine($"{team2.NameTeams} missed!");
                }

                Console.WriteLine($"Current score in round  {i}: {team1.NameTeams} {scoreteam1} | {team2.NameTeams} {scoreteam2}");
            }


            //Display all plenty shoat score 
            Console.WriteLine($"\nFinal Penalty Shootout Score:");

            Console.WriteLine($"{team1.NameTeams} {scoreteam1} | {team2.NameTeams} {scoreteam2}");

            //check who is win and miss and draw

            if (scoreteam1 > scoreteam2)
            {
                Console.WriteLine($"Team {team1.NameTeams} wins the penalty shootout!");
            }
            else if (scoreteam1 < scoreteam2)
            {
                Console.WriteLine($"Team {team2.NameTeams} wins the penalty shootout!");
            }
            else
            {
                Console.WriteLine("The penalty shootout ended in a draw!");
            }



        }
    }
}
    
