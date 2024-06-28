using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Automation;
using System.Windows.Navigation;

namespace DogAtTheRaces.classes
{
    public class Bet
    {
        private int amount;  //the amound of the cash that was bet
        private int dog;  //the number of the dog the bet is on
        private Guy bettor;  //the guy who placed the bet


        public Bet(int betAmount, int dogToWin, Guy bettor)        
        {
            this.amount = betAmount;
            this.dog = dogToWin;
            this.bettor = bettor;

        }

        public string? GetDescription()
        {
            string description;

            if (this.amount == 0)
            {
                description = bettor.name + "hasn't placed a bet";
            }
            else
            {
                 description = bettor.name + "bets" + this.amount + "on dog" + this.dog;

            }

            //return a string that says who placed the bet, how much
            //cash was bet, and which dog he bet on ("joe bets 8 on dog #4").
            //if the amound is zero, no bet was placed ("joe hasn't placed a bet").
            return description;
        }

        public int PayOut(int winner)
        {
            
            int payOut;

            if (this.dog == winner)
            {
                Console.Write("the dog won");
                payOut = amount;      
            }
            else
            {
                Console.Write("the dog lost");
                payOut = -amount;   
            }

            //the parameter is the winner of the race. if the dog won, 
            //return the amound bet. otherwise, return the negative of the amound bet.
            return payOut;
        }

    }
}
