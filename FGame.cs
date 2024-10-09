﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public  class FGame
    {
        private Teams team1;//object 1
        private Teams team2;//object 2
        Random random = new Random();
         static  Dictionary<string,int>score = new Dictionary<string,int>();

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


            CointossTeams();



        }

        public void CointossTeams()
        {


            //a coin toss will determine which team gets to start

            Console.WriteLine("\nCoin toss...");

            int teamstart=random.Next(0,2);

            if (teamstart == 0)
            {
                Console.WriteLine($"Coin toss... Team {team1.NameTeams} will start the game.");

            }
            else 
            {
                Console.WriteLine($"Coin toss... Team {team2.NameTeams} will start the game.");
            }

        }

        public void PlayHalf(string NumHalf)
        {
           
        }

        public void SimulateTurnTeams(Teams Attackteam , Teams Defendsteam)
        {
            Console.WriteLine($"Turn: {Attackteam.NameTeams} is attacking...");
        }

    }
}
