using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xaml.Schema;

namespace DogAtTheRaces.classes
{
    public class Greyhound
    {
        public int startingPosition; // where image starts
        public int racetracklength; //length of racetrack
        public Image? myPictureBox = null; //my image object
        public int location = 0; //my location on the racetrack
        public Random Randomizer; //an instance of random
        TransformGroup trGrp = new TransformGroup();
        TranslateTransform trTrf = new TranslateTransform();


        public Greyhound(int startingPosition, int racetracklength, Random Randomizer, Image myPictureBox)
        {
            this.startingPosition = startingPosition;
            this.racetracklength = racetracklength;
            this.Randomizer = Randomizer;
            this.myPictureBox = myPictureBox;
            trGrp.Children.Add(trTrf);
            this.myPictureBox.RenderTransform = trGrp;
        }

     
        public bool Run()
        {
            int move = Randomizer.Next(1, 4);    //move foreward either 1,2,3 or 4 spaces at random
            location = location + move;

            trTrf.X = location;
            trTrf.X = startingPosition + location;   

            if(trTrf.X > 620)          //klopt dit?
            {                   
                return true;
            }
            else
            {
                return false;
            }




            //update the posistion of my picturebox on the form like:
            //      mypicturebox.left = startingposistion + location;

            //return true if i won the game.
        }

        public void TakeStartingPosition()
        {
            location = 0;
            myPictureBox = null; 

            //reset my location to 0 and my picturebox to starting position
        }
         

    }

   
}
