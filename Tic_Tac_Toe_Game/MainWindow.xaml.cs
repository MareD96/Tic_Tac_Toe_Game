using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //player one x player two 0

        public static List<Button> buttonNames = new List<Button>();
      
        public bool IsPlayerOne { get; set; } = true;
        public bool PlayerOneWinner { get; set; }
        private int clicks = 0;
        //scores
        public int PlayerOneScore { get; set; } = 0;
        public int PlayerTwoScore { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
            FillTheList();
        }

        //not sure about name maybe to rename it in v2
        /// <summary>
        /// This methods defines what will happen when its clicked on button
        /// </summary>
        /// <param name="button"> Button which fires up the event</param>
        private void SettingFiled(Button button)
        {
            if (IsPlayerOne == true)
            {
                button.Content = Utility.XO.X.ToString();
                button.IsEnabled = false;
                button.Foreground =new SolidColorBrush(Colors.Red);
                IsPlayerOne = false;
                contentText.Content = Utility.XO.O.ToString();
                contentText.Foreground = new SolidColorBrush(Colors.Blue);
                clicks++;
            }
            else
            {
                button.Content = Utility.XO.O.ToString();
                button.IsEnabled = false;
                button.Foreground = new SolidColorBrush(Colors.Blue);
                IsPlayerOne = true;
                contentText.Content = Utility.XO.X.ToString();
                contentText.Foreground = new SolidColorBrush(Colors.Red);
                clicks++;
            }
        }

        private void zeroZero_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(zeroZero);
            Winner();
        }

        private void zeroOne_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(zeroOne);
            Winner();
        }

        private void zeroTwo_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(zeroTwo);
            Winner();
        }

        private void oneZero_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(oneZero);
            Winner();
        }

        private void oneOne_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(oneOne);
            Winner();
        }

        private void oneTwo_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(oneTwo);
            Winner();
        }

        private void twoZero_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(twoZero);
            Winner();
        }

        private void twoOne_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(twoOne);
            Winner();

        }

        private void twoTwo_Click(object sender, RoutedEventArgs e)
        {
            SettingFiled(twoTwo);
            Winner();

        }

        /// <summary>
        /// Provides a logic for determining a winner
        /// </summary>
        private void Winner()
        {
            //this means its a draw
            if (clicks==9)
            {
                MessageBox.Show("It's a DRAW!", "We don't have winner, keep playing!", MessageBoxButton.OK, MessageBoxImage.Error);
                RestartContent();
            }
            
            //horizontal check for winner
    
            if (CheckForWinner(zeroZero, zeroOne, zeroTwo))
            {
                DeterminWinner();
            }

            if (CheckForWinner(oneZero, oneOne, oneTwo))
            {
                DeterminWinner();
            }

            if (CheckForWinner(twoZero, twoOne, twoTwo))
            {
                DeterminWinner();
            }

            // vertical check for winner

            if (CheckForWinner(zeroZero, oneZero, twoZero))
            {
                DeterminWinner();
            }

            if (CheckForWinner(zeroOne, oneOne, twoOne))
            {
                DeterminWinner();
            }

            if (CheckForWinner(zeroTwo, oneTwo, twoTwo))
            {
                DeterminWinner();
            }

            // diagaonal check for winner

            if (CheckForWinner(zeroZero, oneOne, twoTwo))
            {
                DeterminWinner();
            }
            if (CheckForWinner(zeroTwo, oneOne, twoZero))
            {
                DeterminWinner();
            }

           


        }
        /// <summary>
        /// Checks if exists the same value in a row, column or on the diagonle
        /// </summary>
        /// <param name="button1"></param>
        /// <param name="button2"></param>
        /// <param name="button3"></param>
        /// <returns></returns>
        private bool CheckForWinner(Button button1, Button button2, Button button3)
        {
            if (button1.Content.ToString() == Utility.XO.X.ToString() && button2.Content.ToString() == Utility.XO.X.ToString() && button3.Content.ToString() == Utility.XO.X.ToString())
            {
                PlayerOneWinner = true;
                return true;
            }
            else if ((button1.Content.ToString() == Utility.XO.O.ToString() && button2.Content.ToString() == Utility.XO.O.ToString() && button3.Content.ToString() == Utility.XO.O.ToString()))
            {
                PlayerOneWinner = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Helper method to fill the list of all buttons
        /// </summary>
        private void FillTheList()
        {
            buttonNames.Add(zeroZero);
            buttonNames.Add(zeroOne);
            buttonNames.Add(zeroTwo);
            buttonNames.Add(oneZero);
            buttonNames.Add(oneOne);
            buttonNames.Add(oneTwo);
            buttonNames.Add(twoZero);
            buttonNames.Add(twoOne);
            buttonNames.Add(twoTwo);
        }


        /// <summary>
        /// Defines what will happend if we have a winner
        /// </summary>
        private void DeterminWinner()
        {
            if (PlayerOneWinner)
            {
                MessageBox.Show("Player one is a Winner", "We've got a winner!", MessageBoxButton.OK, MessageBoxImage.Information);
                PlayerOneScore++;
                playerOneScore.Content = PlayerOneScore;
                RestartContent();
            }
            else
            {
                MessageBox.Show("Player two is a Winner", "We've got a winner!", MessageBoxButton.OK, MessageBoxImage.Information);
                PlayerTwoScore++;
                playerTwoScore.Content = PlayerTwoScore;
                RestartContent();
            }
        }
        /// <summary>
        /// Starts a new round
        /// </summary>
        private void RestartContent()
        {
            foreach (var item in buttonNames)
            {
                ButtonClearer(item);
            }
            IsPlayerOne = true;
            clicks = 0;
            contentText.Content = Utility.XO.X.ToString();
            contentText.Foreground = new SolidColorBrush(Colors.Red);
        }
        /// <summary>
        /// Clears content on selected button
        /// </summary>
        /// <param name="button"></param>
        private void ButtonClearer(Button button)
        {
            button.Content = "";
            button.IsEnabled = true;
        }

        //TODO DRY
    }
}
