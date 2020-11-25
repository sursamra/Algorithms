using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //changes from bugfixes branch
            //from previous checkouts rest ( delete changes)
            // test changes
            //SurSamra made changes online.
            //For pull request
            //forked by l4m2
            // updated by sursamra in master
            Dijkstras_printing_paths.Test();
            Car_fueling_gas_Station.Test1();
            Car_fueling_gas_Station.Test2();
            Algorithms.Trees.BinarySearchTree.Test();
            GFG.RunDijkstra();

            foreach (var item in GetPer(new char[] { 'a', 'b', 'c' }))
            {
                // Console.WriteLine(item);
            }
            MinWindowSubstring(new string[] { "aabdccdbcacd", "aad" });

            Console.WriteLine(AreStringsAnagrams("elvies", "lives"));

            Tuple<int, int> result = FindTwoSum(new[] { 1, 2, 4, 5, 5, 6 }, 10);
            Console.WriteLine(result.Item1 + " " + result.Item2);
            Console.WriteLine(IndexOfLongestRun("aawwwddddccvvzzzzzzzz5555555555555555555555555555555555555555zzzzzzzz"));
            Console.WriteLine(Reverse1("abc def"));
            Console.WriteLine(Reverse2("abc def"));
            Duplicates(new[] { "abc", "def", "abc" }).All(a => { Console.WriteLine(a); return true; });
            Console.WriteLine(RomanToInteger("MCMLXI"));
            Console.WriteLine("Fibonacci numbers");
            Enumerable.Range(0, 10).All(a => { Console.WriteLine(Fibonacci(a)); return true; });
            //Fibonacci();
            Console.WriteLine("end Fibonacci numbers");

            Console.WriteLine(LongestString(new string[] { "hello", "who", "sfsd", "news" }));
            Console.WriteLine(UniqueCharsInString("abcabcabcabcabc"));
            Console.WriteLine(ReverseString("abcdef"));
            Console.WriteLine(Palindrom("eye"));
            Larget3Elements(new string[] { "abc", "sdfsdf", "df", "323", "2333223" }).All(a => { Console.WriteLine(a.ToString()); return true; });

            Console.WriteLine(DeepestString("[a [b [c [d value]]]]"));

            Console.Read();
        }
        // A C# program for Dijkstra's single 
        // source shortest path algorithm. 
        // The program is for adjacency matrix 
        // representation of the graph 
        // details https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/

        class GFG
        {
            static List<string> list = new List<string>();
            // A utility function to find the 
            // vertex with minimum distance 
            // value, from the set of vertices 
            // not yet included in shortest 
            // path tree 
            static int V = 9;
            int minDistance(int[] dist,
                            bool[] sptSet)
            {
                // Initialize min value 
                int min = int.MaxValue, min_index = -1;

                for (int v = 0; v < V; v++)
                {
                    list.Add($"Loop int v = 0; v < V; v++  v-> {v} ; {v} < {V};");
                    list.Add($"if sptSet[v] == false {sptSet[v]} == false && dist[v] <= min {dist[v]} <= {min}");
                    if (sptSet[v] == false && dist[v] <= min)
                    {
                        min = dist[v];
                        min_index = v;
                        list.Add($" min {min} min_index {min_index}");
                    }
                }
                return min_index;
            }

            // A utility function to print 
            // the constructed distance array 
            void printSolution(int[] dist)
            {
                Console.Write("Vertex \t\t Distance "
                              + "from Source\n");
                list.Add("Vertex \t\t Distance "
                              + "from Source\n");
                for (int i = 0; i < V; i++)
                {
                    Console.Write(i + " \t\t " + dist[i] + "\n");
                    list.Add(i + " \t\t " + dist[i] + "\n");
                }
            }

            // Funtion that implements Dijkstra's 
            // single source shortest path algorithm 
            // for a graph represented using adjacency 
            // matrix representation 
            void dijkstra(int[,] graph, int src)
            {
                int[] dist = new int[V]; // The output array. dist[i] 
                                         // will hold the shortest 
                                         // distance from src to i 

                // sptSet[i] will true if vertex 
                // i is included in shortest path 
                // tree or shortest distance from 
                // src to i is finalized 
                bool[] sptSet = new bool[V];

                // Initialize all distances as 
                // INFINITE and stpSet[] as false 
                for (int i = 0; i < V; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                }

                // Distance of source vertex 
                // from itself is always 0 
                dist[src] = 0;

                // Find shortest path for all vertices 
                for (int count = 0; count < V - 1; count++)
                {
                    list.Add($"int count = 0; count < V - 1; count++  count ->{count} {count} < {V - 1}");
                    // Pick the minimum distance vertex 
                    // from the set of vertices not yet 
                    // processed. u is always equal to 
                    // src in first iteration. 
                    int u = minDistance(dist, sptSet);
                    list.Add($"minDistance = {u}");

                    // Mark the picked vertex as processed 
                    sptSet[u] = true;
                    list.Add($"sptSet[u] = {sptSet[u]}");
                    // Update dist value of the adjacent 
                    // vertices of the picked vertex. 
                    list.Add($"Loop 0 to 9");
                    for (int v = 0; v < V; v++)
                    {
                        // Update dist[v] only if is not in 
                        // sptSet, there is an edge from u 
                        // to v, and total weight of path 
                        // from src to v through u is smaller 
                        // than current value of dist[v] 
                        list.Add($"v -> {v}");
                        list.Add($"!sptSet[u] = {sptSet[u]} && graph[u, v] != 0 {graph[u, v]} != 0  && dist[u] != int.MaxValue {dist[u]} !={int.MaxValue} && dist[u] + graph[u, v] < dist[v] {dist[u]} + {graph[u, v]} < {dist[v]} ");
                        //if a vertex is not processed and vertex is reachable from source and distance of vertex is not infinite
                        // distance from source is less than existing path then update distance as new shortest path.
                        if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue
                                && dist[u] + graph[u, v] < dist[v])
                        {

                            dist[v] = dist[u] + graph[u, v];
                            list.Add($"dist[v] = dist[u] + graph[u, v] {dist[v]} = {dist[u]} + {graph[u, v]}");
                        }
                    }
                }

                // print the constructed distance array 
                printSolution(dist);
                System.IO.File.WriteAllLines(@"C:\temp2\test\out2.txt", list);
            }

            // Driver Code 
            public static void RunDijkstra()
            {
                /*
                 * see the image dijkstras-shortest-path-algorithm-greedy-algo2.png
                 * following graph says for element at 0, there are only  2 possible paths go to vertices
                 * 1 with distance / edge 4 hence (0,4) ie from 0 to go to 1 there is distance of 4
                 * then all other next possible path is to vertices 7 with distance of 8. As all other verticies are 
                 * not reachable form location 0 hence they are zero. then repeat
                 * 
                 */
                int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
                GFG t = new GFG();
                t.dijkstra(graph, 0);
            }
        }

        void FindStartingPoint(int[] gasOnStation, int[] gasDrivingCosts, int gasTankSize)
        {
            // Assume gasOnStation.length == gasDrivingCosts.length
            int n = gasOnStation.Length;

            // Make a round, without actually caring how much gas we have.
            int minI = 0;
            int minEndValue = 0;
            int gasValue = 0;
            for (int i = 0; i < n; i++)
            {
                if (gasValue < minEndValue)
                {
                    minI = i;
                    minEndValue = gasValue;
                }
                gasValue = gasValue + gasOnStation[i] - gasDrivingCosts[i];
            }

            if (gasValue < 0)
            {
                Console.WriteLine("Instance does not have a solution: not enough fuel to make a round.");
            }
            else
            {
                // Try a round.
                int gas = DoLeg(gasOnStation, gasDrivingCosts, 0, minI, gasTankSize);
                if (gas < 0)
                {
                    Console.WriteLine("Instance does not have a solution: our tank size is holding us back.");
                    return;
                }
                for (int i = (minI + 1) % n; i != minI; i = (i + 1) % n)
                {
                    gas = DoLeg(gasOnStation, gasDrivingCosts, gas, i, gasTankSize);

                    if (gas < 0)
                    {
                        Console.WriteLine("Instance does not have a solution: our tank size is holding us back.");
                        return;
                    }
                }
                Console.WriteLine("Start at station: " + minI);
            }
        }
        int DoLeg(int[] gasOnStation, int[] gasDrivingCosts, int gas, int i, int gasTankSize)
        {
            gas += gasOnStation[i];
            if (gas > gasTankSize) gas = gasTankSize;
            gas -= gasDrivingCosts[i];
            return gas;
        }
        public static bool TreeConsutructor()
        {
            string[] input = new string[] { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" };
            Dictionary<int, int> ht = new Dictionary<int, int>();
            foreach (var item in input)
            {
                int val = int.Parse(item.Replace(")", string.Empty).Replace("(", "").Split(',')[1]);
                if (ht.ContainsKey(val))
                    return false;
                else
                    ht.Add(val, 1);

            }

            return true;
        }
        public static string MinWindowSubstring(string[] strArr)
        {
            // code goes here  
            Func<List<string>, string, string, bool> match = (lines, candidate, search) =>
            {
                lines.Add($"  candidate {candidate} search {search}");
                lines.Add($"    Loop for candidate.length {candidate.Length}");
                for (int aa = 0; aa < candidate.Length; aa++)
                {
                    var index = search.IndexOf(candidate[aa]);
                    lines.Add($"     index of candidate[aa] {candidate} {aa} {candidate[aa]} in search {search} is {index} ");
                    if (index >= 0)
                    {
                        search = search.Remove(index, 1);
                        lines.Add($"     search {search}");
                        lines.Add($"      check index {index} search.length {search.Length}");
                        if (index == 0 && search.Length == 0)
                        {
                            lines.Add($"      as  index is zero and  search.length zero so this is match");
                            //lines.Add($"     block[aa] index chars {block[aa]} {index} {chars}");
                            return true;
                        }
                    }
                }
                return false;
            };

            var dest = strArr[0];
            List<string> lines1 = new List<string>();
            for (int blockSize = strArr[1].Length; blockSize <= strArr[0].Length; blockSize++)
            {
                lines1.Add($"blockSize {blockSize}");
                for (int strPos = 0; strPos <= strArr[0].Length - blockSize; strPos++)
                {
                    lines1.Add($" strPos {strPos}");
                    var candidate = strArr[0].Substring(strPos, blockSize);
                    if (match(lines1, candidate, strArr[1]))
                    {
                        System.IO.File.WriteAllLines(@"C:\temp2\test\out.txt", lines1);
                        return candidate;
                    }
                }
            }
            return "";
        }
        private static IEnumerable<string> StringSplit(string str, int chunkSize)
        {
            return Enumerable.Range(0, (str.Length + chunkSize - 1) / chunkSize)
                 .Select(i => str.Substring(i * chunkSize, Math.Min(str.Length - i * chunkSize,
                          chunkSize)));
        }
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static List<string> GetPer(char[] list)
        {
            int x = list.Length - 1;
            List<string> retList = new List<string>();
            GetPer(list, retList, 0, x);
            return retList;
        }
        private static char[] GetPer(char[] list, List<string> retList, int k, int m)
        {
            if (k == m)
            {

                //Console.Write(list);
                return list;
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    var v = GetPer(list, retList, k + 1, m);
                    if (v != null)
                        retList.Add(new string(v));
                    Swap(ref list[k], ref list[i]);
                }
            return null;
        }

        public static string DeepestString(string str)
        {
            int start = str.LastIndexOf('[');
            int end = str.IndexOf(']');

            string s = str.Substring(start + 1, end - (start + 1)).Trim();
            str = str.Remove(start, (end + 1) - start);
            return s;
        }

        public static IEnumerable<string> Larget3Elements(params string[] arr)
        {
            return (from i in arr
                    orderby i descending
                    select i).Take(3);
        }
        public static bool Palindrom(string s)
        {
            return (s == ReverseString(s));
        }

        public static string ReverseString(string input)
        {
            return new string(Enumerable.Range(1, input.Length).Select(i => input[input.Length - i]).ToArray());
            /* return new string(original.Select((c, index) => new { c, index })
                                              .OrderByDescending(x => x.index)
                                               .Select(x => x.c)
                                               .ToArray());
                                               */
        }

        public static string UniqueCharsInString(string s)
        {
            return new string(s.Distinct().ToArray());
        }

        public static string LongestString(IList<string> list)
        {
            return list.Aggregate("uoiuoiuuiuoi", (max, cur) => max.Length > cur.Length ? max : cur);
        }

        public static int Fibonacci(int ii)
        {
            //011235813
            return FibonacciInternal(ii);
            int FibonacciInternal(int i) => i <= 1 ? i : Fibonacci(i - 1) + Fibonacci(i - 2);

            //Func<int, int> fib = null;
            //fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
        }

        public static int RomanToInteger(string input)
        {
            int result = 0;
            Dictionary<char, int> map = new Dictionary<char, int>()
      {
        {'I', 1},{'V', 5},{'X', 10},{'L', 50},{'C', 100},{'D', 500},{'M', 1000}
      };

            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && map[input[i]] < map[input[i + 1]])
                {
                    result -= map[input[i]];
                }
                else
                {
                    result += map[input[i]];
                }
            }
            return result;
        }

        public static IList<string> Duplicates(IList<string> data)
        {
            return data.GroupBy(a => a)
                       .Where(g => g.Count() > 1)
                       .Select(k => k.Key)
                       .ToList();

            /*
            return data.GroupBy(a => a)
                       .Where(g => g.Count() > 1)
                       .Select(k => new
                       {
                         Element = k.Key,
                         Count = k.Count()
                       })
                       .ToList();
                       */
        }

        public static string Reverse1(string s)
        {
            Stack<string> stack = new Stack<string>();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            s.Split(' ').All(a => { stack.Push(a); return true; });
            Enumerable.Range(0, stack.Count()).All(a => { sb.AppendFormat("{0} ", stack.Pop()); return true; });
            return sb.ToString().TrimEnd(' ');
        }

        public static string Reverse2(string s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        public static string IndexOfLongestRun(string input)
        {
            //       1233333344455566
            Dictionary<char, int> dict = new Dictionary<char, int>();

            input.ToCharArray().ToList().ForEach(a =>
            {
                if (!dict.ContainsKey(a))
                {
                    dict.Add(a, 1);
                }
                else
                {
                    dict[a]++;
                }
            });

            KeyValuePair<char, int> pair = dict.Aggregate((l, r) => l.Value > r.Value ? l : r);
            return new string(pair.Key, pair.Value);
        }

        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            HashSet<int> col = new HashSet<int>();
            for (int i = 0; i < list.Count; i++)
            {
                int needed = sum - list[i];
                if (col.Contains(needed))
                {
                    return new Tuple<int, int>(needed, i);
                }
                else
                {
                    col.Add(needed);
                }
            }
            return null;
        }

        public static bool AreStringsAnagrams(string s1, string s2)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict[c] = 1;
                }
            }
            foreach (char c in s2)
            {
                if (!dict.ContainsKey(c) || dict[c] <= 0)
                {
                    return false;
                }
                else
                {
                    dict[c]--;
                }
            }
            //return dict.Values.FirstOrDefault(a=>a>0) == 0 ? true : false;
            return true;
        }
    }
}
