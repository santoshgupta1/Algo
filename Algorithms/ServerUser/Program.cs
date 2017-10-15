using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUser
{
    class Program
    {
        static Dictionary<int, List<int>> input = new Dictionary<int, List<int>>();
        
        private static void AddInput()
        {
            input.Add(0, new List<int>() { 3 });
            input.Add(1, new List<int>() { 2 , 1});
            input.Add(2, new List<int>() { 0, 2});
            input.Add(3, new List<int>() { 1, 0});
        }

        static void Main(string[] args)
        {
            AddInput();
            List<Tuple<int, int>> output = new List<Tuple<int, int>>();
            //output = GetUserServerMap(4);
            GetUserServerMapBackTracking(output, 0, 4);
            //output.ForEach(o => Console.WriteLine("{0} -> {1}", o.Item1, o.Item2));
            Console.ReadKey();
        }

        static bool GetUserServerMapBackTracking(List<Tuple<int, int>> userServerMap, int user, int n)
        {
            if(user >= n)
            {
                Console.WriteLine("Solution:");
                userServerMap.ForEach(o => Console.WriteLine("{0} -> {1}", o.Item1, o.Item2));
                return true;
            }

            for(int server = 0; server < n; server++)
            {
                if(IsSafe(userServerMap, user, server))
                {
                    userServerMap.Add(new Tuple<int, int> (user, server));
                    GetUserServerMapBackTracking(userServerMap, user + 1, n);
                    userServerMap.RemoveAll(u => u.Item1 == user);
                }
            }

            return false;
        }

        static bool IsSafe(List<Tuple<int, int>> userServerMap, int user, int server)
        {
            bool result = IsUserOnServer(user, server) && !userServerMap.Any(u => u.Item2 == server);
            return result;
        }

        static List<Tuple<int, int>> GetUserServerMap(int n)
        {
            bool[] usermap = new bool[n];
            List<Tuple<int, int>> output = new List<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (IsUserOnServer(i, j) && !usermap[j])
                    {
                        output.Add(new Tuple<int, int>(i, j));
                        usermap[j] = true;
                        break;
                    }
                }
            }

            return output;
        }

        static bool IsUserOnServer(int user, int server)
        {
            return input[server].Contains(user);
        }
    }
}
