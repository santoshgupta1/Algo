using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        private static int[][] CreateMaze(int n, Func<int> getNextNumber)
        {
            int[][] result = new int[n][];
            for(int i = 0; i< n; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = getNextNumber() % 2;
                }
            }

            return result;
        }

        private static void PrintMaze(int[][] maze)
        {
            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    Console.Write(" " + maze[i][j]);
                }

                Console.Write("\n");
            }            
        }

        static int count = 0;
        private static bool SolveMaze(int[][] maze, int i, int j, int length, string direction)
        {
            count++;
            
            if (i == length-1 && j == length-1 && maze[i][j] == 1)
            {
                //Console.WriteLine(i + ":" + j + "," + direction + " : " + maze[i][j]);
                solution[i][j] = 1;
                return true;
            }
            
            if (i >= 0 && i < length && j>=0 && j<length && maze[i][j] == 1) // check to navigate
            {
                //Console.WriteLine(i + ":" + j + "," + direction + " : " + maze[i][j]);

                solution[i][j] = 1;
                
                if (direction != "up"  && SolveMaze(maze, i +1, j, length, "down")) //bottom
                {
                    return true;
                }
                if (direction != "left" && SolveMaze(maze, i, j + 1, length, "right")) // right
                {
                    return true;
                }
                if (direction != "down" && SolveMaze(maze, i - 1, j, length, "up"))//top 
                {
                    return true;
                }
                if (direction != "right" && SolveMaze(maze, i, j -1, length, "left")) // left
                {
                    return true;
                }

                solution[i][j] = 0;
                return false;
            }

            return false;
        }

        private static int[][] solution;

        static void Main(string[] args)
        {
            int n = 5;
            int[][] maze1 = {
                                new int[] { 1, 0, 1, 1,1 },
                                new int[] { 1, 1, 1, 0,1 },
                                new int[] { 0, 0,0, 1, 1 },
                                new int[] { 0, 0, 0, 1,1 },
                                new int[] { 0, 0,0, 1, 1 } };
            int[][] maze2 = {
                                new int[] { 1, 0, 1, 1,1 },
                                new int[] { 1, 1, 1, 0,1 },
                                new int[] { 0, 0,0, 1, 1 },
                                new int[] { 0, 0, 0, 1,1 },
                                new int[] { 0, 0,0, 1, 1 } };
            Random rand = new Random();
            Func<int> getnext = () => { return rand.Next(); };
            Func<int> getZero = () => { return 0; };
            for (int x = 0; x < 100; x++)
            {
                int[][] maze = CreateMaze(n, getnext);
                solution = CreateMaze(n, getZero);
                PrintMaze(maze);
                Console.WriteLine();
                // PrintMaze(solution);
                Console.WriteLine();
                if (SolveMaze(maze, 0, 0, n, "down"))
                {
                    Console.WriteLine("Result:" + count);
                    PrintMaze(solution);
                }
                else
                {
                    Console.WriteLine("No solution exists");
                }
               
            }

            Console.ReadKey();
        }
    }
}
