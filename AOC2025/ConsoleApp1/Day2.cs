using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2025
{
    internal static class Day2
    {

        public static long Part1()
        {
            string[] ranges = File.ReadAllText("..\\..\\..\\Input\\day2.txt").Split(',');
            long count = 0;

            foreach(var range in ranges)
            {
                var split = range.Split('-');
                var left = Int64.Parse(split[0]); 
                var right = Int64.Parse(split[1]);
                int leftLength = split[0].Length;
                int rightLength = split[1].Length;

                for (long i = left; i <= right; i++)
                {
                    count += HalfAndHalf(i);
                }
            } 

            Console.WriteLine(count);

            return count;
        }

        public static long Part2()
        {
            string[] ranges = File.ReadAllText("..\\..\\..\\Input\\day2.txt").Split(',');
            long count = 0;

            foreach (var range in ranges)
            {
                var split = range.Split('-');
                var left = Int64.Parse(split[0]);
                var right = Int64.Parse(split[1]);
                int leftLength = split[0].Length;
                int rightLength = split[1].Length;

                for (long i = left; i <= right; i++)
                {
                    count += GetIDValidity(i);
                }
            }

            Console.WriteLine(count);

            return count;
        }

        private static long GetIDValidity(long number)
        {
            var indexString = number.ToString();
            int length = indexString.Length;
            int halfLenght = length / 2;

            if (indexString.Length > 1 && indexString.All(x => x.Equals(indexString[0])))
            {
                Console.WriteLine(number);
                return number;
            }

            for (int i = halfLenght; i > 0; i--)
            {
                if (length == 1 || length % i != 0)
                {
                    continue;
                }
                var match = indexString.Substring(0, i);
                int j = 0;
                bool repeated = true;
                while (j < length && repeated == true)
                {
                    var check = indexString.Substring(j, i);
                    repeated = match == check;
                    j += i;
                }

                if (repeated == true) 
                {
                    Console.WriteLine(number);
                    return number;
                }
            }
            
            return 0;
        }

        private static long HalfAndHalf(long number)
        {
            var indexString = number.ToString();
            if (indexString.Length % 2 == 0)
            {
                var lhs = indexString.Substring(0, (indexString.Length / 2));
                var rhs = indexString.Substring(indexString.Length / 2);

                if (lhs == rhs)
                {
                    return number;
                }
            }
            return 0;
        }
    }
}
