using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
    partial class Program
    {
        static List<string> MakeSubstrs(string str, int len)
        {
            if (str.Length <= len)
                return new List<string>() { str };

            var result = new List<string>();
            for (int i = 0; i < str.Length; i += len)
            {
                int lenght = i + len <= str.Length ? len : str.Length - i;
                result.Add(str.Substring(i, lenght));
            }
            return result;
        }

        static HashSet<string> MakeUniqeSubstrs(string str, int len)
        {
            var result = new HashSet<string>();
            for (int i = 0; i < str.Length; i += len)
            {
                int lenght = i + len <= str.Length ? len : str.Length - i;
                result.Add(str.Substring(i, lenght));
            }
            return result;
        }

        static Dictionary<char, int> ToDic(string input)
        {
            return input.ToArray()
                           .GroupBy(c => c)
                           .Select(it => KeyValuePair.Create(it.Key, it.Count()))
                           .ToDictionary(it => it.Key, it => it.Value);
        }

        static void Print2Console(IEnumerable<string> ary)
        {
            for (int j = 0; j < ary.Count(); j++)
            {
                WriteLine($"<{ary.ElementAt(j)}>");
            }
        }

        static void Print2Console(Dictionary<char, int> dic)
        {
            for (int j = 0; j < dic.Count(); j++)
            {
                WriteLine($"<{dic.ElementAt(j).Key}, {dic.ElementAt(j).Value}>");
            }
        }

        static void Print2Console(Dictionary<string, string> dic)
        {
            for (int j = 0; j < dic.Count(); j++)
            {
                WriteLine($"<{dic.ElementAt(j).Key}, {dic.ElementAt(j).Value}>");
            }
        }

        static void Print2Console(Dictionary<char, char> dic)
        {
            for (int j = 0; j < dic.Count(); j++)
            {
                WriteLine($"<{dic.ElementAt(j).Key}, {dic.ElementAt(j).Value}>");
            }
        }
    }
}