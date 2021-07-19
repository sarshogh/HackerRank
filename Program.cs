using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
    partial class Program
    {
        public static void Main(string[] args)
        { // https://www.hackerrank.com/challenges/mars-exploration/problem

            Clear();
            WriteLine("Enter mars message:");
            var ary = ReadLine();

            const string SOS = "SOS";

            var allSubs = MakeSubstrs(ary, 3);
            var wrongsSubs = allSubs.Where(it => it != SOS);
            // Print2Console(wrongsSubs);

            int counter = 0;
            foreach (var item in wrongsSubs)
            {
                for (int j = 0; j < item.Length; j++)
                {
                    if (item[j] != SOS[j]) counter++;
                }

                counter+= SOS.Length - item.Length;
            }

            Console.WriteLine(counter);
        }

        public static void MainCaeserCipher(string[] args)
        { // https://www.hackerrank.com/challenges/caesar-cipher-1/problem

            Clear();
            Write("Enter string:");
            var input = ReadLine();
            WriteLine();
            Write("Enter rotate number:");
            var rotate = int.Parse(ReadLine());

            var result = "";
            foreach (char ch in input)
            {
                result += Rotate(ch, rotate).ToString();
            }

            WriteLine(result);
        }

        static char Rotate(char ch, int rotate)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
            if (!alphabet.Contains(char.ToLower(ch))) return ch;

            var len = alphabet.Length; // 26       
            var idx = alphabet.ToList().IndexOf(char.ToLower(ch));
            var newIndex = idx + rotate;
            newIndex = newIndex % len;
            var item = alphabet.ElementAt(newIndex);

            if (char.IsUpper(ch))
                return char.ToUpper(item);
            else
                return item;
        }

        public static void MainAlternaticeTwoChars(string[] args)
        {  // https://www.hackerrank.com/challenges/two-characters/problem

            Clear();
            Write("Enter a text: ");
            var str = ReadLine();
            var dic = new Dictionary<string, string>();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    var key = string.Join("", new[] { str[i], str[j] });
                    if (!dic.ContainsKey(key))
                    {
                        var value =
                        string.Join("", str.ToArray().Select((ch, index) =>
                        {
                            if (key.Contains(ch))
                                return ch;
                            else
                                return '-';
                        })).Replace("-", "");

                        dic.TryAdd(key, value);
                    }
                }
            }
            var items = dic.Where(it => !HasConsecutiveChars(it.Value)).ToList();
            var result = items.Count == 0 ? 0 : items.Max(it => it.Value.Length);

            WriteLine(result);
        }

        static bool HasConsecutiveChars(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                    return true;
            }

            return false;
        }

        public static void MainStrongPassword(string[] args)
        { // https://www.hackerrank.com/challenges/strong-password/problem
            Clear();

            WriteLine("Enter 'n' for lenght:");
            int n = int.Parse(ReadLine().Trim());

            WriteLine("Enter a password:");
            var password = ReadLine().ToArray();

            const int expectedLen = 6;
            string numbers = "0123456789",
                    lowerCase = "abcdefghijklmnopqrstuvwxyz",
                    upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                    specialCharacters = "!@#$%^&*()-+";

            bool isLenMet = password.Length >= expectedLen,
                    isNumMet = false,
                    isLowerMet = false,
                    isUpMet = false,
                    isSpecialMet = false;

            for (int i = 0; i < password.Length; i++)
            {
                isNumMet = isNumMet == true ? true : numbers.Contains(password[i]);
                isLowerMet = isLowerMet == true ? true : lowerCase.Contains(password[i]);
                isUpMet = isUpMet == true ? true : upperCase.Contains(password[i]);
                isSpecialMet = isSpecialMet == true ? true : specialCharacters.Contains(password[i]);
            }

            var result =
                (isNumMet ? 0 : 1) + (isLowerMet ? 0 : 1) +
                (isUpMet ? 0 : 1) + (isSpecialMet ? 0 : 1);

            if (!isLenMet)
            {
                int debt = expectedLen - password.Length;
                var rest = (debt > result) ? debt : result;
                // return 
                WriteLine(rest);
            }
            else
            {
                WriteLine(result);
                // return result;
            }
        }

        public static void MainCamelCaseWordsCounter(string[] args)
        { // https://www.hackerrank.com/challenges/camelcase/problem
            Clear();
            WriteLine("Enter camelCase string:");
            var str = ReadLine().Trim();
            int counter = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0) continue;
                if (str[i] >= 'A' && str[i] <= 'Z') counter++;
            }

            WriteLine($"number of words{counter}");
        }

        public static void MainSUPER_REDUCED_STRING(string[] args)
        { // https://www.hackerrank.com/challenges/reduced-string/problem
            Clear();
            WriteLine("Please enter a string:");
            var str = ReadLine().ToCharArray();

            var i = 0;

            while (true)
            {
                var temp = string.Join("", str);
                if (i + 1 == str.Length && temp.Contains("-"))
                {
                    i = 0;
                    str = temp.Replace("-", "").ToArray();
                    // WriteLine("********** NEXT Cycle***********");
                }
                if (i + 1 >= str.Length)
                {
                    break;
                }

                if (str[i] == str[i + 1])
                {
                    str[i] = str[i + 1] = '-';
                    // WriteLine(string.Join("", str));
                }
                i++;

            }
            WriteLine("LOL, Final Result is:");
            if (string.Join("", str).Trim() == string.Empty)
            {
                WriteLine("Empty String");
            }
            else
            {
                WriteLine(string.Join("", str));
            }
        }

        public static void MainTimeConversionAM_PM(string[] args)
        { // https://www.hackerrank.com/challenges/time-conversion/problem
            Clear();
            WriteLine("Enter a time with AM/PM format like '07:05:45PM' :");
            var time = ReadLine().Trim().Split(":");
            var h = int.Parse(time[0]);
            var m = int.Parse(time[1]);
            var s = int.Parse(time[2].Substring(0, 2));
            var ampm = time[2].Substring(2, 2);
            var result = ampm switch
            {
                "AM" => $"{h}:{time[1]}:{s}",
                "PM" => $"{h + 12}:{time[1]}:{s}",
                _ => ""
            };

            WriteLine("============");
            WriteLine(result);
        }

        public static void MainBirthdayCackeCandles(string[] args)
        { // https://www.hackerrank.com/challenges/birthday-cake-candles/problem
            Clear();
            System.Console.Write("Enter n:");
            var n = int.Parse(ReadLine());
            System.Console.Write($"Enter {n} numbers seperated by space:");
            var numbers = ReadLine().Trim().Split(" ")
                                 .Select(it => it == "" ? "0" : it)
                                 .Select(it => int.Parse(it)).ToList();

            int compare(int x, int y)
            {
                if (x > y) return 1;
                if (x < y) return -1;
                return 0;
            };

            numbers.Sort(compare);
            var max = numbers[numbers.Count - 1];
            var count = numbers.FindAll(it => it == max).Count();
            WriteLine(count);
        }

        public static void Main_MiniMaxSum(string[] args)
        { // https://www.hackerrank.com/challenges/mini-max-sum/problem
            Clear();
            Console.Write("Enter 5 numbers seperated by space:");
            var numbers = ReadLine().Trim().Split(" ").Select(it => long.Parse(it));

            static int compare(long x, long y)
            {
                if (x > y) return 1;
                if (x < y) return -1;
                return 0;
            }

            numbers.ToList().Sort(compare);
            var min = numbers.Take(numbers.Count() - 1).ToList().Sum();
            //.SkipLast(1).ToList().Sum(); // this line works with C#9 :)
            var max = numbers.Skip(1).Sum();

            WriteLine($"{min} {max}");

        }

        public static void MainStairsCase(string[] args)
        { // https://www.hackerrank.com/challenges/staircase/problem
            Clear();
            Console.Write("Enter a number:");
            var n = int.Parse(ReadLine().Trim());

            for (int i = 1; i <= n; i++)
            {
                var line = String.Join("", Enumerable.Repeat(" ", n - i)) + String.Join("", Enumerable.Repeat("#", i));
                WriteLine(line);
            }
        }

        public static void MainPlusMines(string[] args)
        { //https://www.hackerrank.com/challenges/plus-minus/problem

            Clear();
            WriteLine("enter a series of negetive, zero and positives seperated with space:");
            var numbers = ReadLine().Split(" ")
                                 .Select(it => it.Trim() == "" ? "0" : it)
                                 .Select(it => int.Parse(it)).ToArray();


            int neg = 0, pos = 0, zer = 0;
            var count = numbers.Length * 1.0f;
            for (var i = 0; i < count; i++)
            {
                switch (numbers[i])
                {
                    case > 0:
                        pos++;
                        break;
                    case < 0:
                        neg++;
                        break;
                    case 0:
                        zer++;
                        break;
                }
            }

            WriteLine($"Counts are =>  +:{pos}, -:{neg}, 0:{zer}");
            WriteLine(pos / count);
            WriteLine(neg / count);
            WriteLine(zer / count);
        }

        public static void MainDiagonalAbsoluteDifferenceWithList(string[] arg)
        { // https://www.hackerrank.com/challenges/diagonal-difference/problem
            Clear();

            var items = new List<List<int>>();
            WriteLine("Please enter the n:");
            var n = int.Parse(ReadLine().Trim());

            for (int i = 0; i < n; i++)
            {
                items.Add(ReadLine()
                                  .Split(" ")
                                  .Select(it => it == " " ? "0" : it)
                                  .Select(it => int.Parse(it)).ToList());
            }

            int leftD = 0, rightD = 0;
            for (int j = 0, k = 0; j < n; j++, k++)
            {
                WriteLine("->" + items[j][k]);
                leftD += items[j][k];
            }
            for (int j = 0, m = n - 1; j < n; j++, m--)
            {
                WriteLine("->" + items[j][m]);
                rightD += items[j][m];
            }

            WriteLine($"{Math.Abs(leftD - rightD)}");
        }

        public static void MainDiagonalDifferenceWithArray(string[] args)
        {  // https://www.hackerrank.com/challenges/diagonal-difference/problem
            Clear();
            int[,] input = new int[3, 3];
            for (var i = 0; i < 3; i++)
            {
                WriteLine($"Row {i + 1}, Enter 3 numbers seperated with space:");
                var row = ReadLine()
                            .Split(" ")
                            .Select(it => it.Trim() == "" ? "0" : it).Select(it => int.Parse(it)).ToArray();

                for (var j = 0; j < 3; j++)
                {
                    input[i, j] = row[j];
                }
            }

            int leftD = 0, rightD = 0;

            for (int x = 0, y = 0; x < 3; x++, y++)
            {
                leftD += input[x, y];
            }
            for (int x = 2, y = 0; x >= 0; x--, y++)
            {
                rightD += input[x, y];
            }
            WriteLine($"{Math.Abs(leftD - rightD)}");
        }

        public static void MainBigSum(string[] args)
        { // https://www.hackerrank.com/challenges/a-very-big-sum/problem
            Clear();
            WriteLine("Enter numbers seperated with space:");
            var numbers = ReadLine().Split(" ").Select(it => long.Parse(it)).ToArray();
            WriteLine(String.Join(",", numbers));

            var errors = string.Join(",", numbers.Where(it => it > Math.Pow(10, 10)));
            WriteLine("these are are so big and cause error" + errors);
            WriteLine($"{numbers.Sum()}");
        }

        public static void MainCompareTriplets(string[] args)
        { // https://www.hackerrank.com/challenges/compare-the-triplets/problem
            Clear();
            WriteLine("Step 1, Enter 3 numbers seperated with space like 1 2 3:");
            var firstPersonScores = ReadLine().Split(" ").Select(it => int.Parse(it)).ToArray();
            WriteLine("Step 2, Enter 3 numbers seperated with space like 1 2 3:");
            var secondPersonScores = ReadLine().Split(" ").Select(it => int.Parse(it)).ToArray();
            WriteLine(String.Join(",", firstPersonScores));
            WriteLine(String.Join(",", secondPersonScores));


            var result = CompareTriplets(firstPersonScores, secondPersonScores);
            WriteLine($"{result.Item1}  {result.Item2}");
        }

        static (int, int) CompareTriplets(int[] first, int[] sec)
        {
            int score1 = 0, score2 = 0;

            for (var i = 0; i < 3; i++)
            {
                if (first[i] == sec[i]) continue;

                if (first[i] > sec[i])
                {
                    score1++;
                }
                else
                {
                    score2++;
                }
            }

            return (score1, score2);
        }
    }
}
