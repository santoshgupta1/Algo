using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            bool[,] queen = new bool[n, n];
            PrintQueens(queen);
            Console.WriteLine("Output");
            SolveQueen(queen, 0);
            Console.ReadKey();
        }

        static void PrintQueens(bool[,] nQueens)
        {
            for(int i=0; i< nQueens.GetLength(0); i++)
            {
                for(int j=0; j < nQueens.GetLength(0); j++)
                {
                    Console.Write("{0} ", nQueens[i, j]);
                }

                Console.WriteLine();
            }
        }

        static bool IsSafe(bool[,] board, int row, int col)
        {
            int i, j;

            /* Check this row on left side */
            for (i = 0; i < col; i++)
                if (board[row,i])
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i,j])
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col; j >= 0 && i < board.GetLength(0); i++, j--)
                if (board[i,j])
                    return false;

            return true;
        }

        static bool SolveQueen(bool[,] nQueens, int col)
        {
            if (col >= nQueens.GetLength(0))
            {
                PrintQueens(nQueens);
                return true;
            }

            for(int i=0; i<nQueens.GetLength(0);i++)
            {
                if(IsSafe(nQueens,i,col))
                {
                    nQueens[i, col] = true;
                    if(SolveQueen(nQueens, col + 1))
                    {
                        return true;
                    }
                    nQueens[i, col] = false;
                }
            }

            return false;
        }
    }
}
