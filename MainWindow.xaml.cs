using DogAtTheRaces.classes;
using Microsoft.Win32.SafeHandles;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DogAtTheRaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public Greyhound[] GreyhoundArray = new Greyhound[4];
        public Guy[] guys = new Guy[3];
        Guy selected;
        public MainWindow()
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            // Instellen wat de interval is (1 seconde)
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            InitializeComponent();
            Random Randomizer = new Random();
            GreyhoundArray[0] = new Greyhound((int)dog1.Margin.Left, (int)(raceTrack.Width - dog1.Width), Randomizer, dog1)
            {
               
            };
            GreyhoundArray[1] = new Greyhound((int)dog2.Margin.Left, (int)(raceTrack.Width - dog2.Width), Randomizer, dog2)
            {

            };
            GreyhoundArray[2] = new Greyhound((int)dog3.Margin.Left, (int)(raceTrack.Width - dog3.Width), Randomizer, dog3)
            {

            };
            GreyhoundArray[3] = new Greyhound((int)dog4.Margin.Left, (int)(raceTrack.Width - dog4.Width), Randomizer, dog4)
            {

            };

         

            GreyhoundArray[0].TakeStartingPosition();
            GreyhoundArray[1].TakeStartingPosition();
            GreyhoundArray[2].TakeStartingPosition();
            GreyhoundArray[3].TakeStartingPosition();

            guys[0] = new Guy("Joe", 50, radioButton_Joe)
            {
                myLabel = label_Joe
            };
            guys[1] = new Guy("Bob", 75, radioButton_Bob)
            {
                myLabel = label_Bob
            };
            guys[2] = new Guy("Al",45, radioButton_Al)
            {
                myLabel = label_Al
            };

            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();


           
        }


        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            

            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                if (GreyhoundArray[i].Run() == true)
                {
                   dispatcherTimer.Stop();

                    if (GreyhoundArray[0].Run() == true)
                    {
                       
                    }
                   
                }

                
            }



            //int guyLenght = guys.Length;   heb ik hier iets aan?
            // guys[guyLenght].myBet.PayOut(i);

            //welke nummer hond heeft gewonnen?
            //welke guy heet op dat nummer hond gebet?
            //geef die guy zijn payout


            // logica van wanneer een hond heeft gewonnen
            // bets uitbetalen
            // labels resetten



            // GreyhoundArray[0].Run();
            //  GreyhoundArray[1].Run();
            //  GreyhoundArray[2].Run();
            //  GreyhoundArray[3].Run();

        }



        private void radioButton_Joe_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton_Joe.IsChecked == true)
            {
                GuyBetName.Content = guys[0].name;
                selected = guys[0];
                
            }
        }

        private void radioButton_Bob_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton_Bob.IsChecked == true)
            {
                GuyBetName.Content = guys[1].name;
                selected = guys[1];
            }
        }

        private void radioButton_Al_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton_Al.IsChecked == true)
            {
                GuyBetName.Content = guys[2].name;
                selected = guys[2];
            }
        }


       
        private void PlaceBet(object sender, RoutedEventArgs e)
        {
            int numberBet;
            int numberDog;

            if (int.TryParse(BetAmount.Text, out numberBet) & int.TryParse(DogNumber.Text, out numberDog) & selected != null)
            {
                
                if (numberDog <= GreyhoundArray.Length & numberDog >= 1)
                {
                    selected.PlaceBet(numberBet, (numberDog - 1));
                }
            }
            guys[1].UpdateLabels();        //moet in loop?
            guys[0].UpdateLabels();
            guys[2].UpdateLabels();

         
        }

        private void StartRace(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();


        }
       
        
    }
}