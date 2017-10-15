using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        private static int[,] GetInput()
        {
            int[,] sudoku = new int[, ]{
                      { 3, 0, 6, 5, 0, 8, 4, 0, 0},
                      { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                      { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                      { 0, 0, 3, 0, 1, 0, 0, 8, 0},
                      { 9, 0, 0, 8, 6, 3, 0, 0, 5},
                      { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                      { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                      { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                      { 0, 0, 5, 2, 0, 6, 3, 0, 0}
                    };

            return sudoku;
        }
                      

        static void Main(string[] args)
        {
            int[,] sudoku = GetInput();
            Console.WriteLine("Input:");
            PrintSudoku(sudoku);

            Console.WriteLine("Output");
            if (SolveSudoku(sudoku))
            {
                PrintSudoku(sudoku);
            }
            else
            {
                Console.WriteLine("Cannot solve");
            }

            Console.ReadKey();
        }

        private static bool SolveSudoku(int[,] sudoku)
        {
            int row = -1;
            int col = -1;
            if(!TryGetNextEmptySpot(sudoku, out row, out col))
            {
                return true;
            }

            for(int i=1; i<= 9; i++)
            {
                if (IsSafe(sudoku, row, col, i))
                {
                    sudoku[row, col] = i;
                    if(SolveSudoku(sudoku))
                    {
                        return true;
                    }

                    sudoku[row, col] = 0;
                }
            }            

            return false;
        }

        private static bool IsSafe(int[,] sudoku, int row, int col, int val)
        {
            return RowCheck(sudoku, row, col, val)
                && ColCheck(sudoku, row, col, val)
                && BoxCheck(sudoku, row, col, val);
        }

        private static bool RowCheck(int[,] sudoku, int row, int col, int val)
        {
            bool result = true;
            for(int i=0; i<sudoku.GetLength(0); i++)
            {
                if(sudoku[i,col] == val)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static bool ColCheck(int[,] sudoku, int row, int col, int val)
        {
            bool result = true;
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                if (sudoku[row, i] == val)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static bool BoxCheck(int[,] sudoku, int row, int col, int val)
        {
            bool result = true;
            int rowStart = row - row % 3;
            int colStart = col - col % 3;

            for (int i = rowStart; i < rowStart+3; i++)
            {
                for (int j = colStart; j < colStart + 3; j++)
                {
                    if (sudoku[i, j] == val)
                    {
                        result = false;
                        break;
                    }
                }                    
            }

            return result;
        }

        private static bool TryGetNextEmptySpot(int[,] sudoku, out int row, out int col)
        {
            row = -1;
            col = -1;
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku.GetLength(0); j++)
                {
                    if (sudoku[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return true;
                    }
                }
            }

            return row != -1 && col != -1;
        }

        private static void PrintSudoku(int[,] sudoku)
        {
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku.GetLength(0); j++)
                {
                    Console.Write("{0}  ", sudoku[i, j]);
                }

                Console.WriteLine();
            }
        }

    }
}
