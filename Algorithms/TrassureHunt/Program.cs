using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrassureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] treasure = new int[][]{ new int [] { 2, 3, 2, 1, 2},
                                            new int [] { 2, 3, 4, 5, 6},
                                            new int [] { 1, 3, 4, 7, 1},
                                            new int []  { 3, 4, 1, 2, 4}};

            List<Tuple<int, int>> resultPath = new List<Tuple<int, int>>();

            Console.WriteLine("Problem2 result: " + GetMaxTreasureValue(treasure, out resultPath));
            Console.WriteLine(string.Format("Using problem2 treasure path and running Problem1 and result is : {0}, used matrixIndex: {1}", CheckTreasure(treasure, resultPath),
                string.Join(",", resultPath.Select(t => string.Format("({0},{1})", t.Item1, t.Item2)))));
            Console.ReadKey();
        }

        static int GetMaxTreasureValue(int[][] treasure, out List<Tuple<int, int>> resultPath)
        {
            List<List<Tuple<int, int>>> resultPathCollection = new List<List<Tuple<int, int>>>();
            List<int> tresureSum = new List<int> { };
            for (int i = 0; i < (treasure.Length); i++)
            {
                List<Tuple<int, int>> rowResultPath = new List<Tuple<int, int>>();
                tresureSum.Add(GetRowMaxValue(treasure[i], i, out rowResultPath));
                resultPathCollection.Add(rowResultPath);
            }

            resultPath = new List<Tuple<int, int>>();

            List<Tuple<int, int>> collectionResultPath = new List<Tuple<int, int>>();
            int max = GetRowMaxValue(tresureSum.ToArray(), treasure.Length, out collectionResultPath);
            foreach (var result in collectionResultPath)
            {
                resultPath.AddRange(resultPathCollection.ElementAt(result.Item2));
            }

            return max;
        }

        static int GetRowMaxValue(int[] treasure, int rowIndex, out List<Tuple<int, int>> resultPath)
        {
            return GetMax(treasure, 0, 0, rowIndex, out resultPath);
        }

        static int GetMax(int[] a, int index, int cursum, int rowIndex, out List<Tuple<int, int>> resultPath)
        {
            resultPath = new List<Tuple<int, int>> { };
            if (index > a.Length - 1)
            {
                return 0;
            }

            List<Tuple<int, int>> path1 = new List<Tuple<int, int>> { };
            List<Tuple<int, int>> path2 = new List<Tuple<int, int>> { };
            List<Tuple<int, int>> path3 = new List<Tuple<int, int>> { };
            int includingMe = cursum + a[index] + GetMax(a, index + 2, cursum, rowIndex, out path1);
            int excludingMeIncludingNext = cursum + GetMax(a, index + 1, cursum, rowIndex, out path2);
            int excludingMeExcludingNext = cursum + GetMax(a, index + 2, cursum, rowIndex, out path3);
            if (includingMe > excludingMeIncludingNext && includingMe > excludingMeExcludingNext)
            {
                resultPath.Add(new Tuple<int, int>(rowIndex, index));
                resultPath.AddRange(path1);
            }
            else
            {
                resultPath.AddRange(path2);
            }

            int result = Math.Max(Math.Max(includingMe, excludingMeIncludingNext), excludingMeExcludingNext);
            return result;
        }

        static int CheckTreasure(int[][] treasure, List<Tuple<int, int>> path)
        {
            int value = 0;
            List<Tuple<int, int>> forbidden = new List<Tuple<int, int>>();
            for (int i = 0; i < path.Count(); i++)
            {
                if ((path[i].Item1 < 0 || path[i].Item1 >= treasure.Length) ||
                        (path[i].Item2 < 0 || path[i].Item2 >= treasure[0].Length))
                {
                    throw new ArgumentException("Forbidden");
                }
                else if (forbidden.Any(f => f.Item1 == path[i].Item1 && f.Item2 == path[i].Item2))
                {
                    throw new ArgumentException("Forbidden");
                }

                forbidden.Add(new Tuple<int, int>(path[i].Item1, path[i].Item2 - 1));
                forbidden.Add(new Tuple<int, int>(path[i].Item1, path[i].Item2 + 1));
                for (int j = 0; j < treasure[0].Length; j++)
                {
                    forbidden.Add(new Tuple<int, int>(path[i].Item1 - 1, j));
                    forbidden.Add(new Tuple<int, int>(path[i].Item1 + 1, j));
                }
                value += treasure[path[i].Item1][path[i].Item2];
            }

            return value;
        }
    }
}
