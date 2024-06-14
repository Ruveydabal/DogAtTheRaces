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

            guys[0] = new Guy("Joe", guyBet, 50)
            {
                myLabel = label_Joe
            };
            guys[1] = new Guy("Bob", guyBet, 75)
            {
                myLabel = label_Bob
            };
            guys[2] = new Guy("Al", guyBet, 45)
            {
                myLabel = label_Al
            };

            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();


           
        }




        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            
            GreyhoundArray[2].Run();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }


    }
}