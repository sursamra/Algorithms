using System;
using System.Collections.Generic;
namespace Algorithms
{
    class Logger
    {
        static List<string> logs = new List<string>();
        static string _name = "";
        public static void Log(int indent, string log)
        {
            logs.Add($"{"".PadLeft(indent)}{log}");
        }
        public static void Log(int indent, int log)
        {
            logs.Add($"{"".PadLeft(indent)}{log}");
        }
        public static void Log(int indent, decimal log)
        {
            logs.Add($"{"".PadLeft(indent)}{log}");
        }
        public static void Log(int indent, DateTime log)
        {
            logs.Add($"{"".PadLeft(indent)}{log}");
        }
        public static void Log(int indent, double log)
        {
            logs.Add($"{"".PadLeft(indent)}{log}");
        }

        // array
        public static void Log(int indent, string[] log)
        {
            logs.Add($"{"".PadLeft(indent)}{ArrayToString<string>(log)}");
        }
        public static void Log(int indent, int[] log)
        {
            logs.Add($"{"".PadLeft(indent)}{ArrayToString<int>(log)}");
        }
        public static void Log(int indent, decimal[] log)
        {
            logs.Add($"{"".PadLeft(indent)}{ArrayToString<decimal>(log)}");
        }
        public static void Log(int indent, DateTime[] log)
        {
            logs.Add($"{"".PadLeft(indent)}{ArrayToString<DateTime>(log)}");
        }
        public static void Log(int indent, double[] log)
        {
            logs.Add($"{"".PadLeft(indent)}{ArrayToString<double>(log)}");
        }
        public static void Log(int indent, bool[] log)
        {
            logs.Add($"{"".PadLeft(indent)}{ArrayToString<bool>(log)}");
        }
        //
        public static void Init(string name)
        {
            _name = name;
            logs = new List<string>();
        }
        public static void Flush(bool saveTime = false)
        {
            string str = saveTime ? DateTime.Now.ToString("yyyymmddhhMMss") : "" + ".txt";
            System.IO.File.WriteAllLines($@".\Logs\{_name}{str}", logs);
            logs = new List<string>();
        }
        public static string ArrayToString<T>(T[] arr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int i = 0;
            foreach (var v in arr)
            {
                sb.Append($"{i++}-{v} , ");
            }
            return sb.ToString();
        }
        //public static string ArrayToString<T>(T[,] arr)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    int i = 0;
        //    for (int x = 0; x < arr.Length; x++)
        //    {
        //        for (int y = 0; y < arr[x].Length; y++)
        //        {
        //            foreach (var v in arr)
        //    {
        //        sb.Append($"{i++}->{v} , ");
        //    }
        //    return sb.ToString();
        //}
    }
}
