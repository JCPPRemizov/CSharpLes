using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    public class WinLogic
    {
        public bool IsWinner(char[,] b, char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (b[i, 0] == symbol && b[i, 1] == symbol && b[i, 2] == symbol)
                {
                    return true;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (b[0, j] == symbol && b[1, j] == symbol && b[2, j] == symbol)
                {
                    return true;
                }
            }

            if (b[0, 0] == symbol && b[1, 1] == symbol && b[2, 2] == symbol)
            {
                return true;
            }
            if (b[0, 2] == symbol && b[1, 1] == symbol && b[2, 0] == symbol)
            {
                return true;
            }
            return false;
        }
        public bool isDraw(int moveCount)
        {
            if (moveCount == 9)
            {
                return true;
            }
            return false;
        }
       
    }
}
