using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;

namespace DogAtTheRaces.classes 
{
    public class Guy
    {
        public string name;  //guy's name
        public Bet? myBet = null;  //an instance of bet that has his bet
        public int cash;   //how much cash he has 

        public RadioButton? myRadioButton; //my radio button
        public System.Windows.Controls.Label? myLabel = null;  //my label

        public Guy(string name, Bet myBet, int myCash)
        {
            this.name = name;
            this.myBet = myBet;
            this.cash = myCash;
        }
        public void UpdateLabels()
        {
            
            myLabel.Content = myBet.GetDescription();
            myRadioButton.Content = name + "has" + cash + "bucks";

            //set my label to my bet's description, and the label on my
            //radio button to show my cash("Joe has 43 bucks")
        }
        public void ClearBet()
        {
            myBet = null;
            //reset my bet to zero
        }
        public bool PlaceBet(int betAmount, int dogToWin)
        {
            myBet = new Bet(betAmount, dogToWin, this);

            if (betAmount < 5 | betAmount > cash)
            {
                Console.Write("not enough cash");
                return false;
            }
            else
            {
                return true;
            }

            //place a new bet and store it in my bet field
            //return true if the guy had enough money to bet
            //bets are represented by instances of Bet

        }
        public void Collect(int winner)
        {
            //myBet moet betalen

            myBet.PayOut(winner);

            ClearBet();
            UpdateLabels();
           //het geld moet naar winner
          
            //ask my bet to pay out, clear my bet, and update my labels
            //use bet object
        }

     }
   
}


