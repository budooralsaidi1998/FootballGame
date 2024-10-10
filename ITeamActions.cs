using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameAssignment
{
    public  interface ITeamActions
    {
        void AutomaticallyGeneratPlayer();
        int AttackPlayer();
        int defencePlayer();
        void DisplayPayer();
    }
}
