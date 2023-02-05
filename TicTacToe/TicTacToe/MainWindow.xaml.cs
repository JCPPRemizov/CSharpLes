using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private BotLogic bot = new BotLogic();
        private WinLogic winLogic = new WinLogic();
        private char[,] board = new char[3, 3];
        private char playerSymbol = 'X';
        private char botSymbol = 'O';
        private bool turn = false;
        private int moveCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            DisableAllButtons();
        }
        private void DisableAllButtons()
        {
            Button0_0.IsEnabled = false;
            Button0_1.IsEnabled = false;
            Button0_2.IsEnabled = false;
            Button1_0.IsEnabled = false;
            Button1_1.IsEnabled = false;
            Button1_2.IsEnabled = false;
            Button2_0.IsEnabled = false;
            Button2_1.IsEnabled = false;
            Button2_2.IsEnabled = false;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Button button = (Button)sender;
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                button.Content = playerSymbol;
                board[row, col] = playerSymbol;
                button.IsEnabled = false;
                moveCount++;
                if (winLogic.IsWinner(board, playerSymbol))
                {
                    label1.Content = $"Победили: {playerSymbol} - ки";
                    DisableAllButtons();
                }
                else if (winLogic.isDraw(moveCount) == false)
                {
                    bot.BotMove(board, botSymbol, playerSymbol);
                    moveCount++;
                    if (winLogic.IsWinner(board, botSymbol))
                    {
                        label1.Content = $"Победили: {botSymbol} - ки";
                        DisableAllButtons();
                    }
                }
                else if (winLogic.isDraw(moveCount) == true)
                {
                    label1.Content = "Ничья";
                    DisableAllButtons();
                }
         
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(board, 0, board.Length);
            label1.Content = "Крестики - нолики";
            if (turn == true)
            {
                turn = false;
                playerSymbol = 'O';
                botSymbol = 'X';
            }
            else if (turn == false)
            {
                turn = true;
                playerSymbol = 'X';
                botSymbol = 'O';
            }
            moveCount = 0;
            Button0_0.IsEnabled = true;
            Button0_1.IsEnabled = true;
            Button0_2.IsEnabled = true;
            Button1_0.IsEnabled = true;
            Button1_1.IsEnabled = true;
            Button1_2.IsEnabled = true;
            Button2_0.IsEnabled = true;
            Button2_1.IsEnabled = true;
            Button2_2.IsEnabled = true;

            Button0_0.Background = Brushes.White;
            Button0_1.Background= Brushes.White;
            Button0_2.Background= Brushes.White;
            Button1_0.Background= Brushes.White;
            Button1_1.Background = Brushes.White;
            Button1_2.Background = Brushes.White;
            Button2_0.Background = Brushes.White;
            Button2_1.Background = Brushes.White;
            Button2_2.Background = Brushes.White;


            Button0_0.Content = "";
            Button0_1.Content = "";
            Button0_2.Content = "";
            Button1_0.Content = "";
            Button1_1.Content = "";
            Button1_2.Content = "";
            Button2_0.Content = "";
            Button2_1.Content = "";
            Button2_2.Content = "";
        }
    }
}