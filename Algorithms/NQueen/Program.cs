using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = GetInput();
            PrintBoard(board);
            if(NQueen(board, 0))
            {
                Console.WriteLine("Output:");
                PrintBoard(board);
            }
            else
            {
                Console.WriteLine("solution does not exist");
            }

            Console.ReadKey();  
        }

        private static int[,] GetInput()
        {
            int n = 4;
            int[,] board = new int[n, n];
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    board[i, j] = 0;
                }
            }

            return board;
        }

        private static void PrintBoard(int[,] board)
        {
            for(int i=0; i<= board.GetUpperBound(0); i++)
            {
                for(int j=0; j<= board.GetUpperBound(1);j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static bool NQueen(int[,] board, int col)
        {
            if (col > board.GetUpperBound(1))
            {
                Console.WriteLine("op");
                PrintBoard(board);
                return true;
            }

            for(int row=0; row<= board.GetUpperBound(0); row++)
            {
                if(IsSafe(board, row, col))
                {
                    board[row, col] = 1;
                    if(NQueen(board, col + 1))
                    {
                        return true;
                    }
                    board[row, col] = 0;
                }
            }
            return false;
        }

        static bool IsSafe(int[,] board, int row , int col)
        {
            return IsSafeRow(board, row) && IsSafeCol(board, col)
                && IsSafeDiagonal(board, row, col);
        }

        static bool IsSafeRow(int[,] board, int row)
        {
            for(int i=0; i<= board.GetUpperBound(1); i++)
            {
                if(board[row, i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
        static bool IsSafeCol(int[,] board, int col)
        {

            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                if (board[i, col] == 1)
                {
                    return false;
                }
            }

            return true;
        }
        static bool IsSafeDiagonal(int[,] board, int row, int col)
        {
            // upper diagonal
            for (int i = row, j=col; i >= 0 && j>=0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }
            
            // left lower diagonal
            for (int i = row, j = col; i <= board.GetUpperBound(0) && j >= 0; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
