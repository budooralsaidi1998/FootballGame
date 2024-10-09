using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public  class FGame
    {
        private Teams team1;
        private Teams team2;
         static  Dictionary<string,int>score = new Dictionary<string,int>();

        public void StartGame()
        {
            string teamname1;
            string teamname2;


            Console.WriteLine("Welcome to the Soccer Game Simulator!");

            Console.WriteLine();

            Console.Write(" Enter name of team 1 : ");
            teamname1 = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Enter name of team 1 : ");
            teamname2 = Console.ReadLine();


            team1 = new Teams(teamname1);
            team2 = new Teams(teamname2);

            score[team1.NameTeams] = 0;
            score[team2.NameTeams] = 0;
        }

    }
}
