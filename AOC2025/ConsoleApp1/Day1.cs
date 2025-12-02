using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AOC2025
{
    internal static class Day1
    {
        private const char LEFT = 'L';
        private const char RIGHT = 'R';
        public static int Part1() 
        {
            int currentPos = 50;
            int count = 0;
            string[] text = File.ReadAllText("..\\..\\..\\Input\\day1.txt").Split('\n');

            foreach (string line in text)
            {
                int clicks = 0;
                var direction = line.Take(1).First();
                int.TryParse(line.Substring(1, line.Length - 1), out clicks);

                if (direction == RIGHT)
                    currentPos = currentPos + clicks;
                if (direction == LEFT)
                    currentPos = currentPos - clicks;

                currentPos = resetPos(currentPos);
                if (currentPos == 0)
                {
                    count++; 
                } 
            }

            Console.WriteLine(count);

            return count;
        }

        public static int Part2()
        {
            int currentPos = 50;
            int count = 0;
            string[] text = File.ReadAllText("..\\..\\..\\Input\\day1.txt").Replace("\r", "").Split('\n');

            foreach (string line in text)
            {
                int clicks = 0;
                var direction = line.Take(1).First();
                int.TryParse(line.Substring(1, line.Length - 1), out clicks);

                var amountToZero = currentPos;
                var amountToHundred = 100 - currentPos;
                int clicksPastZero = 0;

                if (direction == LEFT)
                {
                    if (amountToZero <= clicks)
                    {
                        if (amountToZero != 0)
                        {
                            count++;
                        }
                        clicks = clicks - amountToZero;
                        currentPos = 100 - (clicks % 100);
                        if (currentPos == 100)
                        {
                            currentPos = 0;
                        }
                    }
                    else
                    {
                        currentPos = currentPos - clicks;
                    }   
                }
                else if (direction == RIGHT)
                {
                    if (clicks >= amountToHundred)
                    {
                        count++;
                        clicks = clicks - amountToHundred;

                        currentPos = clicks % 100;
                    }
                    else
                    {
                        currentPos = currentPos + clicks;
                    }
                }
                clicksPastZero = clicks / 100;

                count = count + clicksPastZero;
            }

            Console.WriteLine(count);

            return count;
        }

        private static int resetPos(int curPos)
        {
            if (curPos > 99)
            {
                return curPos % 100;
            }
            else if (curPos < 0)
            {
                return 100 + (curPos % -100);
            }
            return curPos;
        }

        //Old implementation I'm keeping for reference
        /*public static int Part2()
        {
            int currentPos = 50;
            int count = 0;
            string[] text = File.ReadAllText("..\\..\\..\\Input\\day1.txt").Replace("\r", "").Split('\n');

            foreach (string line in text)
            {
                int clicks = 0;
                var direction = line.Take(1).First();
                int.TryParse(line.Substring(1, line.Length - 1), out clicks);

                int numberOfZeroClicks = 0;
                bool wasntZero = currentPos != 0;
                if (direction == 'R')
                    currentPos = currentPos + clicks;
                if (direction == 'L')
                    currentPos = currentPos - clicks;
                if (currentPos < 0)
                    numberOfZeroClicks = (currentPos / -100) + Convert.ToInt32(wasntZero);
                else if (currentPos > 0)
                    numberOfZeroClicks = currentPos / 100;

                count = count + numberOfZeroClicks;

                if (currentPos == 0)
                {
                    count++;
                }
                currentPos = resetPos(currentPos);
            }

            Console.WriteLine(count);

            return count;
        }*/
    }
}
