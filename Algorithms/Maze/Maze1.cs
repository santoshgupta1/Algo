using System;

public class RatInMaze
{

    public int[][] solution;

    //initialize the solution matrix in constructor.
    public RatInMaze(int N)
    {
        solution = CreateMaze(N, () => { return 0; });
    }


    private static int[][] CreateMaze(int n, Func<int> getNextNumber)
    {
        int[][] result = new int[n][];
        for (int i = 0; i < n; i++)
        {
            result[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                result[i][j] = getNextNumber() % 2;
            }
        }

        return result;
    }

    public void solveMaze(int[][] maze, int N)
    {
        if (findPath(maze, 0, 0, N, "down"))
        {
            print(solution, N);
        }
        else
        {
            Console.WriteLine("NO PATH FOUND");
        }

    }

    public bool findPath(int[][] maze, int x, int y, int N, string direction)
    {
        // check if maze[x][y] is feasible to move
        if (x == N - 1 && y == N - 1)
        {//we have reached
            solution[x][y] = 1;
            return true;
        }
        if (isSafeToGo(maze, x, y, N))
        {
            // move to maze[x][y]
            solution[x][y] = 1;
            // now rat has four options, either go right OR go down or left or go up
            if (direction != "up" && findPath(maze, x + 1, y, N, "down"))
            { //go down
                return true;
            }
            //else go down
            if (direction != "left" && findPath(maze, x, y + 1, N, "right"))
            { //go right
                return true;
            }
            if (direction != "down" && findPath(maze, x - 1, y, N, "up"))
            { //go up
                return true;
            }
            if (direction != "right" && findPath(maze, x, y - 1, N, "left"))
            { //go left
                return true;
            }
            //if none of the options work out BACKTRACK undo the move
            solution[x][y] = 0;
            return false;
        }
        return false;
    }

    // this function will check if mouse can move to this cell
    public bool isSafeToGo(int[][] maze, int x, int y, int N)
    {
        // check if x and y are in limits and cell is not blocked
        if (x >= 0 && y >= 0 && x < N && y < N && maze[x][y] != 0)
        {
            return true;
        }
        return false;
    }
    public void print(int[][] solution, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(" " + solution[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void Main1(string[] args)
    {
        int N = 5;
        int[][] maze = {
                                new int[] { 1, 1, 1, 1,1 },
                                new int[] { 1, 1, 1, 1,1 },
                                new int[] { 1, 1,1, 1, 1 },
                                new int[] { 1, 1, 1, 1,1 },
                                new int[] { 1, 1,1, 1, 1 } };
        RatInMaze r = new RatInMaze(N);
        r.solveMaze(maze, N);
        Console.ReadKey();
    }

}