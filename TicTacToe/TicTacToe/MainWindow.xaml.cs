﻿using System;
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
        private bool isPlayerTurn = true;
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
            if (isPlayerTurn)
            {
                Button button = (Button)sender;
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                button.Content = playerSymbol;
                board[row, col] = playerSymbol;
                button.IsEnabled = false;
                moveCount++;
                isPlayerTurn= false;

                if (winLogic.IsWinner(board, playerSymbol))
                {
                    label1.Content = $"Победили: {playerSymbol} - ки";
                    DisableAllButtons();
                }
                else if (winLogic.isDraw(moveCount) == true)
                {
                    label1.Content = "Ничья";
                    DisableAllButtons();
                }
                else if (!isPlayerTurn)
                {
                    bot.BotMove(board, botSymbol, playerSymbol);
                    isPlayerTurn = true;
                    moveCount++;
                    if (winLogic.IsWinner(board, botSymbol))
                    {
                        label1.Content = $"Победили: {botSymbol} - ки";
                        DisableAllButtons();
                    }
                }
            }
         
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(board, 0, board.Length);
            label1.Content = "Крестики - нолики";
            if (turn == true)
            {
                turn = false;
                isPlayerTurn = false;
                playerSymbol = 'O';
                botSymbol = 'X';
            }
            else if (turn == false)
            {
                turn = true;
                isPlayerTurn = true;
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


            Button0_0.Content = "";
            Button0_1.Content = "";
            Button0_2.Content = "";
            Button1_0.Content = "";
            Button1_1.Content = "";
            Button1_2.Content = "";
            Button2_0.Content = "";
            Button2_1.Content = "";
            Button2_2.Content = "";
            if (!isPlayerTurn)
            {
                bot.BotMove(board, botSymbol, playerSymbol);
                isPlayerTurn = true;
                moveCount++;
                if (winLogic.IsWinner(board, botSymbol))
                {
                    label1.Content = $"Победили: {botSymbol} - ки";
                    DisableAllButtons();
                }
            }
        }
    }
}
