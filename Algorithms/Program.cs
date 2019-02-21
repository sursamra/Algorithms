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
        // test changes
      //SurSamra made changes online.
      //For pull request
      //forked by l4m2
      // updated by sursamra in master
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
