using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public  interface IGameActions
    {
        void StartGame();
        void SimulateTurnTeams(Teams attackingTeam, Teams defendingTeam);
        void DisplayResults();
        void PlayHalf(string half);
    }
}
