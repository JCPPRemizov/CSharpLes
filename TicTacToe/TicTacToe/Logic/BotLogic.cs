using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace TicTacToe
{
    public class BotLogic
    {
        private WinLogic winLogic = new WinLogic();
        public void BotMove(char[,] board, char botSymbol, char playerSymbol)
        {
            //Проверка, что бот в следующем ходе может выиграть
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                    {
                        board[i, j] = botSymbol;
                        if (winLogic.IsWinner(board, botSymbol))
                        {
                            Button botButton = GetButtonAt(i, j);
                            botButton.Content = botSymbol;
                            botButton.IsEnabled = false;
                            return;
                        }
                        else
                        {
                            board[i, j] = '\0';
                        }
                    }
                }
            }
            //Проверка,что игрок в следующем ходе может выиграть.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                    {
                        board[i, j] = playerSymbol;
                        if (winLogic.IsWinner(board, playerSymbol))
                        {
                            board[i, j] = botSymbol;
                            Button botButton = GetButtonAt(i, j);
                            botButton.Content = botSymbol;
                            botButton.IsEnabled = false;
                            return;
                        }
                        else
                        {
                            board[i, j] = '\0';
                        }
                    }
                }
            }
            //Рандомный ход
            Random rnd = new Random();
            int row, col;
            do
            {
                row = rnd.Next(0, 3);
                col = rnd.Next(0, 3);
            } while (board[row, col] != '\0');

            board[row, col] = botSymbol;
            Button bot_Button = GetButtonAt(row, col);
            bot_Button.Content = botSymbol;
            bot_Button.IsEnabled = false;
        }
        private Button GetButtonAt(int row, int col)
        {
            MainWindow mainWindow = GetMainWindow();
            switch (row)
            {
                case 0:
                    switch (col)
                    {
                        case 0:
                            return mainWindow.Button0_0;
                        case 1:
                            return mainWindow.Button0_1;
                        case 2:
                            return mainWindow.Button0_2;
                        default:
                            return null;
                    }
                case 1:
                    switch (col)
                    {
                        case 0:
                            return mainWindow.Button1_0;
                        case 1:
                            return mainWindow.Button1_1;
                        case 2:
                            return mainWindow.Button1_2;
                        default:
                            return null;
                    }
                case 2:
                    switch (col)
                    {
                        case 0:
                            return mainWindow.Button2_0;
                        case 1:
                            return mainWindow.Button2_1;
                        case 2:
                            return mainWindow.Button2_2;
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
        public static MainWindow GetMainWindow()
        {
            MainWindow mainWindow = null;

            foreach (Window window in Application.Current.Windows)
            {
                Type type = typeof(MainWindow);
                if (window != null && window.DependencyObjectType.Name == type.Name)
                {
                    mainWindow = (MainWindow)window;
                    if (mainWindow != null)
                    {
                        break;
                    }
                }
            }


            return mainWindow;

        }

    }
}
